/* eslint-disable react/prop-types */
import { Route, Routes } from "react-router-dom"
import { AuthorizedRoute } from "./auth/AuthorizedRoute.jsx"
import { Welcome } from "./home/Welcome.jsx"
import { Login } from "./auth/Login.jsx"
import { Register } from "./auth/Register.jsx"
import { AllShoesList } from "./shoes/AllShoesList.jsx"
import { ShoeDetailsForm } from "./shoes/ShoeDetailsForm.jsx"

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
        <Route
          path="shoes"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <AllShoesList />
            </AuthorizedRoute>
          }
        />
        <Route
          path="shoes/:shoeId"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <ShoeDetailsForm loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
      </Route>
    </Routes>
  )
}
