/* eslint-disable */
import Vue from 'vue'
import App from './App.vue'
import {BootstrapVue, BootstrapVueIcons } from 'bootstrap-vue'
import router from './router'
import store from './store'

Vue.config.productionTip = false

Vue.use(BootstrapVue)
Vue.use(BootstrapVueIcons)


import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import "./assets/styles/global.scss";

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
