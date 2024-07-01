/* eslint-disable react/prop-types */
import { Route, Routes } from "react-router-dom"
import { AuthorizedRoute } from "./auth/AuthorizedRoute.jsx"
import { Welcome } from "./home/Welcome.jsx"
import { Login } from "./auth/Login.jsx"
import { Register } from "./auth/Register.jsx"
import { AllShoesList } from "./shoes/AllShoesList.jsx"
import { ShoeDetailsForm } from "./shoes/ShoeDetailsForm.jsx"
import { Profile } from "./profile/Profile.jsx"
import { UsersList } from "./users/UsersList.jsx"
import { UserShoeDetails } from "./shoes/UserShoeDetails.jsx"

export const ApplicationViews = ({ loggedInUser, setLoggedInUser }) => {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Welcome />
            </AuthorizedRoute>
          }
        />
        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
        <Route path="shoes">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <AllShoesList loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
          <Route
            path=":shoeId"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <ShoeDetailsForm loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="users">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <UsersList loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
          <Route
            path=":userId"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <Profile loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
        </Route>
        <Route path="usershoe">
          <Route
            path=":userShoeId"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <UserShoeDetails loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
        </Route>
      </Route>
    </Routes>
  )
}
