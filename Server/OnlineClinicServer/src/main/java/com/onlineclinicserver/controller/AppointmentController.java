package com.onlineclinicserver.controller;

import com.onlineclinicserver.model.Appointment;
import com.onlineclinicserver.model.Doctor;
import com.onlineclinicserver.model.Patient;
import com.onlineclinicserver.repository.AppointmentRepository;
import com.onlineclinicserver.repository.DoctorRepository;
import com.onlineclinicserver.repository.PatientRepository;
import org.springframework.web.bind.annotation.*;
import com.onlineclinicserver.dto.AppointmentRequest;

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

    // --- Create Appointment using IDs ---
    @PostMapping
    public Appointment createAppointment(@RequestBody AppointmentRequest request) {
        Doctor doctor = doctorRepository.findById(request.getDoctor_id())
                .orElseThrow(() -> new RuntimeException("Doctor not found"));
        Patient patient = patientRepository.findById(request.getPatient_id())
                .orElseThrow(() -> new RuntimeException("Patient not found"));

        Appointment appointment = new Appointment(
                doctor,
                patient,
                request.getAppointmentDate(),
                request.getPrice()
        );

        return appointmentRepository.save(appointment);
    }

    @DeleteMapping("/{id}")
    public void deleteAppointment(@PathVariable Integer id) {
        appointmentRepository.deleteById(id);
    }
}