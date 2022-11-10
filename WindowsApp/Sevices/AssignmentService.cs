using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsApp.Services;
using WindowsApp.Services.Interfaces;

namespace WindowsApp.Sevices
{
    public class AssignmentService : RestService<Assignment>, IAssignmentService
    {
        public async Task<List<Assignment>> GetAssignmentsByTenent(int id)
        {
            return await DoHttpGetRequest($"Assignment/AByT/{id}");
        }

        public async Task<Assignment> GetAssignment(int id)
        {
            return await DoHttpGetSingleRequest($"Assignment/AByI/{id}");
        }

        public async Task<string> AddAssignment(Assignment assignment)
        {
            return await DoHttpPostRequest("Assignment", assignment);
        }

        public async Task<string> SaveAssignment(Assignment assignment)
        {
            return await DoHttpPutRequest("Assignment", assignment);
        }
    }
}
