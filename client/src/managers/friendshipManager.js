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
  return fetch(`${_apiUrl}?idOne=${idOne}&idTwo=${idTwo}`, {
    method: "DELETE",
  })
}

export const findFriendship = (loggedInUserId, nonLoggedInUserId) => {
  return fetch(
    `${_apiUrl}/isfriend?loggedInUserId=${loggedInUserId}&nonLoggedInUserId=${nonLoggedInUserId}`
  ).then((res) => res.json())
}
