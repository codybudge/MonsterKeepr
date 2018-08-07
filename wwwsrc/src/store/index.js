import vue from 'vue'
import vuex from 'vuex'
import axios from 'axios'
import router from "../router"

var production = !window.location.host.includes('localhost');
var baseUrl = production ? '//monster-keepr.herokuapp.com/' : '//localhost:5000/';

let api = axios.create({
  baseURL: baseUrl + 'api',
  timeout: 3000,
  withCredentials: true
})

let auth = axios.create({
  baseURL: baseUrl + 'account/',
  timeout: 3000,
  withCredentials: true
})

vue.use(vuex)


export default new vuex.Store({
  state: {
    currentUser: {},
    keeps: [],
    vaults: [],
    currentKeep: {},
    activeVault: {},
    vaultKeeps: [],
    myKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.currentUser = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setKeep(state, keep) {
      state.currentKeep = keep
    },
    setMyKeeps(state, keeps) {
      state.myKeeps = keeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setActiveVault(state, vaultId) {
      state.activeVault = state.vaults.find(v => v.id == vaultId)
    },
    setVaultKeeps(state, keeps) {
      state.vaultKeeps = keeps
    }
  },
  actions: {
    //VaultKeep ---------------------------
    addToVault({},payload) {
      var newvk = {}
      newvk.keepId = payload.keep.id
      newvk.vaultId = payload.vault.id
      console.log(newvk)
      api.post('/vaultkeeps', newvk)
    },
    getVaultKeeps({ commit }, payload) {
      api.get('vaultkeeps/' + payload)
        .then(res => {
          commit("setVaultKeeps", res.data)
        })
    },
    //Vaults -----------------------------------
    addnewVault({ state }, newVault) {
      newVault.UserId = state.currentUser.id
      newVault.Username = state.currentUser.username
      api.get('/vault', newVault)
    },
    getVaults({ commit }) {
      api.get('/vault')
        .then(res => {
          commit('setVaults', res.data)
          console.log(res.data)
        })
    },
    setActiveVault({ commit }, vaultId) {
      commit('setActiveVault', vaultId)
    },
    //Keeps------------------------------------
    createKeep({ dispatch, state }, payload) {
      payload.userId = state.currentUser.id
      payload.Username = state.currentUser.username
      api.post('/keeps', payload)
        .then(res => {
          dispatch('getAllKeeps', res.data)
        })
    },
    addNewKeep({ state }, payload) {
      payload.UserId = state.currentUser.id
      payload.Username = state.currentUser.username
      api.post('/keeps', payload)
    },
    setKeep({ commit }, payload) {
      api.put('/keeps/' + payload.id, payload)
      commit('setKeep', payload)
    },
    getAllKeeps({ commit }) {
      api.get('/keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    //auth -----------------------------------
    login({ commit, dispatch }, payload) {
      auth.post('login', payload)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'Home' })
          dispatch('getVaults', res.data)
        })
        .catch(res => {
          console.log(res)
        })
    },
    logout({ state }) {
      auth.delete('/' + state.currentUser.id)
        .then(res => {
          console.log(res.data)
        })
    },
    register({ commit, dispatch }, payload) {
      console.log(payload)
      auth.post('/register/', payload)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'Home' })
          dispatch('getVaults', res.data)
        })
        .catch(res => {
          console.log(res.data)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('/athenticate/')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'Home' })
          dispatch('getVaults', res.data)
        })
    }



  }
})