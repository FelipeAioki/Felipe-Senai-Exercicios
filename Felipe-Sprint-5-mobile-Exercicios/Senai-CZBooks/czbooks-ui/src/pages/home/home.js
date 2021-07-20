import React, { Component } from 'react';

import axios from 'axios';

import { parseJwt } from '../../services/auth';

import '../../assets/css/login.css';


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

    axios.post('http://localhost:5000/api/usuarios/Login', {
      email: this.state.email,
      senha: this.state.senha
    })

      .then(resposta => {
        if (resposta.status === 200) {
          localStorage.setItem('usuario-login', resposta.data.token);
          console.log(resposta);

          console.log(parseJwt().role);

          if (parseJwt().role === '1') {
            this.props.history.push('/admin');
            console.log('estou logado');
          }
          if (parseJwt().role === '2'){
            this.props.history.push('/autor');
            console.log('Estou logado')
          }
          if (parseJwt().role === '3'){
            this.props.history.push('/cliente');
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
      <div className="body">
      <div className="container">
        <div className="bloquinho">
          <form onSubmit={this.efetuaLogin}>
            <div className="inputs">
              <h1>Email</h1>
              <input className="login_input_email" placeholder="email" type="text" name="email" value={this.state.email} onChange={this.AtualizaStateCampo} />
            </div>
            <div className="inputs">
              <h1>Senha</h1>
              <input className="login_input_senha" placeholder="senha" type="password" name="senha" value={this.state.senha} onChange={this.AtualizaStateCampo} />
            </div>
            <p style={{ color: 'red' }}>{this.state.errorMensagem}</p>
            <div>
            </div>
            <button className="buttonn" type="submit">Logar</button>
          </form>
        </div>
      </div>
    </div>
    )
  }
}

export default Login;