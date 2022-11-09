using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TenentService : RestService<Tenent>, ITenentService
    {
        public async Task<List<Tenent>> GetAllTenents()
        {
            return await DoHttpGetRequest("Event");
        }
    }
}
