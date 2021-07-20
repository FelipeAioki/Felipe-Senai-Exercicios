import React, { Component } from 'react';
  
// import { Link } from 'react-router-dom';

import '../../assets/css/App.css';

class Infos extends Component {
  constructor(props) {
    super(props);
    this.state = {
      repositories: [],
      username: ''
    };
  };

  reposQuery = (e) => {
    e.preventDefault();

    fetch(`http://api.github.com/users/${this.state.username}/repos?sort=created&per_page=10`)
      .then(response => response.json())
      .then(data => this.setState({ repositories: data }))
      .catch(error => console.log(error))

  }
  render() {
    return (
      <div className="divv">
        <form onSubmit={this.reposQuery}>
          <div className="botao1">
            <h1>Api GitHub</h1>
            <input type="text" name="username" id="" placeholder="Username" value={this.state.username} onChange={e => this.setState({ username: e.target.value })} />
            <button className="buttonn" type="submit">Buscar</button>
          </div>
        </form>
        {
          this.state.repositories.map(r => {
            
            { /** 

              Estrutura do condicional (if)
              if (condição) {
                // faço algo
              }

              Estrutura do IF Ternário
              condição ? faço algo se for verdade : faço algo se for mentira
            
            */ }


            return (
              <div class="bloco">
                <div class="bloquinhos">
                  <div class="texts1">Nome</div>
                  <div class="text">{r.name}</div>
                </div>
                <div class="bloquinhos">
                  <div class="texts1">Link</div>
                  <div class="text"><a href={r.html_url}>{r.html_url}</a></div>
                </div>
                <div class="bloquinhos">
                  <div class="texts1">Publico ou Privado</div>
                  <div class="text">{r.private ? 'privado' : 'público'}</div>
                </div>
                <div class="bloquinhos">
                  <div class="texts1">Tamanho</div>
                  <div class="text">{r.size}</div>
                </div>
                <div class="bloquinhos">
                  <div class="texts1">Data de criação</div>
                  <div class="text">{r.created_at}</div>
                </div>
                <div class="bloquinhos">
                  <div class="texts1">Linguagem</div>
                  <div class="text">{r.language}</div>
                </div>
              </div>
            )
          })
        }
      </div>
    );
  }
}


export default Infos;
