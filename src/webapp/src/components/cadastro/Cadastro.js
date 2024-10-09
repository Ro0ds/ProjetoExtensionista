import './Cadastro.css'
import React, {useState} from 'react'
import axios from 'axios';

function Cadastro(){
    const [formData, setFormData] = useState({
        nome: '',
        sobrenome: '',
        nome_social: '',
        foto: '',
        email: '',
        cpf: '',
        telefone: '',
        confirmacao_senha: '',
        cep: '',
        rua: '',
        numero: 0,
        bairro: '',
        cidade: '',
        estado: '',
        pais: '',
        permissao: 2,
        data_criado: '',
      });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData({
          ...formData,
          [name]: value, // Atualiza o campo correto
        });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        
        axios.defaults.headers.post['Content-Type'] ='application/json';
        axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';

        setFormData({
            ...formData,
            data_criado: new Date().toLocaleDateString(),
        });

        axios.post('http://localhost:5205/api/UsuarioCadastro/CadastrarUsuario', formData)
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.error(error);
        });

        console.log('parou o submit');
    };

    return(
        <>
            <div>
                <h1>Cadastro</h1>
            </div>

            <form onSubmit={handleSubmit}>
                <div>
                    <label for="nome">Nome:</label>
                    <input 
                        type="text" 
                        name="nome" 
                        value={formData.nome}
                        onChange={handleInputChange}
                        required />
                </div>
                
                <div>
                    <label for="sobrenome">Sobrenome:</label>
                    <input 
                        type="text" 
                        name="sobrenome" 
                        value={formData.sobrenome}
                        onChange={handleInputChange} 
                        required />
                </div>

                <div>
                    <label for="nome_social">Nome Social:</label>
                    <input 
                        type="text" 
                        name="nome_social"
                        value={formData.nome_social}
                        onChange={handleInputChange} />
                </div>

                <div>
                    <label for="email">Email:</label>
                    <input 
                    type="text" 
                    name="email" 
                    value={formData.email}
                    onChange={handleInputChange} 
                    required />
                </div>

                <div>
                    <label for="cpf">CPF: </label>
                    <input 
                    type="text" 
                    name="cpf" 
                    value={formData.cpf}
                    onChange={handleInputChange}
                    required />
                </div>

                <div>
                    <label for="telefone">Telefone:</label>
                    <input 
                    type="tel" 
                    name="telefone" 
                    value={formData.telefone}
                    onChange={handleInputChange} 
                    required />
                </div>

                <div>
                    <label for="confirmacao_senha">Senha:</label>
                    <input 
                    type="password" 
                    name="confirmacao_senha" 
                    value={formData.confirmacao_senha}
                    onChange={handleInputChange}
                    required />
                </div>
                <br />
                <hr />
                <label>Endereço</label> 
                <br /> <br />
                <div>
                    <label for="cep">Cep:</label>
                    <input 
                    type="text"
                    name="cep"
                    value={formData.cep}
                    onChange={handleInputChange} 
                    required />
                </div>

                <div>
                    <label for="rua">Rua:</label>
                    <input 
                    type="text" 
                    name="rua" 
                    value={formData.rua}
                    onChange={handleInputChange}
                    required />
                </div>

                <div>
                    <label for="numero">Número:</label>
                    <input 
                    type="number" 
                    name="numero" 
                    value={formData.numero}
                    onChange={handleInputChange}
                    required />
                </div>

                <div>
                    <label for="bairro">Bairro:</label>
                    <input 
                    type="text" 
                    name="bairro" 
                    value={formData.bairro}
                    onChange={handleInputChange}
                    required />
                </div>

                <div>
                    <label for="cidade">Cidade:</label>
                    <input 
                    type="text" 
                    name="cidade" 
                    value={formData.cidade}
                    onChange={handleInputChange}
                    required />
                </div>

                <div>
                    <label for="estado">Estado:</label>
                    <input 
                    type="text" 
                    name="estado" 
                    value={formData.estado}
                    onChange={handleInputChange}
                    required />
                </div>

                <div>
                    <label for="pais">País:</label>
                    <input 
                    type="text" 
                    name="pais" 
                    value={formData.pais}
                    onChange={handleInputChange}
                    required />
                </div>

                <div>
                    <label for="foto">Foto:</label>
                    <input 
                    type="text" 
                    name="foto" 
                    value={formData.foto}
                    onChange={handleInputChange} 
                    required />
                </div>

                <div>
                    <label for="permissao">Permissão:</label>
                    <input 
                    type="number" 
                    name="permissao" 
                    value='2'
                    onChange={handleInputChange}
                    required />
                </div>

                <button type="submit">Cadastrar</button>
            </form>
        </>
    );
}

export default Cadastro;