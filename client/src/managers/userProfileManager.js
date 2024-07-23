const _apiUrl = "/api/userprofile"

export const getAllUsersWithBasicInfo = async () => {
  return await fetch(`${_apiUrl}/basic`).then((res) => res.json())
}

export const getAllUsersWithRoles = async () => {
  return await fetch(`${_apiUrl}/withroles`).then((res) => res.json())
}

export const getUserById = async (id) => {
  return await fetch(`${_apiUrl}/${id}`).then((res) => res.json())
}

export const promoteUser = async (userId) => {
  return await fetch(`${_apiUrl}/promote/${userId}`, {
    method: "POST",
  })
}

export const demoteUser = async (userId) => {
  return await fetch(`${_apiUrl}/demote/${userId}`, {
    method: "POST",
  })
}

export const updateUserProfile = async (profile, userId) => {
  return await fetch(`${_apiUrl}/${userId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(profile),
  })
}
