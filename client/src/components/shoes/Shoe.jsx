/* eslint-disable react/prop-types */
import "./Shoe.css"
import { Link } from "react-router-dom"

export const Shoe = ({ shoe }) => {
  return (
    <div className="shoe">
      <Link to={`/shoes/${shoe.id}`}>
        <div className="shoe-img-div">
          <img
            src={`https://localhost:5212/${shoe.image}`}
            alt="shoe shown in detail"
            className="shoe-img"
          />
        </div>
        <div className="shoe-name">{shoe.name}</div>
      </Link>
    </div>
  )
}
