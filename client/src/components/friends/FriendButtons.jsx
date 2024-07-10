/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./Friends.css"
export const FriendButtons = ({ userId, loggedInUser, friends }) => {
  const [showButtons, setShowButtons] = useState(false)

  useEffect(() => {
    if (loggedInUser.id !== parseInt(userId)) {
      setShowButtons(true)
    } else {
      setShowButtons(false)
    }
  }, [loggedInUser.id, userId])

  return (
    <>
      {friends === null ? (
        "Loading..."
      ) : (
        <>
          {friends.some((f) => loggedInUser.id === f.userId) && showButtons && (
            <button
              className="remove-friend-btn"
              onClick={() => console.log("Remove Friend Button")}
            >
              Remove Friend
            </button>
          )}
          {!friends.some((f) => loggedInUser.id === f.userId) &&
            showButtons && (
              <button
                className="add-friend-btn"
                onClick={() => console.log("Add Friend Button")}
              >
                Add Friend
              </button>
            )}
        </>
      )}
    </>
  )
}
