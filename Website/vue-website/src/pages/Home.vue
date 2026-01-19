<template>
  <div class="home">
    <section class="hero">
      <h1>Your health, our priority</h1>
      <p>Book appointments with trusted professionals in just a few clicks.</p>
      <router-link to="/doctors" class="cta-button">Book Now</router-link>
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

.cta-button {
  display: inline-block; /* Makes it a box, not just text */
  background-color: #bd2121; /* Santa Elena Red */
  color: white;
  text-decoration: none; /* Removes the underline */
  padding: 0.8rem 2rem;
  border-radius: 8px;
  font-weight: bold;
  font-size: 1.1rem;
  margin-top: 2rem;
  transition: all 0.2s ease;
  cursor: pointer;
  box-shadow: 0 4px 6px rgba(189, 33, 33, 0.2);
  font-family: 'Segoe UI', 'Geneva', Verdana, sans-serif;
}

.cta-button:hover {
  background-color: #a11b1b; /* Darker red on hover */
  transform: translateY(-2px); /* Slight lift effect */
  box-shadow: 0 6px 12px rgba(189, 33, 33, 0.3);
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