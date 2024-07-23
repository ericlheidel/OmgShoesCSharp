/* eslint-disable react/prop-types */
import "./UsersList.css"
import { useEffect, useState } from "react"
import {
  getAllUsersWithBasicInfo,
  getAllUsersWithRoles,
} from "../../managers/userProfileManager.js"
import { User } from "./User.jsx"

export const UsersList = ({ loggedInUser }) => {
  const [allUsers, setAllUsers] = useState([])

  useEffect(() => {
    getAndSetAllUsers()
  }, [])

  const getAndSetAllUsers = () => {
    if (loggedInUser.roles.includes("Admin")) {
      getAllUsersWithRoles().then(setAllUsers)
    } else {
      getAllUsersWithBasicInfo().then(setAllUsers)
    }
  }

  return (
    <div className="users-container">
      <h2>All Users</h2>
      <article className="users">
        {allUsers.map((user) => {
          return (
            <User
              user={user}
              key={user.id}
              loggedInUser={loggedInUser}
              getAndSetAllUsers={getAndSetAllUsers}
            />
          )
        })}
      </article>
    </div>
  )
}
