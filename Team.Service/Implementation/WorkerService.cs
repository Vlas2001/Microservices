using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shared.Dto.CreateDto;
using Shared.Dto.GetDto;
using Shared.Dto.UpdateDto;
using Shared.Repository;
using Team.Entity;
using Team.Service.Abstraction;

namespace Team.Service.Implementation
{
    public class WorkerService: IWorkerService
    {
        private readonly IRepository<Worker> _workerRepository;
        private readonly IMapper _mapper;

        public WorkerService(IRepository<Worker> workerRepository, IMapper mapper)
        {
            _workerRepository = workerRepository;
            _mapper = mapper;
        }

        public async Task AddWorkerAsync(WorkerDto worker)
        {
            await _workerRepository.AddAsync(_mapper.Map<WorkerDto, Worker>(worker));
        }

        public async Task DeleteWorkerAsync(int id)
        {
            await _workerRepository.DeleteAsync(id);
        }

        public async Task EditWorkerAsync(UpdateWorkerDto workerDto)
        {
            await _workerRepository.EditAsync(_mapper.Map<UpdateWorkerDto, Worker>(workerDto));
        }

        public async Task<GetWorkerDto> GetWorkerAsync(int id)
        {
            return _mapper.Map<Worker, GetWorkerDto>(await _workerRepository.GetAsync(id));
        }

        public async Task<List<GetWorkerDto>> GetAllWorkerAsync()
        {
            var workers = await _workerRepository.GetAllAsync();
            return workers.Select(worker => _mapper.Map<Worker, GetWorkerDto>(worker)).ToList();
        }
    }
}