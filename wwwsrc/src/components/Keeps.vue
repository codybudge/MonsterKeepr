<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col">
        <form @submit.prevent="createKeep">
          <h1>Create a Keep</h1>
          <input type="url" name="url" placeholder="Imge Url" v-model="newKeep.url">
          <input type="text" name="name" placeholder="Title" v-model="newKeep.name">
          <input type="text" name="description" placeholder="Description" id="description" v-model="newKeep.description">
          <button class="btn" type="submit">Submit</button>
        </form>
        <div v-for="keep in keeps">
            <div class="card" style="width: 18rem;">
                <h3 class="card-title">{{keep.name}}</h3>
                <img class="card-img-top" :src="keep.url" alt="Card image">
                <div class="card-body">
                  <p class="card-text">{{keep.description}}</p>
                  <p class="card-text">Views:{{keep.views}}</p>
                  <p class="card-text">Saves: {{keep.saves}}</p>
                  <button @click="makePrivate(keep)">
                    Make Private
                  </button>
                  <button @click="makePublic(keep)">
                    Make Public
                  </button>
                </div>
              </div>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
  export default {
    name: '',
    data() {
      return {

      }
    },
    computed: {},
    methods: {}
  }

</script>

<style>


</style>
