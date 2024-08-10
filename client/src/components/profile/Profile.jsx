/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./Profile.css"
import { Link, useParams } from "react-router-dom"
import { ShoeCollection } from "../shoes/ShoeCollection.jsx"
import { getUserShoeCollectionByUserId } from "../../managers/userShoeManager.js"
import { getUserById } from "../../managers/userProfileManager.js"
import { FriendButtons } from "../friends/FriendButtons.jsx"
import { getFriendsListByUserId } from "../../managers/friendshipManager.js"
import { Friend } from "../friends/Friend.jsx"
import { _DOMAIN } from "../../utility.jsx"

export const Profile = ({ loggedInUser }) => {
  const [user, setUser] = useState([])
  const [collection, setCollection] = useState([])
  const [friends, setFriends] = useState([])

  const { userId } = useParams()

  useEffect(() => {
    getUserShoeCollectionByUserId(userId).then(setCollection)
  }, [userId])

  useEffect(() => {
    if (loggedInUser) {
      getUserById(userId).then(setUser)
    }
  }, [loggedInUser, userId])

  const getAndSetFriends = () => {
    getFriendsListByUserId(parseInt(userId)).then(setFriends)
  }

  useEffect(() => {
    getAndSetFriends()
  }, [userId])

  return (
    <div className="profile">
      <div className="profile-div">
        <div className="profile-img-div">
          <img
            src={`${_DOMAIN}${user.avatar}`}
            alt="User Avatar"
            className="profile-img"
          />
        </div>
        <div className="user-name">{user.name}</div>
        <FriendButtons
          userId={userId}
          loggedInUser={loggedInUser}
          friends={friends}
          getAndSetFriends={getAndSetFriends}
        />
        {friends.length === 0 ? (
          ""
        ) : (
          <>
            <div className="friends-title">Friends</div>
            <div className="friends-list">
              {friends.map((friend) => {
                return (
                  <Friend
                    friend={friend}
                    loggedInUser={loggedInUser}
                    userId={parseInt(userId)}
                    key={friend.userId}
                  />
                )
              })}
            </div>
          </>
        )}
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
          {loggedInUser.id === parseInt(userId) && (
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
