/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./ProfileForm.css"
import { useNavigate, useParams } from "react-router-dom"
import {
  getUserById,
  updateUserProfile,
} from "../../managers/userProfileManager.js"
import { states } from "../../utility.jsx"

export const ProfileForm = ({ loggedInUser }) => {
  const [name, setName] = useState(loggedInUser.name)
  const [city, setCity] = useState(loggedInUser.city)
  const [state, setState] = useState(loggedInUser.state)
  const [avatar, setAvatar] = useState(loggedInUser.avatar)
  const [email, setEmail] = useState(loggedInUser.email)
  const [bio, setBio] = useState(loggedInUser.bio)

  const navigate = useNavigate()

  const handleSubmit = (e) => {
    e.preventDefault()

    const updatedProfile = {
      name,
      city,
      state,
      avatar,
      email,
      bio,
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
                value={name}
                required
                autoFocus
                className="form-control"
                onChange={(e) => {
                  setName(e.target.value)
                }}
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
                  value={city}
                  required
                  autoFocus
                  className="form-control city"
                  style={{ width: "70%" }}
                  onChange={(e) => {
                    setCity(e.target.value)
                  }}
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
                  value={state}
                  required
                  autoFocus
                  className="form-control state-select state"
                  style={{ width: "35%" }}
                  onChange={(e) => {
                    setState(e.target.value)
                  }}
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
                value={avatar}
                required
                autoFocus
                className="form-control"
                onChange={() => {}}
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
                value={email}
                required
                autoFocus
                className="form-control"
                onChange={() => {}}
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
                value={bio}
                required
                autoFocus
                className="form-control"
                onChange={(e) => {
                  setBio(e.target.value)
                }}
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
