using EncuestaProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace EncuestaProject.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(CUENTA cuenta, string ReturnURL) //(CUENTNA cuenta, string URL
        {
            if (isValid(cuenta))
            {

                FormsAuthentication.SetAuthCookie(cuenta.usuario, false);
                if(ReturnURL != null)
                {
                    return Redirect(ReturnURL);
                }
                //redireccionar al Formulario
                return RedirectToAction("Index", "Encuesta");
            }
            TempData["mensaje"] = "Credenciales Incorrectas";
            //return RedirectToAction("index", "Home");

            return View(cuenta);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool isValid(CUENTA cuenta)
        {
            return cuenta.Autenticar();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Register(CUENTA cuenta)
        {
            if (ModelState.IsValid)
            {
                //utilizando metodos de incriptacion para la contrasena 
                var nuevaCuenta = new CUENTA { usuario = cuenta.usuario, password = EncMD5(cuenta.password) };
                EncuestaModel em = new EncuestaModel();

                em.CUENTA.AddOrUpdate(nuevaCuenta);
                em.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["mensaje"] = "valores Incorrectos";

            }
            return View(cuenta);
        }

        private static string EncMD5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes); 
            //password = BitConverter.ToString(encodedBytes).Replace("-", "");
            //var result = password.ToLower();
            //return 
        }
    }
}