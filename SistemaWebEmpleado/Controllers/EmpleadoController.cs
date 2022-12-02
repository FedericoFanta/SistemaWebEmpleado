using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleado.Data;
using SistemaWebEmpleado.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;



namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoContext _context;

        public EmpleadoController(EmpleadoContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            return View(_context.Empleados.ToList());
        }

        //GET: /Empleado/Create
        public IActionResult Create()
        {
            Empleado empleado = new Empleado();
            return View("Create", empleado);
        }

        //POST: /Empleado/Create
        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(empleado);
            }
        }
        

        [HttpGet("/empleado/titulo/{titulo}")]
        // GET: 
        public IActionResult ListaPorTitulo(string titulo)
        {
            List<Empleado> lista = (from e in _context.Empleados
                                    where e.Titulo == titulo
                                    select e).ToList();
            return View("Index", lista);
        }

        [HttpGet("/empleado/traeruno/{id}")]
        // GET: 
        public IActionResult TraerUno(int id)
        {
            List<Empleado> lista = (from e in _context.Empleados
                                    where e.Id == id
                                    select e).ToList();
            return View("Index", lista);
        }

        public IActionResult Edit(int id)
        {
            var empleado = _context.Empleados.SingleOrDefault(m => m.Id == id);//busca el parametro
            empleado.Nombre = "Brandon";
            empleado.Apellido = "Jhosep";//actualiza
            _context.Update(empleado);
            _context.SaveChanges(); //guarda en la db
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var empleado = _context.Empleados.SingleOrDefault(m => m.Id == id); //busca
            _context.Empleados.Remove(empleado); //elimina
            _context.SaveChanges(); //guarda los cambios
            return RedirectToAction(nameof(Index));
        }
    }
}
