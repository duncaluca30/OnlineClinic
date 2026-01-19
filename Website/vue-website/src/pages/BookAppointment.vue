<template>
  <div class="page-container">
    <div class="appointment-card">
      <div class="card-header">
        <h1>📅 Book Appointment</h1>
        <p class="subtitle">Select a date and an available time slot.</p>
      </div>

      <form @submit.prevent="submitAppointment">
        
        <div class="form-group">
  <label for="date">1. Select Date</label>
  <input 
    v-model="selectedDate"
    type="date" 
    id="date" 
    class="form-input" 
    :min="minDate"
    required 
  />
  </div>

        <div class="form-group" v-if="selectedDate">
          <label>2. Select Time</label>
          
          <div v-if="loadingSlots" class="loading-text">Checking availability...</div>
          
          <div v-else class="time-grid">
            <button 
              v-for="time in availableTimeSlots" 
              :key="time"
              type="button"
              class="time-slot-btn"
              :class="{ 'selected': selectedTime === time }"
              @click="selectTime(time)"
            >
              {{ time }}
            </button>
            
            <p v-if="availableTimeSlots.length === 0" class="no-slots">
              No slots available on this date.
            </p>
          </div>
          
          <input type="hidden" :value="formattedDateTime" required />
        </div>

        <p class="note">Consultation Price: {{ form.price }} RON</p>

        <button 
          type="submit" 
          class="submit-btn" 
          :disabled="isSubmitting || !selectedDate || !selectedTime"
        >
          {{ isSubmitting ? 'Booking...' : 'Confirm Booking' }}
        </button>
      </form>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref, onMounted, computed, watch } from 'vue'
import axios from '../api/axios' 
import { useRoute, useRouter } from 'vue-router'
import { useToast } from "vue-toastification";

const route = useRoute()
const router = useRouter()
const toast = useToast();

// 1. Get Data from URL
const doctorIdFromUrl = Number(route.query.doctorId)
// Read price from URL. If missing/invalid, fallback to 150.
const priceFromUrl = Number(route.query.price) || 150 

const isSubmitting = ref(false)
const loadingSlots = ref(false)
const selectedDate = ref('')
const selectedTime = ref('')
const bookedTimes = ref<string[]>([])

interface AppointmentRequest {
  doctorId: number;
  patientId: number;
  appointmentDate: string;
  price: number;
}

const form = ref<AppointmentRequest>({
  doctorId: 1, 
  patientId: 1, 
  appointmentDate: '',
  price: priceFromUrl // <--- ASSIGN DYNAMIC PRICE HERE
})

// ... (Keep your existing Min Date logic) ...
const minDate = computed(() => new Date().toISOString().split('T')[0]);

// ... (Keep your existing Time Slot logic) ...
const allTimeSlots = [
  "09:00", "09:30", "10:00", "10:30", "11:00", "11:30",
  "12:00", "12:30", "13:00", "13:30", "14:00", "14:30",
  "15:00", "15:30", "16:00", "16:30", "17:00"
];

const availableTimeSlots = computed(() => {
  let slots = allTimeSlots.filter(time => !bookedTimes.value.includes(time));
  if (selectedDate.value === minDate.value) {
    const now = new Date();
    const currentHour = now.getHours();
    const currentMin = now.getMinutes();
    slots = slots.filter(time => {
      const [slotHour = 0, slotMin = 0] = time.split(':').map(Number);
      if (slotHour < currentHour) return false;
      if (slotHour === currentHour && slotMin < currentMin) return false;
      return true;
    });
  }
  return slots;
});

const formattedDateTime = computed(() => {
  if (!selectedDate.value || !selectedTime.value) return '';
  return `${selectedDate.value}T${selectedTime.value}:00Z`;
});

watch(selectedDate, async (newDate) => {
  if (!newDate) return;
  await fetchBookedSlots(newDate);
});

onMounted(() => {
  if (doctorIdFromUrl) form.value.doctorId = doctorIdFromUrl;
  
  const userStr = localStorage.getItem("user")
  if (userStr) {
    try {
      const user = JSON.parse(userStr)
      if (user.id) form.value.patientId = user.id;
    } catch (e) {
      console.error(e);
    }
  }
})

async function fetchBookedSlots(dateStr: string) {
  loadingSlots.value = true;
  selectedTime.value = ''; 
  bookedTimes.value = [];
  try {
    const response = await axios.get('/api/appointments/booked', {
      params: { doctorId: form.value.doctorId, date: dateStr }
    });
    bookedTimes.value = response.data;
  } catch (e) {
    console.error("Failed to fetch slots", e);
  } finally {
    loadingSlots.value = false;
  }
}

function selectTime(time: string) {
  selectedTime.value = time;
}

async function submitAppointment() {
  isSubmitting.value = true
  form.value.appointmentDate = formattedDateTime.value;

  try {
    await axios.post('/api/appointments', form.value)
    toast.success("Appointment booked successfully!", { timeout: 3000 });
    router.push('/bookings') 
  } catch (error: any) {
    console.error('Booking failed:', error)
    if (error.response && error.response.status === 400) {
       toast.warning("Please choose a valid future time.");
    } else {
       toast.error("Booking failed. Please try again.");
    }
  } finally {
    isSubmitting.value = false
  }
}
</script>

<style scoped>
/* Keep your existing Layout CSS */
.page-container {
  display: flex;
  justify-content: center;
  align-items: flex-start; 
  padding-top: 6rem; 
  min-height: 80vh;
  font-family: Tahoma, 'Segoe UI', 'Geneva', Verdana, sans-serif;
}

.appointment-card {
  background: white;
  width: 100%;
  max-width: 450px; 
  padding: 3rem 2rem;
  border-radius: 16px;
  border: 1px solid #e5b1b1; 
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.08);
  text-align: center; 
}

.card-header { margin-bottom: 2rem; }
h1 { color: #bd2121; font-size: 1.8rem; margin-bottom: 0.5rem; font-weight: 700; }
.subtitle { color: #666; font-size: 1rem; }

.form-group { margin-bottom: 2rem; text-align: left; }
label { display: block; margin-bottom: 0.8rem; color: #333; font-weight: 600; font-size: 1rem; }
.note { font-size: 0.85rem; color: #888; margin-top: 0.5rem; font-style: italic; }

.form-input {
  width: 100%;
  padding: 1rem;
  font-size: 1.1rem; 
  border: 1px solid #ccc;
  border-radius: 8px;
  background-color: #fff;
  font-family: inherit;
  box-sizing: border-box;
}

/* --- NEW TIME GRID STYLES --- */
.time-grid {
  display: grid;
  grid-template-columns: repeat(4, 1fr); /* 4 columns */
  gap: 10px;
}

.time-slot-btn {
  padding: 10px;
  background-color: #fff0f0; /* Light pink */
  border: 1px solid #e5b1b1;
  border-radius: 6px;
  cursor: pointer;
  font-family: inherit;
  font-weight: 600;
  color: #333;
  transition: all 0.2s;
}

.time-slot-btn:hover {
  background-color: #eecaca;
  transform: translateY(-2px);
}

.time-slot-btn.selected {
  background-color: #bd2121; /* Theme Red */
  color: white;
  border-color: #bd2121;
  box-shadow: 0 4px 8px rgba(189, 33, 33, 0.3);
}

.loading-text, .no-slots {
  text-align: center;
  color: #666;
  font-style: italic;
  padding: 1rem;
  grid-column: 1 / -1;
  width: 100%;
}

/* Submit Button */
.submit-btn {
  width: 100%;
  padding: 1rem;
  background-color: #dd8b8b;
  color: white;
  border: none;
  border-radius: 8px;
  font-size: 1.2rem;
  font-weight: 600;
  cursor: pointer;
  transition: background-color 0.2s ease;
}
.submit-btn:hover { background-color: #bd2121; }
.submit-btn:disabled { background-color: #e0e0e0; cursor: not-allowed; color: #999; }
</style>