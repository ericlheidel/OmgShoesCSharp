/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./User.css"
import { getUserShoeCollectionByUserId } from "../../managers/userShoeManager.js"
import { Link } from "react-router-dom"
import { MakeAdmin } from "../admin/MakeAdmin.jsx"
import { RemoveAdmin } from "../admin/RemoveAdmin.jsx"

export const User = ({ user, loggedInUser, getAndSetAllUsers }) => {
  const [collectionAmount, setCollectionAmount] = useState(0)

  useEffect(() => {
    getUserShoeCollectionByUserId(user.id).then((c) => {
      setCollectionAmount(c.length)
    })
  }, [user.id])

  return (
    <div className="user">
      <div className="user-img-div">
        <Link to={`/users/${user.id}`}>
          <img
            src={`https://localhost:5212/${user.avatar}`}
            alt="User"
            className="user-img"
          />
        </Link>
      </div>
      <div className="user-name">{user.name}</div>
      <div className="user-list-info-div">
        <div className="user-list-location">
          {user.city}, {user.state}
        </div>
        <div className="user-amount">
          Shoes in Collection: {collectionAmount}
        </div>
      </div>

      {/* if the loggedInUser is an ADMIN
      &&
      the user in the UsersList is NOT an ADMIN
      THEN
      the display the Make Admin Button*/}
      {loggedInUser.roles.includes("Admin") &&
        !user.roles.includes("Admin") && (
          <MakeAdmin user={user} getAndSetAllUsers={getAndSetAllUsers} />
        )}

      {/* if the loggedInUser is an ADMIN
      &&
      the loggedInUser is not the user in the UsersList
      &&
      the user in the UsersList is not an ADMIN 
      THEN
      Display the Remove Admin Button*/}
      {loggedInUser.roles.includes("Admin") &&
        loggedInUser.id !== user.id &&
        user.roles.includes("Admin") && (
          <RemoveAdmin user={user} getAndSetAllUsers={getAndSetAllUsers} />
        )}
    </div>
  )
}
