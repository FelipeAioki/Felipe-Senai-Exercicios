import React from 'react';
import './App.css';

function FormattedDate(props) {
  return <h2>Horário atual: {props.date.toLocaleTimeString()}</h2>
}

class Clock extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      date: new Date()
    };
  }

  componentDidMount() {
    this.timerId = setInterval(() => {
      this.tick()
    }, 1000);
  }

  componentWillUnmount() {
    clearInterval(this.timerId);
  }

  tick() {
    this.setState({
      date: new Date()
    });
  }

  Pause() {
    clearInterval(this.timerId);
  }

  Continue() {
    this.timerId = setInterval(() => {
      this.tick()
    }, 1000);
  }
  
  render() {
    return (
      <div>
        <h1>Relógio</h1>
        <FormattedDate date = {this.state.date} />
        <button className="btn-Pause" onClick={() => this.Pause()}>Pause</button>
        <button className="btn-Continue" onClick={() => this.Continue()}>Continue</button>
      </div>
    )
  }
}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Clock />
        <Clock />
      </header>
    </div>
  );
}

export default App;