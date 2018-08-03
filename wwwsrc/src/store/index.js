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
    vaultKeps: [],
    myKeeps: []
  },
  mutations: {

  },
  actions: {
    
  }
})