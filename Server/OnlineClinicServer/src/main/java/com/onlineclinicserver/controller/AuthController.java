package com.onlineclinicserver.controller;

import com.onlineclinicserver.dto.LoginRequestDTO;
import com.onlineclinicserver.dto.LoginResponseDTO;
import com.onlineclinicserver.dto.RegisterRequestDTO;
import com.onlineclinicserver.model.Patient;
import com.onlineclinicserver.model.User;
import com.onlineclinicserver.repository.PatientRepository;
import com.onlineclinicserver.repository.UserRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDate;
import java.util.Optional;

@RestController
@RequestMapping("/api/auth")
public class AuthController {

    private final UserRepository userRepository;
    private final PatientRepository patientRepository;


    public AuthController(UserRepository userRepository, PatientRepository patientRepository) {
        this.userRepository = userRepository;
        this.patientRepository = patientRepository;
    }


    @PostMapping("/login")
    public ResponseEntity<?> login(@RequestBody LoginRequestDTO loginRequest) {
        Optional<User> optionalUser = userRepository.findByUsername(loginRequest.getUsername());

        if (optionalUser.isEmpty() || !optionalUser.get().getPassword().equals(loginRequest.getPassword())) {
            return ResponseEntity.status(401).body("Invalid username or password");
        }

        User user = optionalUser.get();
        String name = null;
        Integer userId = user.getId(); // Default to User ID

        // CRITICAL FIX: If they are a PATIENT, grab the specific PATIENT ID
        if ("PATIENT".equals(user.getRole()) && user.getPatient() != null) {
            name = user.getPatient().getName();
            userId = user.getPatient().getId(); // <--- This gets ID '6' for Marius
        } else if ("DOCTOR".equals(user.getRole()) && user.getDoctor() != null) {
            name = user.getDoctor().getName();
            userId = user.getDoctor().getId();
        }

        // Pass the correct ID to the new constructor
        LoginResponseDTO response = new LoginResponseDTO(userId, user.getUsername(), user.getRole(), name);

        return ResponseEntity.ok(response);
    }

    @PostMapping("/register")
    public ResponseEntity<?> register(@RequestBody RegisterRequestDTO request) {
        // Check if email already exists
        if (userRepository.findByUsername(request.getUsername()).isPresent()) {
            return ResponseEntity.status(409).body("Email already registered");
        }
        // Create Patient
        Patient patient = new Patient();
        patient.setName(request.getName());
        patient.setEmail(request.getUsername());
        LocalDate dob = LocalDate.parse(request.getDob());
        patient.setDateOfBirth(dob);
        patient.setPhone(request.getPhone());

        patientRepository.save(patient); // assuming you have this

        // Create User
        User user = new User();
        user.setUsername(request.getUsername());
        user.setPassword(request.getPassword()); // hash this!
        user.setRole("PATIENT");
        user.setPatient(patient); // link the patient

        userRepository.save(user);

        return ResponseEntity.ok("Registration successful");
    }

}

