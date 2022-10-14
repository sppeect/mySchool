
const hasToken = (model) => {
  if (model.token) {
    return true
  }
  return false
}

const AUTH_SUCCESS = (state, model) => {
  console.log('AUTH_SUCCESS')
  const isAuth = hasToken(model)
  model = Object.assign(model, { isAuthenticated: isAuth })
  state.current = model
  state.isAuthenticated = isAuth
  localStorage.setItem(process.env.VUE_APP_AUTH, JSON.stringify(model))
}

const AUTH_LOGOUT = (state) => {
  console.log('AUTH_LOGOUT')
  state.current = null
  state.isAuthenticated = false
  localStorage.removeItem(process.env.VUE_APP_AUTH)
}

export default {
  AUTH_SUCCESS,
  AUTH_LOGOUT
}
