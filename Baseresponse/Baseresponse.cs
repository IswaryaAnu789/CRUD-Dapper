namespace Dapperempdetails.Responses
{
    public class Baseresponse
    {
        public string Status { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public int Inserted {  get; set; }

        public int Deleted {  get; set; }
    }
}
