/* eslint-disable */
import Vue from 'vue';
import VueRouter from 'vue-router';
import { store } from "@/store";
import login from "../modules/account/views/index";
import home from "../modules/home/views/index";

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
      next("/success");
      console.log("Success");

      return;
    }
  }

  next("/");
};

Vue.use(VueRouter)


const routes = [
  {
    path:"/success",
    redirect:"/home"
  },

  {
    path: '/',
    name: 'login',
    component: login
  },
  {
    path: '/home',
    name: 'home',
    component: home
  },


  
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.VUE_APP_BASE_URL,
  routes
})

export default router
