namespace PayCore.API.Models.Filters
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string id) : base(id + " not found!")
        {
        }
    }
}
