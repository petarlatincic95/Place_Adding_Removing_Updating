namespace Place_Adding_Removing_Updating.Data.Model
{
    public class Country
    {
       
        public int Id { get; set; }
        public string? Name { get; set; }


        //Navigation property
       
        public List<Place> PlaceList { get; set; } = new List<Place>();
    }
}
