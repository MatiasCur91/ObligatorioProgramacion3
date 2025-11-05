


namespace Obligatorio.Utilidades;

public class Crypto
{
    

        public static string HashPasswordConBcrypt(string passwordOriginal,int wf) {

            string hash = BCrypt.Net.BCrypt.HashPassword(passwordOriginal, wf);
            return hash;
        }

        public static bool VerificarPasswordConBcrypt(string passOriginal, string passHash) {

            return BCrypt.Net.BCrypt.Verify(passOriginal, passHash);
        }

    
}

