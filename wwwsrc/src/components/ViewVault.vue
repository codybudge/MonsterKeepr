<template>
  <div class="CreateVault container d-flex justify-content-center">
    <div class="row">
      <div class="col">
        <h1>{{activeVault.name}}</h1>
        <div v-for="ViewKeep in keeps" class="col">
          <div class="card" style="width: 18rem;">
            <h3 class="card-title">{{SeeKeep.name}}</h3>
            <img class="card-img-top" :src="SeeKeep.url" alt="Card image">
            <div class="card-body">
              <p class="card-text">{{SeeKeep.description}}</p>
              <p class="card-text">Views:{{SeeKeep.views}}</p>
              <p class="card-text">Saves: {{SeeKeep.saves}}</p>
              <a href="#" @click="setKeep(keep)">View Keep</a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import Nav from './Nav'
  export default {
    name: 'ViewVault',
    mounted() {
      this.$store.dispatch('setActiveVault', this.vaultId)
      this.$store.dispatch('getVaultKeeps', this.vaultId)
    },
    props: ['vaultId'],
    components: {
      Nav,
      getAllKeeps() {
        this.$store.dispatch('getVaultKeeps', this.vaultId)
      }
    },
    data() {
      return {
 
      }
    },
    computed: {
      activeVault() {
        return this.$store.state.activeVault
      },
      keeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {}
  }

</script>

<style>
</style>