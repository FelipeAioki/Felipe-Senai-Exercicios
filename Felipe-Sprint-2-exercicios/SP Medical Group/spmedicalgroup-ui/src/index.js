import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch} from 'react-router-dom';

//chama o css
import './index.css';

//chama as pages
import App from './pages/home/App';

//chama arquivo de teste
import reportWebVitals from './reportWebVitals';


const routing = (
  <Router>
    <div>
      <switch>
        <Route exact path="/" component={App}/> {/*Home*/}
      </switch>
    </div>
  </Router>
)
ReactDOM.render(routing, document.getElementById('root'));   //Especifica qual pagina vai carregar

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
