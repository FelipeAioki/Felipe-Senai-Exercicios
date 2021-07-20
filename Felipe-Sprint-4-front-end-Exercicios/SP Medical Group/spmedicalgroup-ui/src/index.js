//IMPORTS
import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch } from 'react-router-dom';

//IMPORT PAGES
import Admin from './pages/admin/admin.js';
import notFound from './pages/notFound/notFound';
import Paciente from './pages/paciente/paciente';
import Login from './pages/login/login';
import Medico from './pages/medico/medico';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} />
        <Route path="/Admin" component={Admin} />
        <Route exact path="/NotFound" component={notFound} />
        <Route exact path="/Paciente" component={Paciente} />
        <Route exact path="/Medico" component={Medico} />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing,document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
