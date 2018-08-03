import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import  Login from '@/components/Login'
import  Keeps from '@/components/Keeps'
import  ViewKeep from '@/components/ViewKeep'
import  Vault from '@/components/Vault'
import  ViewVault from '@/components/ViewVault'
import  KeepDetails from '@/components/KeepDetails'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/Home',
      name: 'Home',
      component: Home
    },{
      path: '/',
      name: 'Login',
      component: Login
    },{
      path: '/Keeps',
      name: 'Keeps',
      component: Keeps
    },{
      path: '/ViewKeep',
      name: 'ViewKeep',
      component: ViewKeep
    },{
      path: '/Vault',
      name: 'Vault',
      component: Vault
    },{
      path: '/ViewVault/:vaultId',
      name: 'ViewVault',
      props: true,
      component: ViewVault
    },{
      path: '/KeepDetails/:keepId',
      name: 'KeepDetails',
      props: true,
      component: KeepDetails
    },
  ]
})
