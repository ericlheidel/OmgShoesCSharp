/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./ProfileForm.css"
import { useNavigate } from "react-router-dom"
import {
  getUserById,
  updateUserProfile,
} from "../../managers/userProfileManager.js"
import { states } from "../../utility.jsx"

export const ProfileForm = ({ loggedInUser }) => {
  const [user, setUser] = useState([])

  const navigate = useNavigate()

  useEffect(() => {
    getUserById(loggedInUser.id).then(setUser)
  }, [loggedInUser.id])

  const handleInputChange = (e) => {
    const userCopy = { ...user }
    userCopy[e.target.name] = e.target.value
    setUser(userCopy)
  }

  const handleSubmit = (e) => {
    e.preventDefault()

    const updatedProfile = {
      name: user.name,
      city: user.city,
      state: user.state,
      avatar: user.avatar,
      email: user.email,
      bio: user.bio,
    }

    updateUserProfile(updatedProfile, loggedInUser.id).then(
      navigate(`/users/${loggedInUser.id}`)
    )
  }
  return (
    <div className="profile-edit">
      <form className="edit-profile-form color-four" onSubmit={handleSubmit}>
        <h2>Edit Profile</h2>
        <fieldset>
          <div className="form-group">
            <label>
              Name:
              <input
                type="text"
                name="name"
                spellCheck={false}
                value={user.name ? user.name : ""}
                required
                autoFocus
                className="form-control"
                onChange={handleInputChange}
              />
            </label>
          </div>
        </fieldset>
        <div className="location-div flex">
          <fieldset>
            <div className="form-group">
              <label>
                City:
                <input
                  type="text"
                  name="city"
                  spellCheck={false}
                  value={user.city ? user.city : ""}
                  required
                  autoFocus
                  className="form-control city"
                  style={{ width: "70%" }}
                  onChange={handleInputChange}
                />
              </label>
            </div>
          </fieldset>
          <fieldset>
            <div className="form-group">
              <label>
                State:
                <select
                  name="state"
                  value={user.state ? user.state : ""}
                  required
                  autoFocus
                  className="form-control state-select state"
                  style={{ width: "35%" }}
                  onChange={handleInputChange}
                >
                  <option value={0} key={0}>
                    Select a state...
                  </option>
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
            <label>
              Avatar Url:
              <input
                type="text"
                name="avatar"
                spellCheck={false}
                value={user.avatar ? user.avatar : ""}
                required
                autoFocus
                className="form-control"
                onChange={handleInputChange}
              />
            </label>
          </div>
        </fieldset>
        <fieldset>
          <div className="form-group">
            <label>
              Email:
              <input
                type="text"
                name="email"
                spellCheck={false}
                value={user.email ? user.email : ""}
                required
                autoFocus
                className="form-control"
                onChange={handleInputChange}
              />
            </label>
          </div>
        </fieldset>
        <fieldset>
          <div className="form-group">
            <label>
              Bio:
              <input
                type="text"
                name="bio"
                value={user.bio ? user.bio : ""}
                required
                autoFocus
                className="form-control"
                onChange={handleInputChange}
              />
            </label>
          </div>
        </fieldset>
        <fieldset>
          <div className="form-group">
            <button type="submit" className="btn-submit edit-profile-btn">
              Save Profile
            </button>
          </div>
        </fieldset>
      </form>
    </div>
  )
}
