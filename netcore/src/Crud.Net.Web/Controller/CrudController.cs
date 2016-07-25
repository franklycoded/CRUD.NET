using System;
using System.Threading.Tasks;
using Crud.Net.Core.DataModel;
using Crud.Net.Core.DataContract;
using Crud.Net.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Net.Web.Controller
{
    /// <summary>
    /// Generic controller for CRUD operations
    /// </summary>
    public class CrudController<TEntity, TDto>: Microsoft.AspNetCore.Mvc.Controller where TEntity: class, IEntity where TDto: class, ICrudDto
    {
        protected readonly ICrudService<TEntity, TDto> Service;

        /// <summary>
        /// Creates a new instance of the CrudController
        /// </summary>
        /// <param name="manager">The CrudService to be used for data retrieval and other operations</param>
        public CrudController(ICrudService<TEntity, TDto> service)
        {
            if(service == null) throw new ArgumentNullException(nameof(service));

            Service = service;
        }

        /// <summary>
        /// Gets the resource by id
        /// </summary>
        /// <param name="id">The id of the resource</param>
        /// <returns>The resource</returns>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(long id){
            try {
                var dto = await Service.GetByIdAsync(id);

                if(dto == null) return NotFound();

                return Ok(dto);
            }
            catch(Exception ex){
                // Log error
                return StatusCode(500, "Error while getting item by id " + id + ": " + ex);
            }
        }

        /// <summary>
        /// Creates a new instance of the resource
        /// </summary>
        /// <param name="dto">The data contract representation of the new resource instance</param>
        /// <returns>The new resource instance</returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto dto){
            try
            {
                var newDto = await Service.AddAsync(dto);
                return Ok(newDto);
            }
            catch (Exception ex)
            {
                // log error
                return StatusCode(500, "Error while adding item. " + ex);
            }
        }

        /// <summary>
        /// Modifies the data of the existing resource
        /// </summary>
        /// <param name="dto">The data contract representation of the modifiable resource</param>
        /// <returns>The modified resource</returns>
        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TDto dto){
            try {
                var updatedDto = await Service.UpdateAsync(dto);

                if(updatedDto == null) return NotFound();

                return Ok(updatedDto);
            }
            catch(Exception ex){
                // Log error
                return StatusCode(500, "Error while updating item! " + ex);
            }
        }

        /// <summary>
        /// Deletes a resource using the id
        /// </summary>
        /// <param name="id">The id of the resource to delete</param>
        /// <returns>True if deleted successfully, false otherwise</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id){
            try
            {
                var isDeleteSuccessful = await Service.DeleteAsync(id);

                if(isDeleteSuccessful == false) return NotFound();

                return Ok();
            }
            catch (System.Exception ex)
            {
                // log error
                return StatusCode(500, "Error while deleting item with id " + id + ". " + ex);
            }
        }
    }
}
