using JCF.Domain.Entitys;
using JCF.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Application.Services
{
    public class OperationLogService
    {
        private readonly IOperationLogRepository _operationLogRepository;
        public OperationLogService(IOperationLogRepository operationLogRepository)
        {
            _operationLogRepository = operationLogRepository;
        }

        public async Task<List<OperationLogEntity>> GetOperationLogList()
        {
            var list = await _operationLogRepository.Query();
            return list;
        }

        public async Task<int> AddOperationLogList()
        {
            int count = 0;
            List<OperationLogEntity> operationLogs = new List<OperationLogEntity>();
            for (int i = 0; i < 100; i++)
            {
                operationLogs.Add(new OperationLogEntity()
                {
                    Code = "CODE" + i,
                    OrderId = 1,
                    ProcessName = "PCB工序1",
                    Producer = "test Producer",
                    ProductionTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Remark = "test data" 
                });
            }

            count = await _operationLogRepository.Add(operationLogs);

            return count;
        }
    }
}
