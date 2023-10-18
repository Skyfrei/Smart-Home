namespace ApiGateway.Dto
{
    public class NotificationReadDto
    {
        public int Id { get; set; }
                
        public DateTime ProcTime { get; set; }

        public string NotificationDetails { get; set; }
        
        public string Type { get; set; }
        
        public bool Triggered { get; set; }
    }
}