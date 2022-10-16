import { Promise } from 'core-js'
import HTTP from '@/utils/http'
const api = new HTTP('auth')

const signIn = async ({ commit }, payload) => {
  return await api
    .post('token', payload)
    .then(async (resp) => {
      commit('AUTH_SUCCESS', resp.data)
      return Promise.resolve(resp)
    })
    .catch((err) => {
      return Promise.reject(err)
    })
}

const signOut = ({ commit }) => {
  commit('AUTH_LOGOUT')
}

export default { signIn, signOut }
