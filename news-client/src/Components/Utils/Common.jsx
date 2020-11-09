// return the user data from the session storage
export const getUser = () => {
  const userStr = localStorage.getItem("user");
  if (userStr) return JSON.parse(userStr);
  else return null;
};

// return the token from the session storage
export const getToken = () => {
  const getToken = localStorage.getItem("token");
  if (getToken) return JSON.parse(getToken);  
  else return null;
};

export const getAccess = () => {
  const getAccess = localStorage.getItem("access");
  if (getAccess) return JSON.parse(getAccess);
  else return null;
}

// remove the token and user from the session storage
export const removeUserSession = () => {
  localStorage.removeItem("token");
  localStorage.removeItem("user");
  localStorage.removeItem("access");
};

// set the token and user from the session storage
export const setUserSession = (data) => {
  if (JSON.stringify(data.username)) {
    localStorage.setItem("token", JSON.stringify(data.token));
    localStorage.setItem("user", JSON.stringify(data.username));
    localStorage.setItem("access", JSON.stringify(data.access));
  } else alert("Пользователя не существует");
};
