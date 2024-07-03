const _apiUrl = "/api/comment"

export const getCommentsByUserShoeId = (userShoeId) => {
  return fetch(`${_apiUrl}/${userShoeId}`).then((res) => res.json())
}

export const postComment = (comment) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(comment),
  })
}

export const removeCommentById = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
  })
}

export const updateComment = (comment) => {
  return fetch(`${_apiUrl}/${comment.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(comment),
  })
}
