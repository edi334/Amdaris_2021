import React from 'react';
import './App.css';
import Cards from './cards';
import Films from './films';
import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom"

function App() {

  return (
    <Router>
      <Switch>
        <Route path="/" exact>
          <h1>STAR WARS PEOPLE CARDS</h1>
          <Cards/>
        </Route>
        <Route path="/films" exact>
          <Films/>
        </Route>
      </Switch>
    </Router>
   
  );
}

export default App;
