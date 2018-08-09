<template>
    <div class="card" style="width: 18rem;">
        <h3 class="card-title">{{keep.name}}</h3>
        <img class="card-img-top" :src="keep.url" alt="Card image">
        <div class="card-body">
          <p class="card-text">{{keep.description}}</p>
          <p class="card-text">Views:{{keep.views}}</p>
          <p class="card-text">Saves: {{keep.saves}}</p>
          <a href="#" @click="setKeep(keep)">View Keep</a>
        </div>
      </div>
</template>

<script>
  export default {
    name: 'KeepDetails',
    data() {
      return {

      }
    },
    computed: {
      keep () {
        return this.$store.state.currentKeep
      }
    },
    methods: {
      setKeep() {
        this.$store.dispatch('setKeep', keep)
      }
    }
  }

</script>

<style>


</style>
