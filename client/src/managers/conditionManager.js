const _apiUrl = "/api/condition"

export const getAllConditions = async () => {
  return await fetch(_apiUrl).then((res) => res.json())
}
