import actions from './actions'
import getters from './getters'
import mutations from './mutations'

const auth = JSON.parse(localStorage.getItem(process.env.VUE_APP_AUTH))

const state = {
  current: auth,
  isAuthenticated: auth && auth.isAuthenticated
}

export default {
  namespaced: true,
  state,
  actions,
  getters,
  mutations
}
