import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch } from 'react-router-dom';

import './index.css';

import reportWebVitals from './reportWebVitals';

import Cliente from './pages/cliente/cliente';
import Login from './pages/home/home';
import Autor from './pages/autor/autor';
import Admin from './pages/admin/admin';



const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} />
        <Route path="/Cliente" component={Cliente} />
        <Route path="/Admin" component={Admin} />
        <Route path="/Autor" component={Autor} />
      </Switch>
    </div>
  </Router>
)


ReactDOM.render(routing,document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
