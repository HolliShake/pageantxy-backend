using APP.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class GenericController<IService, TModel> : ControllerBase where IService : IGenericService<TModel>
{
    protected readonly IMapper _mapper;
    protected readonly IService _repo;
    public GenericController(IMapper mapper, IService repo)  : base()
    { 
        _mapper = mapper;
        _repo = repo;
    }

    // GetAll
    protected async Task<ActionResult> GenericGetAll<Dto>()
    {
        return Ok(_mapper.Map<ICollection<Dto>>(await _repo.GetAllAsync()));
    }

    // Get
    protected async Task<ActionResult> GenericGet<Dto>(int id)
    {
        var record = await _repo.GetAsync(id);

        return (record != null)
            ? Ok(_mapper.Map<Dto>(record))
            : NotFound($"{typeof(Dto).Name} does not exist!");
    }

    // Get
    protected async Task<ActionResult> GenericGet<Dto>(string id)
    {
        var record = await _repo.GetAsync(id);

        return (record != null)
            ? Ok(_mapper.Map<Dto>(record))
            : NotFound();
    }

    // Create
    protected async Task<ActionResult> GenericCreate<Dto>([FromBody] Dto createbody)
    {
        var newEntry = _mapper.Map<TModel>(createbody);

        return (await _repo.CreateAsync(newEntry))
            ? Ok(newEntry)
            : BadRequest("Something went wrong!");
    }

    // Update
    protected async Task<ActionResult> GenericUpdate<Dto>(int id, [FromBody] Dto updatebody)
    {
        var existingRecord = await _repo.GetAsync(id);

        if (existingRecord == null)
        {
            return NotFound();
        }

        var updatedEntry = _mapper.Map(updatebody, existingRecord);
        var name = this.GetType().Name.Replace("Controller", "");

        return (await _repo.UpdateAsync(updatedEntry))
            ? NoContent()
            : BadRequest($"Could not update {name} with id {id}!");
    }

    // Update
    protected async Task<ActionResult> GenericUpdate<Dto>(string id, [FromBody] Dto updatebody)
    {
        var existingRecord = await _repo.GetAsync(id);

        if (existingRecord == null)
        {
            return NotFound();
        }

        var updatedEntry = _mapper.Map(updatebody, existingRecord);
        var name = this.GetType().Name.Replace("Controller", "");

        return (await _repo.UpdateAsync(updatedEntry))
            ? NoContent()
            : BadRequest($"Could not update {name} with id {id}!");
    }

    // Delete
    protected async Task<ActionResult> GenericDelete(int id)
    {
        var existingRecord = await _repo.GetAsync(id);

        if (existingRecord == null)
        {
            return NotFound();
        }

        var name = this.GetType().Name.Replace("Controller", "");
        return (await _repo.DeleteAsync(existingRecord))
            ? NoContent()
            : BadRequest($"Could not delete {name} with id {id}!");
    }

    // Delete
    protected async Task<ActionResult> GenericDelete(string id)
    {
        var existingRecord = await _repo.GetAsync(id);

        if (existingRecord == null)
        {
            return NotFound();
        }

        var name = this.GetType().Name.Replace("Controller", "");
        return (await _repo.DeleteAsync(existingRecord))
            ? NoContent()
            : BadRequest($"Could not delete {name} with id {id}!");
    }
}