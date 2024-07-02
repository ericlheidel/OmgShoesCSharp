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
    // if (loggedInUser.roles.includes("Admin")) {
    //   getAllUsersWithRoles().then(setAllUsers)
    // } else {
    //   getAllUsersWithBasicInfo().then(setAllUsers)
    // }
    getAndSetAllUsers()
    // eslint-disable-next-line react-hooks/exhaustive-deps
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
      {/* <UsersFilterBar setSearchTerm={setSearchTerm} /> */}
      <article className="users">
        {allUsers.map((user) => {
          return (
            <User
              user={user}
              key={user.id}
              loggedInUser={loggedInUser}
              getAndSetAllUsers={getAndSetAllUsers}
              // setSortedUsers={setSortedUsers}
            />
          )
        })}
      </article>
    </div>
  )
}
