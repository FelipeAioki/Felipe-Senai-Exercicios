import React from 'react';

import '../../assets/css/Admin.css';

class Admin extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsulta: []
        }
    }

    BuscarConsultas = () => {
        console.log('agora vamos chamar a api')

        fetch('http://localhost:5000/api/consulta')

            .then(resposta => resposta.json())

            //atualiza o state listaconsulta com os daos obtidos
            .then(data => this.setState({ listaConsulta: data }))

            //caso ocorra erro, irá mostrar um erro no console
            .catch((erro) => console.log(erro))
    }

    componentDidMount() {
        this.BuscarConsultas();
    }

    render() {
        return (
            <div>
                <main>
                    <div className="admin_background">
                        <div className="admin_consultas">
                            <h1>Consultas</h1>
                            {
                                this.state.listaConsulta.map((listaConsulta) => {
                                    return (
                                        <div key={listaConsulta.idConsulta}>
                                            <div className="admin_bloco">
                                                <div className="admin_texts">
                                                    <div className="admin_divtext">
                                                        <h1>Especialidade</h1>
                                                    </div>
                                                    <div className="admin_divtext">
                                                        <h1>Médico</h1>
                                                    </div>
                                                    <div className="admin_divtext">
                                                        <h1>Data</h1>
                                                    </div>
                                                    <div className="admin_divtext">
                                                        <h1>Situação</h1>
                                                    </div>
                                                    <div className="admin_divtext">
                                                        <h1>Local</h1>
                                                    </div>
                                                </div>
                                                <div className="admin_inputs">
                                                    <div className="admin__div">
                                                        <div className="admin_inputss">{listaConsulta.especialidade}</div>
                                                    </div>
                                                    <div className="admin__div">
                                                        <div className="admin_inputss">{listaConsulta.medico}</div>
                                                    </div>
                                                    <div className="admin__div">
                                                        <div className="admin_inputss">{listaConsulta.dataDaConsulta}</div>
                                                    </div>
                                                    <div className="admin__div">
                                                        <div className="admin_inputss">{listaConsulta.situação}</div>
                                                    </div>
                                                    <div className="admin__div">
                                                        <div className="admin_inputss">{listaConsulta.endereço}</div>
                                                    </div>
                                                </div>
                                                <div className="admin_botao">
                                                    <button><a href="/">PDF</a></button>
                                                </div>
                                            </div>
                                        </div>
                                    )
                                })
                            }
                        </div>
                    </div>
                </main>
            </div>
        );
    }
}
export default Admin;