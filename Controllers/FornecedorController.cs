using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudFornecedor.Models;
using CrudFornecedor.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CrudFornecedor.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;

        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        public IActionResult Index()
        {
            var fornecedores = _fornecedorRepositorio.BuscarTodos();
            return View(fornecedores);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Fornecedor fornecedor)
        {
            try
            {
                if(ModelState.IsValid)
            {
                _fornecedorRepositorio.Adicionar(fornecedor);
                TempData["MensagemSucesso"] = "Salvo com sucesso!";
                return RedirectToAction("Index");
            }
            
            return View(fornecedor);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Algo deu errado!, detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            Fornecedor fornecedor =  _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }
        [HttpPost]
        public IActionResult Alterar(Fornecedor fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fornecedorRepositorio.Atualizar(fornecedor);
                    TempData["MensagemSucesso"] = "Alterado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View("Editar", fornecedor);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Algo deu errado!, detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
        
        public IActionResult ApagarConfirmacao(int id)
        {
            Fornecedor fornecedor =  _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _fornecedorRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Excluído com sucesso!"; 
                }
                else
                {
                    TempData["MensagemErro"] = $"Algo deu errado!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Algo deu errado! mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}