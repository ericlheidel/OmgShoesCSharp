/* eslint-disable react/prop-types */
import "./NavBar.css"
import { Link, useNavigate } from "react-router-dom"
import { logout } from "../managers/authManager.js"
import { _DOMAIN } from "../utility.jsx"

export const NavBar = ({ loggedInUser, setLoggedInUser }) => {
  const navigate = useNavigate()

  return (
    <>
      {loggedInUser ? (
        <nav>
          <div className="navbar-placeholder">
            <ul className="navbar">
              <Link to={`/users/${loggedInUser.id}`}>
                <img
                  className="navbar-user-img"
                  src={`${_DOMAIN}${loggedInUser.avatar}`}
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
                      navigate("/login")
                    })
                  }}
                >
                  Logout
                </Link>
              </li>
            </ul>
          </div>
        </nav>
      ) : (
        ""
      )}
    </>
  )
}
