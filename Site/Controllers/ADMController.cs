using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.Models;
using Domain.Entity;
using Infra.Repository;

namespace Site.Controllers
{
    public class ADMController : Controller
    {
        // GET: ADM
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CadastroProduto()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        #region Contas
        public ActionResult CadastroConta()
        {
            return View();
        }


        [HttpPost]
        public ActionResult IncluiCervejas(IEnumerable<string> nomes)
        {
            return View();
        }

        public ActionResult CadastroContaAvulsa(ModelContaAvulsa mdp, string id)
        {
            //insere cliente avulso
            Cliente cl = new Cliente();
            //////////
            Conta c = new Conta();
            ContaRepository cr = new ContaRepository();
            if (id == null)
            {

                ClienteRepository clr = new ClienteRepository();
                cl.NomeCliente = "avulso";
                cl.TpCliente = Cliente.TipoCliente.Avulso;
                cl.CPFCliente = "000.000.000-00";
                cl.EmailCliente = "avulso@com";
                cl.DtaCadastro = DateTime.Now;
                clr.Insert(cl);
            }

            //ModelContaAvulsa mdc = new ModelContaAvulsa();
            c.StatusConta = false;
            if (id == null)
                c.TpConta = Conta.TipoConta.Avulso;
            else
                c.TpConta = Conta.TipoConta.Regular;
            c.ValorConta = 0;
            c.DataConta = DateTime.Now;
            if (id == null)
                c.IdCliente = cl.IdCliente;
            else
                c.IdCliente = int.Parse(id);
            cr.Insert(c);

            //  mdc.IdConta = c.IdConta;

            CervejaRepository cra = new CervejaRepository();
            QueijoRepository crq = new QueijoRepository();
            VinhoRepository crv = new VinhoRepository();
            MassaRepository crm = new MassaRepository();

            List<Cerveja> listcerv = new List<Cerveja>(cra.ObterTodos());
            List<Queijo> listqueij = new List<Queijo>(crq.ObterTodos());
            List<Vinho> listvinh = new List<Vinho>(crv.ObterTodos());
            List<Massa> listmass = new List<Massa>(crm.ObterTodos());

            List<string> listaCerveja = new List<string>();
            List<string> listaQueijo = new List<string>();
            List<string> listaVinho = new List<string>();
            List<string> listaMassa = new List<string>();

            foreach (var itemcerva in listcerv)
            {
                listaCerveja.Add(itemcerva.NomeCerveja);
            }
            foreach (var itemcerva in listqueij)
            {
                listaQueijo.Add(itemcerva.NomeQueijo);
            }
            foreach (var itemcerva in listvinh)
            {
                listaVinho.Add(itemcerva.NomeVinho);
            }
            foreach (var itemcerva in listmass)
            {
                listaMassa.Add(itemcerva.NomeMassa);
            }

            ViewBag.cerva = new SelectList(listaCerveja, "NomeCerveja");
            ViewBag.queijo = new SelectList(listaQueijo, "NomeQueijo");
            ViewBag.vinho = new SelectList(listaVinho, "NomeVinho");
            ViewBag.massa = new SelectList(listaMassa, "NomeMassa");

            return View("CadastroContaAvulsa", mdp);
        }

        public ActionResult CadastroContaFidelizadaOld(string IdsCli)
        {
            ModelContaAvulsa mdc = new ModelContaAvulsa();
            mdc.IdCliente = int.Parse(IdsCli);
            return RedirectToAction("CadastroContaAvulsa", new { id = IdsCli });
        }

        [HttpPost]
        public ActionResult CadastroContaAvulsaOld(IEnumerable<string> IdsCerva, IEnumerable<string> IdsMassas,
            IEnumerable<string> IdsVinhos, IEnumerable<string> IdQueijos, string qtdCerva, string qtdMassa,
            string qtdVinho, string qtdQueijo, string nMesa)
        {
            ItemConta itemConta = new ItemConta();
            ItemRepository ir = new ItemRepository();
            ContaRepository crc = new ContaRepository();
            Conta crConta = new Conta();
            var idConta = crc.UltimaConta();

            //inclui numero da mesa na conta
            crConta.DataConta = idConta.DataConta;
            crConta.IdCliente = idConta.IdCliente;
            crConta.IdConta = idConta.IdConta;
            crConta.NumeroMesa = int.Parse(nMesa);
            crConta.StatusConta = idConta.StatusConta;
            crConta.TpConta = idConta.TpConta;
            crConta.ValorConta = idConta.ValorConta;
            crc.Update(crConta);

            if (IdsCerva != null)
            {
                foreach (var item in IdsCerva)
                {
                    itemConta.IdConta = idConta.IdConta;
                    itemConta.TpProduto = 2;
                    itemConta.NomeProduto = item.ToString();
                    itemConta.QtdItem = int.Parse(qtdCerva);
                    ir.Insert(itemConta);
                }
            }
            //queijos
            if (IdQueijos != null)
            {
                foreach (var item in IdQueijos)
                {
                    itemConta.IdConta = idConta.IdConta;
                    itemConta.TpProduto = 3;
                    itemConta.NomeProduto = item.ToString();
                    itemConta.QtdItem = int.Parse(qtdQueijo);
                    ir.Insert(itemConta);
                }
            }
            //vinhos
            if (IdsVinhos != null)
            {
                foreach (var item in IdsVinhos)
                {
                    itemConta.IdConta = idConta.IdConta;
                    itemConta.TpProduto = 1;
                    itemConta.NomeProduto = item.ToString();
                    itemConta.QtdItem = int.Parse(qtdVinho);
                    ir.Insert(itemConta);
                }
            }
            //massas
            if (IdsMassas != null || IdsMassas.ToString() != "")
            {
                foreach (var item in IdsMassas)
                {
                    if (item != "")
                    {
                        itemConta.IdConta = idConta.IdConta;
                        itemConta.TpProduto = 4;
                        itemConta.NomeProduto = item.ToString();
                        itemConta.QtdItem = int.Parse(qtdMassa);
                        ir.Insert(itemConta);
                    }
                }
            }

            ModelState.Clear();

            ViewBag.Mensagem = "Itens Cadastrados com sucesso!";

            ModelContaAvulsa mdp = new ModelContaAvulsa();
            mdp.IdConta = idConta.IdConta;

            return View("CadastroContaAvulsa", mdp);
        }


        public ActionResult CadastroContaFidelizada()
        {
            return View();
        }

        #endregion



        #region Cadastros
        public ActionResult CadastroCliente(ModelCliente mdc)
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadastroClienteOld(ModelCliente mdc)
        {
            Cliente c = new Cliente();
            ClienteRepository cr = new ClienteRepository();
            c.CPFCliente = mdc.CPFCliente;
            c.DtaCadastro = DateTime.Now;
            c.EmailCliente = mdc.EmailCliente;
            c.NomeCliente = mdc.NomeCliente;
            c.TpCliente = Cliente.TipoCliente.Regular;
            cr.Insert(c);
            ModelState.Clear();
            ViewBag.Mensagem = "Cliente " + c.NomeCliente + ", cadastrado com sucesso.";
            return View("CadastroCliente");
        }

        #region Usuario

        public ActionResult CadastroUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroUsuario(ModelFuncionario mdf, string ddlPerfil)
        {

            Fucionario f = new Fucionario();
            FuncionarioRepository fr = new FuncionarioRepository();

            f.Login = mdf.Login;
            f.NomeFuncionario = mdf.NomeFuncionario;
            if (ddlPerfil == "1")
                f.Perfil = Fucionario.PerfilFuncionario.Garcom;
            else
                f.Perfil = Fucionario.PerfilFuncionario.Gerente;
            f.Senha = mdf.Senha;

            fr.Insert(f);


            ViewBag.Mensagem = "Usuário " + f.NomeFuncionario + ", cadastrado com sucesso.";
            ModelState.Clear();
            return View();
        } 
        #endregion


        [HttpPost]
        public ActionResult ValidaUsuario(ModelFuncionario mdf)
        {
            Fucionario f = new Fucionario();
            FuncionarioRepository fr = new FuncionarioRepository();

            // primeiro procura na base 
            var validado = fr.ProcuraFuncionario(mdf.Login, mdf.Senha);
            if (validado == true)
            {
                var teste = new List<Fucionario>(fr.DirecionaPorPerfil(mdf.Login, mdf.Senha));
                foreach (var item in teste)
                {
                    if (item.Perfil == Fucionario.PerfilFuncionario.Garcom)
                    {
                        Session.Add("usuariologado", item);
                        return View("CadastroConta");//, new { id = item.Perfil });
                    }
                    else
                    {
                        Session.Add("usuariologado", item);
                        return View("Index");// , new { id = item.Perfil });
                    }
                }

            }
            else
            {
                ViewBag.Mensagem = "Funcionario não cadastrado.";
                return View("Login");
            }
            return View();

            //se achar valida o perfil 

        }

        public ActionResult Logout()
        {

            Session.Remove("usuariologado");
            Session.Abandon();
            return View("Login");
        }
        #endregion

        #region Vinho
        public ActionResult CadastroVinho(ModelVinho mdv)
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroVinhos(ModelVinho mdv)
        {
            Vinho v = new Vinho();
            VinhoRepository vr = new VinhoRepository();

            if (ModelState.IsValid)
            {
                v.NomeVinho = mdv.NomeVinho;
                v.QTDVinhoEstoque = mdv.QTDVinhoEstoque;
                v.TipoVinho = mdv.TipoVinho;
                v.TpProduto = 1;
                vr.Insert(v);

                ViewBag.Mensagem = "Vinho " + v.NomeVinho + ", cadastrado com sucesso.";
            }
            ModelState.Clear();
            return View("CadastroVinho");
        }
        #endregion

        #region Cerveja
        public ActionResult CadastroCerveja()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroCervejas(ModelCerveja mdc)
        {
            Cerveja c = new Cerveja();
            CervejaRepository cv = new CervejaRepository();
            c.NacionalidadeCerveja = mdc.NacionalidadeCerveja;
            c.NomeCerveja = mdc.NomeCerveja;
            c.QTDCervejaEstoque = mdc.QTDCervejaEstoque;
            c.ValorCerveja = mdc.ValorCerveja;
            c.TpProduto = 2;
            cv.Insert(c);
            ViewBag.Mensagem = "Cerveja " + c.NomeCerveja + ", cadastrada com sucesso.";
            ModelState.Clear();

            return View("CadastroCerveja");
        }

        #endregion

        #region Queijo
        public ActionResult CadastroQueijo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroQueijos(ModelQueijo mdq)
        {
            Queijo q = new Queijo();
            QueijoRepository qr = new QueijoRepository();

            q.NomeQueijo = mdq.NomeQueijo;
            q.QTDQueijoEstoque = mdq.QTDQueijoEstoque;
            q.TipoQueijo = mdq.TipoQueijo;
            q.TpProduto = 3;
            qr.Insert(q);

            ViewBag.Mensagem = "Queijo " + q.NomeQueijo + ", cadastrado com sucesso.";

            return View("CadastroQueijo");
        }
        #endregion

        #region Massa
        public ActionResult CadastroMassa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroMassas(ModelMassa mdm)
        {
            Massa m = new Massa();
            MassaRepository mr = new MassaRepository();
            m.NomeMassa = mdm.NomeMassa;
            m.QTDEMassaEstoque = mdm.QTDEMassaEstoque;
            m.TipoMassa = mdm.TipoMassa;
            m.TpProduto = 4;

            ViewBag.Mensagem = "Massa " + m.NomeMassa + ", cadastrada com sucesso.";


            return View("CadastroMassa");
        }

        #endregion


        #region Relatorios
        public ActionResult Relatorios()
        {
            return View();
        }


        public ActionResult RelatorioCliente()
        {
            return View();
        }


        [HttpGet]
        public ActionResult DeletCLI(int id)
        {
            ClienteRepository cr = new ClienteRepository();
            Cliente cl = cr.Obter(id);
            cr.Remove(cl);
            return View("RelatorioCliente");

        }

        [HttpGet]
        public ActionResult EditCli(int id)
        {
            ModelCliente mdc = new ModelCliente();
            ClienteRepository cr = new ClienteRepository();
            Cliente c = cr.Obter(id);
            if (c != null)
            {
                mdc.CPFCliente = c.CPFCliente;
                mdc.EmailCliente = c.EmailCliente;
                mdc.NomeCliente = c.NomeCliente;
                mdc.IdCliente = id;

                return View("AlteraUsuario_", mdc);
            }
            else
            {
                return View();
            }          
        }


        [HttpPost]
        public ActionResult AlterarClienteID(ModelCliente mdc)
        {
            var listaCli = new List<ModelCliente>();
            Cliente c = new Cliente();
            ClienteRepository cr = new ClienteRepository();
            c.CPFCliente = mdc.CPFCliente;
            c.EmailCliente = mdc.EmailCliente;
            c.NomeCliente = mdc.NomeCliente;
            c.IdCliente = mdc.IdCliente;
            c.DtaCadastro = DateTime.Now;
            c.TpCliente = Cliente.TipoCliente.Regular;
            cr.Update(c);

            var modelCli = new ModelCliente();
            foreach (Cliente cCli in cr.ClientesFidelizados())
            {
                
                modelCli.CPFCliente = cCli.CPFCliente;
                modelCli.EmailCliente = cCli.EmailCliente;
                modelCli.NomeCliente = cCli.NomeCliente;
                modelCli.IdCliente = cCli.IdCliente;
                listaCli.Add(modelCli);
            }
            return View("RelatorioCliente");

        }
        #endregion

    }
}