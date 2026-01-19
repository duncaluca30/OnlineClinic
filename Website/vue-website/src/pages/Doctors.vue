<template>
  <div>
    <h2>Our Doctors</h2>
    <div v-if="loading">Loading...</div>
    <div v-else>
      <div v-for="doc in doctors" :key="doc.id" class="doctor-card">
        <h3>{{ doc.name }}</h3>
        <p>{{ doc.specialization }}</p>
        <button @click="book(doc.id)">Book Appointment</button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import axios from '../api/axios'
import { useRouter } from 'vue-router'
import type { Doctor } from '../types/Doctor'

const doctors = ref<Doctor[]>([])
const loading = ref(true)
const router = useRouter()

onMounted(async () => {
  console.log('Fetching doctors...')
  const res = await axios.get<Doctor[]>('/api/doctors')
  console.log('Fetched doctors:', res.data)
  doctors.value = res.data
  loading.value = false
})

function book(doctorId: number) {
  router.push({ name: 'BookAppointment', query: { doctorId } })
}
</script>

<style scoped>
.doctor-card {
  border: 1px solid #ccc;
  padding: 1rem;
  margin-bottom: 1rem;
  border-radius: 8px;
}
</style>
