using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using personaApi.Models;
using System.Collections.Generic;

namespace personaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public List<Person> personasPublicas = new List<Person>
        {
            new Person{Id = 1, Nombre="Maria"},
            new Person{Id = 2, Nombre= "Rodrigo" }
        };

        public List<Person> personasPrivadas = new List<Person>
        {
            new Person{Id = 1, Nombre="Hector"},
            new Person{Id = 2, Nombre= "Andrea" }
        };

        public List<Person> personasPrivadasConPermiso = new List<Person>
        {
            new Person{Id = 1, Nombre="Alberto"},
            new Person{Id = 2, Nombre= "Fabiola" }
        };

        
        [HttpGet("getPersonasPublicas")]
        public IEnumerable<Person> getPersonasPublicas()
        {
            return personasPublicas;
        }
        [Authorize]
        [HttpGet("getPersonasPrivadas")]
        public IEnumerable<Person> getPersonasPrivadas()
        {
            return personasPrivadas;
        }

        [Authorize("read:permissions")]
        [HttpGet("getPersonasPrivadasConPermiso")]
        public IEnumerable<Person> getPersonasPrivadasConPermiso()
        {
            return personasPrivadasConPermiso;
        }
    }
}
