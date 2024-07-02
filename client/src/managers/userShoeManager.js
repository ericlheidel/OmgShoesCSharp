const _apiUrl = "/api/usershoe"

export const getUserShoeCollectionByUserId = (userId) => {
  return fetch(`${_apiUrl}/collection/${userId}`).then((res) => res.json())
}

export const getUserShoeCollectionWithLikeByUserId = (userId) => {
  return fetch(`${_apiUrl}/${userId}/everything`).then((res) => res.json())
}

export const getUserShoeById = (userShoeId, userId) => {
  return fetch(`${_apiUrl}/${userShoeId}?userId=${userId}`).then((res) =>
    res.json()
  )
}

export const addShoeToUserCollection = (userShoe) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userShoe),
  })
}

export const deleteUserShoeFromCollection = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
  })
}

export const editUserShoe = (userShoe, userShoeId) => {
  return fetch(`${_apiUrl}/${userShoeId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userShoe),
  })
}
