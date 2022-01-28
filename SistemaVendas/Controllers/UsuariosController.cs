using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaVendas.Context;

namespace SistemaVendas.Controllers
{
    public class UsuariosController : Controller
    {
        SistemaVendasDatabaseEntities dbObj = new SistemaVendasDatabaseEntities();

        // GET: Cadastro de Usuários
        public ActionResult Cadastro()
        {
            return View();
        }

        // GET: Usuarios
        public ActionResult Lista()
        {
            var listaUsuarios = dbObj.Tb_Usuario.ToList();

            return View(listaUsuarios);
        }

        // POST: Usuarios
        [HttpPost]
        public ActionResult CadastrarUsuario(Tb_Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Tb_Usuario obj = new Tb_Usuario();
                obj.Nome = usuario.Nome;
                obj.Cpf = usuario.Cpf;
                obj.Telefone = usuario.Telefone;
                obj.DesLogin = usuario.DesLogin;
                obj.Senha = usuario.Senha;

                dbObj.Tb_Usuario.Add(obj);
                dbObj.SaveChanges();
            }

            ModelState.Clear();

            return RedirectToAction("Lista");
        }
    }
}