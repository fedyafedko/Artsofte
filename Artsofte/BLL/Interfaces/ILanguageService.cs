using Employee.Common.DTO.Language;

namespace BLL.Interfaces;

public interface ILanguageService
{
    Task<LanguageDTO> AddLanguage(LanguageDTO language);
    List<DAL.Entities.ProgrammingLanguage> GetAll();
    Task<LanguageDTO> UpdateLanguage(LanguageDTO language, string name);
    Task<bool> DeleteLanguage(string name);
}