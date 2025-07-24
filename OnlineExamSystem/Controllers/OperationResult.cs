using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace OnlineExamSystem.Controllers
{
    public class OperationResult
    {
        public bool Success{get;set ;}
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
