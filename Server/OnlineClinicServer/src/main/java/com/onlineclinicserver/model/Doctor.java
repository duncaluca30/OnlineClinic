package com.onlineclinicserver.model;

import jakarta.persistence.*;

@Entity
@Table(name = "doctors")
public class Doctor {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "doctor_id")
    private Integer id;

    @Column(nullable = false, length = 100)
    private String name;

    @Column(length = 100)
    private String specialty;

    @Column(length = 20)
    private String phone;

    @Column(length = 100)
    private String email;

    // --- Constructors ---
    public Doctor() {}

    public Doctor(String name, String specialty, String phone, String email) {
        this.name = name;
        this.specialty = specialty;
        this.phone = phone;
        this.email = email;
    }

    // --- Getters and Setters ---
    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSpecialty() {
        return specialty;
    }

    public void setSpecialty(String specialty) {
        this.specialty = specialty;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}