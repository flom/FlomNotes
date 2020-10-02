<template>
  <router-link to="/">Home</router-link>
  <router-link to="/note">Notes</router-link>
  <router-link to="/about">About</router-link>

  <router-view></router-view>
</template>

<script>
  import { RouterLink } from 'vue-router';

  export default {
    name: 'App',
    components: {
      RouterLink
    }
  }
</script>

<style>
  #app {
  }
</style>
