package com.onlineclinicserver.controller;

import com.onlineclinicserver.model.Patient;
import com.onlineclinicserver.repository.PatientRepository;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/patients")
public class PatientController {

    private final PatientRepository patientRepository;

    public PatientController(PatientRepository patientRepository) {
        this.patientRepository = patientRepository;
    }

    @GetMapping
    public List<Patient> getAllPatients() {
        return patientRepository.findAll();
    }

    @GetMapping("/{id}")
    public Patient getPatientById(@PathVariable Integer id) {
        return patientRepository.findById(id).orElse(null);
    }

    @PostMapping
    public Patient createPatient(@RequestBody Patient patient) {
        return patientRepository.save(patient);
    }

    @PutMapping("/{id}")
    public Patient updatePatient(@PathVariable Integer id, @RequestBody Patient patientDetails) {
        return patientRepository.findById(id).map(patient -> {
            patient.setName(patientDetails.getName());
            patient.setDateOfBirth(patientDetails.getDateOfBirth());
            patient.setPhone(patientDetails.getPhone());
            patient.setEmail(patientDetails.getEmail());
            return patientRepository.save(patient);
        }).orElse(null);
    }

    @DeleteMapping("/{id}")
    public void deletePatient(@PathVariable Integer id) {
        patientRepository.deleteById(id);
    }
}