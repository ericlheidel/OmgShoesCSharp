const _apiUrl = "/api/userprofile"

export const getAllUsers = () => {
  return fetch(_apiUrl).then((res) => res.json())
}

export const getAllUsersWithBasicInfo = () => {
  return fetch(`${_apiUrl}/basic`).then((res) => res.json())
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

export const promoteUser = (userId) => {
  return fetch(`${_apiUrl}/promote/${userId}`, {
    method: "POST",
  })
}

export const demoteUser = (userId) => {
  return fetch(`${_apiUrl}/demote/${userId}`, {
    method: "POST",
  })
}

export const updateUserProfile = (profile, userId) => {
  return fetch(`${_apiUrl}/${userId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(profile),
  })
}
