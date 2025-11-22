package com.onlineclinicserver.controller;

import com.onlineclinicserver.dto.AppointmentDto;
import com.onlineclinicserver.model.Appointment;
import com.onlineclinicserver.model.Doctor;
import com.onlineclinicserver.model.Patient;
import com.onlineclinicserver.repository.AppointmentRepository;
import com.onlineclinicserver.repository.DoctorRepository;
import com.onlineclinicserver.repository.PatientRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import com.onlineclinicserver.dto.AppointmentRequest;
import org.springframework.http.ResponseEntity;

import java.util.List;

@RestController
@RequestMapping("/api/appointments")
public class AppointmentController {

    private final AppointmentRepository appointmentRepository;
    private final DoctorRepository doctorRepository;
    private final PatientRepository patientRepository;

    public AppointmentController(AppointmentRepository appointmentRepository,
                                 DoctorRepository doctorRepository,
                                 PatientRepository patientRepository) {
        this.appointmentRepository = appointmentRepository;
        this.doctorRepository = doctorRepository;
        this.patientRepository = patientRepository;
    }

    @GetMapping
    public List<Appointment> getAllAppointments() {
        return appointmentRepository.findAll();
    }

    @GetMapping("/{id}")
    public Appointment getAppointmentById(@PathVariable Integer id) {
        return appointmentRepository.findById(id).orElse(null);
    }
    @PutMapping("/{id}")
    public ResponseEntity<Appointment> updateAppointment(
            @PathVariable Integer id,
            @RequestBody AppointmentDto dto) {

        Appointment existing = appointmentRepository.findById(id)
                .orElseThrow(() -> new RuntimeException("Appointment not found"));

        Patient patient = patientRepository.findById(dto.getPatientId())
                .orElseThrow(() -> new RuntimeException("Patient not found"));
        Doctor doctor = doctorRepository.findById(dto.getDoctorId())
                .orElseThrow(() -> new RuntimeException("Doctor not found"));

        existing.setPatient(patient);
        existing.setDoctor(doctor);
        existing.setAppointmentDate(dto.getAppointmentDate());
        existing.setPrice(dto.getPrice());

        Appointment updated = appointmentRepository.save(existing);
        return ResponseEntity.ok(updated);
    }

    // --- Create Appointment using IDs ---
    @PostMapping
    public ResponseEntity<Appointment> createAppointment(@RequestBody AppointmentDto dto) {
        Patient patient = patientRepository.findById(dto.getPatientId())
                .orElseThrow(() -> new RuntimeException("Patient not found"));
        Doctor doctor = doctorRepository.findById(dto.getDoctorId())
                .orElseThrow(() -> new RuntimeException("Doctor not found"));

        Appointment appointment = new Appointment();
        appointment.setPatient(patient);
        appointment.setDoctor(doctor);
        appointment.setAppointmentDate(dto.getAppointmentDate());
        appointment.setPrice(dto.getPrice());

        Appointment saved = appointmentRepository.save(appointment);
        return ResponseEntity.status(HttpStatus.CREATED).body(saved);
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteAppointment(@PathVariable Integer id) {
        appointmentRepository.deleteById(id);
        return ResponseEntity.noContent().build();
    }
}