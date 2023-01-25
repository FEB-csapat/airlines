import { createRouter, createWebHistory } from 'vue-router';
import IndexView from "@/views/IndexView.vue";
import CartView from "@/views/CartView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      name:'Index',
      path:'/',
      component: IndexView
    },
    {
      name:'Cart',
      path:'/cart',
      component: CartView
    }
  ]

})

export default router
