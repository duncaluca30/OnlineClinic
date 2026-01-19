<template>
  <div class="page-container">
    <div class="header-section">
      <h1>My Bookings</h1>
      <p>Manage your upcoming and past appointments.</p>
    </div>

    <div v-if="userRole === 'DOCTOR'" class="management-card">
      <div class="management-header">
        <h2>Manage My Profile</h2>
        <p>Update your consultation settings.</p>
      </div>
      
      <div class="price-updater">
        <label>My Consultation Fee (RON):</label>
        <div class="input-group">
          <input 
            v-model="currentPrice" 
            type="number" 
            step="10" 
            class="price-input" 
          />
          <button @click="updatePrice" :disabled="updating" class="update-btn">
            {{ updating ? 'Saving...' : 'Update Price' }}
          </button>
        </div>
      </div>
    </div>

    <div v-if="loading" class="loading-state">
      Loading appointments...
    </div>

    <div v-else-if="appointments.length === 0" class="empty-state">
      <p>You have no appointments scheduled.</p>
      <router-link to="/doctors" class="book-btn">Book New Appointment</router-link>
    </div>

    <div v-else class="bookings-grid">
      <div v-for="app in appointments" :key="app.id" class="booking-card">
        
        <div class="card-top">
          <div class="doctor-info">
  
            <template v-if="userRole === 'DOCTOR'">
              <span class="label">Patient</span>
              <h3>{{ app.patient ? app.patient.name : 'Unknown Patient' }}</h3>
            </template>

            <template v-else>
              <span class="label">Doctor</span>
              <h3>{{ app.doctor ? app.doctor.name : 'Unknown Doctor' }}</h3>
            </template>

            <span class="specialty" v-if="app.doctor && userRole !== 'DOCTOR'">
             {{ app.doctor.specialty }}
            </span>
          </div>
          <div class="date-box">
             <span class="month">{{ getMonth(app.appointmentDate) }}</span>
             <span class="day">{{ getDay(app.appointmentDate) }}</span>
          </div>
        </div>

        <div class="card-details">
          <p><strong>🕒 Time:</strong> {{ getTime(app.appointmentDate) }}</p>
          <p><strong>💰 Price:</strong> {{ app.price }} RON</p>
          <p><strong>📍 Status:</strong> 
            <span :class="isPast(app.appointmentDate) ? 'status-past' : 'status-upcoming'">
              {{ isPast(app.appointmentDate) ? 'Completed' : 'Upcoming' }}
            </span>
          </p>
        </div>

        <div class="card-actions" v-if="!isPast(app.appointmentDate)">
          <button @click="cancelAppointment(app.id)" class="cancel-btn">Cancel Booking</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import axios from '../api/axios' 
import { useRouter } from 'vue-router'
import { useToast } from "vue-toastification";

const appointments = ref<any[]>([])
const loading = ref(true)
const router = useRouter()
const userRole = ref('') 
const toast = useToast();

// New Refs for Price Update
const currentPrice = ref(0)
const updating = ref(false)
const doctorId = ref<number | null>(null)

onMounted(async () => {
  const userStr = localStorage.getItem("user")
  if (!userStr) {
    router.push('/login')
    return
  }

  const user = JSON.parse(userStr)
  userRole.value = user.role; 
  const userId = user.id;

  // --- 1. Doctor Logic: Fetch Price & ID ---
  if (user.role === 'DOCTOR') {
      try {
          const allDocs = await axios.get('/api/doctors');
          // Find the doctor profile matching the logged-in user
          // We check ID or Email to be safe
          const myProfile = allDocs.data.find((d: any) => d.id === userId || d.email === user.username);
          
          if (myProfile) {
              doctorId.value = myProfile.id;
              currentPrice.value = myProfile.price;
          } else {
             // Fallback: assume ID matches directly
             doctorId.value = userId;
          }
      } catch (e) { console.error("Error fetching doctor profile", e) }
  }

  // --- 2. Fetch Appointments ---
  try {
    let response;
    if (user.role === 'DOCTOR') {
      response = await axios.get(`/api/appointments/doctor/${userId}`)
    } else {
      response = await axios.get(`/api/appointments/patient/${userId}`)
    }

    appointments.value = response.data.sort((a: any, b: any) => 
      new Date(b.appointmentDate).getTime() - new Date(a.appointmentDate).getTime()
    )
  } catch (error) {
    console.error("Failed to load bookings", error)
  } finally {
    loading.value = false
  }
})

// --- New Function: Update Price ---
async function updatePrice() {
  if (!doctorId.value) return;
  updating.value = true;
  
  try {
    await axios.put(`/api/doctors/${doctorId.value}/price`, {
      price: currentPrice.value
    });
    toast.success("Price updated successfully!",{ timeout: 3000 });
  } catch (error) {
    console.error(error);
    toast.error("Failed to update price.",{ timeout: 3000 });
  } finally {
    updating.value = false;
  }
}

async function cancelAppointment(id: number) {
  if(!confirm("Are you sure you want to cancel this appointment?")) return;
  try {
    await axios.delete(`/api/appointments/${id}`)
    appointments.value = appointments.value.filter(app => app.id !== id)
    toast.info("Appointment cancelled.",{ timeout: 3000 });
  } catch (error) {
    toast.error("Failed to cancel.",{ timeout: 3000 });
  }
}

function getMonth(dateStr: string) {
  return new Date(dateStr).toLocaleDateString('en-US', { month: 'short' }).toUpperCase();
}
function getDay(dateStr: string) {
  return new Date(dateStr).getDate();
}
function getTime(dateStr: string) {
  return new Date(dateStr).toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });
}
function isPast(dateStr: string) {
  return new Date(dateStr) < new Date();
}
</script>

<style scoped>
.page-container {
  padding: 3rem 2rem;
  max-width: 1000px;
  margin: 0 auto;
  font-family: Tahoma, 'Segoe UI', sans-serif;
}

.header-section {
  text-align: center;
  margin-bottom: 3rem;
}
.header-section h1 { color: #bd2121; margin-bottom: 0.5rem; }

/* Management Card CSS */
.management-card {
  background: white;
  border: 1px solid #bd2121;
  border-left: 6px solid #bd2121;
  border-radius: 8px;
  padding: 1.5rem;
  margin-bottom: 2rem; /* Spacing between this and list */
  display: flex;
  justify-content: space-between;
  align-items: center;
  box-shadow: 0 4px 12px rgba(189, 33, 33, 0.1);
}
.management-header h2 { margin: 0; color: #333; font-size: 1.4rem; }
.management-header p { margin: 0.2rem 0 0; color: #666; }

.price-updater {
  display: flex;
  flex-direction: column;
  align-items: flex-end;
}
.price-updater label { font-weight: bold; color: #555; margin-bottom: 0.5rem; }
.input-group { display: flex; gap: 0.5rem; }

.price-input {
  padding: 0.6rem;
  border: 1px solid #ccc;
  border-radius: 6px;
  width: 100px;
  font-size: 1rem;
}
.update-btn {
  background-color: #bd2121;
  color: white;
  border: none;
  padding: 0.6rem 1.2rem;
  border-radius: 6px;
  cursor: pointer;
  font-weight: bold;
}
.update-btn:hover { background-color: #a11b1b; }
.update-btn:disabled { background-color: #ccc; cursor: not-allowed; }

/* Existing Grid Layout */
.bookings-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
  gap: 2rem;
}

/* Card Styling */
.booking-card {
  background: white;
  border: 1px solid #e5b1b1;
  border-radius: 16px;
  padding: 1.5rem;
  box-shadow: 0 4px 10px rgba(0,0,0,0.05);
  transition: transform 0.2s;
  display: flex;
  flex-direction: column;
}
.booking-card:hover { transform: translateY(-4px); }

.card-top {
  display: flex;
  justify-content: space-between;
  align-items: flex-start;
  margin-bottom: 1rem;
  border-bottom: 1px solid #eee;
  padding-bottom: 1rem;
}

.doctor-info h3 { margin: 0.2rem 0; color: #333; }
.label { font-size: 0.75rem; text-transform: uppercase; color: #888; font-weight: bold; }
.specialty { font-size: 0.9rem; color: #dd8b8b; font-weight: 600; }

.date-box {
  background: #fff0f0;
  color: #bd2121;
  padding: 0.5rem 0.8rem;
  border-radius: 8px;
  text-align: center;
  display: flex;
  flex-direction: column;
  line-height: 1;
}
.date-box .month { font-size: 0.8rem; font-weight: bold; }
.date-box .day { font-size: 1.5rem; font-weight: 700; }

.card-details p { margin: 0.5rem 0; color: #555; }

/* Status Badges */
.status-upcoming { color: #2ecc71; font-weight: bold; }
.status-past { color: #95a5a6; font-weight: bold; }

/* Buttons */
.card-actions { margin-top: auto; padding-top: 1rem; }
.cancel-btn {
  width: 100%;
  padding: 0.6rem;
  background: white;
  border: 1px solid #bd2121;
  color: #bd2121;
  border-radius: 8px;
  cursor: pointer;
  transition: all 0.2s;
}
.cancel-btn:hover { background: #bd2121; color: white; }

.empty-state { text-align: center; margin-top: 3rem; color: #666; }
.book-btn {
  display: inline-block;
  margin-top: 1rem;
  background: #dd8b8b;
  color: white;
  padding: 0.8rem 1.5rem;
  border-radius: 8px;
  text-decoration: none;
}
</style>