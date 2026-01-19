package com.onlineclinicserver.controller;

import com.onlineclinicserver.dto.AppointmentDto;
import com.onlineclinicserver.model.Appointment;
import com.onlineclinicserver.model.Doctor;
import com.onlineclinicserver.model.Patient;
import com.onlineclinicserver.repository.AppointmentRepository;
import com.onlineclinicserver.repository.DoctorRepository;
import com.onlineclinicserver.repository.PatientRepository;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.OffsetDateTime;
import java.util.List;
import java.util.stream.Collectors;

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

    // --- NEW ENDPOINT: Get Booked Slots ---
    // This is called by the Frontend to grey out buttons
    @GetMapping("/booked")
    public ResponseEntity<List<String>> getBookedSlots(
            @RequestParam Integer doctorId,
            @RequestParam String date) { // Expects "yyyy-MM-dd"

        // 1. Calculate the start (00:00:00) and end (23:59:59) of the requested day
        LocalDate localDate = LocalDate.parse(date);
        LocalDateTime startOfDay = localDate.atStartOfDay();
        LocalDateTime endOfDay = startOfDay.plusDays(1).minusSeconds(1);

        // 2. Fetch appointments from DB using the Repository method we just created
        List<Appointment> appointments = appointmentRepository.findByDoctorIdAndAppointmentDateBetween(
                doctorId, startOfDay, endOfDay
        );

        // 3. Extract just the time strings (e.g., converts full date to just "09:00", "14:30")
        List<String> bookedTimes = appointments.stream()
                .map(a -> a.getAppointmentDate().toLocalTime().toString().substring(0, 5))
                .collect(Collectors.toList());

        return ResponseEntity.ok(bookedTimes);
    }

    // --- Existing Endpoints below ---

    @GetMapping
    public List<Appointment> getAllAppointments() {
        return appointmentRepository.findAll();
    }

    @GetMapping("/{id}")
    public Appointment getAppointmentById(@PathVariable Integer id) {
        return appointmentRepository.findById(id).orElse(null);
    }

    @GetMapping("/patient/{patientId}")
    public ResponseEntity<List<Appointment>> getAppointmentsByPatient(@PathVariable Integer patientId) {
        List<Appointment> appointments = appointmentRepository.findByPatientId(patientId);
        return ResponseEntity.ok(appointments);
    }
    @GetMapping("/doctor/{doctorId}")
    public ResponseEntity<List<Appointment>> getAppointmentsByDoctor(@PathVariable Integer doctorId) {
        List<Appointment> appointments = appointmentRepository.findByDoctorId(doctorId);
        return ResponseEntity.ok(appointments);
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

        if (dto.getAppointmentDate().isBefore(OffsetDateTime.now())) {
            return ResponseEntity.badRequest().body(null);
        }

        existing.setPatient(patient);
        existing.setDoctor(doctor);
        existing.setAppointmentDate(dto.getAppointmentDate().toLocalDateTime());
        existing.setPrice(dto.getPrice());

        Appointment updated = appointmentRepository.save(existing);
        return ResponseEntity.ok(updated);
    }

    @PostMapping
    public ResponseEntity<Appointment> createAppointment(@RequestBody AppointmentDto dto) {
        Patient patient = patientRepository.findById(dto.getPatientId())
                .orElseThrow(() -> new RuntimeException("Patient not found"));
        Doctor doctor = doctorRepository.findById(dto.getDoctorId())
                .orElseThrow(() -> new RuntimeException("Doctor not found"));

        if (dto.getAppointmentDate().isBefore(OffsetDateTime.now())) {
            return ResponseEntity.badRequest().body(null);
        }

        Appointment appointment = new Appointment();
        appointment.setPatient(patient);
        appointment.setDoctor(doctor);
        appointment.setAppointmentDate(dto.getAppointmentDate().toLocalDateTime());
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