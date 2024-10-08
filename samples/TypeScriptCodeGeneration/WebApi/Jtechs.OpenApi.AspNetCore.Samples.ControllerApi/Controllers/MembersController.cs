using Jtechs.OpenApi.AspNetCore.Samples.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Jtechs.OpenApi.AspNetCore.Samples.ControllerApi.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes("application/json")]
[Produces("application/json")]
public class MembersController : ControllerBase
{
    [HttpGet(Name = "ListMembers")]
    [ProducesResponseType<IEnumerable<Member>>(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Member>> List([FromQuery] MemberQueryParameter queryParameter)
    {
        return Ok(new List<Member>());
    }

    [HttpGet(template: "{id}", Name = "GetMember")]
    [ProducesResponseType<Member>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] Guid id)
    {
        return NotFound();
    }

    [HttpPost(Name = "CreateMember")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Create([FromBody][Required] Member newMember)
    {
        return Created($"/Members/{newMember.Id}", null);
    }

    [HttpPut(template: "{id}", Name = "UpdateMember")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Update([FromRoute] Guid id, [FromBody][Required] Member existingMember)
    {
        return Ok();
    }

    [HttpDelete(template: "{id}", Name = "DeleteMember")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        return NoContent();
    }
}
