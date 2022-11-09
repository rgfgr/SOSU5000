using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private SOSUContext context = new();
        private GenericRepository<Tenent> tenentRepository;
        private AssignmentRepository assignmentRepository;
        private bool disposedValue;

        public GenericRepository<Tenent> TenentRepository
        {
            get
            {
                tenentRepository ??= new(context);
                return tenentRepository;
            }
        }
        public AssignmentRepository AssignmentRepository
        {
            get
            {
                assignmentRepository ??= new(context);
                return assignmentRepository;
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
