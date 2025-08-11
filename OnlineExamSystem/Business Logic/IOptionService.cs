using OnlineExamSystem.Models.Questions;

namespace OnlineExamSystem.Business_Logic
{
    public interface IOptionService
    {
        IEnumerable<Option> GetOptionsByQuestionId(int questionId);

        Option GetOptionById(int optionId);
        bool AddOption(Option option);
        bool UpdateOption(Option option);
        bool DeleteOption(int optionId);

    }
}
