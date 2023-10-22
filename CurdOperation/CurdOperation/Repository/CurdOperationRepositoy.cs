using CurdOperation.IRepository;
using CurdOperation.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace CurdOperation.Repository
{
    public class CurdOperationRepository : ICurdOperations
    {
        private readonly ReadDbContext _contextR;
        private readonly WriteDbContext _contextW;
        IConfiguration _configuration;
        public CurdOperationRepository(ReadDbContext readDbContext,WriteDbContext writeDbContext, IConfiguration configuration)
        {
            _contextR = readDbContext;
            _contextW = writeDbContext;
            _configuration = configuration;
        }
    }
}
