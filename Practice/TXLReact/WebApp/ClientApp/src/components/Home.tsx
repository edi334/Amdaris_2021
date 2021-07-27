import * as React from 'react';
import { connect } from 'react-redux';

const Home = () => (
  <div>
        <h1>My First React ASP.NET Core App</h1>
        <h3>Will be the coolest ASP.Net Core App</h3>
  </div>
);

export default connect()(Home);
