using Place_Adding_Removing_Updating.Data.Model;

namespace Place_Adding_Removing_Updating.Data.HelperModels
{
    public class CountryHelperClass
    {
        private readonly dbContext dbContext;

        public CountryHelperClass(dbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }



        public async Task<object> GetAllCountries()
        {
            //var allCountries = await dbContext.Countries/*.Include(x => x.PlaceList).*/.ToListAsync();
            //return allCountries;
            var allCountries=await dbContext.Countries.ToListAsync();
            var toReturn = from country in allCountries
                           select new
                           {
                               countryId = country.Id,
                               countryName = country.Name,



                           };
            return toReturn;
        
        
        }
        public async Task<ICollection<Country>> Get_All_Countries()
        {


              var allCountries = await dbContext.Countries.Include(x => x.PlaceList).ToListAsync();
              return allCountries;





        }

        public async Task<object> GetCountryById(int id)
        {
            var countryToReturn = await (from country in dbContext.Countries
                                         where country.Id == id
                                         select new
                                         {
                                             countryId = country.Id,
                                             countryName = country.Name

                                         }).FirstAsync();
            if (await dbContext.Countries.FindAsync(id)==null)
                return null;
            else


            
            return countryToReturn;
        
        
        
        }
        public async Task<bool> AddNewCountry(CountryDTO request)
        {
            var countryToAdd = new Country();

            if (string.IsNullOrEmpty(request.Name)||request.Name=="string")
                return false;
            else
                countryToAdd.Name = request.Name.ToUpper();
            await dbContext.Countries.AddAsync(countryToAdd);
            await dbContext.SaveChangesAsync();
            return true;
               
        }


        public async Task<bool> UpdateCountryName(int id, string newName)
        {
            var countryToUpdate = await dbContext.Countries.FindAsync(id);
            if (id == 0 || string.IsNullOrEmpty(newName)||newName=="string")
                return false;



            else  if(countryToUpdate==null)
                return false;
            else
                countryToUpdate.Name = newName.ToUpper();
                await dbContext.SaveChangesAsync();
            return true;
        
        }


        public async Task<bool> DeleteCountry(int id)
        {
            var countryToDelete=await dbContext.Countries.FindAsync(id);

            if (countryToDelete == null)
                return false;
            else
            {
                dbContext.Countries.Remove(countryToDelete);
                await dbContext.SaveChangesAsync();


            return true;
            }

        }


    }
}
