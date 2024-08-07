const _apiUrl = "/api/auth"

export const login = async (email, password) => {
  return await fetch(`${_apiUrl}/login`, {
    method: "POST",
    credentials: "same-origin",
    headers: {
      Authorization: `Basic ${btoa(`${email}:${password}`)}`,
    },
  }).then((res) => {
    if (res.status !== 200) {
      return Promise.resolve(null)
    } else {
      return tryGetLoggedInUser()
    }
  })
}

export const logout = async () => {
  return await fetch(`${_apiUrl}/logout`)
}

export const tryGetLoggedInUser = async () => {
  return await fetch(`${_apiUrl}/me`).then((res) => {
    return res.status === 401 ? Promise.resolve(null) : res.json()
  })
}

export const register = async (userProfile) => {
  userProfile.password = btoa(userProfile.password)
  return await fetch(`${_apiUrl}/register`, {
    credentials: "same-origin",
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userProfile),
  }).then(() => tryGetLoggedInUser())
}
