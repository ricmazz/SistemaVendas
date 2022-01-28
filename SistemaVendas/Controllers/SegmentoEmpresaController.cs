using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVendas.Context;

namespace SistemaVendas.Controllers
{
    public class SegmentoEmpresaController : Controller
    {
        SistemaVendasDatabaseEntities dbObj = new SistemaVendasDatabaseEntities();

        // GET: Cadastro de Segmentos
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: SegmentoEmpresa
        public ActionResult Lista()
        {
            var listaSegmentoEmpresa = dbObj.Tb_SegmentoEmpresa.ToList();
            return View(listaSegmentoEmpresa);
        }

        // POST: SegmentoEmpresa
        [HttpPost]
        public ActionResult CadastrarSegmentoEmpresa(Tb_SegmentoEmpresa segmentoEmpresa)
        {
            if (ModelState.IsValid)
            {
                Tb_SegmentoEmpresa obj = new Tb_SegmentoEmpresa();
                obj.Ativo = segmentoEmpresa.Ativo;
                obj.DesSegmento = segmentoEmpresa.DesSegmento;
                obj.IdEmpresa = segmentoEmpresa.IdEmpresa;
                
                dbObj.Tb_SegmentoEmpresa.Add(obj);
                dbObj.SaveChanges();
            }

            ModelState.Clear();

            return RedirectToAction("Lista");
        }
    }
}