using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wcf_PorductosNetofice.Models;


namespace wcf_PorductosNetofice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Cambio Hecho desde Otro PC
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            
            ProductoNetoficeEntities db = new ProductoNetoficeEntities();
            List<ObjProducto> ListProd = new List<ObjProducto>();
            foreach (var item in db.Tbl_Productos.ToList())
            {
                //Verico impares
                if (item.Id % 2 == 0)
                    ViewData["color"] = "style=color:red;";
                else
                    ViewData["color"] = "style=color:green;";
                ObjProducto obj = new ObjProducto();
                obj.Id = item.Id;
                obj.Cantidad = item.Cantidad;
                obj.Codigo = item.Codigo;
                obj.Descripcion = item.Descripcion;
                obj.Estado = item.Estado;
                obj.Fecha_Creacion = item.Fecha_Creacion;
                obj.Usuario = item.Usuario;
                obj.TransactionId = item.TransactionId;
                ListProd.Add(obj);
            }
            
            return View(ListProd);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: p/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Codigo, Descripcion, Cantidad, Estado, Fecha_Creacion, Usuario")] ObjProducto prod)
        {
            try
            {
                int accion = 1;
                Models.dal insertar = new Models.dal();
                insertar.insertar(accion,prod);
                return RedirectToAction("Contact");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            int accion = 2;
            ObjProducto obj = new ObjProducto();
            Models.dal edit = new Models.dal();
            
            return View(edit.editarListar(accion, id));
        }

        // POST: p/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Codigo, Descripcion, Cantidad, Estado, Fecha_Creacion, Usuario")] ObjProducto prod)
        {
            try
            {
                int accion = 3;
                Models.dal insertar = new Models.dal();
                prod.Id = id;
                insertar.insertar(accion, prod);

                return RedirectToAction("Contact");
            }
            catch
            {
                return View();
            }
        }
    }
}