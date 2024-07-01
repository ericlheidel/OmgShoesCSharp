/* eslint-disable react/prop-types */
import { useNavigate, useParams } from "react-router-dom"
import "./ShoeDetails.css"
import { useEffect, useState } from "react"
import { getAllConditions } from "../../managers/conditionManager.js"
import {
  deleteUserShoeFromCollection,
  editUserShoe,
  getUserShoeById,
} from "../../managers/userShoeManager.js"
import { ProfileColumn } from "../profile/ProfileColumn.jsx"

export const UserShoeDetails = ({ loggedInUser }) => {
  const [userShoe, setUserShoe] = useState([])
  const [conditions, setConditions] = useState([])
  const [editedCondition, setEditedCondition] = useState(0)
  const [editedDescription, setEditedDescription] = useState("")
  const [isChecked, setIsChecked] = useState(false)
  const [isHidden, setIsHidden] = useState(false)
  // const [userShoeComments, setUserShoeComments] = useState([])

  const { userShoeId } = useParams()

  const navigate = useNavigate()

  const getAndSetShoe = () => {
    getUserShoeById(userShoeId).then(setUserShoe)
  }

  useEffect(() => {
    getAndSetShoe()
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  useEffect(() => {
    getAllConditions().then(setConditions)
  }, [])

  useEffect(() => {
    setEditedCondition(userShoe.conditionId)
  }, [userShoe])

  useEffect(() => {
    setEditedDescription(userShoe.description)
  }, [userShoe])

  const handleSave = (e) => {
    e.preventDefault()

    const editedUserShoe = {
      userProfileId: loggedInUser.id,
      shoeId: userShoe.shoeId,
      shoeSize: userShoe.shoeSize,
      conditionId: editedCondition,
      description: editedDescription,
    }

    editUserShoe(editedUserShoe, userShoeId).then(() => {
      getAndSetShoe()
      setIsHidden(false)
    })
  }

  const handleDeleteShoe = () => {
    deleteUserShoeFromCollection(userShoeId).then(() => {
      navigate(`/users/${loggedInUser.id}`)
    })
  }

  let count = 1
  return (
    <>
      <div className="details">
        <ProfileColumn userShoe={userShoe} loggedInUser={loggedInUser} />
        <div className="inner-details-div">
          {loggedInUser.id === userShoe.userProfileId ? (
            <div className="shoe-details-container">
              <div className="shoe-details-div">
                <div className="shoe-details">
                  <img
                    src={`https://localhost:5212/${userShoe.shoe?.image}`}
                    alt="detailed view of shoe class"
                    className="shoe-details-img"
                  />
                  <div className="shoe-detail-one">{userShoe.shoe?.name}</div>
                  <div className="shoe-detail-two">
                    Style: {userShoe.shoe?.style}
                  </div>
                  <div className="shoe-detail-two">{userShoe.shoe?.year}</div>
                  <div className="shoe-detail-two">
                    {userShoe.shoe?.modelNumber}
                  </div>
                  <div className="shoe-detail-two">
                    {userShoe.shoe?.colorway}
                  </div>
                  <div className="shoe-detail-two" hidden={isHidden}>
                    <div className="color-one">
                      <div className="shoe-detail-two">Condition:</div>
                      {userShoe.condition?.description}
                    </div>
                  </div>
                  <div className="shoe-detail-two" hidden={isHidden}>
                    <div className="color-one">
                      <div className="shoe-detail-two">Description:</div>
                      {userShoe?.description}
                    </div>
                  </div>
                  <button
                    className="form-btn btn-toggle"
                    hidden={isHidden}
                    onClick={() => {
                      setIsChecked(true)
                      setIsHidden(true)
                    }}
                  >
                    Edit Shoe
                  </button>
                  <button
                    className="form-btn btn-toggle"
                    hidden={!isHidden}
                    onClick={() => {
                      setIsChecked(false)
                      setIsHidden(false)
                    }}
                  >
                    Back
                  </button>
                  <button
                    className="form-btn btn-toggle"
                    hidden={!isHidden}
                    onClick={() => {
                      // removeComments()
                      handleDeleteShoe()
                    }}
                  >
                    Remove Shoe
                  </button>
                  <div className="edit-shoe-div" hidden={!isHidden}>
                    <form className="edit-shoe-form">
                      <fieldset>
                        <label className="edit-label-one">
                          Edit Condition
                          <br />
                          <select
                            value={editedCondition}
                            name="condition"
                            required
                            hidden={!isChecked}
                            className="form-select edit-select"
                            onChange={(e) =>
                              setEditedCondition(parseInt(e.target.value))
                            }
                          >
                            {conditions.map((condition) => {
                              return (
                                <option value={condition.id} key={condition.id}>
                                  {condition.description}
                                </option>
                              )
                            })}
                          </select>
                        </label>
                      </fieldset>
                      <fieldset>
                        <label className="edit-label-two">
                          Edit Description:
                          <textarea
                            value={editedDescription}
                            name="description"
                            required
                            className="form-textarea"
                            onChange={(e) =>
                              setEditedDescription(e.target.value)
                            }
                          ></textarea>
                        </label>
                      </fieldset>
                      <fieldset>
                        <div className="save-btn-div">
                          <button
                            type="submit"
                            className="save-btn form-btn"
                            onClick={handleSave}
                          >
                            Save Shoe
                          </button>
                        </div>
                      </fieldset>
                    </form>
                  </div>
                </div>
              </div>
            </div>
          ) : (
            <div className="shoe-details-container">
              <div className="shoe-details-div" key={count++}>
                <div className="shoe-details">
                  <img
                    src={`https://localhost:5212/${userShoe.shoe?.image}`}
                    alt="detailed view of shoe"
                    className="shoe-details-img"
                  />
                  <div className="shoe-detail-one">{userShoe.shoe?.name}</div>
                  <div className="shoe-detail-two">
                    Style: {userShoe.shoe?.style}
                  </div>
                  <div className="shoe-detail-two">
                    Size: {userShoe?.shoeSize}
                  </div>
                  <div className="shoe-detail-two">
                    Condition: {userShoe.condition?.condition}
                  </div>
                  <div className="shoe-detail-two">
                    Description: {userShoe?.description}
                  </div>
                  {/* {currentUser.id !== userShoe.userId && (
                    <LikesDiv currentUser={currentUser} userShoe={userShoe} />
                  )} */}
                </div>
              </div>
            </div>
          )}
          {/* <Comments currentUser={currentUser} userShoeId={userShoeId} /> */}
        </div>
      </div>
    </>
  )
}
