import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/POS.vue'
import About from '../views/About.vue'

const routes = [
  {
    path: '/',
    name: 'POS',
    component: Home
  },
  {
    path: '/about',
    name: 'About',
    component: About
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
