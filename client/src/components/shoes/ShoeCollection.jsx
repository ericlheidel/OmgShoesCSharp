/* eslint-disable react/prop-types */
import { Link } from "react-router-dom"
import "./ShoeCollection.css"

export const ShoeCollection = ({ collection }) => {
  // const navigate = useNavigate()

  let count = 1
  return (
    <div className="shoe-collection">
      {collection.map((userShoe) => {
        return (
          <div className="user-shoe" value={userShoe.id} key={count++}>
            <Link to={`/usershoe/${userShoe.id}`}>
              <div className="user-shoe-img-div">
                <img
                  src={`https://localhost:5212/${userShoe.shoe.image}`}
                  alt="detailed view of shoe"
                  className="user-shoe-img"
                />
              </div>
            </Link>
            <div className="collection-shoe-name">{userShoe.shoe.name}</div>
            <div className="user-shoe-info">
              <div className="user-shoe-size">{userShoe.shoeSize}</div>
              <div className="user-shoe-condition">
                {userShoe.condition.description}
              </div>
              <div className="user-shoe-description">
                {userShoe.description}
              </div>
            </div>
          </div>
        )
      })}
    </div>
  )
}
