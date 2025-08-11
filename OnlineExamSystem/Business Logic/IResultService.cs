using OnlineExamSystem.Models.DTOs;

namespace OnlineExamSystem.Business_Logic
{
    public interface IResultService
    {
        IEnumerable<ResultReadDto> GetAll();
        ResultReadDto GetById(int resultId);
        ResultReadDto Create(ResultDto resultDto);
        bool Update(int id,ResultUpdateDto resultDto);
        bool Delete(int resultId);
    }
}
