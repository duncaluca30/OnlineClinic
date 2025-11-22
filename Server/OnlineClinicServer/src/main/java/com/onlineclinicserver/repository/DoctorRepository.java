package com.onlineclinicserver.repository;

import com.onlineclinicserver.model.Doctor;
import org.springframework.data.jpa.repository.JpaRepository;

public interface DoctorRepository extends JpaRepository<Doctor, Integer> {
    // You can add custom queries here if needed, e.g.:
    // List<Doctor> findBySpecialty(String specialty);
}