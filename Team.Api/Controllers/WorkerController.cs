using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;
using Team.Service;
using Team.Service.Abstraction;

namespace Team.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }
        
        [HttpPost("/AddWorker")]
        public async Task AddWorker(WorkerDto worker)
        {
            await _workerService.AddWorkerAsync(worker);
        }

        [HttpDelete("/DeleteWorker")]
        public async Task DeleteWorker(int id)
        {
            await _workerService.DeleteWorkerAsync(id);
        }

        [HttpPut("/EditWorker")]
        public async Task EditWorker(UpdateWorkerDto workerDto)
        {
            await _workerService.EditWorkerAsync(workerDto);
        }

        [HttpGet("/GetWorker")]
        public async Task<GetWorkerDto> GetWorker(int id)
        {
            return await _workerService.GetWorkerAsync(id);
        }

        [HttpGet("/GetAllWorkers")]
        public async Task<List<GetWorkerDto>> GetAllWorker()
        {
            return await _workerService.GetAllWorkerAsync();
        }
    }
}