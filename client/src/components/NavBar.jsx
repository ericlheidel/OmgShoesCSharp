/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./NavBar.css"
import { Link } from "react-router-dom"
import { getUserById } from "../managers/userProfileManager.js"
import { logout } from "../managers/authManager.js"

export const NavBar = ({ loggedInUser, setLoggedInUser }) => {
  const [user, setUser] = useState([])

  useEffect(() => {
    if (loggedInUser.id) {
      getUserById(loggedInUser.id).then((userObj) => {
        setUser(userObj)
      })
    }
  }, [loggedInUser])

  return (
    <>
      <nav>
        <div className="navbar-placeholder">
          <ul className="navbar">
            <Link to={`/users/${loggedInUser.id}`}>
              <img
                className="navbar-user-img"
                src={user.avatar}
                alt="User avatar"
              />
            </Link>
            <li className="navbar-item">
              <Link to="/shoes">All Shoes</Link>
            </li>
            <li className="navbar-item">
              <Link to="/users">Users</Link>
            </li>
            {loggedInUser.roles.includes("Admin") && (
              <li className="navbar-item">
                <Link to={"/addshoe"}>Add Shoe to DB</Link>
              </li>
            )}
            <li className="navbar-item">
              <Link
                to=""
                onClick={(e) => {
                  e.preventDefault()
                  logout().then(() => {
                    setLoggedInUser(null)
                  })
                }}
              >
                Logout
              </Link>
            </li>
          </ul>
        </div>
      </nav>
    </>
  )
}
