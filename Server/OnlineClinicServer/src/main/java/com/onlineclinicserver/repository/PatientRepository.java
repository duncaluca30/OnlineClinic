package com.onlineclinicserver.repository;

import com.onlineclinicserver.model.Patient;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PatientRepository extends JpaRepository<Patient, Integer> {
    // Example custom query:
    // List<Patient> findByNameContaining(String name);
}