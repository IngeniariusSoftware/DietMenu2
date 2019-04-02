
namespace DietMenu2.Modules
{
    using System.Security.Cryptography;
    using System.Text;

    public static class Protection
    {
        private static readonly SHA256 Encryptor = SHA256.Create();

        public static byte[] GenerateHash(string login, string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(login + password);
            return Encryptor.ComputeHash(data);
        }

        public static bool CheckHash(string userLogin, string password, string protectKey)
        {
            bool isRight = true;
            byte[] key = GenerateHash(userLogin, password);
            for (int i = 0; i < key.Length && isRight; i++)
            {
                if (key[i] != protectKey[i])
                {
                    isRight = false;
                }
            }

            return isRight;
        }
    }
}
