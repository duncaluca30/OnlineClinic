package com.onlineclinicserver.controller;

import com.onlineclinicserver.model.Doctor;
import com.onlineclinicserver.repository.DoctorRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.math.BigDecimal;
import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/api/doctors")
public class DoctorController {

    private final DoctorRepository doctorRepository;

    public DoctorController(DoctorRepository doctorRepository) {
        this.doctorRepository = doctorRepository;
    }

    @GetMapping
    public List<Doctor> getAllDoctors() {
        return doctorRepository.findAll();
    }

    @GetMapping("/{id}")
    public Doctor getDoctorById(@PathVariable Integer id) {
        return doctorRepository.findById(id).orElse(null);
    }

    @PostMapping
    public Doctor createDoctor(@RequestBody Doctor doctor) {
        return doctorRepository.save(doctor);
    }

    @PutMapping("/{id}")
    public Doctor updateDoctor(@PathVariable Integer id, @RequestBody Doctor doctorDetails) {
        return doctorRepository.findById(id).map(doctor -> {
            doctor.setName(doctorDetails.getName());
            doctor.setSpecialty(doctorDetails.getSpecialty());
            doctor.setPhone(doctorDetails.getPhone());
            doctor.setEmail(doctorDetails.getEmail());
            // You can also update price here if you want the main update to handle it too
            if (doctorDetails.getPrice() != null) {
                doctor.setPrice(doctorDetails.getPrice());
            }
            return doctorRepository.save(doctor);
        }).orElse(null);
    }

    // --- NEW ENDPOINT: Update Price Only ---
    // Used by the "Manage My Profile" section in the frontend
    @PutMapping("/{id}/price")
    public ResponseEntity<?> updatePrice(@PathVariable Integer id, @RequestBody Map<String, BigDecimal> payload) {
        BigDecimal newPrice = payload.get("price");

        if (newPrice == null) {
            return ResponseEntity.badRequest().body("Price is required");
        }

        return doctorRepository.findById(id)
                .map(doctor -> {
                    doctor.setPrice(newPrice);
                    doctorRepository.save(doctor);
                    return ResponseEntity.ok("Price updated successfully");
                })
                .orElse(ResponseEntity.notFound().build());
    }

    @DeleteMapping("/{id}")
    public void deleteDoctor(@PathVariable Integer id) {
        doctorRepository.deleteById(id);
    }
}