/* eslint-disable react/prop-types */
import { Link } from "react-router-dom"

export const ProfileColumn = ({ loggedInUser }) => {
  return (
    <div className="profile">
      <div className="profile-div">
        <div className="profile-img-div">
          <Link to={`/users/${loggedInUser.id}`}>
            <img
              src={`https://localhost:5212/${loggedInUser.avatar}`}
              alt="User Avatar"
              className="profile-img"
            />
          </Link>
        </div>
        <div className="user-name">{loggedInUser.name}</div>
        <div className="user-info-div">
          <div className="user-bio">{loggedInUser.bio}</div>
        </div>
        <div className="user-info-div">
          <div className="user-location">
            {loggedInUser.city}, {loggedInUser.state}
          </div>
        </div>
      </div>
    </div>
  )
}
