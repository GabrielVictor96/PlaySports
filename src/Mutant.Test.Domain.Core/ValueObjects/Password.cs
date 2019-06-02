using PlaySports.Domain.Core.Security;

namespace PlaySports.Domain.Core.ValueObjects
{
    public class Password
    {
        protected Password() { }

        public Password(string passwordText)
        {
            EncryptPassword(passwordText);
        }

        public string SenhaCriptografada { get; private set; }

        private void EncryptPassword(string password) => SenhaCriptografada = PasswordEncryptor.Md5Hash(password);
    }
}