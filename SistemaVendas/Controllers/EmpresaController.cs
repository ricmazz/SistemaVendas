using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVendas.Context;

namespace SistemaVendas.Controllers
{
    public class EmpresaController : Controller
    {
        SistemaVendasDatabaseEntities dbObj = new SistemaVendasDatabaseEntities();

        // GET: Cadastro de Empresas
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Empresa
        public ActionResult Lista()
        {
            var listaEmpresa = dbObj.Tb_Empresa.ToList();
            return View(listaEmpresa);
        }

        // POST: Empresa
        [HttpPost]
        public ActionResult CadastrarEmpresa(Tb_Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                Tb_Empresa obj = new Tb_Empresa();
                obj.IdUsuarioCadastro = empresa.IdUsuarioCadastro;
                obj.RazaoSocial = empresa.RazaoSocial;
                obj.Cnpj = empresa.Cnpj;
                obj.Endereco = empresa.Endereco;
                obj.Telefone = empresa.Telefone;

                dbObj.Tb_Empresa.Add(obj);
                dbObj.SaveChanges();
            }

            ModelState.Clear();

            return RedirectToAction("Lista");
        }
    }
}