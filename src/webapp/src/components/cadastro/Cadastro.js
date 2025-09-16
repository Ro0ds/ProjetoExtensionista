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
        endereco: {
            cep: '',
            rua: '',
            numero: 0,
            bairro: '',
            cidade: '',
            estado: '',
            pais: '',
        },
        permissao_id: 2,
        data_criado: new Date().toISOString(),
    });

    // Função para lidar com as mudanças nos campos de dados pessoais
    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData((prevState) => ({
        ...prevState,
        [name]: value, // Atualiza o campo correto
        }));
    };

    // Função para lidar com as mudanças nos campos de endereço
    const handleEnderecoInputChange = (e) => {
        const { name, value } = e.target;
        setFormData((prevState) => ({
        ...prevState,
        endereco: {
            ...prevState.endereco, // Mantém os outros campos de endereço
            [name]: value, // Atualiza apenas o campo do endereço que foi alterado
        },
        }));
    };
        
    const handleSubmit = (event) => {
        event.preventDefault();
        
        axios.defaults.headers.post['Content-Type'] ='application/json';
        axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';

        axios.post('http://localhost:5205/api/usuario/cadastro/CadastrarUsuario', formData)
        .then(function (response) {
            var dados = response.data;

            if(dados.sucesso){
                console.log(`usuario ${dados._USUARIO.nome} cadastrado com sucesso`);
                console.log(`email: ${dados._USUARIO.email}`);
            }
        })
        .catch(function (error) {
            console.error(error);
        });
    };

    return(
        <>
            <div>
                <h1>Cadastro</h1>
            </div>

            <form onSubmit={handleSubmit}>
                <div>
                    <label>Nome:</label>
                    <input 
                        type="text" 
                        name="nome" 
                        value={formData.nome}
                        onChange={handleInputChange}
                        required />
                </div>
                
                <div>
                    <label>Sobrenome:</label>
                    <input 
                        type="text" 
                        name="sobrenome" 
                        value={formData.sobrenome}
                        onChange={handleInputChange} 
                        required />
                </div>

                <div>
                    <label>Nome Social:</label>
                    <input 
                        type="text" 
                        name="nome_social"
                        value={formData.nome_social}
                        onChange={handleInputChange} />
                </div>

                <div>
                    <label>Email:</label>
                    <input 
                        type="text" 
                        name="email" 
                        value={formData.email}
                        onChange={handleInputChange} 
                        required />
                </div>

                <div>
                    <label>CPF: </label>
                    <input 
                        type="text" 
                        name="cpf" 
                        value={formData.cpf}
                        onChange={handleInputChange}
                        required />
                </div>

                <div>
                    <label>Telefone:</label>
                    <input 
                        type="tel" 
                        name="telefone" 
                        value={formData.telefone}
                        onChange={handleInputChange} 
                        required />
                </div>

                <div>
                    <label>Senha:</label>
                    <input 
                        type="password" 
                        name="confirmacao_senha" 
                        value={formData.confirmacao_senha}
                        onChange={handleInputChange}
                        required />
                </div>

                <div>
                    <label>Cep:</label>
                    <input 
                        type="text"
                        name="cep"
                        value={formData.endereco.cep}
                        onChange={handleEnderecoInputChange} 
                        required />
                </div>

                <div>
                    <label>Rua:</label>
                    <input 
                        type="text" 
                        name="rua" 
                        value={formData.endereco.rua}
                        onChange={handleEnderecoInputChange}
                        required />
                </div>

                <div>
                    <label>Número:</label>
                    <input 
                        type="text" 
                        name="numero" 
                        value={formData.endereco.numero}
                        onChange={handleEnderecoInputChange}
                        required />
                </div>

                <div>
                    <label>Bairro:</label>
                    <input 
                        type="text" 
                        name="bairro" 
                        value={formData.endereco.bairro}
                        onChange={handleEnderecoInputChange}
                        required />
                </div>

                <div>
                    <label>Cidade:</label>
                    <input 
                        type="text" 
                        name="cidade" 
                        value={formData.endereco.cidade}
                        onChange={handleEnderecoInputChange}
                        required />
                </div>

                <div>
                    <label>Estado:</label>
                    <input 
                        type="text" 
                        name="estado" 
                        value={formData.endereco.estado}
                        onChange={handleEnderecoInputChange}
                        required />
                </div>

                <div>
                    <label>País:</label>
                    <input 
                        type="text" 
                        name="pais" 
                        value={formData.endereco.pais}
                        onChange={handleEnderecoInputChange}
                        required />
                </div>

                <div>
                    <label>Foto:</label>
                    <input 
                        type="text" 
                        name="foto" 
                        value={formData.foto}
                        onChange={handleInputChange} 
                        required />
                </div>

                <div>
                    <label>Permissão:</label>
                    <input 
                        type="number" 
                        name="permissao_id" 
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