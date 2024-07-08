/* eslint-disable react/prop-types */
import "./Friends.css"
import { Link } from "react-router-dom"

export const Friend = ({ friend }) => {
  return (
    <div className="friend">
      <Link to={`/users/${friend.userId}`}>
        <img
          className="friend-avatar"
          src={`https://localhost:5212/${friend.avatar}`}
          alt="friend avatar"
        />
      </Link>
    </div>
  )
}
