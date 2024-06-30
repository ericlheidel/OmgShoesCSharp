/* eslint-disable react/prop-types */
import "./LoginAndRegister.css"
import { Link, useNavigate } from "react-router-dom"
// import { getUserByEmail } from "../../services/usersService.jsx"
import { useState } from "react"
import { handleClick } from "../../utility.jsx"
import { login } from "../../managers/authManager.js"

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
        <form className="login-form color-four">
          <div className="text-div">
            <h1>
              <span onClick={() => setEmail("charlie@kelly.com")}>OMG,</span>
              <span onClick={() => setEmail("the@waitress.com")}> Shoes</span>
              <span onClick={() => setPassword("password")}>...</span>
            </h1>
            <h2>
              <span onClick={() => setEmail("dee@reynolds.com")}>Please</span>{" "}
              <span onClick={() => setEmail("dennis@reynolds.com")}>sign</span>{" "}
              <span onClick={() => setEmail("frank@reynolds.com")}>in</span>
            </h2>
          </div>
          <fieldset>
            <div className="form-group">
              <label>
                <span onClick={() => setEmail(handleClick)}>Email:</span>
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
              <label>
                <span onClick={() => setEmail(handleClick)}>Password:</span>
                <input
                  type="password"
                  value={password}
                  required
                  autoFocus
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
              <button
                type="submit"
                className="btn-submit form-btn btn-login"
                onClick={handleSubmit}
              >
                Sign in
              </button>
            </div>
          </fieldset>
        </form>
      </section>
      <section className="register-link">
        <Link to="/register">Not a member yet?</Link>
      </section>
    </main>
  )
}
