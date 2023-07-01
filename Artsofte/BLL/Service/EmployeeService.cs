using AutoMapper;
using BLL.Interfaces;
using DAL.Repositories.Interfaces;
using Employee.Common.DTO;

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
    public async Task<AddEmployeeDTO> AddEmployee(AddEmployeeDTO employee)
    {
        DAL.Entities.Employee entity = _mapper.Map<DAL.Entities.Employee>(employee);
        if (await _repository.Table.FindAsync(entity.Id) != null)
            throw new InvalidOperationException("Entity with such key already exists in the database");
        entity.Gender = employee.Gender.ToString();
        await _repository.AddAsync(entity);
        return _mapper.Map<AddEmployeeDTO>(entity);
    }
    public async Task<EmployeeDTO?> GetById(int id)
    {
        var employee = await _repository.Table.FindAsync(id);
        return employee != null ? _mapper.Map<EmployeeDTO>(employee) : null;
    }
    public List<EmployeeDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<EmployeeDTO>>(_repository.GetAll()).ToList();
    }

    public async Task<UpdateEmployeeDTO> UpdateEmployee(UpdateEmployeeDTO employee, int id)
    {
        var entity = await _repository.Table.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Unable to find entity with such key {id}");

        _mapper.Map(employee, entity);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<UpdateEmployeeDTO>(entity);
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var employer = await _repository.Table.FindAsync(id);
        return employer != null && await _repository.DeleteAsync(employer) > 0;
    }
}