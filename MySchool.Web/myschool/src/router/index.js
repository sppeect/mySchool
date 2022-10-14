/* eslint-disable */
import Vue from 'vue'
import VueRouter from 'vue-router'
import { store } from "@/store";
import login from "../modules/account/views/index"

const expired = (auth) => {
  let currentDate = moment(moment.utc(moment.utc().toDate()).toDate()).format();
  let expiresDate = moment(auth.expireIn, "DD/MM/YYYY HH:mm:ss").format();

  return moment(currentDate).isAfter(expiresDate);
};

const ifAuthenticated = (to, from, next) => {
  let auth = store.state.auth;

  if (auth) {
    if (expired(auth)) {
      auth = null;
      auth.isAuthenticated = false;
      localStorage.removeItem(process.env.VUE_APP_AUTH);

      next("/login");
      return;
    }

    if (auth.isAuthenticated) {
      next();

      return;
    }
  }

  next("/");
};

Vue.use(VueRouter)


const routes = [
  {
    path: '/',
    name: 'login',
    component: login
  },
  
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.VUE_APP_BASE_URL,
  routes
})

export default router
