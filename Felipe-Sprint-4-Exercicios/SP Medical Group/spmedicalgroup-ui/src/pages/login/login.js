import React, { Component } from 'react';

import axios from 'axios';

import { parseJwt } from '../../services/auth';

import '../../assets/css/Login.css';


class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: '',
      senha: '',
      errorMensagem: ''
    }
  }

  efetuaLogin = (event) => {
    event.preventDefault();

    axios.post('http://localhost:5000/api/usuario/Login', {
      email: this.state.email,
      senha: this.state.senha
    })

      .then(resposta => {
        if (resposta.status === 200) {
          localStorage.setItem('usuario-login', resposta.data.token);
          console.log(resposta);

          console.log(parseJwt().role);

          if (parseJwt().role === '2') {
            this.props.history.push('/medico');
            console.log('estou logado');
          }
          if (parseJwt().role === '1'){
            this.props.history.push('/admin');
            console.log('Estou logado')
          }
          if (parseJwt().role === '3'){
            this.props.history.push('/paciente');
            console.log('Estou logado')
          }
        }
      })


      .catch(() => {
        // define o state erroMensagem com uma mensagem personalizada e que a requisição terminou
        this.setState({ errorMensagem: 'E-mail ou senha inválidos! Tente novamente.' });
      })
  }

  AtualizaStateCampo = (campo) => {
    this.setState({ [campo.target.name]: campo.target.value })
  }

  render() {
    return (
      <div>
        <div className="login_background">
          <div className="login_background-img">
          </div>
          <div className="login_login">
            <form onSubmit={this.efetuaLogin}>
              <div className="login_login-img">
              </div>
              <div>
                <input className="login_input__login" placeholder="email" type="text" name="email" value={this.state.email} onChange={this.AtualizaStateCampo} />
              </div>
              <div>
                <input className="login_input__login" placeholder="senha" type="password" name="senha" value={this.state.senha} onChange={this.AtualizaStateCampo} />
              </div>
              <p style={{ color: 'red' }}>{this.state.errorMensagem}</p>
              <div>
                <button className="login_login-bottom" type="submit">Logar</button>
              </div>
            </form>
          </div>
        </div>

      </div>
    )
  }
}

export default Login;