using System.Numerics;

namespace Api.JWT
{
    public static class ChaveJWT
    {
        public static string GerarChaveSecreta()
        {
            BigInteger hora = (BigInteger)Math.Pow(DateTime.Now.Millisecond, 24);
            BigInteger ano = (BigInteger)Math.Pow(DateTime.Now.Year, 24);

            return (hora * ano).ToString();
        }

        public static string PegarChaveSecreta(IConfiguration configuration)
        {
            var key = configuration["JwtSettings:Secret"]!;
            return key;
        }
    }
}