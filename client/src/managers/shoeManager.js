const _apiUrl = "/api/shoe"

export const getAllShoes = () => {
  return fetch(_apiUrl).then((res) => res.json())
}

export const getShoeById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json())
}

export const createShoe = (shoe) => {
  return fetch(_apiUrl, {
    method: "POST",
    headers: {
      "content-Type": "application/json",
    },
    body: JSON.stringify(shoe),
  })
}

export const getShoesBySearch = (searchTerm, filterYear) => {
  return fetch(
    `${_apiUrl}/search?searchTerm=${searchTerm}&filterYear=${filterYear}`
  ).then((res) => res.json())
}
