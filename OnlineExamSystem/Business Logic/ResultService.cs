using OnlineExamSystem.Data;
using OnlineExamSystem.Models.DTOs;
using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Business_Logic
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _repository;
        public ResultService(IResultRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<ResultReadDto> GetAll()
        {
            return _repository.GetAllResults()
                .Select(r => new ResultReadDto
                {
                    ResultID = r.ResultID,
                    TotalScore = r.TotalScore,
                    CorrectAnswers = r.CorrectAnswers,
                    WrongAnswers = r.WrongAnswers,
                    Percentage = r.Percentage,
                    Passed = r.Passed
                });
        }

        public ResultReadDto GetById(int id)
        {
            var result = _repository.GetResultById(id);
            if (result == null) return null;
            return new ResultReadDto
            {
                ResultID = result.ResultID,
                TotalScore = result.TotalScore,
                CorrectAnswers = result.CorrectAnswers,
                WrongAnswers = result.WrongAnswers,
                Percentage = result.Percentage,
                Passed = result.Passed
            };
        }
        public ResultReadDto Create(ResultDto resultDto)
        {
            var percentage = resultDto.TotalScore > 0 ?
                ((decimal)resultDto.CorrectAnswers / resultDto.TotalScore) * 100 : 0;

            var passed = percentage >= 50;

            var result = new Result
            {
                TotalScore = resultDto.TotalScore,
                CorrectAnswers = resultDto.CorrectAnswers,
                WrongAnswers = resultDto.WrongAnswers,
                Percentage = percentage,
                Passed = passed
            };

            _repository.AddResult(result);
            _repository.SaveChanges();

            return GetById(result.ResultID);
        }

        public bool Update(int id, ResultUpdateDto resultDto)
        {
            var existingResult = _repository.GetResultById(id);
            if (existingResult == null) return false;
            existingResult.TotalScore = resultDto.TotalScore;
            existingResult.CorrectAnswers = resultDto.CorrectAnswers;
            existingResult.WrongAnswers = resultDto.WrongAnswers;
            
            existingResult.Percentage =resultDto.TotalScore > 0 ?
                ((decimal)resultDto.CorrectAnswers / resultDto.TotalScore) * 100 : 0;
            existingResult.Passed = existingResult.Percentage >= 50;

            _repository.UpdateResult(existingResult);
            _repository.SaveChanges();
            return true;
        }
        public bool Delete(int resultId)
        {
            var existingResult = _repository.GetResultById(resultId);
            if (existingResult == null) return false;
            _repository.DeleteResult(resultId);
            _repository.SaveChanges();
            return true;
        }
    }
}
