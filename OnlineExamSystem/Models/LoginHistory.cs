namespace OnlineExamSystem.Models
{
    public class LoginHistory
    {
        public int LoginID { get; set; } // Unique identifier for the login history

        public int UserID { get; set; } // Foreign key to the User

        public DateTime LoginTime { get; set; } // Timestamp of the login

        public bool IsSuccessful { get; set; } // Indicates if the login was successful
        public string FailureReason { get; set; } // Reason for failure if login was unsuccessful

        public User User { get; set; } // Navigation property to the User
    }
}
