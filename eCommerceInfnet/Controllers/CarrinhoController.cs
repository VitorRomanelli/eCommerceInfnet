using eCommerceInfnet.Application.Dtos;
using eCommerceInfnet.Application.Interfaces;
using eCommerceInfnet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceInfnet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhoController(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> ObterCarrinho(int clienteId)
        {
            var carrinho = await _carrinhoService.ObterCarrinhoPorClienteId(clienteId);
            return Ok(carrinho);
        }

        [HttpPost("{clienteId}/adicionar")]
        public async Task<IActionResult> AdicionarItem(int clienteId, [FromBody] ItemCarrinhoDto item)
        {
            var itemCarrinho = new ItemCarrinho 
            {
                ProdutoId = item.ProdutoId,
                Quantidade = item.Quantidade,
            };

            await _carrinhoService.AdicionarItemAoCarrinho(itemCarrinho, clienteId);
            return NoContent();
        }
    }
}
