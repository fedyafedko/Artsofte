using AutoMapper;
using BLL.Interfaces;
using DAL.Repositories.Interfaces;
using Employer.Common.DTO;

namespace BLL.Service;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<AddEmployeeDTO> AddEmployer(AddEmployeeDTO addEmployee)
    {
        DAL.Entities.Employee entity = _mapper.Map<DAL.Entities.Employee>(addEmployee);
        if (await _repository.Table.FindAsync(entity.Id) != null)
            throw new InvalidOperationException("Entity with such key already exists in the database");
        await _repository.AddAsync(entity);
        return _mapper.Map<AddEmployeeDTO>(entity);
    }

    public List<EmployeeDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<EmployeeDTO>>(_repository.GetAll()).ToList();
    }

    public async Task<UpdateEmployeeDTO> UpdateEmployer(UpdateEmployeeDTO employee, int id)
    {
        var entity = await _repository.Table.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Unable to find entity with such key {id}");

        _mapper.Map(employee, entity);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<UpdateEmployeeDTO>(entity);
    }

    public async Task<bool> DeleteEmployer(int id)
    {
        var employer = await _repository.Table.FindAsync(id);
        return employer != null && await _repository.DeleteAsync(employer) > 0;
    }

    public async Task<EmployeeDTO?> GetById(int id)
    {
        var employer = await _repository.Table.FindAsync(id);
        return employer != null ? _mapper.Map<EmployeeDTO>(employer) : null;
        
    }
}