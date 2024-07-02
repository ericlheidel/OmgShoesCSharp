const _apiUrl = "/api/like"

export const postLike = (like) => {
  return fetch(`${_apiUrl}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(like),
  })
}

export const removeLike = (userShoeId, userId) => {
  return fetch(`${_apiUrl}?userShoeId=${userShoeId}&userId=${userId}`, {
    method: "DELETE",
  })
}
