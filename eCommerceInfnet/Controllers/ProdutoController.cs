using eCommerceInfnet.Application.Dtos;
using eCommerceInfnet.Application.Interfaces;
using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceInfnet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterProduto(int id)
        {
            var produto = await _produtoService.ObterProdutoPorId(id);
            return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosOsProdutos()
        {
            var produtos = await _produtoService.ObterTodosOsProdutos();
            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] ProdutoDto produtoDto)
        {
            var preco = new Preco(produtoDto.Preco);
            var categoria = new Categoria(produtoDto.Categoria);

            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Preco = preco,
                Categoria = categoria
            };

            await _produtoService.CriarProduto(produto);
            return CreatedAtAction(nameof(ObterProduto), new { id = produto.Id }, produto);
        }
    }
}
