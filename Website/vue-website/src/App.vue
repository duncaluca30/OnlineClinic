<template>
  <div id="app">
    <nav class="navbar">
      <div class="logo-container">
        <img src="@/assets/logo.png" alt="Clinic Logo" class="logo" />
      </div>

      <router-link class="nav-btn" to="/">Home</router-link>
      <router-link class="nav-btn" to="/doctors">Book</router-link>
      <router-link class="nav-btn" to="/support">Support</router-link>
      <router-link class="nav-btn login-btn" to="/login">Log In / Register</router-link>
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

.login-btn {
  margin-left: auto;
  background-color: #ffffff;
}

.login-btn:hover {
  background-color: #dfdfdf;
}

.navbar a {
  text-decoration: none;
  color: #333;
  font-weight: bold;
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