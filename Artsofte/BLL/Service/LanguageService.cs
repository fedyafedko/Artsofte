using BLL.Interfaces;
using DAL.EF;
using Employee.Common.DTO.Language;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BLL.Service;

public class LanguageService : ILanguageService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public LanguageService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
    }

    public async Task<LanguageDTO> AddLanguage(LanguageDTO language)
    {
        await _applicationDbContext.Database.ExecuteSqlRawAsync(
            "EXEC [dbo].[AddLanguage] @Name",
            new SqlParameter("@Name", language.Name));
        return language;
    }

    public List<DAL.Entities.ProgrammingLanguage> GetAll()
    {
        return _applicationDbContext.Languages.FromSqlRaw("GetAllLanguages").ToList();
    }

    public async Task<LanguageDTO> UpdateLanguage(LanguageDTO language, string name)
    {
        await _applicationDbContext.Database.ExecuteSqlRawAsync(
            "EXEC [dbo].[UpdateLanguage] @Id, @Name",
        new SqlParameter("@Id", name),
        new SqlParameter("@Name", language.Name));
        return language;
    }

    public async Task<bool> DeleteLanguage(string name)
    {
        var language = await _applicationDbContext.Database.ExecuteSqlRawAsync(
            "EXEC [dbo].[DeleteLanguage] @Id",
            new SqlParameter("@Id", name));
        return language < 0;
    }
}