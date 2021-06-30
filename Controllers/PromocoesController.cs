using System.Linq;
using Market.Data;
using Market.DTO;
using Market.Models;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    public class PromocoesController : Controller
    {
        private readonly ApplicationDbContext database;
        public PromocoesController(ApplicationDbContext database){
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(PromocaoDTO promocaoTemporaria){
            if(ModelState.IsValid){
                Promocao promocao = new Promocao();
                promocao.Nome = promocaoTemporaria.Nome;
                promocao.Produto = database.Produtos.First(p => p.Id == promocaoTemporaria.ProdutoId);
                promocao.Porcentagem = promocaoTemporaria.Porcentagem;
                promocao.Status = true;
                database.Promocoes.Add(promocao);
                database.SaveChanges();
                return RedirectToAction("Promocoes", "Gestao");
            }
            else{
                ViewBag.Produtos = database.Produtos.ToList();
                return View("../Gestao/NovaPromocao");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(PromocaoDTO promocaoTemporaria){
            if(ModelState.IsValid){
                var promocao = database.Promocoes.First(p => p.Id == promocaoTemporaria.Id);
                promocao.Nome = promocaoTemporaria.Nome;
                promocao.Porcentagem = promocaoTemporaria.Porcentagem;
                promocao.Produto = database.Produtos.First(p => p.Id == promocaoTemporaria.ProdutoId);
                database.SaveChanges();
                return RedirectToAction("Promocoes", "Gestao");
            }
            else{
                return RedirectToAction("Promocoes", "Gestao");
            }
        }
        
        public IActionResult Deletar(int id){
            if(id > 0){
                var promocao = database.Promocoes.First(p => p.Id == id);
                promocao.Status = false;
                database.SaveChanges(); 
            }
            return RedirectToAction("Promocoes", "Gestao");
        }
    }
}