import { createRouter, createWebHistory } from 'vue-router'
import type { RouteRecordRaw } from 'vue-router'


const routes: RouteRecordRaw[] = [
  {
    path: '/doctors',
    name: 'Doctors',
    component: () => import('../pages/Doctors.vue')
  },
  {
    path: '/bookings',
    name: 'Bookings',
    component: () => import('../pages/Bookings.vue')
  },
  {
    path: '/',
    name: 'Home',
    component: () => import('../pages/Home.vue')
  },
  {
    path: '/login',
    name: 'Login',
    component: () => import('../pages/Login.vue')
  },
  {
    path: '/support',
    name: 'Support',
    component: () => import('../pages/Support.vue')
  },
  {
    path: '/book',
    name: 'BookAppointment',
    component: () => import('../pages/BookAppointment.vue')
  }
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

export default router
