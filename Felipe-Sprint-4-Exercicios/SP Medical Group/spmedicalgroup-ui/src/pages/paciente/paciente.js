import React from 'react';


class Paciente extends React.Component {
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
            <main>
                <div className="background">
                    <div className="consultas">
                        <h1>Consultas</h1>
                    </div>
                </div>
            </main>
        );
    }
}
export default Paciente;