using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace MvcCatalog.Domain
{
    public class User
    {
        protected User() { }

        public User(string name, string email, string username, string password)
        {
            Contract.Requires<Exception>(name.Length > 3, "Nome inválido");
            Contract.Requires<Exception>(Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"), "E-mail inválido");
            Contract.Requires<Exception>(username.Length > 6, "Username inválido");
            Contract.Requires<Exception>(password.Length > 6, "Senha inválida");

            this.Id = 0;
            this.Name = name;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string Image { get; set; }

        public void ChangeEmail(string email)
        {
            Contract.Requires<Exception>(Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"), "E-mail inválido");
            this.Email = email;
        }

        public void ChangePassword(string username, string password, string newPassword, string confirmPassword)
        {
            Contract.Requires<Exception>(this.Username.ToLower() == username && this.Password == password, "Usuário ou senha inválidos");
            Contract.Requires<Exception>(newPassword != this.Password, "A nova senha deve ser diferente da atual");
            Contract.Requires<Exception>(newPassword.Length > 6, "Senha inválida");
            Contract.Requires<Exception>(newPassword == confirmPassword, "As senhas digitadas não coincidem");

            this.Password = newPassword;
        }

        public void Authenticate(string username, string password)
        {
            Contract.Requires<InvalidOperationException>(this.Username.ToLower() == username.ToLower(), "Usuário ou senha inválidos");
            Contract.Requires<InvalidOperationException>(this.Password == password, "Usuário ou senha inválidos");
        }

        public void Register(string name, string email, string username, string password, string confirmPassword)
        {
            Contract.Requires<InvalidCastException>(name.Length > 3, "O nome deve conter mais de 3 caracteres");
            Contract.Requires<InvalidCastException>(Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"), "E-mail inválido");
            Contract.Requires<InvalidCastException>(username.Length > 6, "Nome de usuário inválido");
            Contract.Requires<InvalidCastException>(password.Length >= 6, "A senha deve conter pelo menos 6 caracteres");
            Contract.Requires<InvalidCastException>(password == confirmPassword, "As senhas informadas não coincidem");

            this.Name = name;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

        public void UpdateInfo(string name, string email, string username, string password, string confirmPassword)
        {
            Contract.Requires<InvalidCastException>(name.Length > 3, "O nome deve conter mais de 3 caracteres");
            Contract.Requires<InvalidCastException>(Regex.IsMatch(email, @"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}"), "E-mail inválido");
            Contract.Requires<InvalidCastException>(username.Length > 6, "Nome de usuário inválido");
            Contract.Requires<InvalidCastException>(password.Length >= 6, "A senha deve conter pelo menos 6 caracteres");
            Contract.Requires<InvalidCastException>(password == confirmPassword, "As senhas informadas não coincidem");

            this.Name = name;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }
    }
}
