/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import { Link } from "react-router-dom"
import { getUserById } from "../../managers/userProfileManager"

export const ProfileColumn = ({ userShoe }) => {
  const [user, setUser] = useState([])

  useEffect(() => {
    getUserById(userShoe.userProfileId).then(setUser)
  }, [userShoe])

  return (
    <div className="profile">
      <div className="profile-div">
        <div className="profile-img-div">
          <Link to={`/users/${userShoe.userProfileId}`}>
            <img
              src={`https://localhost:5212/${user.avatar}`}
              alt="User Avatar"
              className="profile-img"
            />
          </Link>
        </div>
        <div className="user-name">{user.name}</div>
        <div className="user-info-div">
          <div className="user-bio">{user.bio}</div>
        </div>
        <div className="user-info-div">
          <div className="user-location">
            {user.city}, {user.state}
          </div>
        </div>
      </div>
    </div>
  )
}
