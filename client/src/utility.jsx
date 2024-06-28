let clickCount = 0
export const handleClick = () => {
  clickCount++

  if (clickCount === 1) {
    return "ronald@macdonald.com"
  } else {
    if (clickCount === 2) {
      return "early@cuyler.com"
    } else {
      if (clickCount === 3) {
        return "rusty@cuyler.com"
      } else {
        if (clickCount === 4) {
          clickCount = 0
          return ""
        }
      }
    }
  }
}

export const states = [
  { id: 1, state: "AL" },
  { id: 2, state: "AK" },
  { id: 3, state: "AZ" },
  { id: 4, state: "AR" },
  { id: 5, state: "CA" },
  { id: 6, state: "CO" },
  { id: 7, state: "CT" },
  { id: 8, state: "DE" },
  { id: 9, state: "FL" },
  { id: 10, state: "GA" },
  { id: 11, state: "HI" },
  { id: 12, state: "ID" },
  { id: 13, state: "IL" },
  { id: 14, state: "IN" },
  { id: 15, state: "IA" },
  { id: 16, state: "KS" },
  { id: 17, state: "KY" },
  { id: 18, state: "LA" },
  { id: 19, state: "ME" },
  { id: 20, state: "MD" },
  { id: 21, state: "MA" },
  { id: 22, state: "MI" },
  { id: 23, state: "MN" },
  { id: 24, state: "MS" },
  { id: 25, state: "MO" },
  { id: 26, state: "MT" },
  { id: 27, state: "NE" },
  { id: 28, state: "NV" },
  { id: 29, state: "NH" },
  { id: 30, state: "NJ" },
  { id: 31, state: "NM" },
  { id: 32, state: "NY" },
  { id: 33, state: "NC" },
  { id: 34, state: "ND" },
  { id: 35, state: "OH" },
  { id: 36, state: "OK" },
  { id: 37, state: "OR" },
  { id: 38, state: "PA" },
  { id: 39, state: "RI" },
  { id: 40, state: "SC" },
  { id: 41, state: "SD" },
  { id: 42, state: "TN" },
  { id: 43, state: "TX" },
  { id: 44, state: "UT" },
  { id: 45, state: "VT" },
  { id: 46, state: "VA" },
  { id: 47, state: "WA" },
  { id: 48, state: "WV" },
  { id: 49, state: "WI" },
  { id: 50, state: "WY" },
]
