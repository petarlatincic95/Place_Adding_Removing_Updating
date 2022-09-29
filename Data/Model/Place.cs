using System.ComponentModel.DataAnnotations.Schema;

namespace Place_Adding_Removing_Updating.Data.Model
{
    public class Place
    {
     
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ZipCode { get; set; }

        public Country Country { get; set; }


    }
}
