using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;

namespace Team.Service.Abstraction
{
    public interface IWorkerService
    {
        Task AddWorkerAsync(WorkerDto worker);

        Task DeleteWorkerAsync(int id);

        Task EditWorkerAsync(UpdateWorkerDto workerDto);

        Task<GetWorkerDto> GetWorkerAsync(int id);

        Task<List<GetWorkerDto>> GetAllWorkerAsync();
    }
}