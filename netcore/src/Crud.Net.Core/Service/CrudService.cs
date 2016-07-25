using System;
using System.Threading.Tasks;
using Crud.Net.Core.DataModel;
using Crud.Net.Core.DataContract;
using Crud.Net.Core.DataContractMapper;
using Crud.Net.Core.UnitOfWork;
using Crud.Net.Core.Repository;

namespace Crud.Net.Core.Service
{
    /// <summary>
    /// Generic application-level class for CRUD operations
    /// </summary>
    public class CrudService<TContext, TEntity, TDto> : ICrudService<TEntity, TDto> where TContext : class where TEntity : class, IEntity 
    where TDto: class, ICrudDto
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ICrudRepository<TEntity> _repository;
        protected readonly ICrudDtoMapper<TEntity, TDto> _dataContractMapper;

        /// <summary>
        /// Creates a new instance of the CrudService
        /// </summary>
        /// <param name="unitOfWork">The unit of work instance to persist data changes to the context</param>
        /// <param name="repository">The repository for data manipulation</param>
        /// <param name="dataContractMapper">The mapper that translates between dtos and entities</param>
        public CrudService(IUnitOfWork unitOfWork, ICrudRepository<TEntity> repository, ICrudDtoMapper<TEntity, TDto> dataContractMapper)
        {
            if(unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
            if(repository == null) throw new ArgumentNullException(nameof(repository));
            if(dataContractMapper == null) throw new ArgumentNullException(nameof(dataContractMapper));

            _unitOfWork = unitOfWork;
            _repository = repository;
            _dataContractMapper = dataContractMapper;
        }

        /// <summary>
        /// <see cref="ICrudService.AddAsync" />
        /// </summary>
        public async Task<TDto> AddAsync(TDto dto)
        {
            if(dto == null) throw new ArgumentNullException(nameof(dto));
            
            // Making sure that Id is 0 and the date fields are generated on the server
            dto.Id = 0;
            dto.CreatedUTC = DateTime.UtcNow;
            dto.ModifiedUTC = DateTime.UtcNow;
            
            var newEntity = _dataContractMapper.MapDtoToEntity(dto);

            _repository.Add(newEntity);
            await _unitOfWork.SaveChangesAsync();
            return _dataContractMapper.MapEntityToDto(newEntity);
        }

        /// <summary>
        /// <see cref="ICrudService.DeleteAsync" />
        /// </summary>
        public async Task<bool> DeleteAsync(long id)
        {
            var jobItem = await _repository.GetByIdAsync(id);

            if(jobItem == null) return false;

            _repository.Delete(jobItem);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// <see cref="ICrudService.GetByIdAsync" />
        /// </summary>
        public async Task<TDto> GetByIdAsync(long id)
        {
            var jobItem = await _repository.GetByIdAsync(id);
            
            if(jobItem !=null){
                return _dataContractMapper.MapEntityToDto(jobItem);
            }

            return null;
        }

        /// <summary>
        /// <see cref="ICrudService.UpdateAsync" />
        /// </summary>
        public async Task<TDto> UpdateAsync(TDto dto)
        {
            if(dto == null) throw new ArgumentNullException(nameof(dto));

            var entity = await _repository.GetByIdAsync(dto.Id);

            if(entity == null) return null;

            // Making sure the createdutc date can't be modified and the modifyutc date gets updated
            dto.CreatedUTC = entity.CreatedUTC;
            dto.ModifiedUTC = DateTime.UtcNow;

            entity = _dataContractMapper.MapDtoToEntity(dto, entity);
            
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return _dataContractMapper.MapEntityToDto(entity);
        }
    }
}
