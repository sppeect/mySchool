/* eslint-disable */
import Vue from "vue";
import Vuex from "vuex";

import auth from "../modules/account/store";
Vue.use(Vuex);

export const store = new Vuex.Store({
  state: {
    isLoading: false,
  },
  
  modules: {
    auth: auth,
  },

  mutations: {
    authSuccess() {
      const hasToken = (model) => {
        if (model.token) {
          return true;
        }
        return false;
      };

      let isAuth = hasToken(auth.current);
      auth = Object.assign(auth, { isAuthenticated: isAuth });
      auth.isAuthenticated = isAuth;
      localStorage.setItem("auth", JSON.stringify(auth));
    },
    authLogout() {
      auth.current = null;
      auth.isAuthenticated = false;
      localStorage.removeItem("auth");
    },
  },
  actions: {
  },
});
