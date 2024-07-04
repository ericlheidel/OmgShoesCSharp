/* eslint-disable react/prop-types */
import "./Friends.css"
export const FriendButtons = ({ userId, loggedInUser, getAndSetFriends }) => {
  return (
    <>
      {parseInt(userId) === loggedInUser.id ? (
        ""
      ) : (
        <>
          {foundInitiator.length === 1 && foundRecipient.length === 1 && (
            <button className="remove-friend-btn" onClick={handleRemove}>
              Remove Friend
            </button>
          )}
          {foundInitiator.length === 0 && foundRecipient.length === 0 && (
            <button className="add-friend-btn" onClick={handleAdd}>
              Add Friend
            </button>
          )}
        </>
      )}
    </>
  )
}
