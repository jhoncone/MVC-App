using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiBotica.SolPedido.Entidades.Core;
using MiBotica.SolPedido.LogicaNegocio.Core;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MiBotica.SolPedido.AccesoDatos.Core;
using MiBotica.SolPedido.Utiles.Helpers;

namespace MiBotica.SolPedido.Cliente.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<Usuario> usuario = new List<Usuario>();
            usuario = new UsuarioLN().ListaUsuarios();

            return View(usuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            Usuario usuario = new Usuario();
            /*
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = new UsuarioLN().DetalleUsuario(usuario);

            return View(usuarios);
            */
            //List<Usuario> usuario = new List<Usuario>();
            usuario = new UsuarioLN().DetalleUsuario(id);

            return View(usuario);

        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            Usuario usuario = new Usuario();
            return View(usuario);
            //return View();
        }

        // POST: Usuario/Create

       

        //
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(Usuario usuario)
        {

            //proban


            //


             try
            {

           // byte[] byteArr = { 0, 16, 104, 213 };

            // TODO: Add insert logic here
           // Usuario usuario = new Usuario();
           // usuario.ClaveTexto ="nvis";
                 usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
                new UsuarioLN().InsertarUsuario(usuario);
                return RedirectToAction("Index");



                ///return RedirectToAction("Index");
           }
            catch
            {
                return View();
            }
           
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {

            Usuario usuario = new Usuario(); 
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
            // TODO: Add update logic here
            usuario.Clave = EncriptacionHelper.EncriptarByte(usuario.ClaveTexto);
            new UsuarioLN().EditarUsuario(id,usuario);
                return RedirectToAction("Index");
           }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuario = new Usuario();
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Usuario usuario)
        {
            //try
            // {
            // TODO: Add delete logic here
            //usuario.Clave = EncriptacionHelper.EncriptarByte(null);
            new UsuarioLN().DeleteUsuario(id,usuario);
                return RedirectToAction("Index");
           /* }
            catch
            {
                return View();
            }*/
        }

    }
}
