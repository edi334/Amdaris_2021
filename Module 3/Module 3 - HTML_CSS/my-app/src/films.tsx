import React, { useEffect } from "react";
import {Switch, Route, useRouteMatch, useLocation, useParams} from "react-router-dom"

const Films = () => {
    const films = useParams();
    let match = useRouteMatch();

   //https://css-tricks.com/the-hooks-of-react-router/

    const logFilms = () => {
        console.log(films);
    }


    return (
        <Switch>
            <Route path={`${match.path}/:name`}>
                <button onClick={logFilms}>see films</button>
            </Route>
            <Route>
                <h1>Could not find films</h1>
            </Route>
        </Switch>
    );
}

export default Films;