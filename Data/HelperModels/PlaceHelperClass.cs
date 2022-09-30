using Place_Adding_Removing_Updating.Data.Model;

namespace Place_Adding_Removing_Updating.Data.HelperModels
{
    public  class PlaceHelperClass
     {
        private readonly dbContext _dbContext;
        public PlaceHelperClass(dbContext _dbContext)
        {
        this._dbContext = _dbContext;
        }

        public async Task<List<object>> GetAllPlaces()
        {
            var places = await _dbContext.Places.Include(x => x.Country).ToListAsync();
            List<object> toReturn= new List<object>();
            for(int i=0;i<places.Count;i++)
            {

                var temp = new
                {
                    id=places[i].Id,
                    place = places[i].Name,
                    zipcode = places[i].ZipCode,
                    country = places[i].Country.Name
                };
            
             toReturn.Add(temp);
            }
            return toReturn;
        }

        public async Task<object> GetbyId(int id)
        {
            
            var place = await (from placee in _dbContext.Places
                               where placee.Id == id
                               select new
                               {
                                   name = placee.Name,
                                   zipcode = placee.ZipCode,
                                   country = placee.Country.Name

                               }).FirstAsync();
            return place;






        
        }


        public async Task<bool> PostToDatabase(PlaceDTO request)
        {

            var placeToAdd = new Place();
            //ZipCode check

            var isZipCodeOk = int.TryParse(request.ZipCode, out int reult);
            




            


            if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.ZipCode) || string.IsNullOrEmpty(request.CountryofPlace)
                || request.Name == "string" || request.ZipCode == "string"||isZipCodeOk==false) 
                return false;
            
            else
            placeToAdd.Name = request.Name.ToUpper();
            placeToAdd.ZipCode = request.ZipCode;
            /*placeToAdd.CountryofPlace = request.CountryofPlace; *///Should get from body, user should choose it from dropdown, there shouldn't be any gramtical mistakes
            await _dbContext.Places.AddAsync(placeToAdd);
            var country = await _dbContext.Countries.Where(y => y.Name == request.CountryofPlace).Include(x => x.PlaceList).FirstAsync();

            country.PlaceList.Add(placeToAdd);
            

            await _dbContext.SaveChangesAsync();
            return true;

        }


        public async Task<bool> UpdatePlace(int id, string name, string zipcode)
        {
            var placeToUpdate = await _dbContext.Places.FindAsync(id);
            if (placeToUpdate == null || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(zipcode) || name == "string" || zipcode == "string")
                return false;
            else

            placeToUpdate.Name = name.ToUpper() ;
            placeToUpdate.ZipCode = zipcode;
            await _dbContext.SaveChangesAsync();
            return true;
        
        }

        public async Task<bool> DeletePlace(int id)
        { 
            var placeToRemove=await _dbContext.Places.FindAsync(id);
            if (placeToRemove==null)
                return false;


            else
                 _dbContext.Places.Remove(placeToRemove);
                 await _dbContext.SaveChangesAsync();
                 return true;
        
        }
    }
}
