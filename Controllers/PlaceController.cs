using Microsoft.AspNetCore.Mvc;
using Place_Adding_Removing_Updating.Data.HelperModels;
using Place_Adding_Removing_Updating.Data.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Place_Adding_Removing_Updating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {

       private readonly dbContext _dbcontext;

        public PlaceController(dbContext _dbContext)
        {
          this._dbcontext = _dbContext;
        }
        // GET: api/<PlaceController>
        [HttpGet("{page}")]
        public async Task<IActionResult> Get(int page)
            {
            
            var helperObj = new PlaceHelperClass(_dbcontext);
            var allPlaces=await helperObj.GetAllPlaces();
            var placeResult = 3f;
            
            var placeCount = Math.Ceiling(allPlaces.Count()/placeResult);
            var toReturn = allPlaces.Skip((page - 1) * (int)placeResult)
                .Take((int)placeResult).ToList();
            var placeResponse = new Places_PagingDTO
            {
                Places = toReturn,
                CurrentPage = page,
                Pages = (int)placeCount





            };
            return Ok(placeResponse);
        }

        // GET api/<PlaceController>/5
        [HttpGet("Single_Place/{id}")]
        public async Task<IActionResult> GetPlace(int id)
        {
            var helperObj = new PlaceHelperClass(_dbcontext);
            if (await helperObj.GetbyId(id) == null)
                return BadRequest("Record with given id not found!");
            else
                return Ok(await helperObj.GetbyId(id));



        }

        // POST api/<PlaceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlaceDTO placeDTO)
        {
            var helperObj=new PlaceHelperClass(_dbcontext);
            if (await helperObj.PostToDatabase(placeDTO) == false)
                return BadRequest("Unsuccessfull atempt to save record");
            else
                return Ok("Record saved successfully");




        }

        // PUT api/<PlaceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult>Put(int id, [FromBody] Place_noCountryField_DTO request)
        {
            var helperObj=new PlaceHelperClass(_dbcontext);
            if (await helperObj.UpdatePlace(id, request.Name, request.ZipCode) == false)
                return BadRequest("Unable to make changes");
            else
                return Ok("Place successfully updated");
        }

        // DELETE api/<PlaceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var helperObj=new PlaceHelperClass(_dbcontext);
            if (await helperObj.DeletePlace(id) == false)
                return BadRequest("Record with given id not found");
            else
                return Ok("Place successfully deleted from database");


        }
    }
}
