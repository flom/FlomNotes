<template>
  <div class="grid-x">
    <div class="cell small-2">
      <ul class="vertical menu">
        <li><a href="#"><i class="far fa-calendar-alt"></i> Daily</a></li>
        <li><a href="#"><i class="fas fa-list"></i> All Pages</a></li>
      </ul>
      <hr>
      <h4><i class="fas fa-star"></i>Shortcuts</h4>
      <ul class="vertical menu">
        <li><a href="#">Daily</a></li>
        <li><a href="#">All Pages</a></li>
      </ul>
    </div>

    <div class="cell auto">
      <div class="grid-x">
        <div class="cell">
          <div class="top-bar">
            <div class="top-bar-left">
              <ul class="dropdown menu" data-dropdown-menu>
                <li class="menu-text">FlomNotes</li>
                <li><router-link to="/">Home</router-link></li>
                <li><router-link to="/note">Notes</router-link></li>
                <li><router-link to="/about">About</router-link></li>
              </ul>
            </div>
            <div class="top-bar-right">
              <ul class="menu">
                <li><input type="search" placeholder="Search"></li>
                <li><button type="button" class="button">Search</button></li>
              </ul>
            </div>
          </div>

        </div>
        <div class="cell small-offset-2">
          <router-view></router-view>
        </div>
      </div>
    </div>
  </div>

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
