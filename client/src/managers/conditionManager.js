const _apiUrl = "/api/condition"

export const getAllConditions = () => {
  return fetch(_apiUrl).then((res) => res.json())
}
