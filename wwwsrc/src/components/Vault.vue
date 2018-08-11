<template>
  <div class="vaults container-fluid">
    <div class="row">
      <div class="col">
        <div v-if="!currentUser.id">
          <form @submit.prevent="addNewVault">
            <input type="text" placeholder="Title" v-model="newVault.name">
            <input type="text" placeholder="Description" v-model="newVault.description">
            <button class="btn" type="submit">
              Submit
            </button>
          </form>
          <div v-for="vault in vaults">
            <div class="card" style="width: 18rem;">
              <h3 class="card-title">{{vault.name}}</h3>
              <div class="card-body">
                <p class="card-text">{{vault.description}}</p>
                <router-link :to="{name: 'ViewVault', params: {vaultId: vault.id}}">
                  Go to Vault
                </router-link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import Nav from './Nacv'
  export default {
    name: 'Vault',
    data() {
      return {
        newVaut: {
          Description: ''
        }
      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      },
      currentUser() {
        return thus.$store.satate.currentUser
      }
    },
    methods: {
      addNewVault() {
        this.$store.dispatch('addNewVault', this.newVault)
      },
      setVault() {
        this.$store.dispatch('setVault', vault)
      }
    }
  }

</script>

<style>
</style>