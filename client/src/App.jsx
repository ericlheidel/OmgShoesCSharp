import { useEffect, useState } from "react"
import { tryGetLoggedInUser } from "./managers/authManager.js"
import { NavBar } from "./components/NavBar.jsx"
import { ApplicationViews } from "./components/ApplicationViews.jsx"

function App() {
  const [loggedInUser, setLoggedInUser] = useState()

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
      <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
      <ApplicationViews
        loggedInUser={loggedInUser}
        setLoggedInUser={setLoggedInUser}
      />
    </>
  )
}

export default App
