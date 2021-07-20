import React from 'react';

import '../../assets/css/cliente.css';

class Admin extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            listaLivros: []
        }
    }

    BuscarLivros = () => {
        console.log('Buscando livros...')

        fetch('http://localhost:5000/api/livros')
        .then(response => response.json())
        .then(data => this.setState({ listaLivros : data }))
        console.log('Api já chamada')

    }

    componentDidMount() {
        this.BuscarLivros();
    }


    render() {
        return (
            <div>
                <div className="cliente_meio">
                    <div className="cliente_container">
                        <h1 className="cliente_h1page">Livros</h1>
                        {
                            this.state.listaLivros.map((listaLivros) => {
                                return (
                                    <div className="cliente_bloco" key={listaLivros.idLivro}>
                                        <div className="cliente_bloquinhos">
                                            <div className="cliente_texts1">Título</div>
                                            <div className="cliente_text">{listaLivros.titulo}</div>
                                        </div>
                                        <div className="cliente_bloquinhos">
                                            <div className="cliente_texts1">Sinopse</div>
                                            <div className="cliente_text">{listaLivros.sinopse}</div>
                                        </div>
                                        <div className="cliente_bloquinhos">
                                            <div className="cliente_texts1">Autor</div>
                                            <div className="cliente_text">{listaLivros.idAutor}</div>
                                        </div>
                                        <div className="cliente_bloquinhos">
                                            <div className="cliente_texts1">Data de Publicação</div>
                                            <div className="cliente_text">{listaLivros.dataDePublicacao}</div>
                                        </div>
                                        <div className="cliente_bloquinhos">
                                            <div className="cliente_texts1">Preço</div>
                                            <div className="cliente_text">{listaLivros.preco}</div>
                                        </div>
                                    </div>
                                )
                            })
                        }
                    </div>
                </div>
            </div>
        )
    }
}
export default Admin;