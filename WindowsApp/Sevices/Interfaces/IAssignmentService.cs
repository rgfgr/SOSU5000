using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp.Services.Interfaces
{
    public interface IAssignmentService : IRestService<Assignment>
    {
        Task<Assignment> GetAssignment(int id);
        Task<List<Assignment>> GetAssignmentsByTenent(int id);
    }
}
