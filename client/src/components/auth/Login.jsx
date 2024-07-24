/* eslint-disable react/prop-types */
import "./LoginAndRegister.css"
import { Link, useNavigate } from "react-router-dom"
import { useState } from "react"
import { login } from "../../managers/authManager.js"
import { UserSelect } from "./UserSelect.jsx"

export const Login = ({ setLoggedInUser }) => {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")

  const navigate = useNavigate()

  const handleSubmit = (e) => {
    e.preventDefault()
    login(email, password).then((user) => {
      if (!user) {
        window.alert("User does not exist")
      } else {
        setLoggedInUser(user)
        navigate("/")
      }
    })
  }

  return (
    <main>
      <section>
        <h2>
          Thank you for visiting OMG, Shoes...<br></br>If you are here to browse
          functionality,<br></br>please select an existing user.
          <br></br>
          <br></br>
          Feel free to register yourself below as well.<br></br>
        </h2>
        <UserSelect
          email={email}
          setEmail={setEmail}
          password={password}
          setPassword={setPassword}
        />
      </section>
      <section>
        <form className="login-form" onSubmit={handleSubmit}>
          <div className="text-div">
            <h1>OMG, Shoes...</h1>
            <h2>Please sign in</h2>
          </div>
          <fieldset>
            <div className="form-group">
              <label style={{ textAlign: "left" }}>
                Email:
                <input
                  type="email"
                  value={email}
                  required
                  autoFocus
                  className="form-control"
                  onChange={(e) => {
                    setEmail(e.target.value)
                  }}
                />
              </label>
            </div>
          </fieldset>
          <fieldset>
            <div className="form-group">
              <label style={{ textAlign: "left" }}>
                Password:
                <input
                  type="password"
                  value={password}
                  required
                  className="form-control"
                  onChange={(e) => {
                    setPassword(e.target.value)
                  }}
                />
              </label>
            </div>
          </fieldset>
          <fieldset>
            <div className="form-group">
              <button type="submit" className="btn-submit form-btn btn-login">
                Sign in
              </button>
            </div>
          </fieldset>
        </form>
      </section>
      <section className="register-link">
        <Link to="/register">Register as a New User</Link>
      </section>
    </main>
  )
}
