package com.onlineclinicserver.dto;
import java.time.LocalDateTime;
import java.math.BigDecimal;
import java.time.OffsetDateTime;

public class AppointmentDto {
    private Integer doctorId;
    private Integer patientId;
    private OffsetDateTime appointmentDate;
    private BigDecimal price;

    // Getters and setters
    public Integer getDoctorId() {
        return doctorId;
    }

    public void setDoctorId(Integer doctorId) {
        this.doctorId = doctorId;
    }

    public Integer getPatientId() {
        return patientId;
    }

    public void setPatientId(Integer patientId) {
        this.patientId = patientId;
    }

    public OffsetDateTime getAppointmentDate() {
        return appointmentDate;
    }

    public void setAppointmentDate(OffsetDateTime appointmentDate) {
        this.appointmentDate = appointmentDate;
    }

    public BigDecimal getPrice() {
        return price;
    }

    public void setPrice(BigDecimal price) {
        this.price = price;
    }
}
