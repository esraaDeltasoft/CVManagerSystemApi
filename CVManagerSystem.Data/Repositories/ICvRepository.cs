using CVManagerSystem.Data.Helper;
using CVManagerSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManagerSystem.Data.Repositories
{
    public interface ICvRepository
    {
        Task<QueryResult> GetAllCVsAsync();
        Task<QueryResult> GetCVByIdAsync(int id);
        Task<QueryResult> CreateCVAsync(CV cv);
        Task<QueryResult> UpdateCVAsync(CV cv);
        Task<QueryResult> DeleteCVAsync(int id);
    }
}
