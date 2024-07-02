/* eslint-disable react/prop-types */
import { postLike, removeLike } from "../../managers/likeManager.js"
import { getUserShoeById } from "../../managers/userShoeManager.js"
import "./LikesDiv.css"

export const LikesDiv = ({ loggedInUser, userShoe, getAndSetShoe }) => {
  const addLike = () => {
    if (!userShoe.isLikedByCurrentUser) {
      const newLike = {
        userProfileId: loggedInUser.id,
        userShoeId: userShoe.id,
      }

      postLike(newLike).then(() => {
        getUserShoeById(userShoe.id, loggedInUser.id).then(getAndSetShoe)
      })
    }
  }

  const deleteLike = () => {
    if (userShoe.isLikedByCurrentUser) {
      removeLike(userShoe.id, loggedInUser.id).then(() => {
        getUserShoeById(userShoe.id, loggedInUser.id).then(getAndSetShoe)
      })
    }
  }

  return (
    <div className="likes-div flex">
      {userShoe.isLikedByCurrentUser ? (
        <button className="like-btn" onClick={deleteLike}>
          <i className="fa-solid fa-thumbs-down"></i>
        </button>
      ) : (
        <button className="like-btn" onClick={addLike}>
          <i className="fa-solid fa-thumbs-up"></i>
        </button>
      )}
      {/* {userShoe.likes?.find((like) => loggedInUser.id === like.userId) ? (
        <button className="like-btn" onClick={removeLike}>
          <i className="fa-solid fa-thumbs-down"></i>
        </button>
      ) : (
        <button className="like-btn" onClick={addLike}>
          <i className="fa-solid fa-thumbs-up"></i>
        </button>
      )} */}
      <div className="shoe-detail-one likes">
        {/* {userShoe.likes?.length ? userShoe.likes?.length : "0"} */}
        {userShoe.likes?.length}
      </div>
    </div>
  )
}
