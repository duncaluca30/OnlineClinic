<template>
  <div class="home">
    <section class="hero">
      <h1>Your health, our priority</h1>
      <p>Book appointments with trusted professionals in just a few clicks.</p>
      <router-link to="/book" class="cta-btn">Book Now</router-link>
    </section>

    <section class="gallery">
        <div class="scroll-container">
            <img src="@/assets/facility.png" alt="Clinic Room" />
            <img src="@/assets/reception.png" alt="Reception Area" />
            <img src="@/assets/doctors.png" alt="Doctors Team" />
            <img src="@/assets/consult.png" alt="Consultation Room" />
        </div>
    </section>

    <section class="features">
      <div class="feature">👨‍⚕️ Certified Doctors</div>
      <div class="feature">🕒 Flexible Scheduling</div>
      <div class="feature">🔒 Secure Platform</div>
    </section>
  </div>
</template>

<style scoped>
.home {
  text-align: center;
  padding: 2rem;
}

.hero {
  background-color: #ffc3c3;
  padding: 2rem;
  border-radius: 16px;
  box-shadow: 0 2px 6px rgba(0,0,0,0.1);
}

.hero h1 {
  font-size: 2rem;
  color: #b03a48;
  font-family: 'Segoe UI', 'Geneva', Verdana, sans-serif;
}
.hero p {
  font-size: 1.2rem;
  margin-top: 0.5rem;
  color: #1d1d1d;
  font-family: Tahoma, 'Segoe UI', 'Geneva', Verdana, sans-serif;
}

.gallery {
  margin-top: 3rem;
  text-align: center;
}

.scroll-container {
  display: flex;
  overflow-x: auto;
  gap: 1rem;
  padding: 1rem;
  scroll-snap-type: x mandatory;
}

.scroll-container img {
  height: 500px;
  border-radius: 12px;
  scroll-snap-align: start;
  flex-shrink: 0;
  box-shadow: 0 2px 6px rgba(0,0,0,0.1);
}

.cta-btn {
  display: inline-block;
  margin-top: 1rem;
  padding: 0.6rem 1.2rem;
  background-color: #b03a48;
  color: white;
  border-radius: 8px;
  border: 1px solid #e5b1b1;
  text-decoration: none;
  font-weight: bold;
  font-family: 'Segoe UI', 'Geneva', Verdana, sans-serif;
  font-size: 1.1rem;
}
.cta-btn:hover {
  background-color: #9e3a43;
  border-color: rgb(26, 26, 26);
}

.features {
  display: flex;
  justify-content: center;
  gap: 2rem;
  margin-top: 2rem;
  font-family: 'Segoe UI', 'Geneva', Verdana, sans-serif;
  font-size: 1.1rem;
}

.feature {
  background-color: #ffc3c3;
  padding: 1rem;
  border-radius: 12px;
  font-weight: 600;
}
</style>