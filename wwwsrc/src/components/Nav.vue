<template>
  <div class="Nav container-fluid">
    <nav class="navbar sticky-top navbar-light bg-light">
      <h2>Keepr</h2>
      <h3>Hello {{User.username}}</h3>
      <router-link :to="{name: 'Home'}">
        Home
      </router-link>
      <router-link :to="{name: 'ViewKeep'}">
        All Posts
      </router-link>
      <div v-if="User.id">
        <button class="btn" @click="logout">Logout</button>
      </div>
    </nav>
  </div>
</template>

<script>
  export default {
    name: 'Nav',
    data() {
      return {
      }
    },
    computed: {
      User() {
        return this.$store.state.currentUser
      }
    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      }
    }
  }

</script>

<style>
</style>