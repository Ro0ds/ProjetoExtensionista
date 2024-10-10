import './Login.css'
import React, {useState} from 'react'
import Cadastro from '../cadastro/Cadastro';

function Login(){
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    
    const handleSubmit = (event) => {
        event.preventDefault();

        console.log('parou');
        console.log('Email: ' + email + ' Senha: ' + senha);
    };

    return(
        <>
            <div>
                <h1>Tela de Login</h1>
            </div>

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
                <a href='#'>Esqueceu a senha?</a>
                
                <button type='submit'> <a href='#'></a>Cadastrar</button>
                
                <div className='cadastro-link'>
                    <p>Não tem uma conta?
                        <button> <a href='/cadastro/Cadastro'>REGISTRAR</a></button>
                    </p>
                </div>

            </form>
        </>
    );
}

export default Login;