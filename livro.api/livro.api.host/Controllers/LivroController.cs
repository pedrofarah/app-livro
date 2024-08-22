using livro.api.domain.Dto;
using livro.api.domain.Interfaces.ILivroQueryService;
using livro.api.domain.Interfaces.LivroCreateService;
using livro.api.domain.Interfaces.LivroDeleteService;
using livro.api.domain.Interfaces.LivroUpdateService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace livro.api.host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LivroController : ControllerBase
    {

        private readonly ILivroCreateService _livroCreateService;

        private readonly ILivroUpdateService _livroUpdateService;

        private readonly ILivroDeleteService _livroDeleteService;

        private readonly ILivroQueryService _livroQueryService;

        public LivroController(
            ILivroCreateService livroCreateService,
            ILivroUpdateService livroUpdateService,
            ILivroDeleteService livroDeleteService,
            ILivroQueryService livroQueryService
        )
        {
            _livroCreateService = livroCreateService;
            _livroUpdateService = livroUpdateService;
            _livroDeleteService = livroDeleteService;
            _livroQueryService = livroQueryService;
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] LivroQueryDto query, CancellationToken cancellationToken) =>
            Ok(await _livroQueryService.Handle(query, cancellationToken));

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(string id, CancellationToken cancellationToken) =>
            Ok(await _livroQueryService.Handle(new LivroQueryDto { Id = Guid.Parse(id) }, cancellationToken));

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] LivroCreateDto value, CancellationToken cancellationToken)
        {
            var resultID = await _livroCreateService.Handle(value, cancellationToken);
            return Created("", resultID);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromBody] LivroUpdateDto value, CancellationToken cancellationToken)
        {
            await _livroUpdateService.Handle(value, cancellationToken);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await _livroDeleteService.Handle(new LivroDeleteDto { Id = Guid.Parse(id) }, cancellationToken);
            return Ok();
        }

    }
}
