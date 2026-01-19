<template>
  <div id="app">
    <nav class="navbar">
      <div class="nav-left">
        <div class="logo-container">
          <img src="@/assets/logo.png" alt="Clinic Logo" class="logo" />
        </div>

        <router-link class="nav-btn" to="/">Home</router-link>
        <router-link class="nav-btn" to="/doctors">Book</router-link>
        <router-link class="nav-btn" to="/support">Support</router-link>
        </div>

      <div class="nav-right">
        <div v-if="userName" class="user-menu-container">
          <div class="dropdown">
            <button class="dropdown-toggle" @click="toggleDropdown">
              Welcome, {{ userName }} <span class="arrow">▼</span>
            </button>

            <div v-if="showDropdown" class="dropdown-menu">
              <router-link to="/bookings" class="dropdown-item">Bookings</router-link>
              <button class="dropdown-item" @click="handleLogout">Log Out</button>
            </div>
          </div>
        </div>

        <div v-else>
          <router-link class="nav-btn login-btn" to="/login">Log In / Register</router-link>
        </div>
      </div>
    </nav>

    <main>
      <router-view />
    </main>

    <footer class="footer">
      <p>📍 Cluj-Napoca, Romania</p>
      <p>📞 +40 123 456 789</p>
      <p>✉️ contact@santaelena.ro</p>
    </footer>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'

const userName = ref(null)
const showDropdown = ref(false)
const router = useRouter()

onMounted(() => {
  const storedUser = JSON.parse(localStorage.getItem("user"))
  userName.value = storedUser?.name || null
})
function toggleDropdown() {
  showDropdown.value = !showDropdown.value
}
function handleLogout() {
  localStorage.removeItem("user")
  userName.value = null
  router.push('/')
}
</script>


<style scoped>
.logo-container {
  display: flex;
  align-items: center;
  margin-right: 0.8rem;
}

.logo {
  height: 65px;
  width: auto;
}

.navbar {
  display: flex;
  gap: 2.3rem;
  padding: 1rem 2rem;
  background-color: #dd8b8b;
  border: 1px solid #bd2121;
  align-items: center;
  border-radius: 16px;
  box-shadow: 0 2px 6px rgba(0,0,0,0.1);
}
.nav-left {
  display: flex;
  align-items: center;
  gap: 2rem;
}
.nav-right {
  margin-left: auto;
}

.nav-btn {
  padding: 0.5rem 1rem;
  background-color: #ffffff;
  border-radius: 8px;
  font-size: 1.2rem;
  font-family: Tahoma, 'Segoe UI', 'Geneva', Verdana, sans-serif;
  font-weight: 600;
  letter-spacing: 0.5px;
  border: 1px solid #e5b1b1;
  transition: all 0.2s ease;
}
.nav-btn:hover {
  background-color: #dfdfdf;
  border-color: #000000;
}

.navbar a {
  text-decoration: none;
  color: #333;
  font-weight: bold;
}
.dropdown {
  position: relative; /* CRITICAL: This allows the menu to position itself relative to this box */
  display: inline-block;
}

.dropdown-toggle {
  background: #ffffff; /* Explicit white background */
  border: 1px solid #e5b1b1; /* Same border as your other buttons */
  border-radius: 8px; /* Match nav-btn radius */
  padding: 0.5rem 1rem;
  cursor: pointer;
  
  /* Font settings to match your other nav buttons */
  font-family: Tahoma, 'Segoe UI', 'Geneva', Verdana, sans-serif;
  font-size: 1.2rem;
  font-weight: 600;
  color: #333; /* Force black/dark grey text */
  
  display: flex;
  align-items: center;
  gap: 8px;
  transition: all 0.2s ease;
}

.dropdown-toggle:hover {
  background-color: #dfdfdf;
  border-color: #000000;
  color: #000;
}

.arrow {
  font-size: 0.7rem;
  opacity: 0.7;
}

.dropdown-menu {
  position: absolute;
  right: 0;
  top: 115%;
  
  background-color: #ffffff;
  border: 1px solid #e5b1b1;
  border-radius: 12px;
  box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
  min-width: 160px;
  z-index: 1000;
  overflow: hidden;
  display: flex;
  flex-direction: column;
}

.dropdown-item {
  width: 100%;
  padding: 12px 16px;
  text-align: left;
  background: none;
  border: none;
  cursor: pointer;
  color: #333;
  font-size: 1.1rem;
  font-family: Tahoma, 'Segoe UI', 'Geneva', Verdana, sans-serif; 
  font-weight: bold;
  
  transition: background-color 0.2s ease;
}

.dropdown-item:hover {
  background-color: #fcebeb;
  color: #bd2121;
}

button.dropdown-item {
  font-family: Tahoma, 'Segoe UI', 'Geneva', Verdana, sans-serif;
}

.footer {
  margin-top: 3rem;
  padding: 1rem;
  background-color: #dd8b8b;
  border: 1px solid #bd2121;
  border-radius: 16px;
  text-align: center;
  color: #000000;
  font-family: 'Segoe UI', 'Geneva', Verdana, sans-serif;
  font-size: 1.2rem;
}
#app {
  display: flex;
  flex-direction: column;
  min-height: 98vh;
}

main {
  padding: 2rem;
  flex: 1;
}
</style>