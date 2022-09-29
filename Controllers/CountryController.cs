using Microsoft.AspNetCore.Mvc;
using Place_Adding_Removing_Updating.Data.HelperModels;
using Place_Adding_Removing_Updating.Data.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Place_Adding_Removing_Updating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly dbContext _dbcontext;

        public CountryController(dbContext _dbContext)
        {
            this._dbcontext = _dbContext;
        }
        // GET: api/<Country_Controller>
        [HttpGet]
        public async Task<object> Get()
        {
            var helperObj=new CountryHelperClass(_dbcontext);
            return await helperObj.GetAllCountries();
            
            
        }
        

        // GET api/<Country_Controller>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            var helperObj=new CountryHelperClass(_dbcontext);
            var country=await helperObj.GetCountryById(id);
            if (country == null)
                return NotFound("Country with given id not found");
            else
                return Ok(country);
            
            
        }

        // POST api/<Country_Controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryDTO request)
        {
            var helperObj=new CountryHelperClass(_dbcontext);
            if (await helperObj.AddNewCountry(request) == false)
                return BadRequest("Unsuccessfull attempt to ad new Country");
            else
                return Ok("New Country added to database");
        }

        // PUT api/<Country_Controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            var helperObj=new CountryHelperClass(_dbcontext);
            if (await helperObj.UpdateCountryName(id, value) == false)
                return BadRequest("Unable to update Country");
            else
                return Ok("Country name successfully updated");

            

        }

        // DELETE api/<Country_Controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var helperObj = new CountryHelperClass(_dbcontext);
            if (await helperObj.DeleteCountry(id) == false)
                return BadRequest("Record with given id doesn't exist");
            else 
                return Ok("Country successfully deleted");
        }
    }
}
