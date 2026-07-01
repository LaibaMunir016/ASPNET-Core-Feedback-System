namespace MyMvcApp.Models
{
public class Feedback 
    { 
        public int Id { get; set; }  // Database ID 
        public string StudentName { get; set; } 
        public string Course { get; set; } 
        public string? Comments { get; set; } 
        public int Rating { get; set; } 
        public DateTime DateSubmitted = DateTime.Now; 
    }
}
