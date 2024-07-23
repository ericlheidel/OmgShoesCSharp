const _apiUrl = "/api/usershoe"

export const getUserShoeCollectionByUserId = async (userId) => {
  return await fetch(`${_apiUrl}/collection/${userId}`).then((res) =>
    res.json()
  )
}

export const getUserShoeById = async (userShoeId, userId) => {
  return await fetch(`${_apiUrl}/${userShoeId}?userId=${userId}`).then((res) =>
    res.json()
  )
}

export const addShoeToUserCollection = async (userShoe) => {
  return await fetch(_apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userShoe),
  })
}

export const deleteUserShoeFromCollection = async (id) => {
  return await fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
  })
}

export const editUserShoe = async (userShoe, userShoeId) => {
  return await fetch(`${_apiUrl}/${userShoeId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userShoe),
  })
}
