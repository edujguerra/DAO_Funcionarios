﻿using DAO_Funcionarios.Models;
using Microsoft.AspNetCore.Mvc;

namespace DAO_Funcionarios.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioDAL funci;
        public FuncionarioController(IFuncionarioDAL funcionario)
        {
            funci = funcionario;
        }

        public IActionResult Index()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            listaFuncionarios = funci.GetAllFuncionarios().ToList();

            return View(listaFuncionarios);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Funcionario funcionario = funci.GetFuncionario(id);

            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                funci.AddFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Funcionario funcionario = funci.GetFuncionario(id);

            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                funci.UpdateFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Funcionario funcionario = funci.GetFuncionario(id);

            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            funci.DeleteFuncionario(id);
            return RedirectToAction("Index");
        }
    }
}
