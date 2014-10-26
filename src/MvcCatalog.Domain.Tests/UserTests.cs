using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvcCatalog.Domain.Tests
{
    [TestClass]
    public class Dado_um_novo_usuario
    {
        [TestMethod]
        [TestCategory("Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_um_nome()
        {
            var user = new User("", "andre@andre.com", "andrebaltieri", "andrebaltieri");
        }

        [TestMethod]
        [TestCategory("Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_um_email()
        {
            var user = new User("André", "", "andrebaltieri", "andrebaltieri");
        }

        [TestMethod]
        [TestCategory("Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_um_username()
        {
            var user = new User("André", "andre@andre.com", "", "andrebaltieri");
        }

        [TestMethod]
        [TestCategory("Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_uma_senha()
        {
            var user = new User("André", "andre@andre.com", "andrebaltieri", "");
        }
    }

    [TestClass]
    public class Ao_alterar_o_email
    {
        [TestMethod]
        [TestCategory("Alterar E-mail")]
        [ExpectedException(typeof(Exception))]
        public void O_novo_email_deve_ser_valido()
        {
            var user = new User("André", "andre@andre.com", "andrebaltieri", "andrebaltieri");
            user.ChangeEmail("nada");
        }

    }

    [TestClass]
    public class Ao_alterar_a_senha
    {
        [TestMethod]
        [TestCategory("Alterar Senha")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_e_senha_devem_ser_validos()
        {
            var user = new User("André", "andre@andre.com", "andrebaltieri", "andrebaltieri");
            user.ChangePassword("nada", "nada", "123456", "123456");
        }

        [TestMethod]
        [TestCategory("Alterar Senha")]
        [ExpectedException(typeof(Exception))]
        public void A_nova_senha_deve_ser_diferente_da_atual()
        {
            var user = new User("André", "andre@andre.com", "andrebaltieri", "andrebaltieri");
            user.ChangePassword("andrebaltieri", "andrebaltieri", "andrebaltieri", "andrebaltieri");
        }

        [TestMethod]
        [TestCategory("Alterar Senha")]
        [ExpectedException(typeof(Exception))]
        public void A_senha_deve_conter_mais_de_seis_caracteres()
        {
            var user = new User("André", "andre@andre.com", "andrebaltieri", "");
        }

        [TestMethod]
        [TestCategory("Alterar Senha")]
        [ExpectedException(typeof(Exception))]
        public void A_nova_senha_deve_ser_igual_sua_confirmacao()
        {
            var user = new User("André", "andre@andre.com", "andrebaltieri", "andrebaltieri");
            user.ChangePassword("andrebaltieri", "andrebaltieri", "12345678", "andrebaltieri");
        }
    }
}
