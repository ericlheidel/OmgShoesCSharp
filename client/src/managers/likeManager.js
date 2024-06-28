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

export const removeLikeById = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
  })
}
