using DemoWebAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonnesController : ControllerBase
{
    private static readonly List<Personne> _personnes =
    [
        new Personne { Id = 1, Lastname = "Dubois", Firstname = "Marie", BirthDate = new DateOnly(1985, 3, 15) },
        new Personne { Id = 2, Lastname = "Martin", Firstname = "Pierre", BirthDate = new DateOnly(1990, 7, 22) },
        new Personne { Id = 3, Lastname = "Bernard", Firstname = "Sophie", BirthDate = new DateOnly(1978, 11, 8) },
        new Personne { Id = 4, Lastname = "Thomas", Firstname = "Lucas", BirthDate = new DateOnly(1995, 1, 30) },
        new Personne { Id = 5, Lastname = "Robert", Firstname = "Emma", BirthDate = new DateOnly(1988, 5, 17) },
        new Personne { Id = 6, Lastname = "Petit", Firstname = "Alexandre", BirthDate = new DateOnly(1982, 9, 3) },
        new Personne { Id = 7, Lastname = "Durand", Firstname = "Camille", BirthDate = new DateOnly(1992, 12, 25) },
        new Personne { Id = 8, Lastname = "Leroy", Firstname = "Hugo", BirthDate = new DateOnly(1987, 4, 14) },
        new Personne { Id = 9, Lastname = "Moreau", Firstname = "Léa", BirthDate = new DateOnly(1998, 6, 9) },
        new Personne { Id = 10, Lastname = "Simon", Firstname = "Nathan", BirthDate = new DateOnly(1975, 2, 28) },
        new Personne { Id = 11, Lastname = "Laurent", Firstname = "Chloé", BirthDate = new DateOnly(1993, 8, 19) },
        new Personne { Id = 12, Lastname = "Lefebvre", Firstname = "Maxime", BirthDate = new DateOnly(1980, 10, 7) },
        new Personne { Id = 13, Lastname = "Michel", Firstname = "Julie", BirthDate = new DateOnly(1996, 3, 12) },
        new Personne { Id = 14, Lastname = "Garcia", Firstname = "Thomas", BirthDate = new DateOnly(1989, 7, 5) },
        new Personne { Id = 15, Lastname = "David", Firstname = "Sarah", BirthDate = new DateOnly(1991, 11, 21) },
        new Personne { Id = 16, Lastname = "Bertrand", Firstname = "Antoine", BirthDate = new DateOnly(1984, 1, 16) },
        new Personne { Id = 17, Lastname = "Roux", Firstname = "Manon", BirthDate = new DateOnly(1997, 5, 8) },
        new Personne { Id = 18, Lastname = "Vincent", Firstname = "Théo", BirthDate = new DateOnly(1986, 9, 29) },
        new Personne { Id = 19, Lastname = "Fournier", Firstname = "Océane", BirthDate = new DateOnly(1994, 4, 2) },
        new Personne { Id = 20, Lastname = "Morel", Firstname = "Louis", BirthDate = new DateOnly(1981, 12, 13) }
    ];

    [HttpGet()]
    public IEnumerable<Personne> Get()
    {
        return _personnes;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Personne), StatusCodes.Status200OK, Description = "La personne")]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public ActionResult<Personne> Get(int id)
    {
        if (id < 0 || id > _personnes.Count)
            return NotFound();

        return Ok(_personnes.FirstOrDefault(p => p.Id == id));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Personne), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public IActionResult Post ([FromBody] CreatePersonneDTO personneDto)
    {
        if (personneDto == null)
            return BadRequest();

        var p = new Personne
        {
            Id = _personnes.OrderByDescending(p => p.Id).First().Id + 1,
            Lastname = personneDto.Lastname,
            Firstname = personneDto.Firstname,
            BirthDate = personneDto.BirthDate
        };

        _personnes.Add(p);


        return Created("personneCree", _personnes.Last());
    }

}
