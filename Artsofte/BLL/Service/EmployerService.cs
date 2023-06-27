using AutoMapper;
using BLL.Interfaces;
using DAL.Repositories.Interfaces;
using Employer.Common.DTO;

namespace BLL.Service;

public class EmployerService : IEmployerService
{
    private readonly IEmployerRepository _repository;
    private readonly IMapper _mapper;

    public EmployerService(IEmployerRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<AddEmployerDTO> AddEmployer(AddEmployerDTO addEmployer)
    {
        DAL.Entities.Employer entity = _mapper.Map<DAL.Entities.Employer>(addEmployer);
        if (await _repository.Table.FindAsync(entity.Id) != null)
            throw new InvalidOperationException("Entity with such key already exists in the database");
        await _repository.AddAsync(entity);
        return _mapper.Map<AddEmployerDTO>(entity);
    }

    public List<EmployerDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<EmployerDTO>>(_repository.GetAll()).ToList();
    }

    public async Task<UpdateEmployerDTO> UpdateEmployer(UpdateEmployerDTO employer, int id)
    {
        var entity = await _repository.Table.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Unable to find entity with such key {id}");

        _mapper.Map(employer, entity);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<UpdateEmployerDTO>(entity);
    }

    public async Task<bool> DeleteEmployer(int id)
    {
        var employer = await _repository.Table.FindAsync(id);
        return employer != null && await _repository.DeleteAsync(employer) > 0;
    }

    public async Task<EmployerDTO?> GetById(int id)
    {
        var employer = await _repository.Table.FindAsync(id);
        return employer != null ? _mapper.Map<EmployerDTO>(employer) : null;
        
    }
}