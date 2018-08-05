import vue from 'vue'
import vuex from 'vuex'
import axios from 'axios'
import router from "../router"
import Vue from 'vue';

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
    setVaults(state, vaults)
    {
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
    //VaultKeeps ---------------------------
    addToVault(payload) {
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
    getVaults({commit}) {
      api.get('/vault')
      .then(res => {
        commit('setVaults', res.data)
        console.log(res.data)
      })
    },


  }
})