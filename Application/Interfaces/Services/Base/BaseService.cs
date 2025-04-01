using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces.Repositories;

namespace Application.Interfaces.Services.Base
{
    public class BaseService<TEntity, TDto> : IBaseService<TDto> where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? default : _mapper.Map<TDto>(entity);
        }

        public async Task<bool> CreateAsync(TDto dto)
        {
            var nameProperty = typeof(TDto).GetProperty("Name");
            if (nameProperty == null)
                throw new ArgumentException("El DTO debe tener una propiedad 'Name'.");

            var name = nameProperty.GetValue(dto)?.ToString();

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (await _repository.ExistsByNameAsync(name))
                throw new ArgumentException($"El nombre '{name}' ya existe.");

            var entity = _mapper.Map<TEntity>(dto);
            await _repository.AddAsync(entity);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(int id, TDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            var nameProperty = typeof(TDto).GetProperty("Name");
            if (nameProperty == null)
                throw new ArgumentException("El DTO debe tener una propiedad 'Name'.");

            var name = nameProperty.GetValue(dto)?.ToString();

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("El nombre no puede estar vacío.");

            var entityName = typeof(TEntity).GetProperty("Name")?.GetValue(entity)?.ToString();
            if (name != entityName && await _repository.ExistsByNameAsync(name))
                throw new ArgumentException($"El nombre '{name}' ya existe.");

            _mapper.Map(dto, entity);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _repository.Delete(entity);
            return await _repository.SaveChangesAsync();
        }
    }
}
