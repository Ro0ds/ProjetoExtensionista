import './Login.css';
import React, { useState } from 'react';
import Cadastro from '../cadastro/Cadastro';

function Login() {
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log('parou');
        console.log('Email: ' + email + ' Senha: ' + senha);
    };

    return (
        <div className="login-container">
            <div className="logo-container">
                <img src="./imagens/logo01-inovarjunto.png" alt="Logo" className="logo" />
            </div>
            <div className="login-form-container">
                <h1>Seja bem vindo </h1>
                <form onSubmit={handleSubmit}>
                    <div>
                        <label>Email: </label>
                        <input 
                            type='email' 
                            name='email' 
                            id='email'
                            onChange={(e) => setEmail(e.target.value)}>    
                        </input>
                    </div>
                    <div>
                        <label>Senha: </label>
                        <input 
                            type='password' 
                            name='senha' 
                            id='senha'
                            onChange={(e) => setSenha(e.target.value)}> 
                        </input>
                    </div>
                    <button type='submit'>Entrar</button>
                    <button type='submit'> <a href='#'></a>Cadastrar</button>
                </form>
                
            </div>
        </div>
    );
}

export default Login;