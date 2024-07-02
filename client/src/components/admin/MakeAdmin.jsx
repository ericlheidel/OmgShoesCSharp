/* eslint-disable react/prop-types */
import { promoteUser } from "../../managers/userProfileManager.js"
import "../users/User.css"

export const MakeAdmin = ({ user, getAndSetAllUsers }) => {
  const handlePromote = () => {
    promoteUser(user.id).then(getAndSetAllUsers)
  }

  return (
    <>
      <button className="admin-btn" onClick={handlePromote}>
        Make Admin
      </button>
    </>
  )
}
