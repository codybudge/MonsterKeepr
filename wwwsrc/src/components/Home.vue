<template>
  <div class="container-fluid Home">
    <div class="nav justify-content-center">
    <h1>NavBar Here</h1>
      <Nav></Nav>
      <h1>Test Script</h1>
      <Keeps></Keeps>
      <Vault></Vault>
    </div>
  </div>
</template>

<script>

  import router from '../router'
  import Keeps from './Keeps'
  import Nav from './Nav'
  import ViewKeep from './ViewKeep'
  import Vault from './Vault'

  export default {
    name: 'Home',
    mounted() {
      if (!this.store.state.currenctUser.id) {
        router.push({ name: 'Login' })
      } else {
        this.$store.dispatch('getAllKeeps')
      }
    },
    components: {
      Nav,
      Keeps,
      ViewKeep,
      Vault
    },
    computed: {
      currenctUser() {
        return this.$store.state.currenctUser
      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  h1,
  h2 {
    font-weight: normal;
  }

  ul {
    list-style-type: none;
    padding: 0;
  }

  li {
    display: inline-block;
    margin: 0 10px;
  }

  a {
    color: #42b983;
  }
</style>