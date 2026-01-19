<template>
  <div class="page-container">
    
    <div class="header-section">
      <h1>We are here to help</h1>
      <p>Have questions? Find answers below or get in touch with our team.</p>
    </div>

    <div class="contact-grid">
      <div class="contact-card">
        <div class="icon">📞</div>
        <h3>Call Us</h3>
        <p>Mon-Fri, 8am - 8pm</p>
        <a href="tel:+40123456789" class="contact-link">+40 123 456 789</a>
      </div>

      <div class="contact-card">
        <div class="icon">✉️</div>
        <h3>Email Us</h3>
        <p>We reply within 24 hours</p>
        <a href="mailto:contact@santaelena.ro" class="contact-link">contact@santaelena.ro</a>
      </div>

      <div class="contact-card">
        <div class="icon">📍</div>
        <h3>Visit Us</h3>
        <p>Central Clinic</p>
        <span class="contact-text">Cluj-Napoca, Romania</span>
      </div>
    </div>

    <div class="content-split">
      
      <div class="faq-section">
        <h2>Frequently Asked Questions</h2>
        
        <div class="faq-item">
          <h4>How do I cancel an appointment?</h4>
          <p>Go to the <strong>Bookings</strong> page. You can cancel any upcoming appointment by clicking the "Cancel Booking" button.</p>
        </div>

        <div class="faq-item">
          <h4>Do I need to pay online?</h4>
          <p>No. Payment is handled at the clinic after your consultation. The prices listed on the website are standard estimates.</p>
        </div>

        <div class="faq-item">
          <h4>What if I forgot my password?</h4>
          <p>Currently, you will need to contact support via email to reset your account credentials.</p>
        </div>

        <div class="emergency-box">
          <strong>🚑 Medical Emergency?</strong>
          <p>If you require immediate medical attention, please call <strong>112</strong> immediately. Do not use this website for emergencies.</p>
        </div>
      </div>

      <div class="form-section">
        <div class="form-card">
          <h2>Send us a message</h2>
          <form @submit.prevent="sendMessage">
            <div class="form-group">
              <label>Name</label>
              <input v-model="form.name" type="text" placeholder="Your Name" required class="form-input" />
            </div>

            <div class="form-group">
              <label>Email</label>
              <input v-model="form.email" type="email" placeholder="Your Email" required class="form-input" />
            </div>

            <div class="form-group">
              <label>Message</label>
              <textarea v-model="form.message" rows="4" placeholder="How can we help?" required class="form-input"></textarea>
            </div>

            <button type="submit" class="submit-btn" :disabled="loading">
              {{ loading ? 'Sending...' : 'Send Message' }}
            </button>
          </form>
        </div>
      </div>

    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'

const loading = ref(false)
const form = ref({
  name: '',
  email: '',
  message: ''
})

function sendMessage() {
  loading.value = true
  
  // Simulate sending to backend
  setTimeout(() => {
    alert(`Thank you, ${form.value.name}! Your message has been sent.`)
    form.value = { name: '', email: '', message: '' } // Reset form
    loading.value = false
  }, 1500)
}
</script>

<style scoped>
.page-container {
  padding: 3rem 2rem;
  max-width: 1100px;
  margin: 0 auto;
  font-family: Tahoma, 'Segoe UI', sans-serif;
}

/* Header */
.header-section {
  text-align: center;
  margin-bottom: 3rem;
}
.header-section h1 { color: #bd2121; font-size: 2.2rem; margin-bottom: 0.5rem; }
.header-section p { color: #666; font-size: 1.1rem; }

/* Contact Grid */
.contact-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 2rem;
  margin-bottom: 4rem;
}

.contact-card {
  background: white;
  border: 1px solid #e5b1b1;
  border-radius: 12px;
  padding: 2rem;
  text-align: center;
  box-shadow: 0 4px 12px rgba(0,0,0,0.05);
  transition: transform 0.2s;
}
.contact-card:hover { transform: translateY(-5px); }
.icon { font-size: 2.5rem; margin-bottom: 1rem; }
.contact-card h3 { color: #333; margin-bottom: 0.5rem; }
.contact-card p { color: #777; margin-bottom: 1rem; font-size: 0.9rem; }
.contact-link { 
  color: #bd2121; 
  font-weight: bold; 
  text-decoration: none; 
  font-size: 1.1rem;
}
.contact-text { color: #333; font-weight: 600; }

/* Split Layout */
.content-split {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 4rem;
  align-items: start;
}

/* FAQ Styling */
.faq-section h2 { color: #333; margin-bottom: 1.5rem; }
.faq-item { margin-bottom: 1.5rem; border-bottom: 1px solid #eee; padding-bottom: 1rem; }
.faq-item h4 { color: #bd2121; margin-bottom: 0.5rem; }
.faq-item p { color: #555; line-height: 1.5; }

.emergency-box {
  background-color: #ffeaea;
  border-left: 4px solid #bd2121;
  padding: 1rem;
  margin-top: 2rem;
  border-radius: 4px;
}
.emergency-box strong { color: #bd2121; display: block; margin-bottom: 0.5rem; font-size: 1.1rem; }

/* Form Styling */
.form-card {
  background: #fff;
  padding: 2rem;
  border-radius: 16px;
  border: 1px solid #e5b1b1;
  box-shadow: 0 5px 20px rgba(0,0,0,0.08);
}
.form-card h2 { text-align: center; margin-bottom: 1.5rem; color: #333; }

.form-group { margin-bottom: 1.2rem; }
.form-group label { display: block; margin-bottom: 0.5rem; color: #333; font-weight: 600; }
.form-input {
  width: 100%;
  padding: 0.8rem;
  border: 1px solid #ccc;
  border-radius: 8px;
  font-family: inherit;
  font-size: 1rem;
  box-sizing: border-box;
}
.form-input:focus { outline: none; border-color: #dd8b8b; box-shadow: 0 0 0 3px rgba(221,139,139,0.2); }

textarea.form-input { resize: vertical; }

.submit-btn {
  width: 100%;
  padding: 1rem;
  background-color: #dd8b8b;
  color: white;
  border: none;
  border-radius: 8px;
  font-size: 1.1rem;
  font-weight: 600;
  cursor: pointer;
  transition: background-color 0.2s;
}
.submit-btn:hover { background-color: #bd2121; }
.submit-btn:disabled { background-color: #ccc; cursor: not-allowed; }

/* Responsive Mobile */
@media (max-width: 768px) {
  .content-split { grid-template-columns: 1fr; gap: 2rem; }
}
</style>