/* eslint-disable react/prop-types */
import { useEffect, useState } from "react"
import "./Comments.css"
import { formatDate } from "../../utility.jsx"
import { updateComment } from "../../managers/commentManager.js"
import { getUserShoeById } from "../../managers/userShoeManager"

export const Comment = ({ loggedInUser, comment, getAndSetShoe }) => {
  const [isHidden, setIsHidden] = useState(false)
  const [originalCommentText, setOriginalCommentText] = useState("")
  const [updatedCommentText, setUpdatedCommentText] = useState(comment.text)

  useEffect(() => {
    setOriginalCommentText(comment.text)
  }, [comment])

  const handleUpdate = () => {
    const updatedComment = {
      id: comment.id,
      userProfileId: comment.userProfileId,
      userShoeId: comment.userShoeId,
      text: updatedCommentText,
    }

    updateComment(updatedComment).then(() => {
      getUserShoeById(comment.userShoeId, comment.userProfileId).then(
        getAndSetShoe
      )
    })
  }

  const handleDelete = () => {
    console.log("handleDelete()")
  }

  return (
    <div className="flex col">
      <div className="comment" hidden={isHidden}>
        {comment.text}
      </div>
      <textarea
        className="comment"
        hidden={!isHidden}
        value={updatedCommentText}
        onChange={(e) => {
          setUpdatedCommentText(e.target.value)
        }}
      >
        {comment.text}
      </textarea>
      <div className="commenter flex row">
        <img
          className="commenter-img"
          src={`https://localhost:5212/${comment.user.avatar}`}
          alt="commenter"
        ></img>
        <div className="commenter-name">{comment.user.name}</div>
      </div>
      <div className="comment-btn-div flex">
        <div className="comment-timestamp">
          <i>
            <b>{comment.isEdited && "edited:"}</b>
          </i>{" "}
          {formatDate(comment.timeStamp)}
        </div>
        {loggedInUser.id === comment.userProfileId && (
          <>
            <button
              className="form-btn cancel-btn"
              hidden={!isHidden}
              onClick={() => {
                setIsHidden(false)
                setUpdatedCommentText(originalCommentText)
              }}
            >
              X
            </button>
            <button
              className="form-btn submit-comment-btn"
              hidden={!isHidden}
              onClick={() => {
                handleUpdate()
                setIsHidden(false)
              }}
            >
              Submit
            </button>
            <button
              className="form-btn edit-comment-btn"
              hidden={isHidden}
              onClick={() => setIsHidden(true)}
            >
              Edit
            </button>
            <button
              className="form-btn delete-comment-btn"
              onClick={handleDelete}
            >
              Delete
            </button>
          </>
        )}
      </div>
    </div>
  )
}
