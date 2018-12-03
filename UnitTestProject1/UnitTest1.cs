using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entity;
using Infra.Repository;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                Fucionario f = new Fucionario();
                FuncionarioRepository fr = new FuncionarioRepository();

               // f.IdFuncionario = 0;
                f.Login = "iaiai";
                f.NomeFuncionario = "eu";
                f.Perfil = Fucionario.PerfilFuncionario.Garcom;
                f.Senha = "123";
                fr.Insert(f);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
