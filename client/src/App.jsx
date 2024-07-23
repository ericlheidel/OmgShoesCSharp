import { useEffect, useState } from "react"
import { tryGetLoggedInUser } from "./managers/authManager.js"
import { NavBar } from "./components/NavBar.jsx"
import { ApplicationViews } from "./components/ApplicationViews.jsx"
import { useNavigate } from "react-router-dom"

function App() {
  const [loggedInUser, setLoggedInUser] = useState()

  const navigate = useNavigate()

  useEffect(() => {
    // user will be null if not authenticated
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user)
    })
  }, [])

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return <div>Loading...</div>
  }

  return (
    <>
      {!loggedInUser && navigate("/login")}
      <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
      <ApplicationViews
        loggedInUser={loggedInUser}
        setLoggedInUser={setLoggedInUser}
      />
    </>
  )
}

export default App
