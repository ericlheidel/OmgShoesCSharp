/* eslint-disable react/prop-types */
import "./Friends.css"
import { Link } from "react-router-dom"

export const Friend = ({ friendship }) => {
  return (
    <div className="friend">
      <Link to={`/users/${friendship.recipient.id}`}>
        <img
          className="friend-avatar"
          src={`https://localhost:5212/${friendship.recipient.avatar}`}
          alt="friend avatar"
        />
      </Link>
    </div>
  )
}
