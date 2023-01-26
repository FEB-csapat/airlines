
<template>
  <nav-bar></nav-bar>
  <router-view></router-view>
</template>

<script>
import { RouterLink, RouterView } from 'vue-router';
import NavBar from '../components/layouts/NavBar.vue';

export default{
  components:{
    NavBar,
    RouterView
  }
}
</script>
