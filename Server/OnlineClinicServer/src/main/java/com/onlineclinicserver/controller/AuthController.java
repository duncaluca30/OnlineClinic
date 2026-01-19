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
import org.springframework.security.crypto.password.PasswordEncoder; // Ensure this is imported

import java.time.LocalDate;
import java.util.Optional;

@RestController
@RequestMapping("/api/auth")
public class AuthController {

    private final UserRepository userRepository;
    private final PatientRepository patientRepository;
    private final PasswordEncoder passwordEncoder; // Defined here

    // 1. FIXED CONSTRUCTOR: Added PasswordEncoder parameter and assignment
    public AuthController(UserRepository userRepository, PatientRepository patientRepository, PasswordEncoder passwordEncoder) {
        this.userRepository = userRepository;
        this.patientRepository = patientRepository;
        this.passwordEncoder = passwordEncoder;
    }

    @PostMapping("/login")
    public ResponseEntity<?> login(@RequestBody LoginRequestDTO loginRequest) {
        Optional<User> optionalUser = userRepository.findByUsername(loginRequest.getUsername());

        // 2. FIXED LOGIN: Use passwordEncoder.matches() instead of .equals()
        // Format: .matches(rawPassword, databaseHashedPassword)
        if (optionalUser.isEmpty() || !passwordEncoder.matches(loginRequest.getPassword(), optionalUser.get().getPassword())) {
            return ResponseEntity.status(401).body("Invalid username or password");
        }

        User user = optionalUser.get();
        String name = null;
        Integer userId = user.getId();

        // Preserving your custom ID logic
        if ("PATIENT".equals(user.getRole()) && user.getPatient() != null) {
            name = user.getPatient().getName();
            userId = user.getPatient().getId();
        } else if ("DOCTOR".equals(user.getRole()) && user.getDoctor() != null) {
            name = user.getDoctor().getName();
            userId = user.getDoctor().getId();
        }

        LoginResponseDTO response = new LoginResponseDTO(userId, user.getUsername(), user.getRole(), name);

        return ResponseEntity.ok(response);
    }

    @PostMapping("/register")
    public ResponseEntity<?> register(@RequestBody RegisterRequestDTO request) {
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

        patientRepository.save(patient);

        // Create User
        User user = new User();
        user.setUsername(request.getUsername());

        // 3. FIXED REGISTER: Encode the password before saving
        user.setPassword(passwordEncoder.encode(request.getPassword()));

        user.setRole("PATIENT");
        user.setPatient(patient);

        userRepository.save(user);

        return ResponseEntity.ok("Registration successful");
    }
}