namespace back.Models
{
    public class Response
    {
        public double Premium{get; set;}

        public Response(double value)
        {
            this.Premium = value;
        }
    }
}