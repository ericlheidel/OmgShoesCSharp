/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./Profile.css"
import { Link, useParams } from "react-router-dom"
import { ShoeCollection } from "../shoes/ShoeCollection.jsx"
import { getUserShoeCollectionByUserId } from "../../managers/userShoeManager.js"

export const Profile = ({ loggedInUser }) => {
  const [collection, setCollection] = useState([])

  const { userId } = useParams()

  useEffect(() => {
    getUserShoeCollectionByUserId(userId).then(setCollection)
  }, [])

  return (
    <div className="profile">
      <div className="profile-div">
        <div className="profile-img-div">
          <img
            src={`https://localhost:5212/${loggedInUser.avatar}`}
            alt="User Avatar"
            className="profile-img"
          />
        </div>
        <div className="user-name">{loggedInUser.name}</div>
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
          <div className="user-bio">{loggedInUser.bio}</div>
        </div>
        <div className="user-info-div">
          <div className="user-location">
            {loggedInUser.city}, {loggedInUser.state}
          </div>
        </div>
        <div className="user-info-div">
          <div className="user-collection-amount">
            {/* Shoes in Collection: {reducedCollectionArray.length} */}
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
        <div className="dropdown-div">
          {/* <select
            className="form-select profile-dropdown"
            onChange={(e) => {
              setChosenShoeValue(parseInt(e.target.value))
            }}
          >
            <option value={0} key={0}>
              All Shoes
            </option>
            {reducedCollectionArray.map((userShoe) => {
              return (
                <option value={userShoe.shoe.id} key={userShoe.shoe.id}>
                  {userShoe.shoe.name}
                </option>
              )
            })}
          </select> */}
        </div>
      </div>
      <div className="collection-div">
        <ShoeCollection
          userId={userId}
          loggedInUser={loggedInUser}
          // filteredShoes={filteredShoes}
          // getAndSetCollectionByUserId={getAndSetCollectionByUserId}
        />
      </div>
    </div>
  )
}
