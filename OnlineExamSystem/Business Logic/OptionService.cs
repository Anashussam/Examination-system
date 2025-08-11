using OnlineExamSystem.Data;
using OnlineExamSystem.Models.Questions;

namespace OnlineExamSystem.Business_Logic
{
    public class OptionService : IOptionService
    {
        private readonly ExamDbContext _context;
        public OptionService(ExamDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Option> GetOptionsByQuestionId(int questionId)
        {
            return _context.Options.Where(o => o.QuestionID == questionId).ToList();
        }
        public Option GetOptionById(int optionId)
        {
            return _context.Options.FirstOrDefault(o => o.OptionID == optionId);
        }
        public bool AddOption(Option option)
        {
            if (_context.Options.Any(o => o.OptionID == option.OptionID))
                return false;
            _context.Options.Add(option);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateOption(Option option)
        {
            if (!_context.Options.Any(o => o.OptionID == option.OptionID))
                return false;
            _context.Options.Update(option);
            return _context.SaveChanges() > 0;
        }
        public bool DeleteOption(int optionId)
        {
            var option = _context.Options.FirstOrDefault(o => o.OptionID == optionId);
            if (option == null)
                return false;
            _context.Options.Remove(option);
            return _context.SaveChanges() > 0;
        }
    }
}
