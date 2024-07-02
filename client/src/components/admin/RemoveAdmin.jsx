/* eslint-disable react/prop-types */
import { demoteUser } from "../../managers/userProfileManager.js"
import "../users/User.css"

export const RemoveAdmin = ({ user, getAndSetAllUsers }) => {
  const handleDemote = () => {
    demoteUser(user.id).then(getAndSetAllUsers)
  }

  return (
    <>
      <button className="admin-btn" onClick={handleDemote}>
        Remove Admin
      </button>
    </>
  )
}
