const _apiUrl = "/api/like"

export const postLike = async (like) => {
  return await fetch(`${_apiUrl}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(like),
  })
}

export const removeLike = async (userShoeId, userId) => {
  return await fetch(`${_apiUrl}?userShoeId=${userShoeId}&userId=${userId}`, {
    method: "DELETE",
  })
}
