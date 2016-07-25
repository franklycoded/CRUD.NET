using Crud.Net.Core.DataModel;
using Crud.Net.Core.DataContract;

namespace Crud.Net.Core.DataContractMapper
{
    /// <summary>
    /// Base class for data contract mappers to automatically map Id, creation and modification dates
    /// </summary>
    public abstract class CrudDtoMapper<TEntity, TDto> : ICrudDtoMapper<TEntity, TDto> 
    where TEntity : class, IEntity, new()
    where TDto : class, ICrudDto, new()
    {
        /// <summary>
        /// <see cref="IDataContractMapper.MapDtoToEntity" />
        /// </summary>
        public TEntity MapDtoToEntity(TDto dto)
        {
            var entity = OnMapDtoToEntity(dto, new TEntity());
            
            // Making sure the derived class doesn't change these values
            entity.Id = dto.Id;
            entity.CreatedUTC = dto.CreatedUTC;
            entity.ModifiedUTC = dto.ModifiedUTC;

            return entity;
        }

        /// <summary>
        /// <see cref="IDataContractMapper.MapEntityToDto" />
        /// </summary>
        public TDto MapEntityToDto(TEntity entity)
        {
            var dto = OnMapEntityToDto(entity, new TDto());
            
            // Making sure the derived class doesn't change these values
            dto.Id = entity.Id;
            dto.CreatedUTC = entity.CreatedUTC;
            dto.ModifiedUTC = entity.ModifiedUTC;

            return OnMapEntityToDto(entity, dto);
        }

        // <summary>
        /// <see cref="IDataContractMapper.MapEntityToDto" />
        /// </summary>
        public TDto MapEntityToDto(TEntity entity, TDto existingDto)
        {
            var dto = OnMapEntityToDto(entity, existingDto);
            
            // Making sure the derived class doesn't change these values
            dto.Id = entity.Id;
            dto.CreatedUTC = entity.CreatedUTC;
            dto.ModifiedUTC = entity.ModifiedUTC;

            return OnMapEntityToDto(entity, dto);
        }

        /// <summary>
        /// <see cref="IDataContractMapper.MapDtoToEntity" />
        /// </summary>
        public TEntity MapDtoToEntity(TDto dto, TEntity existingEntity)
        {
            var entity = OnMapDtoToEntity(dto, existingEntity);
            
            // Making sure the derived class doesn't change these values
            entity.Id = dto.Id;
            entity.CreatedUTC = dto.CreatedUTC;
            entity.ModifiedUTC = dto.ModifiedUTC;

            return entity;
        }

        /// <summary>
        /// The place where the domain-specific Entity to Dto mapping should be implemented
        /// </summary>
        /// <param name="entity">The entity to map</param>
        /// <param name="dto">The dto to map the entity to</param>
        /// <returns>The dto</returns>
        protected abstract TDto OnMapEntityToDto(TEntity entity, TDto dto);
        
        /// <summary>
        /// The place where the domain-specific Dto to Entity mapping should be implemented
        /// </summary>
        /// <param name="dto">The dto to map</param>
        /// <param name="entity">The entity to map the dto to</param>
        /// <returns>The entity</returns>
        protected abstract TEntity OnMapDtoToEntity(TDto dto, TEntity entity);
        
    }
}
