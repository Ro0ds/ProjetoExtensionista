using Api.Seguranca.Interfaces;
using Api.Models;
using System.Security.Cryptography;
using System.Text;
using Api.DTO.Requisicao.Usuario.Cadastro;

namespace Api.Seguranca
{
    public class Senha : IHashSenha
    {
        public byte[] GerarSalt()
        {
            using(var aleatorio = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[32];
                aleatorio.GetBytes(salt);

                return salt;
            }
        }

        public string HashSenha(string senha, byte[] salt)
        {
            using(var sha256 = SHA256.Create())
            {
                byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);
                byte[] saltedSenha = new byte[senhaBytes.Length + salt.Length];

                // concatena a senha com o salt
                Buffer.BlockCopy(senhaBytes, 0, saltedSenha, 0, senhaBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedSenha, senhaBytes.Length, salt.Length);

                // adiciona hash a senha com o salt
                byte[] hashedBytes = sha256.ComputeHash(saltedSenha);

                // concatena o salt e o hash para guardar
                byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
                Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

                return Convert.ToBase64String(hashedPasswordWithSalt);
            }
        }

        public bool SenhaEstaCorreta(USUARIO usuario, UsuarioCadastroRequisicao usuarioRequisicao)
        {
            string storedHashedPassword = usuario.SENHA!.HASH;
            byte[] storedSaltBytes = usuario.SENHA!.SALT;
            string enteredPassword = usuarioRequisicao.CONFIRMACAO_SENHA;

            byte[] enteredPasswordBytes = Encoding.UTF8.GetBytes(enteredPassword);

            // concatena a senha digitada e o salt armazenado
            byte[] saltedPassword = new byte[enteredPasswordBytes.Length + storedSaltBytes.Length];
            Buffer.BlockCopy(enteredPasswordBytes, 0, saltedPassword, 0, enteredPasswordBytes.Length);
            Buffer.BlockCopy(storedSaltBytes, 0, saltedPassword, enteredPasswordBytes.Length, storedSaltBytes.Length);

            // hash a senha concatenada
            string enteredPasswordHash = HashSenha(enteredPassword, storedSaltBytes);

            // verifica se a senha digitada está correta
            if(enteredPasswordHash == storedHashedPassword)
            {
                return true;
            }

            return false;
        }
    }
}