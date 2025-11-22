package com.onlineclinicserver.dto;

import java.math.BigDecimal;
import java.time.LocalDateTime;

public class AppointmentRequest {
    private Integer doctor_id;
    private Integer patient_id;
    private LocalDateTime appointmentDate;
    private BigDecimal price;

    // Getters and setters
    public Integer getDoctor_id() { return doctor_id; }
    public void setDoctor_id(Integer doctor_id) { this.doctor_id = doctor_id; }

    public Integer getPatient_id() { return patient_id; }
    public void setPatient_id(Integer patient_id) { this.patient_id = patient_id; }

    public LocalDateTime getAppointmentDate() { return appointmentDate; }
    public void setAppointmentDate(LocalDateTime appointmentDate) { this.appointmentDate = appointmentDate; }

    public BigDecimal getPrice() { return price; }
    public void setPrice(BigDecimal price) { this.price = price; }

}