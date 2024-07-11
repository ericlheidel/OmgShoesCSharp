/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./Friends.css"
import {
  addFriendship,
  removeFriendship,
} from "../../managers/friendshipManager"
export const FriendButtons = ({
  userId,
  loggedInUser,
  friends,
  getAndSetFriends,
}) => {
  const [showButtons, setShowButtons] = useState(false)

  useEffect(() => {
    if (loggedInUser.id !== parseInt(userId)) {
      setShowButtons(true)
    } else {
      setShowButtons(false)
    }
  }, [loggedInUser.id, userId])

  const handleAddFriendship = () => {
    const newFriendship = {
      initiatorId: loggedInUser.id,
      recipientId: parseInt(userId),
    }

    addFriendship(newFriendship).then(getAndSetFriends)
  }

  const handleRemoveFriendship = () => {
    removeFriendship(loggedInUser.id, parseInt(userId)).then(getAndSetFriends)
  }

  return (
    <>
      {friends === null ? (
        "Loading..."
      ) : (
        <>
          {friends.some((f) => loggedInUser.id === f.userId) && showButtons && (
            <button
              className="remove-friend-btn"
              onClick={handleRemoveFriendship}
            >
              Remove Friend
            </button>
          )}
          {!friends.some((f) => loggedInUser.id === f.userId) &&
            showButtons && (
              <button className="add-friend-btn" onClick={handleAddFriendship}>
                Add Friend
              </button>
            )}
        </>
      )}
    </>
  )
}
