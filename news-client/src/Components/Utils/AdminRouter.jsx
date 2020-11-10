import React from "react";
import { Route, Redirect } from "react-router-dom";
import { getAccess } from "./Common";

// отображение приватных компонентов
function AdminRouter({ component: Component, ...rest }) {
  return (
    <Route
      {...rest}
      render={(props) =>
        (getAccess() >= 1) ? (
          <Component {...props} />
        ) : (
          <Redirect
            to={{ pathname: "/login", state: { from: props.location } }}
          />
        )
        
      }
    />
    
  );

}

export default AdminRouter;