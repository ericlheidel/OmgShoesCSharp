/* eslint-disable react/prop-types */
import { useNavigate, useParams } from "react-router-dom"
import "./ShoeDetails.css"
import { useEffect, useState } from "react"
import { deleteShoe, getShoeById } from "../../managers/shoeManager.js"
import { getAllConditions } from "../../managers/conditionManager"
import { sizes } from "../../utility.jsx"
import { addShoeToUserCollection } from "../../managers/userShoeManager.js"

export const ShoeDetailsForm = ({ loggedInUser }) => {
  const { shoeId } = useParams()

  const [shoe, setShoe] = useState([])
  const [conditions, setConditions] = useState([])

  const [chosenCondition, setChosenCondition] = useState("0")
  const [chosenSize, setChosenSize] = useState("0")
  const [userShoeDescription, setUserShoeDescription] = useState("")

  const [isDisabled, setIsDisabled] = useState([])

  const navigate = useNavigate()

  useEffect(() => {
    getShoeById(shoeId).then(setShoe)
  }, [shoeId])

  useEffect(() => {
    getAllConditions().then(setConditions)
  }, [])

  const handleAddShoeToUserCollection = (e) => {
    e.preventDefault()

    const newShoe = {
      userProfileId: loggedInUser.id,
      shoeId: parseInt(shoeId),
      shoeSize: chosenSize,
      conditionId: parseInt(chosenCondition),
      description: userShoeDescription,
    }

    addShoeToUserCollection(newShoe).then(() => {
      navigate(`/users/${loggedInUser.id}`)
    })
  }

  useEffect(() => {
    if (
      chosenCondition !== "0" &&
      chosenSize !== "0" &&
      userShoeDescription !== ""
    ) {
      setIsDisabled(false)
    } else {
      setIsDisabled(true)
    }
  }, [chosenCondition, chosenSize, userShoeDescription])

  const handleDelete = () => {
    deleteShoe(shoe.id).then(navigate("/shoes"))
  }

  return (
    <div className="shoe-details-container">
      <div className="shoe-details-div">
        <div className="shoe-details">
          <img
            src={`https://localhost:5212/${shoe?.image}`}
            alt="shoe shown in detail"
            className="shoe-details-img"
          />
          <div className="shoe-detail-one">{shoe.name}</div>
          <div className="shoe-detail-two">Style: {shoe.style}</div>
          <div className="shoe-detail-two">{shoe.year}</div>
          <div className="shoe-detail-two">{shoe.modelNumber}</div>
          <div className="shoe-detail-two">{shoe.colorway}</div>
        </div>
        <form className="form" onSubmit={handleDelete}>
          <fieldset>
            <div className="form-group">
              <select
                className="condition-dropdown form-select"
                required
                onChange={(e) => setChosenCondition(e.target.value)}
              >
                <option value={0} key={0}>
                  Select a condition
                </option>
                {conditions.map((condition) => {
                  return (
                    <option value={condition.id} key={condition.id}>
                      {condition.description}
                    </option>
                  )
                })}
              </select>
            </div>
          </fieldset>
          <div>
            <fieldset>
              <select
                className="size-dropdown form-select"
                required
                onChange={(e) => setChosenSize(e.target.value)}
              >
                <option value={0} key={0}>
                  Select a Size...
                </option>
                {sizes.map((size) => {
                  return (
                    <option value={size.size} key={size.id}>
                      {size.size}
                    </option>
                  )
                })}
              </select>
            </fieldset>
            <fieldset>
              <div className="flex row">
                <div className="shoe-description">
                  <textarea
                    type="text"
                    className="form-textarea"
                    required
                    value={userShoeDescription}
                    onChange={(e) => setUserShoeDescription(e.target.value)}
                  ></textarea>
                </div>
                <div
                  className="hidden-div"
                  onClick={() => setUserShoeDescription("Great Condition!")}
                ></div>
              </div>
            </fieldset>
            <fieldset>
              <div className="add-btn-div">
                <button
                  type="submit"
                  className="add-btn form-btn"
                  disabled={isDisabled}
                  onClick={handleAddShoeToUserCollection}
                >
                  Add Shoe to Collection
                </button>
              </div>
            </fieldset>
          </div>
        </form>
        {shoe.id >= 123 && (
          <button
            className="form-btn"
            style={{ marginBottom: "15px", marginRight: "77.5%" }}
          >
            Delete
          </button>
        )}
      </div>
    </div>
  )
}
