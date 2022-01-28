using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVendas.Context;

namespace SistemaVendas.Controllers
{
    public class VendasController : Controller
    {
        SistemaVendasDatabaseEntities dbObj = new SistemaVendasDatabaseEntities();

        // GET: Vendas
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Vendas
        public ActionResult Lista()
        {
            var listaVendas = dbObj.Tb_Vendas.ToList();

            return View(listaVendas);
        }

        // POST: Usuarios
        [HttpPost]
        public ActionResult CadastrarVenda(Tb_Vendas venda)
        {
            //if (ModelState.IsValid)
            //{
            Tb_Vendas obj = new Tb_Vendas();
            obj.DataVenda = venda.DataVenda;
            obj.EmitidoNF = venda.EmitidoNF;
            obj.IdEmpresa = venda.IdEmpresa;
            obj.IdUsuarioCadastro = venda.IdUsuarioCadastro;
            obj.ValorVenda = venda.ValorVenda;

            dbObj.Tb_Vendas.Add(obj);
            dbObj.SaveChanges();
            //}

            ModelState.Clear();

            return RedirectToAction("Lista");
        }
    }
}