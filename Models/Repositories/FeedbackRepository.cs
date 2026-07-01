using System.Data.SqlClient;
namespace MyMvcApp.Models
{
    public class FeedbackRepository
    {
        private string connection="Server=localhost;Database=Feedback_Form;trusted_connection=True;";
        public void GiveFeedback(Feedback feedback)
        {
            SqlConnection conn=new SqlConnection(connection);
            string query="INSERT INTO Feedbacks(StudentName,Course,Comments,Rating,DateSubmitted)"+
                      "VALUES(@StudentName,@Course,@Comments,@Rating,@DateSubmitted)";
            SqlCommand cmd=new SqlCommand(query,conn);
            cmd.Parameters.AddWithValue("@StudentName",feedback.StudentName); 
            cmd.Parameters.AddWithValue("@Course",feedback.Course);
            cmd.Parameters.AddWithValue("@Comments",feedback.Comments); 
            cmd.Parameters.AddWithValue("@Rating",feedback.Rating); 
            cmd.Parameters.AddWithValue("@DateSubmitted",DateTime.Now);  
            conn.Open();
            cmd.ExecuteNonQuery();     
            conn.Close();
        
        }
        public List<Feedback> AllFeedbacks()
        {
            SqlConnection conn=new SqlConnection(connection);
            string query="SELECT * FROM  Feedbacks";
            SqlCommand cmd=new SqlCommand(query,conn);
            conn.Open();
            List<Feedback>list=new List<Feedback>();
            SqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                list.Add(new Feedback{
                    Id=int.Parse(reader[0].ToString()),StudentName=reader[1].ToString(),Course=reader[2].ToString(),Comments=reader[3].ToString(),Rating=int.Parse(reader[4].ToString()),DateSubmitted=DateTime.Parse(reader[5].ToString())
                    });
            }
            conn.Close();
            return list;    
            
        
        }
    
    }
}
