const _apiUrl = "/api/friendship"

export const getFriendsListByUserId = async (userId) => {
  return await fetch(`${_apiUrl}/${userId}`).then((res) => res.json())
}

export const addFriendship = async (friendship) => {
  return await fetch(`${_apiUrl}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(friendship),
  }).then((res) => res.json())
}

export const removeFriendship = async (idOne, idTwo) => {
  return await fetch(`${_apiUrl}/${idOne}/${idTwo}`, {
    method: "DELETE",
  })
}
