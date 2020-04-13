namespace StimulusChallenge.API.Models
{
    public class Pledge
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string ZipCode { get; set; }
        
        public int NonProfit { get; set; }
        
        public int SmallBiz { get; set; }
    }
}