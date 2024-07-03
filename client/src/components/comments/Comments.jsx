/* eslint-disable react/prop-types */
import { useState } from "react"
import "./Comments.css"
import { Comment } from "./Comment.jsx"
import { postComment } from "../../managers/commentManager.js"
import { getUserShoeById } from "../../managers/userShoeManager.js"

export const Comments = ({ loggedInUser, userShoe, getAndSetShoe }) => {
  const [commentText, setCommentText] = useState("")

  const handleSubmit = () => {
    const newComment = {
      userProfileId: loggedInUser.id,
      userShoeId: userShoe.id,
      text: commentText,
    }

    postComment(newComment).then(() => {
      getUserShoeById(userShoe.id, loggedInUser.id).then(getAndSetShoe)
    })
  }

  return (
    <div className="comments">
      <h2 onClick={() => setCommentText("These are hard to find!")}>
        Comments
      </h2>
      <div className="new-comment-div">
        <textarea
          className="form-textarea comments-textarea"
          required
          value={commentText}
          onChange={(e) => {
            setCommentText(e.target.value)
          }}
        ></textarea>
      </div>
      <div className="comments-btn-div">
        <button
          className="form-btn comment-btn"
          onClick={() => {
            handleSubmit()
            setCommentText("")
          }}
        >
          Submit
        </button>
      </div>
      <div className="old-comments-div">
        <article className="old-comments">
          {userShoe.comments?.map((comment) => {
            return (
              <Comment
                loggedInUser={loggedInUser}
                comment={comment}
                userShoe={userShoe}
                getAndSetShoe={getAndSetShoe}
                key={comment.id}
              />
            )
          })}
        </article>
      </div>
    </div>
  )
}
