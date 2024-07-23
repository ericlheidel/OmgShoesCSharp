/* eslint-disable react/prop-types */
export const UserSelect = ({ setEmail, setPassword }) => {
  const handleSelectUser = (e) => {
    if (e.target.value === "") {
      setPassword("")
    } else {
      setPassword("password")
    }
    setEmail(e.target.value)
  }

  return (
    <div>
      <select
        style={{
          marginRight: "0",
          marginTop: "1rem",
          padding: ".75rem",
          width: "auto",
        }}
        className="user-dropdown"
        onChange={(e) => handleSelectUser(e)}
      >
        <option value={""}>Users</option>
        <option value={"dee@reynolds.com"}>Dee Reynolds</option>
        <option value={"dennis@reynolds.com"}>Dennis Reynolds</option>
        <option value={"frank@reynolds.com"}>Frank Reynolds</option>
        <option value={"ronald@macdonald.com"}>Mac McDonald</option>
        <option value={"charlie@kelly.com"}>Charlie Kelly (Admin)</option>
        <option value={"the@waitress.com"}>The Waitress (Admin)</option>
      </select>
    </div>
  )
}
