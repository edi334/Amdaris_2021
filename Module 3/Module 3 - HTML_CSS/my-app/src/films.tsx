import React from "react";
import {Switch, Route, useRouteMatch, useLocation} from "react-router-dom"

const Films = () => {
    const {state} = useLocation();
    let match = useRouteMatch();


    const logFilms = () => {
        console.log(state);
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