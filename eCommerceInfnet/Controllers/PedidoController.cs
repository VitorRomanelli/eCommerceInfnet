using eCommerceInfnet.Application.Dtos;
using eCommerceInfnet.Application.Interfaces;
using eCommerceInfnet.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceInfnet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPedido(int id)
        {
            var pedido = await _pedidoService.ObterPedidoPorId(id);
            return Ok(pedido);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosOsPedidos()
        {
            var pedidos = await _pedidoService.ObterTodosOsPedidos();
            return Ok(pedidos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] PedidoDto pedidoDto)
        {
            var pedido = new Pedido
            {
                ClienteId = pedidoDto.ClienteId,
                Itens = pedidoDto.Itens.Select(i => new ItemCarrinho
                {
                    ProdutoId = i.ProdutoId,
                    Quantidade = i.Quantidade
                }).ToList()
            };

            await _pedidoService.CriarPedido(pedido);
            return CreatedAtAction(nameof(ObterPedido), new { id = pedido.Id }, pedido);
        }
    }
}
