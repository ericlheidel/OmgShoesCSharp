/* eslint-disable react/prop-types */
import "./LoginAndRegister.css"
import { /* Link,  */ useNavigate } from "react-router-dom"
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
          Thank you for visiting OMG, Shoes...<br></br>Please sign in as an one
          of the existing users!
          <br></br>
          <br></br>
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
        {/* <Link to="/register" disable>Register as a New User</Link> */}
      </section>
      <section>
        <h4 className="disclaimer">
          <p>
            Disclaimer: This project, including all images, characters, and
            content, is intended solely for educational and non-commercial
            purposes. The use of images and references to any existing products
            or pop culture references is intended as a parody and does not imply
            any endorsement or affiliation with the respective copyright
            holders. All trademarks, images, and characters referenced within
            this project are the property of their respective copyright holders.
            The use of such materials is protected under the principles of fair
            use and free speech. No copyright infringement is intended. Users of
            this project should be aware that the project owner does not claim
            ownership of any copyrighted materials referenced herein, and no
            profit is being made from the distribution or use of this project.
          </p>
        </h4>
      </section>
    </main>
  )
}
