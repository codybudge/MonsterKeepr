<template>
  <div class="create container-fluid d-flex justify-content-center">
    <div class="row">
      <div v-for="ViewKeep in Keeps" class="col">
        <div class="card" style="width: 18;">
          <h3 class="card-title">
            {{ViewKeep.name}}
          </h3>
          <img class="card-img-top" :src="ViewKeep.url" alt="Card imge">
          <div class="card-body">
            <p class="card-text">
              {{ViewKeep.description}}
            </p>
            <p class="card-text">
              Views: {{ViewKeep.views}}
            </p>
            <p class="card-text">
              Saves: {{ViewKeep.saves}}
            </p>
            <button @click="setKeep(ViewKeep)">
              View Keep
            </button>
          </div>
          <div v-for="vault in vaults">
            <button @click="addToVault(vault, ViewKeep)">
              Add to Vault: {{vault.name}}
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  import Nav from './Nav'
  export default {
    created() {
      this.$store.dispatch('getAllKeeps')
    },
    name: 'ViewKeep',

    components: {
      Nav,
      getAllKeeps() {
        this.$store.dispatch('getAllKeeps')
      }
    },
    data() {
      return {

      }
    },
    computed: {
      Keeps() {
        return this.$store.state.keeps
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      addToVault(vault, keep) {
        keep.views++
        this.$store.dispatch('setKeep', keep)
        this.$store.dispatch('addToVault', { vault, keep })
      },
      setKeep(keep) {
        keep.view++
        this.$store.dispatch('setKeep', keep)
        this.$router.push({ name: 'KeepDetails', params: { keepId: keep.id } })
      },
      addNewKeep() {
        this.$store.dispatch('addNewKeep', this.newKeep)
      },
      getVault() {
        this.$store.dispatch('getVault', this.vaultId)
      }
    }
  }

</script>

<style>
</style>