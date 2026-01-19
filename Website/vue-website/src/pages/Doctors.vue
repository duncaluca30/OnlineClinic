<template>
  <div class="page-container">
    <h2 class="page-title">Our Doctors</h2>

    <div v-if="loading" class="loading-state">
      Loading...
    </div>

    <div v-else class="doctors-grid">
      <div v-for="doc in doctors" :key="doc.id" class="doctor-card">
        <div class="card-header">
           <div class="avatar-circle">{{ doc.name.charAt(4) }}</div>
           <h3>{{ doc.name }}</h3>
        </div>
        
        <p class="specialization">
          {{ doc.specialty || 'Specialization not listed' }}
        </p>
        
        <button class="book-btn" @click="book(doc.id)">
          Book Appointment
        </button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import axios from '../api/axios' // Ensure this path is correct for your project
import { useRouter } from 'vue-router'
// Assuming you have a types file, if not, you can remove the import
import type { Doctor } from '../types/Doctor' 

const doctors = ref<Doctor[]>([])
const loading = ref(true)
const router = useRouter()

onMounted(async () => {
  try {
    console.log('Fetching doctors...')
    const res = await axios.get<Doctor[]>('/api/doctors')
    console.log('Fetched doctors:', res.data)
    doctors.value = res.data
  } catch (error) {
    console.error("Error loading doctors:", error)
  } finally {
    loading.value = false
  }
})

function book(doctorId: number) {
  router.push({ name: 'BookAppointment', query: { doctorId: doctorId, price: doctors.value.find(doc => doc.id === doctorId)?.price } })
}
</script>

<style scoped>
/* 1. Fix the Global Font */
.page-container {
  font-family: Tahoma, 'Segoe UI', 'Geneva', Verdana, sans-serif;
  padding: 2rem;
  max-width: 1200px;
  margin: 0 auto;
}

.page-title {
  color: #333;
  font-size: 2rem;
  margin-bottom: 2rem;
  text-align: center;
  font-weight: 700;
}

/* 2. Grid Layout for the cards */
.doctors-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(280px, 1fr)); /* Responsive grid */
  gap: 2rem;
}

/* 3. The Card Styling */
.doctor-card {
  background: white;
  border: 1px solid #e5b1b1; /* Matches your nav border */
  padding: 2rem;
  border-radius: 16px;
  box-shadow: 0 4px 6px rgba(0,0,0,0.05);
  display: flex;
  flex-direction: column;
  align-items: center; /* Centers everything */
  text-align: center;
  transition: transform 0.2s ease, box-shadow 0.2s ease;
}

.doctor-card:hover {
  transform: translateY(-5px); /* Lifts up slightly on hover */
  box-shadow: 0 10px 20px rgba(0,0,0,0.1);
  border-color: #bd2121;
}

.card-header h3 {
  margin: 1rem 0 0.5rem 0;
  color: #333;
  font-size: 1.4rem;
}

/* 4. The Specialization Text */
.specialization {
  color: #666;
  font-size: 1.1rem;
  font-weight: 500;
  margin-bottom: 1.5rem;
  background-color: #fcebeb; /* Light pink pill background */
  padding: 4px 12px;
  border-radius: 20px;
  display: inline-block;
}

/* 5. The "Book Appointment" Button */
.book-btn {
  background-color: #dd8b8b; /* Your theme color */
  color: white;
  border: none;
  padding: 0.8rem 1.5rem;
  font-size: 1rem;
  font-weight: 600;
  border-radius: 8px;
  cursor: pointer;
  width: 100%;
  transition: background-color 0.2s ease;
  font-family: inherit; /* Ensures button has the same font */
}

.book-btn:hover {
  background-color: #bd2121; /* Darker red on hover */
}

/* Optional: Avatar Circle */
.avatar-circle {
  width: 60px;
  height: 60px;
  background-color: #eee;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 1.5rem;
  font-weight: bold;
  color: #888;
  margin: 0 auto;
}
</style>