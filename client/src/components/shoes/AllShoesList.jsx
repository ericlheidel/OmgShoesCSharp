import "./AllShoesList.css"
import { useEffect, useState } from "react"
import { getShoesBySearch } from "../../managers/shoeManager.js"
import { ShoesFilterBar } from "./ShoesFilterBar.jsx"
import { Shoe } from "./Shoe.jsx"

export const AllShoesList = () => {
  const [queriedShoes, setQueriedShoes] = useState([])
  const [searchTerm, setSearchTerm] = useState("")
  const [filterYear, setFilterYear] = useState("")

  useEffect(() => {
    getShoesBySearch(searchTerm, filterYear).then(setQueriedShoes)
  }, [searchTerm, filterYear])

  return (
    <div className="shoes-container">
      <h2>All Shoes</h2>
      <ShoesFilterBar
        setFilterYear={setFilterYear}
        setSearchTerm={setSearchTerm}
      />
      <article className="shoes">
        {queriedShoes.map((shoe) => {
          return <Shoe shoe={shoe} key={shoe.id} />
        })}
      </article>
    </div>
  )
}
