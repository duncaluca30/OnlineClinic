package com.onlineclinicserver.controller;

import com.onlineclinicserver.model.Doctor;
import com.onlineclinicserver.repository.DoctorRepository;
import jakarta.persistence.criteria.CriteriaBuilder;
import org.springframework.web.bind.annotation.*;

import java.util.List;

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
            return doctorRepository.save(doctor);
        }).orElse(null);
    }

    @DeleteMapping("/{id}")
    public void deleteDoctor(@PathVariable Integer id) {
        doctorRepository.deleteById(id);
    }
}