import axios from 'axios'
// import qs from "qs";
import { store } from '@/store'
import router from '@/router'

class HTTP {
  constructor (url) {
    const instance = axios.create({
      baseURL: process.env.VUE_APP_SERVICE_URL,
      json: true
    })

    instance.interceptors.request.use(
      function (config) {
        store.commit('showLoading')
        const auth = store.state.auth
        if (auth.isAuthenticated) { config.headers.Authorization = `Bearer ${auth.current.token}` }
        return config
      },
      function (error) {
        return Promise.reject(error)
      }
    )

    instance.interceptors.response.use(
      function (response) {
        store.commit('hideLoading')
        return response
      },
      function (error) {
        store.commit('hideLoading')
        if (error.response) {
          if (error.response.status === 400) {
            store.commit('notifyError', error.response.data)
          } else if (error.response.status === 401) {
            store.dispatch('account/signOut').then(() => {
              router.push('/login')
            })
          } else if (error.response.status === 403) {
            store.dispatch('account/signOut').then(() => {
              router.push('/login')
            })
          } else if (error.response.status === 500) {
            store.commit('notifyError', {
              Errors: [
                {
                  Message:
                    'Ocorreu um erro no sistema, por favor, tente novamente mais tarde.'
                }
              ]
            })
          }
        }
        return Promise.reject(error)
      }
    )

    instance.url = url

    instance.getOne = function (id) {
      return this.get(this.url + `/${id}`)
    }

    instance.getAll = function () {
      return this.get(this.url)
    }

    instance.update = function (toUpdate, correlationId) {
      const url = this.url
      if (correlationId) {
        Object.assign(toUpdate, { CorrelationId: correlationId })
      }
      return this.put(url, toUpdate)
    }

    instance.create = function (toCreate) {
      return this.post(this.url, toCreate)
    }

    instance.remove = function (id) {
      return this.delete(this.url + `?correlationId=${id}`)
    }

    return instance
  }
}

export default HTTP
