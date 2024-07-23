const _apiUrl = "/api/comment"

export const postComment = async (comment) => {
  return await fetch(_apiUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(comment),
  })
}

export const removeCommentById = async (id) => {
  return await fetch(`${_apiUrl}/${id}`, {
    method: "DELETE",
  })
}

export const updateComment = async (comment) => {
  return await fetch(`${_apiUrl}/${comment.id}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(comment),
  })
}
