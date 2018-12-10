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

        public ActionResult Venda_conta_buffet_itens()
        {
            return View();
        }

        public ActionResult CadastroContaAvulsa(ModelContaAvulsa mdp, string id, string buffet)
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

            if (buffet == "0")
            {
                return View("Venda_conta_buffet_itens", mdp);
            }

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

        public ActionResult CadastroContaFidelizadaOld(string IdsCli, string bft)
        {
            ModelContaAvulsa mdc = new ModelContaAvulsa();
            mdc.IdCliente = int.Parse(IdsCli);
            // mdc.Buffet = bft;
            return RedirectToAction("CadastroContaAvulsa", new { id = mdc.IdCliente, buffet = bft });
        }

        public ActionResult TheEndContaAberta(int id)
        {
            ContaRepository cr = new ContaRepository();
            VendasRepository vr = new VendasRepository();
            Vendas v = new Vendas();

            Conta c = cr.Obter(id);
            c.DataConta = c.DataConta;
            c.IdCliente = c.IdCliente;
            c.IdConta = c.IdConta;
            c.NumeroMesa = c.NumeroMesa;
            c.TpConta = c.TpConta;
            c.ValorConta = c.ValorConta;
            c.StatusConta = true;
            cr.Update(c);
            v.DataVenda = DateTime.Now;
            v.ValorVenda = c.ValorConta;
            vr.Insert(v);
            return View("ContasAbertas_");
        }


        public ActionResult VerificarContaAberta(int idConta)
        {

            return View("");
        }

        #region somatorio itens conta
        public decimal SomaItensConta(int idConta, int tpProduto, int qtdItem, string nomeProduto, int nMesa)
        {
            CervejaRepository cr = new CervejaRepository();
            VinhoRepository vr = new VinhoRepository();
            BuffetRepository br = new BuffetRepository();
            QueijoRepository qr = new QueijoRepository();
            MassaRepository mr = new MassaRepository();
            ContaRepository contaR = new ContaRepository();
            decimal valor = 0;
            decimal valorCervas = 0;
            decimal valorQueijos = 0;
            decimal valorPratos = 0;
            decimal valorVinhos = 0;
            decimal valorBuffet = 0;

            #region Cerva
            if (tpProduto == 2)
            {
                var retornoCerva = cr.listCerva(nomeProduto);
                foreach (var item in retornoCerva)
                {
                    valorCervas = Convert.ToDecimal(item.ValorCerveja) * Convert.ToDecimal(qtdItem);
                }

            }
            #endregion

            #region buffet
            if (tpProduto == 5)
            {
                var retornoBuffet = br.listBuffet(nomeProduto);
                foreach (var item in retornoBuffet)
                {
                    valorBuffet = Convert.ToDecimal(item.ValorBuffet) * Convert.ToDecimal(qtdItem);
                }
            }
            #endregion

            #region Prato
            if (tpProduto == 4)
            {
                var retornoPrato = mr.listPrato(nomeProduto);
                foreach (var item in retornoPrato)
                {
                    valorPratos = Convert.ToDecimal(item.Valor) * Convert.ToDecimal(qtdItem);
                }
            }
            #endregion

            #region queijo
            if (tpProduto == 3)
            {
                var retornoQueijo = qr.listQueijo(nomeProduto);
                foreach (var item in retornoQueijo)
                {
                    valorQueijos = Convert.ToDecimal(item.Valor) * Convert.ToDecimal(qtdItem);
                }
            }
            #endregion

            #region Vinho
            if (tpProduto == 1)
            {
                var retornoVinho = vr.listVinho(nomeProduto);
                foreach (var item in retornoVinho)
                {
                    valorVinhos = Convert.ToDecimal(item.ValorVinho) * Convert.ToDecimal(qtdItem);
                }
                #endregion              
            }
            valor = valorBuffet + valorCervas + valorPratos + valorQueijos + valorVinhos;


            Conta c = contaR.Obter(idConta);
            c.IdCliente = c.IdCliente;
            c.IdConta = c.IdConta;
            c.NumeroMesa = c.NumeroMesa;
            c.StatusConta = c.StatusConta;
            c.TpConta = c.TpConta;
            c.ValorConta = c.ValorConta + valor;
            c.DataConta = c.DataConta;
            contaR.Update(c);

            return valor;
        }
        #endregion

        [HttpPost]
        public ActionResult CadastroContaAvulsaOld(IEnumerable<string> IdsCerva, IEnumerable<string> IdsMassas,
            IEnumerable<string> IdsVinhos, IEnumerable<string> IdQueijos, string qtdCerva, string qtdMassa,
            string qtdVinho, string qtdQueijo, string nMesa, IEnumerable<string> IdsBuffet)
        {
            ItemConta itemConta = new ItemConta();
            ItemRepository ir = new ItemRepository();
            ContaRepository crc = new ContaRepository();
            Conta crConta = new Conta();
            var idConta = crc.UltimaConta();

            //inclui numero da mesa na conta
            #region inclui numero da mesa na conta
            crConta.DataConta = idConta.DataConta;
            crConta.IdCliente = idConta.IdCliente;
            crConta.IdConta = idConta.IdConta;
            if (nMesa == null)
                crConta.NumeroMesa = 0;
            else
                crConta.NumeroMesa = int.Parse(nMesa);
            crConta.StatusConta = idConta.StatusConta;
            crConta.TpConta = idConta.TpConta;
            crConta.ValorConta = idConta.ValorConta;
            crc.Update(crConta);
            #endregion

            if (IdsBuffet != null)
            {
                foreach (var item in IdsBuffet)
                {
                    itemConta.IdConta = idConta.IdConta;
                    itemConta.TpProduto = 5;
                    itemConta.NomeProduto = item.ToString();
                    itemConta.QtdItem = 1;
                    ir.Insert(itemConta);
                    SomaItensConta(idConta.IdConta, 5, itemConta.QtdItem, itemConta.NomeProduto, crConta.NumeroMesa);

                }
            }
            if (IdsCerva != null)
            {
                foreach (var item in IdsCerva)
                {
                    itemConta.IdConta = idConta.IdConta;
                    itemConta.TpProduto = 2;
                    itemConta.NomeProduto = item.ToString();
                    itemConta.QtdItem = int.Parse(qtdCerva);
                    ir.Insert(itemConta);
                    SomaItensConta(idConta.IdConta, 2, itemConta.QtdItem, itemConta.NomeProduto, crConta.NumeroMesa);
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
                    SomaItensConta(idConta.IdConta, 3, itemConta.QtdItem, itemConta.NomeProduto, crConta.NumeroMesa);
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
                    SomaItensConta(idConta.IdConta, 1, itemConta.QtdItem, itemConta.NomeProduto, crConta.NumeroMesa);
                }
            }
            //massas
            if (IdsMassas != null)
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
                        SomaItensConta(idConta.IdConta, 4, itemConta.QtdItem, itemConta.NomeProduto, crConta.NumeroMesa);
                    }
                }
            }

            ModelState.Clear();

            ViewBag.Mensagem = "Itens Cadastrados com sucesso!";

            ModelContaAvulsa mdp = new ModelContaAvulsa();
            mdp.IdConta = idConta.IdConta;

            if (IdsBuffet != null)
            {
                return View("Venda_conta_buffet");
            }

            return View("ContasAbertas_");
        }



        public ActionResult EditContaAberta(int id, int nMesa)
        {
            return RedirectToAction("EditarContaAberta_", new { idContaOpem = id, nMesa = nMesa });
        }


        public ActionResult EditarContaAberta_(int idContaOpem, int nMesa)
        {
            ItemConta itemConta = new ItemConta();
            ItemRepository ir = new ItemRepository();
            ContaRepository crc = new ContaRepository();
            Conta crConta = new Conta();



            return View();
        }


        public ActionResult EditarContaAberta_Old(IEnumerable<string> IdsCerva, IEnumerable<string> IdsMassas,
            IEnumerable<string> IdsVinhos, IEnumerable<string> IdQueijos, string qtdCerva, string qtdMassa,
            string qtdVinho, string qtdQueijo, string nMesa, IEnumerable<string> IdsBuffet, string idContaOpem)
        {
            ItemConta itemConta = new ItemConta();
            ItemRepository ir = new ItemRepository();
            ContaRepository crc = new ContaRepository();
            Conta crConta = new Conta();

            if (IdsBuffet != null)
            {
                foreach (var item in IdsBuffet)
                {
                    itemConta.IdConta = int.Parse(idContaOpem);
                    itemConta.TpProduto = 5;
                    itemConta.NomeProduto = item.ToString();
                    itemConta.QtdItem = 1;
                    ir.Insert(itemConta);
                    SomaItensConta(int.Parse(idContaOpem), 5, itemConta.QtdItem, itemConta.NomeProduto, int.Parse(nMesa));
                }
            }
            if (IdsCerva != null)
            {
                foreach (var item in IdsCerva)
                {
                    itemConta.IdConta = int.Parse(idContaOpem);
                    itemConta.TpProduto = 2;
                    itemConta.NomeProduto = item.ToString();
                    itemConta.QtdItem = int.Parse(qtdCerva);
                    ir.Insert(itemConta);
                    SomaItensConta(int.Parse(idContaOpem), 2, itemConta.QtdItem, itemConta.NomeProduto, int.Parse(nMesa));


                }
            }
            //queijos
            if (IdQueijos != null)
            {
                foreach (var item in IdQueijos)
                {
                    itemConta.IdConta = int.Parse(idContaOpem);
                    itemConta.TpProduto = 3;
                    itemConta.NomeProduto = item.ToString();
                    itemConta.QtdItem = int.Parse(qtdQueijo);
                    ir.Insert(itemConta);
                    SomaItensConta(int.Parse(idContaOpem), 3, itemConta.QtdItem, itemConta.NomeProduto, int.Parse(nMesa));

                }
            }
            //vinhos
            if (IdsVinhos != null)
            {
                foreach (var item in IdsVinhos)
                {
                    itemConta.IdConta = int.Parse(idContaOpem);
                    itemConta.TpProduto = 1;
                    itemConta.NomeProduto = item.ToString();
                    itemConta.QtdItem = int.Parse(qtdVinho);
                    ir.Insert(itemConta);
                    SomaItensConta(int.Parse(idContaOpem), 1, itemConta.QtdItem, itemConta.NomeProduto, int.Parse(nMesa));

                }
            }
            //massas
            if (IdsMassas != null)
            {
                foreach (var item in IdsMassas)
                {
                    if (item != "")
                    {
                        itemConta.IdConta = int.Parse(idContaOpem);
                        itemConta.TpProduto = 4;
                        itemConta.NomeProduto = item.ToString();
                        itemConta.QtdItem = int.Parse(qtdMassa);
                        ir.Insert(itemConta);
                        SomaItensConta(int.Parse(idContaOpem), 4, itemConta.QtdItem, itemConta.NomeProduto, int.Parse(nMesa));
                    }
                }
            }

            ModelState.Clear();

            ViewBag.Mensagem = "Itens Cadastrados com sucesso!";

            return View("ContasAbertas_");
        }


        public ActionResult DeletContaAberta(int id)
        {
            ContaRepository cr = new ContaRepository();
            ItemRepository ir = new ItemRepository();
            Conta c = cr.Obter(id);
            cr.Remove(c);
            List<ItemConta> listItens = new List<ItemConta>(ir.ListContasAbertas(id));

            foreach (var item in listItens)
            {
                ItemConta ic = ir.Obter(item.IdItem);
                ir.Remove(ic);
            }

            return View("ContasAbertas_");
        }


        public ActionResult ContasAbertas_()
        {
            return View();
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
            ModelUsuario mdu = new ModelUsuario();
            // primeiro procura na base 
            var validado = fr.ProcuraFuncionario(mdf.Login, mdf.Senha);
            if (validado == true)
            {
                var teste = new List<Fucionario>(fr.DirecionaPorPerfil(mdf.Login, mdf.Senha));
                foreach (var item in teste)
                {
                    if (item.Perfil == Fucionario.PerfilFuncionario.Garcom)
                    {
                       // ModelUsuario mdu = new ModelUsuario();
                        mdu.Perfil = 1;

                        Session.Add("usuariologado", item);
                        return View("IndexGarçom",mdu);//, new { id = item.Perfil });
                    }
                    else
                    {
                        // ModelUsuario mdu = new ModelUsuario();
                        mdu.Perfil = 2;
                        Session.Add("usuariologado", item);
                        return View("Index",mdu);// , new { id = item.Perfil });
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
                v.Nacionalidade = mdv.Nacionalidade;
                v.ValorVinho = Convert.ToDecimal(mdv.ValorVinho);
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
        public ActionResult IncluiCervejas(IEnumerable<string> nomes)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroCervejas(ModelCerveja mdc)
        {
            Cerveja c = new Cerveja();
            CervejaRepository cv = new CervejaRepository();
            if (ModelState.IsValid)
            {
                c.NacionalidadeCerveja = mdc.NacionalidadeCerveja;
                c.NomeCerveja = mdc.NomeCerveja;
                c.QTDCervejaEstoque = mdc.QTDCervejaEstoque;
                c.ValorCerveja = mdc.ValorCerveja;
                c.TpProduto = 2;
                cv.Insert(c);
                ViewBag.Mensagem = "Cerveja " + c.NomeCerveja + ", cadastrada com sucesso.";
                ModelState.Clear();
            }

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
            q.Nacionalidade = mdq.Nacionalidade;
            q.Valor = Convert.ToDecimal(mdq.ValorQueijo);
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
            // m.QTDEMassaEstoque = mdm.QTDEMassaEstoque;
            // m.TipoMassa = mdm.TipoMassa;
            m.Valor =
             m.TpProduto = 4;
            mr.Insert(m);

            ViewBag.Mensagem = "Massa " + m.NomeMassa + ", cadastrada com sucesso.";


            return View("CadastroMassa");
        }

        #endregion

        #region buffet
        public ActionResult CadastroBuffet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroBuffet(ModelBuffet mdb)
        {
            Buffet b = new Buffet();
            BuffetRepository br = new BuffetRepository();

            b.NacionalidadeBuffet = mdb.NacionalidadeBuffet;
            b.NomeBuffet = mdb.NomeBuffet;
            b.TipoBuffet = mdb.TipoBuffet;
            b.ValorBuffet = mdb.ValorBuffet;
            b.TpProduto = 5;
            br.Insert(b);
            ViewBag.Mensagem = "Serviço " + b.NomeBuffet + ", cadastrada com sucesso.";
            ModelState.Clear();


            return View("CadastroBuffet");


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
        public ActionResult RelatorioUsuario()
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
        public ActionResult DeletFunc(int id)
        {
            FuncionarioRepository fr = new FuncionarioRepository();
            Fucionario f = fr.Obter(id);
            fr.Remove(f);
            return View("RelatorioUsuario");

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

        [HttpGet]
        public ActionResult EditFunc(int id)
        {
            ModelFuncionario mdf = new ModelFuncionario();
            FuncionarioRepository fr = new FuncionarioRepository();
            Fucionario f = fr.Obter(id);
            if (f != null)
            {
                mdf.IdFuncionario = id;
                mdf.Login = f.Login;
                mdf.NomeFuncionario = f.NomeFuncionario;
                if (f.Perfil == Fucionario.PerfilFuncionario.Garcom)
                    mdf.Perfil = 1;
                else
                    mdf.Perfil = 2;
                mdf.Senha = f.Senha;
                return View("AlteraFuncionario_", mdf);
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult AlterarFuncionarioID(ModelFuncionario mdf)
        {
            var listaFunc = new List<ModelFuncionario>();
            Fucionario f = new Fucionario();
            FuncionarioRepository fr = new FuncionarioRepository();
            f.IdFuncionario = mdf.IdFuncionario;
            f.Login = mdf.Login;
            f.NomeFuncionario = mdf.NomeFuncionario;
            if (mdf.Perfil == 1)
                f.Perfil = Fucionario.PerfilFuncionario.Garcom;
            else
                f.Perfil = Fucionario.PerfilFuncionario.Gerente;
            f.Senha = mdf.Senha;
            fr.Update(f);

            var modelFunc = new ModelFuncionario();
            foreach (Fucionario fFunc in fr.ObterTodos())
            {
                modelFunc.Login = fFunc.Login;
                modelFunc.IdFuncionario = fFunc.IdFuncionario;
                modelFunc.NomeFuncionario = fFunc.NomeFuncionario;
                if (fFunc.Perfil == Fucionario.PerfilFuncionario.Garcom)
                    modelFunc.Perfil = 1;
                else
                    modelFunc.Perfil = 2;
                modelFunc.Senha = fFunc.Senha;
                listaFunc.Add(modelFunc);

            }
            return View("RelatorioUsuario");
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

        #region RelatorioProduto
        public ActionResult Relatorio_Produtos()
        {
            return View();
        }


        public ActionResult RelatorioVendaVinho()
        {
            return View();
        }
        #endregion

        #region MenuProdCadastro
        public ActionResult MenuProdCadastro()
        {
            return View();
        }

        public ActionResult CervejasCadastradas()
        {
            return View();
        }

        public ActionResult QueijosCadastrados()
        {
            return View();
        }

        public ActionResult VinhosCadastrados()
        {
            return View();
        }

        public ActionResult PratosCadastrados()
        {
            return View();
        }

        public ActionResult BuffetCadastrado()
        {
            return View();
        }



        #endregion

        #region vendabuffet
        public ActionResult Venda_conta_buffet()
        {
            return View();
        }
        #endregion

    }
}