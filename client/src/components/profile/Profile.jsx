/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./Profile.css"
import { Link, useParams } from "react-router-dom"
import { ShoeCollection } from "../shoes/ShoeCollection.jsx"
import { getUserShoeCollectionByUserId } from "../../managers/userShoeManager.js"
import { getUserById } from "../../managers/userProfileManager.js"

export const Profile = ({ loggedInUser }) => {
  const [user, setUser] = useState([])
  const [collection, setCollection] = useState([])

  const { userId } = useParams()

  useEffect(() => {
    getUserShoeCollectionByUserId(userId).then(setCollection)
  }, [userId])

  useEffect(() => {
    if (loggedInUser) {
      getUserById(userId).then(setUser)
    }
  }, [loggedInUser, userId])

  return (
    <div className="profile">
      <div className="profile-div">
        <div className="profile-img-div">
          <img
            src={`https://localhost:5212/${user.avatar}`}
            alt="User Avatar"
            className="profile-img"
          />
        </div>
        <div className="user-name">{user.name}</div>
        {/* <FriendButtons
          userId={userId}
          currentUser={currentUser}
          getAndSetUserFriends={getAndSetUserFriends}
        />
        {userFriends.length === 0 ? (
          ""
        ) : (
          <>
            <div className="friends-title">Friends</div>
            <div className="friends-list">
              {userFriends.map((friend) => {
                return <Friend friend={friend} key={friend.id} />
              })}
            </div>
          </>
        )} */}
        <div className="user-info-div">
          <div className="user-bio">{user.bio}</div>
        </div>
        <div className="user-info-div">
          <div className="user-location">
            {user.city}, {user.state}
          </div>
        </div>
        <div className="user-info-div">
          <div className="user-collection-amount">
            Shoes in Collection: {collection.length}
          </div>
        </div>
        <div className="edit-btn-div">
          {loggedInUser.id === userId && (
            <Link to={`/users/${userId}/edit`}>
              <button className="btn-edit btn-submit">Edit Profile</button>
            </Link>
          )}
        </div>
      </div>
      <div className="collection-div">
        <ShoeCollection
          userId={userId}
          loggedInUser={loggedInUser}
          collection={collection}
        />
      </div>
    </div>
  )
}
