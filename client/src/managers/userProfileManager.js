const _apiUrl = "/api/userprofile"

export const getAllUsers = () => {
  return fetch(_apiUrl).then((res) => res.json())
}

export const getAllUsersWithRoles = () => {
  return fetch(`${_apiUrl}/withroles`).then((res) => res.json())
}

export const getUserById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json())
}

export const getUserByIdWithRoles = (userId) => {
  return fetch(`${_apiUrl}/withroles/${userId}`).then((res) => res.json())
}
