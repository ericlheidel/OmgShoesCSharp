/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./Friends.css"
import { getFriendships } from "../../managers/friendshipManager.js"
export const FriendButtons = ({ userId, loggedInUser, friends }) => {
  const [friendships, setFriendships] = useState([])

  useEffect(() => {
    getFriendships().then(setFriendships)
  }, [])

  return (
    <>
      {/* {friends.some((f) => f.userId === loggedInUser.id) ? (
        <button
          className="remove-friend-btn"
          onClick={() => console.log("Remove Friend Button")}
        >
          Remove Friend
        </button>
      ) : (
        <button
          className="add-friend-btn"
          onClick={() => console.log("Add Friend Button")}
        >
          Add Friend
        </button>
      )} */}

      {/* if the list of friends does NOT include the current loggedInUserId, the Add button should display */}

      {friendships.some((f) => f.userId !== loggedInUser.id) && (
        <button
          className="add-friend-btn"
          onClick={() => console.log("Add Friend Button")}
        >
          Add Friend
        </button>
      )}

      {/* if the list of friends DOES include the current loggedInUserId, the Remove button should appear */}

      {friendships.some((f) => f.userId === loggedInUser.id) && (
        <button
          className="remove-friend-btn"
          onClick={() => console.log("Remove Friend Button")}
        >
          Remove Friend
        </button>
      )}
    </>
  )
}
