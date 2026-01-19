<template>
  <div class="auth-page">
    <div class="tabs">
      <button :class="{ active: activeTab === 'login' }" @click="activeTab = 'login'">Log In</button>
      <button :class="{ active: activeTab === 'register' }" @click="activeTab = 'register'">Register</button>
    </div>

    <div v-if="activeTab === 'login'" class="form-box">
      <h2>Log In</h2>
      <form @submit.prevent="handleLogin">
        <input type="text" placeholder="Email" v-model="loginUsername" required />
        <input type="password" placeholder="Password" v-model="loginPassword" required />
        <button type="submit">Log In</button>
      </form>
    </div>

    <div v-else class="form-box">
      <h2>Register</h2>
      <form @submit.prevent="handleRegister">
        <input type="text" placeholder="Full Name" v-model="registerName" required />
        <input type="email" placeholder="Email" v-model="registerEmail" required />
        <input type="password" placeholder="Password" v-model="registerPassword" required />
        <input type="date" placeholder="Date of Birth" v-model="registerDob" required />
        <input type="tel" placeholder="Phone Number" v-model="registerPhone" required />
        <button type="submit">Register</button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'

const activeTab = ref('login')

const loginUsername = ref('')
const loginPassword = ref('')

const registerName = ref('')
const registerEmail = ref('')
const registerPassword = ref('')
const registerDob = ref('')
const registerPhone = ref('')

function handleLogin() {
  console.log('Logging in with', loginUsername.value, loginPassword.value)
}

function handleRegister() {
  console.log('Registering with', registerName.value, registerEmail.value, registerPassword.value, registerDob.value, registerPhone.value)
}
</script>

<style scoped>
.auth-page {
  max-width: 400px;
  margin: 2rem auto;
  padding: 2rem;
  background-color: #fff0f0;
  border-radius: 16px;
  box-shadow: 0 2px 8px rgba(0,0,0,0.1);
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  font-size: 1rem;
}

.tabs {
  display: flex;
  justify-content: center;
  gap: 1rem;
  margin-bottom: 1rem;
}

.tabs button {
  padding: 0.5rem 1rem;
  background-color: #ffffff;
  border: 1px solid #e5b1b1;
  border-radius: 8px;
  font-weight: bold;
  cursor: pointer;
  color: #b03a48;
  font-family: "Segoe UI", "Geneva", Verdana, sans-serif;
  font-size: 1.2rem;
}

.tabs button.active {
  background-color: #b03a48;
  color: white;
}

.form-box h2 {
  margin-bottom: 1rem;
  color: #b03a48;
  text-align: center;
  font-family: 'Segoe UI', 'Geneva', Verdana, sans-serif;
}

input {
  display: block;
  width: 100%;
  margin-bottom: 1rem;
  padding: 0.6rem;
  border-radius: 8px;
  border: 1px solid #ccc;
  font-family: "Segoe UI", "Geneva", Verdana, sans-serif;
  font-size: 1rem;
}

button[type="submit"] {
  width: 100%;
  padding: 0.6rem;
  background-color: #b03a48;
  color: white;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  font-family: "Segoe UI", "Geneva", Verdana, sans-serif;
    font-size: 1.1rem;
}

button[type="submit"]:hover {
  background-color: #8c2e3a;
}
</style>