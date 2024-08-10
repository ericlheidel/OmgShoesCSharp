/* eslint-disable react/prop-types */
import "./Shoe.css"
import { Link } from "react-router-dom"
import { _DOMAIN } from "../../utility.jsx"

export const Shoe = ({ shoe }) => {
  return (
    <div className="shoe">
      <Link to={`/shoes/${shoe.id}`}>
        <div className="shoe-img-div">
          <img
            src={`${_DOMAIN}${shoe.image}`}
            alt="shoe shown in detail"
            className="shoe-img"
          />
        </div>
        <div className="shoe-name">{shoe.name}</div>
      </Link>
    </div>
  )
}
