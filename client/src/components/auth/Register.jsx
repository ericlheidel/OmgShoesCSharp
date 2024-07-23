/* eslint-disable react/prop-types */
import "./LoginAndRegister.css"
import { useState } from "react"
import { useNavigate } from "react-router-dom"
import { register } from "../../managers/authManager.js"
import { states } from "../../utility.jsx"

export const Register = ({ setLoggedInUser }) => {
  const [email, setEmail] = useState("")
  const [name, setName] = useState("")
  const [city, setCity] = useState("")
  const [state, setState] = useState("")
  const [avatar, setAvatar] = useState("/avatars/default.jpg")
  const [bio, setBio] = useState("")
  const [password, setPassword] = useState("")

  const [confirmPassword, setConfirmPassword] = useState("")

  const [userName, setUserName] = useState("")

  const navigate = useNavigate()

  const handleSubmit = (e) => {
    e.preventDefault()

    if (password !== confirmPassword) {
      window.alert("Passwords don't match")
    } else {
      const newUser = {
        email,
        name,
        city,
        state,
        avatar,
        bio,
        password,
        userName,
      }
      register(newUser).then((user) => {
        if (user) {
          setLoggedInUser(user)
          navigate("/")
        } else {
          window.alert("Registration failed")
        }
      })
    }
  }

  return (
    <main>
      <div>
        <form className="register-form color-four" onSubmit={handleSubmit}>
          <div className="text-div">
            <h1>OMG, Shoes...</h1>
            <h2>Please Register</h2>
          </div>
          <div className="name-div">
            <fieldset>
              <div className="form-group">
                <label style={{ textAlign: "left" }}>
                  Full Name:
                  <input
                    type="text"
                    id="name"
                    value={name}
                    required
                    autoFocus
                    spellCheck={false}
                    className="form-control"
                    onChange={(e) => {
                      setName(e.target.value)
                      setUserName(name.split(" ")[0])
                    }}
                  />
                </label>
              </div>
            </fieldset>
          </div>
          <div className="location-div flex">
            <fieldset>
              <div className="form-group">
                <label style={{ textAlign: "left" }}>
                  City:
                  <input
                    type="text"
                    id="city"
                    value={city}
                    required
                    autoFocus
                    spellCheck={false}
                    className="form-control city"
                    style={{ width: "90%" }}
                    onChange={(e) => {
                      setCity(e.target.value)
                    }}
                  />
                </label>
              </div>
            </fieldset>
            <fieldset>
              <div className="form-group">
                <label style={{ textAlign: "left" }}>
                  State:
                  <select
                    id="state"
                    value={state}
                    required
                    spellCheck={false}
                    className="state-dropdown form-select state-two"
                    style={{ width: "85%", height: "70%", fontSize: "1.25rem" }}
                    onChange={(e) => {
                      setState(e.target.value)
                    }}
                  >
                    <option value={0} key={0}></option>
                    {states.map((state) => {
                      return (
                        <option value={state.state} key={state.id}>
                          {state.state}
                        </option>
                      )
                    })}
                  </select>
                </label>
              </div>
            </fieldset>
          </div>
          <fieldset>
            <div className="form-group">
              <label style={{ textAlign: "left" }}>
                Avatar Url:
                <input
                  type="text"
                  id="avatar"
                  value={avatar}
                  disabled
                  autoFocus
                  spellCheck={false}
                  className="form-control"
                  onChange={(e) => {
                    setAvatar(e.target.value)
                  }}
                />
              </label>
            </div>
          </fieldset>
          <fieldset>
            <div className="form-group">
              <label style={{ textAlign: "left" }}>
                Email:
                <input
                  type="email"
                  id="email"
                  value={email}
                  required
                  autoFocus
                  spellCheck={false}
                  className="form-control"
                  onChange={(e) => setEmail(e.target.value)}
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
                  id="password"
                  value={password}
                  required
                  autoFocus
                  spellCheck={false}
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
              <label style={{ textAlign: "left" }}>
                Confirm Password:
                <input
                  type="password"
                  id="password"
                  value={confirmPassword}
                  required
                  autoFocus
                  spellCheck={false}
                  className="form-control"
                  onChange={(e) => {
                    setConfirmPassword(e.target.value)
                  }}
                />
              </label>
            </div>
          </fieldset>
          <fieldset>
            <div className="form-group">
              <label style={{ textAlign: "left" }}>
                Bio:
                <input
                  type="text"
                  id="bio"
                  value={bio}
                  required
                  autoFocus
                  className="form-control"
                  onChange={(e) => setBio(e.target.value)}
                />
              </label>
            </div>
          </fieldset>
          <fieldset>
            <div className="form-group">
              <button
                type="submit"
                className="btn-submit form-btn"
                onClick={handleSubmit}
              >
                Register
              </button>
            </div>
          </fieldset>
        </form>
      </div>
    </main>
  )
}
