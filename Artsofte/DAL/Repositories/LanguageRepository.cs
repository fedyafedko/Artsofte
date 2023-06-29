using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class LanguageRepository : Repo<ProgrammingLanguage, string>, ILanguageRepository
{
    public LanguageRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
}