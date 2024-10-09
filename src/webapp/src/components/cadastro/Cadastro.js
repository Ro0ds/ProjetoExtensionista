import './Cadastro.css'
import React, {useState} from 'react'
import axios from 'axios';

function Cadastro(){
    const [enderecoFormData, setEnderecoFormData] = useState({
        cep: '',
        rua: '',
        numero: 0,
        bairro: '',
        cidade: '',
        estado: '',
        pais: ''
      });

    const [formData, setFormData] = useState({
        nome: '',
        sobrenome: '',
        nome_social: '',
        foto: '',
        email: '',
        cpf: '',
        telefone: '',
        confirmacao_senha: '',
        endereco: enderecoFormData,
        permissao_id: 2,
        data_criado: new Date().toISOString(),
      });

      const handleEnderecoInputChange = (e) => {
          const { name, value } = e.target;
          setEnderecoFormData({
              ...enderecoFormData,
              [name]: value, // Atualiza o campo correto
            });
        };

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

        setEnderecoFormData({
            ...enderecoFormData
        });

        setFormData({
            ...formData,
            endereco: enderecoFormData
        });

        axios.post('http://localhost:5205/api/usuario/cadastro/CadastrarUsuario', formData)
        .then(function (response) {
            var dados = response.data;

            if(dados.sucesso){
                console.log(`usuario ${dados._USUARIO.nome} cadastrado com sucesso`);
                console.log(`email: ${dados._USUARIO.email}`);
            }
        })
        .catch(function (error) {
            var erro = error.data;

            console.error(erro.erros);
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
                <br />
                <hr />
                <label>Endereço</label> 
                <br /> <br />
                <div>
                    <label>Cep:</label>
                    <input 
                    type="text"
                    name="cep"
                    value={enderecoFormData.cep}
                    onChange={handleEnderecoInputChange} 
                    required />
                </div>

                <div>
                    <label>Rua:</label>
                    <input 
                    type="text" 
                    name="rua" 
                    value={enderecoFormData.rua}
                    onChange={handleEnderecoInputChange}
                    required />
                </div>

                <div>
                    <label>Número:</label>
                    <input 
                    type="text" 
                    name="numero" 
                    value={enderecoFormData.numero}
                    onChange={handleEnderecoInputChange}
                    required />
                </div>

                <div>
                    <label>Bairro:</label>
                    <input 
                    type="text" 
                    name="bairro" 
                    value={enderecoFormData.bairro}
                    onChange={handleEnderecoInputChange}
                    required />
                </div>

                <div>
                    <label>Cidade:</label>
                    <input 
                    type="text" 
                    name="cidade" 
                    value={enderecoFormData.cidade}
                    onChange={handleEnderecoInputChange}
                    required />
                </div>

                <div>
                    <label>Estado:</label>
                    <input 
                    type="text" 
                    name="estado" 
                    value={enderecoFormData.estado}
                    onChange={handleEnderecoInputChange}
                    required />
                </div>

                <div>
                    <label>País:</label>
                    <input 
                    type="text" 
                    name="pais" 
                    value={enderecoFormData.pais}
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