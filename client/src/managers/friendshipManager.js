const _apiUrl = "/api/friendship"

export const getFriendsListByUserId = (userId) => {
  return fetch(`${_apiUrl}/${userId}`).then((res) => res.json())
}

export const getFriendships = () => {
  return fetch(`${_apiUrl}`).then((res) => res.json())
}

export const addFriendship = (friendship) => {
  return fetch(`${_apiUrl}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(friendship),
  }).then((res) => res.json())
}

export const removeFriendship = (idOne, idTwo) => {
  return fetch(`${_apiUrl}/${idOne}/${idTwo}`, {
    method: "DELETE",
  })
}
