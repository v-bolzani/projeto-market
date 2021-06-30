using System.Linq;
using Market.Data;
using Market.DTO;
using Market.Models;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly ApplicationDbContext database;
        public FornecedoresController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(FornecedorDTO fornecedorTemporario){
            if(ModelState.IsValid){
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = fornecedorTemporario.Nome;
                fornecedor.Email = fornecedorTemporario.Email;
                fornecedor.Telefone = fornecedorTemporario.Telefone;
                fornecedor.Status = true;
                database.Fornecedores.Add(fornecedor);
                database.SaveChanges();
                return RedirectToAction("Fornecedores", "Gestao");
            }
            else{
                return View("../Gestao/NovoFornecedor");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(FornecedorDTO fornecedorTemporario){
            if(ModelState.IsValid){
                var fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == fornecedorTemporario.Id);
                fornecedor.Nome = fornecedorTemporario.Nome;
                fornecedor.Email = fornecedorTemporario.Email;
                fornecedor.Telefone = fornecedorTemporario.Telefone;
                database.SaveChanges();
                return RedirectToAction("Fornecedores", "Gestao");
            }
            else{
                return View("../Gestao/EditarFornecedor");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id){
            if(id > 0){
                var fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == id);
                fornecedor.Status = false;
                database.SaveChanges(); 
            }
            return RedirectToAction("Fornecedores", "Gestao");
        }
    }
}