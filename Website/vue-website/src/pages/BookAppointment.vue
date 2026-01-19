<template>
  <div class="book-appointment">
    <h1>Book an Appointment</h1>

    <form @submit.prevent="submitAppointment">
      <div>
        <label for="doctor">Doctor ID:</label>
        <input v-model="form.doctor_id" type="number" id="doctor" required />
      </div>

      <div>
        <label for="patient">Patient ID:</label>
        <input v-model="form.patient_id" type="number" id="patient" required />
      </div>

      <div>
        <label for="date">Date & Time:</label>
        <input v-model="form.appointmentDate" type="datetime-local" id="date" required />
      </div>

      <div>
        <label for="price">Price:</label>
        <input v-model="form.price" type="number" id="price" required />
      </div>

      <button type="submit">Book</button>
    </form>
  </div>
</template>

<script lang="ts" setup>
import { ref } from 'vue'
import axios from 'axios'
import { useRoute } from 'vue-router'
import type { AppointmentRequest } from '@/types/AppointmentRequest'

const route = useRoute()
const doctorId = Number(route.query.doctorId)

const form = ref<AppointmentRequest>({
  doctor_id: 1,
  patient_id: 1,
  appointmentDate: '',
  price: 150
})

form.value.doctor_id = doctorId

async function submitAppointment() {
  try {
    await axios.post('/api/appointments', form.value)
    alert('Appointment booked successfully!')
  } catch (error) {
    console.error('Booking failed:', error)
    alert('Failed to book appointment.')
  }
}
</script>

<style scoped>
.book-appointment {
  max-width: 500px;
  margin: auto;
  padding: 1rem;
}
form > div {
  margin-bottom: 1rem;
}
</style>