using AutoMapper;
using BLL.Interfaces;
using DAL.Repositories.Interfaces;
using Employee.Common.DTO.Department;

namespace BLL.Service;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<DepartmentDTO> AddDepartment(DepartmentDTO department)
    {
        DAL.Entities.Department entity = _mapper.Map<DAL.Entities.Department>(department);
        if (await _repository.Table.FindAsync(entity.Id) != null)
            throw new InvalidOperationException("Entity with such key already exists in the database");
        await _repository.AddAsync(entity);
        return _mapper.Map<DepartmentDTO>(entity);
    }

    public List<DepartmentDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<DepartmentDTO>>(_repository.GetAll()).ToList();
    }

    public async Task<DepartmentDTO> UpdateDepartment(DepartmentDTO department, int id)
    {
        var entity = await _repository.Table.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Unable to find entity with such key {id}");

        _mapper.Map(department, entity);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<DepartmentDTO>(entity);
    }

    public async Task<bool> DeleteDepartment(int id)
    {
        var language = await _repository.Table.FindAsync(id);
        return language != null && await _repository.DeleteAsync(language) > 0;
    }
}