using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPetShopAPI.Controllers
{
    //api/pet
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        
        //Multiple optional parameters
        //api/pet/Filter
        [HttpGet("Filter")]
        public List<Pet> FilterPets(string? name = null, string? type = null, string? color = null, int? minAge = null, int? maxAge = null)
        {
            //create a list with all of the pets
            List<Pet> result = new List<Pet>();
            using(PetDBContext context = new PetDBContext())
            {
                result = context.Pets.ToList();
            }

            //Running multiple filters on the same list to find a match for all params
            //ignores any params not entered

            //if a name was entered, filter down by name
            if(name != null)
            {
                result = result.Where(p => p.PetName == name).ToList();
            }

            //if a type was entered, filter down by type
            if (type != null)
            {
                result = result.Where(p => p.PetType == type).ToList();
            }

            //if a color was entered, filter down by color
            if (color != null)
            {
                result = result.Where(p => p.FurColor == color).ToList();
            }

            //if a minAge was entered, filter down by minAge
            if (minAge != null)
            {
                result = result.Where(p => p.Age >= minAge).ToList();
            }

            //if a maxAge was entered, filter down by maxAge
            if (maxAge != null)
            {
                result = result.Where(p => p.Age <= maxAge).ToList();
            }

            //return the final filtered list
            return result;
        }

        //api/pet
        [HttpGet()]
        public List<Pet> GetAllPets()
        {
            using(PetDBContext context = new PetDBContext())
            {
                return context.Pets.ToList();
            }
        }

        //api/pet/{type}
        //api/pet/dog
        //api/pet/etc
        [HttpGet("{type}")]
        public List<Pet> SearchByType(string type)
        {
            using(PetDBContext context = new PetDBContext())
            {
                List<Pet> result = context.Pets.ToList().Where(p => p.PetType.ToLower() == type.ToLower()).ToList();
                return result;
            }
        }

        ////api/pet/color?color=black
        [HttpGet("color")]
        public List<Pet> SearchByColor(string color)
        {
            using (PetDBContext context = new PetDBContext())
            {
                List<Pet> result = context.Pets.ToList().Where(p => p.FurColor.ToLower() == color.ToLower()).ToList();
                return result;
            }
        }

        //api/pet/MinAge?age=5
        [HttpGet("MinAge")]
        public List<Pet> FilterByMinAge(int age)
        {
            using (PetDBContext context = new PetDBContext())
            {
                List<Pet> result = context.Pets.ToList().Where(p => p.Age >= age).ToList();
                return result;
            }
        }

        //api/pet/MaxAge?age=5
        [HttpGet("MaxAge")]
        public List<Pet> FilterByMaxAge(int age)
        {
            using (PetDBContext context = new PetDBContext())
            {
                List<Pet> result = context.Pets.ToList().Where(p => p.Age <= age).ToList();
                return result;
            }
        }

        //api/pet/Name?name=Baja Blast
        [HttpGet("Name")]
        public Pet FindByName(string name)
        {
            using (PetDBContext context = new PetDBContext())
            {
                Pet result = context.Pets.ToList().Find(p => p.PetName == name);
                return result;
            }
        }
        //api/pet/AddPet?name=Tums&type=hamster&color=brown&age=1
        [HttpPost("AddPet")]
        public Pet AddPet(string name, string type, string color, int age)
        {
            Pet pet = new Pet();
            pet.PetName = name;
            pet.PetType = type;
            pet.FurColor = color;
            pet.Age = age;

            using (PetDBContext context = new PetDBContext())
            {
                context.Pets.Add(pet);
                context.SaveChanges();
            }

            return pet;
        }
    }
}
