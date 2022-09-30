using Place_Adding_Removing_Updating.Data.Model;

namespace Place_Adding_Removing_Updating.Data.HelperModels
{
    public class Places_PagingDTO
    {
        public List<object> Places { get; set; } = new List<object>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }

       
    }
}
