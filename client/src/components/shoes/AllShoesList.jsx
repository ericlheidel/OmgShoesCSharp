import { useEffect, useState } from "react"
import "./AllShoesList.css"
import { getShoesBySearch } from "../../managers/shoeManager.js"

export const AllShoesList = () => {
  const [queriedShoes, setQueriedShoes] = useState([])

  useEffect(() => {
    getShoesBySearch("", "").then(setQueriedShoes)
  }, [])

  return <div>AllShoesList</div>
}
