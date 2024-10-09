import './Login.css'
import React, {useState} from 'react'

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
                <button type='submit'>Cadastrar</button>
            </form>
        </>
    );
}

export default Login;