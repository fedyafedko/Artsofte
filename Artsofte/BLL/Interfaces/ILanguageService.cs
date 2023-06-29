using Employer.Common.DTO;
using Employer.Common.DTO.Language;

namespace BLL.Interfaces;

public interface ILanguageService
{
    Task<LanguageDTO> AddLanguage(LanguageDTO language);
    List<LanguageDTO> GetAll();
    Task<LanguageDTO> UpdateLanguage(LanguageDTO language, int id);
    Task<bool> DeleteLanguage(int id);
}