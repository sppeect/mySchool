import { Promise } from 'core-js'
import HTTP from '@/utils/http'
const api = new HTTP('home')

const createSchool = async ({ commit }, payload) => {
    return await api
      .post('school', payload)
      .then(async (resp) => {
        return Promise.resolve(resp)
      })
      .catch((err) => {
        return Promise.reject(err)
      })
  }

export default { createSchool}
