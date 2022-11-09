using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AssignmentRepository : GenericRepository<Assignment>
    {
        public AssignmentRepository(SOSUContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByTenent(int id)
        {
            return await dbSet.Where(s => s.TenentId == id).ToListAsync();
        }
    }
}
