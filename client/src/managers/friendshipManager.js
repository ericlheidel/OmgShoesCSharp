const _apiUrl = "/api/friendship"

export const getFriendshipsByUserId = (userId) => {
  return fetch(`${_apiUrl}/${userId}`).then((res) => res.json())
}

export const postFriendship = (friendship) => {
  return fetch(`${_apiUrl}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(friendship),
  }).then((res) => res.json())
}

export const removeFriendshipById = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
  })
}
