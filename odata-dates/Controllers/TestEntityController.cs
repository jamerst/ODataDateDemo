using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class TestEntityController : ODataController
{
    private List<TestEntity> _entities = new List<TestEntity>()
    {
        new TestEntity { Id = 1, Date = DateTime.Parse("2022-01-01T12:00:00Z")},
        new TestEntity { Id = 2, Date = DateTime.Parse("2021-02-01T15:00:00Z")},
        new TestEntity { Id = 3, Date = DateTime.Parse("2023-01-02T12:31:25Z")},
        new TestEntity { Id = 4, Date = DateTime.Parse("2022-07-01T13:00:00Z")},
        new TestEntity { Id = 5, Date = DateTime.Parse("2022-08-01T03:00:00Z")},
    };

    [HttpGet]
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_entities);
    }

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