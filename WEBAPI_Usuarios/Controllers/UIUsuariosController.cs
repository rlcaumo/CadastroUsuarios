using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBAPI_Usuarios.Controllers
{
    public class UIUsuariosController : Controller
    {
        // GET: UIUsuarios
        public ActionResult Cadastro()
        {
            return View();
        }
    }
}