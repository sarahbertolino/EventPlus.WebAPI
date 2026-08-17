namespace EventPlus.WebAPI.Utils
{
    /// <summary>
    /// Utilitario estpatuci responsável pelas operações de criptografia e hashing de senhas na API
    /// </summary>
    public static class Criptografia
    {
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }
    }
}
