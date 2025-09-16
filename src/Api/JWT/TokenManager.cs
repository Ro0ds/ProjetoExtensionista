namespace Api.JWT
{
    public static class TokenManager
    {
        private static List<string> tokensRevogados = new List<string>();

        public static void AdicionarParaTokensRevogados(string token)
        {
            if(!tokensRevogados.Contains(token))
            {
                tokensRevogados.Add(token);
            }
        }

        public static bool TokenFoiRevogado(string token)
        {
            return tokensRevogados.Contains(token);
        }
    }
}