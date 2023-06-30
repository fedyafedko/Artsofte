using AutoMapper;
using BLL.Interfaces;
using DAL.Repositories.Interfaces;
using Employee.Common.DTO.Language;

namespace BLL.Service;

public class LanguageService : ILanguageService
{
    private readonly ILanguageRepository _repository;
    private readonly IMapper _mapper;

    public LanguageService(ILanguageRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<LanguageDTO> AddLanguage(LanguageDTO language)
    {
        DAL.Entities.ProgrammingLanguage entity = _mapper.Map<DAL.Entities.ProgrammingLanguage>(language);
        if (await _repository.Table.FindAsync(entity.Id) != null)
            throw new InvalidOperationException("Entity with such key already exists in the database");
        await _repository.AddAsync(entity);
        return _mapper.Map<LanguageDTO>(entity);
    }

    public List<LanguageDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<LanguageDTO>>(_repository.GetAll()).ToList();
    }

    public async Task<LanguageDTO> UpdateLanguage(LanguageDTO language, int id)
    {
        var entity = await _repository.Table.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Unable to find entity with such key {id}");

        _mapper.Map(language, entity);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<LanguageDTO>(entity);
    }

    public async Task<bool> DeleteLanguage(int id)
    {
        var language = await _repository.Table.FindAsync(id);
        return language != null && await _repository.DeleteAsync(language) > 0;
    }
}