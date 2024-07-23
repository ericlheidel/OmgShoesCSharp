const _apiUrl = "/api/shoe"

export const getShoeById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json())
}

export const createShoe = async (shoe) => {
  return await fetch(_apiUrl, {
    method: "POST",
    headers: {
      "content-Type": "application/json",
    },
    body: JSON.stringify(shoe),
  }).then((res) => res.json())
}

export const getShoesBySearch = (searchTerm, filterYear) => {
  return fetch(
    `${_apiUrl}/search?searchTerm=${searchTerm}&filterYear=${filterYear}`
  ).then((res) => res.json())
}

export const deleteShoe = (shoeId) => {
  return fetch(`${_apiUrl}/${shoeId}`, {
    method: "DELETE",
  })
}
