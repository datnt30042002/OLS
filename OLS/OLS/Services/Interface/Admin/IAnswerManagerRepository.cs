using OLS.DTO.Answers.Admin;

namespace OLS.Services.Interface.Admin
{
    public interface IAnswerManagerRepository
    {
        Task<List<AnswerReadAdminDTO>> GetAllAnswersByQuestionId(int questionId);
        Task<AnswerCreateAdminDTO> CreateAnswer(AnswerCreateAdminDTO answer);
        Task<AnswerUpdateAdminDTO> UpdateAnswerByAnswerId(int answerId, AnswerUpdateAdminDTO updatedAnswer);
        Task<bool> DeleteAnswerByAnswerId(int answerId);
    }
}
