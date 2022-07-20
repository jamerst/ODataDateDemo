using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class TestEntityController : ODataController
{
    [HttpPost]
    public IActionResult Post([FromBody] TestEntity testEntity)
    {
        if (testEntity.Date.Kind == DateTimeKind.Utc)
        {
            return Ok(testEntity.Date.Kind.ToString());
        }
        else
        {
            return StatusCode(500, testEntity.Date.Kind.ToString());
        }
    }
}