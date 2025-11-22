package com.onlineclinicserver.controller;

import com.onlineclinicserver.dto.LoginRequestDTO;
import com.onlineclinicserver.model.User;
import com.onlineclinicserver.repository.UserRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping("/api/auth")
public class AuthController {

    private final UserRepository userRepository;

    public AuthController(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    @PostMapping("/login")
    public ResponseEntity<?> login(@RequestBody LoginRequestDTO loginRequest) {
        return userRepository.findByUsername(loginRequest.getUsername())
                .filter(user -> user.getPassword().equals(loginRequest.getPassword()))
                .<ResponseEntity<?>>map(user -> ResponseEntity.ok(user))
                .orElse(ResponseEntity.status(401).body("Invalid username or password"));
    }
}

