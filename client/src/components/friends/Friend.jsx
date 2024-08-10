/* eslint-disable react/prop-types */
import "./Friends.css"
import { Link } from "react-router-dom"
import { _DOMAIN } from "../../utility.jsx"

export const Friend = ({ friend }) => {
  return (
    <div className="friend">
      <Link to={`/users/${friend.userId}`}>
        <img
          className="friend-avatar"
          src={`${_DOMAIN}${friend.avatar}`}
          alt="friend avatar"
        />
      </Link>
    </div>
  )
}
