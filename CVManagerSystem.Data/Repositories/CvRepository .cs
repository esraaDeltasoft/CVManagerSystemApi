using CVManagerSystem.Data.Data;
using CVManagerSystem.Data.Helper;
using CVManagerSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CVManagerSystem.Data.Repositories
{
    public class CvRepository : ICvRepository
    {
        private readonly CVManagerSystemDbContext _context;

        public CvRepository(CVManagerSystemDbContext context)
        {
            _context = context;
        }
        public async Task<QueryResult> GetAllCVsAsync()
        {
            try
            {
                var cvs =await _context.CVs
                    .Include(c=>c.PersonalInformation)
                    .Include(c=>c.ExperienceInformation)
                    .ToListAsync();
                return new QueryResult() { Successed = true, Message = cvs };
            }
            catch (Exception)
            {
                return new QueryResult() { Successed = false, Message = "حدث خطأ" };
            }
        }
        public async Task<QueryResult> GetCVByIdAsync(int id)
        {
            try
            {
                var cv= await _context.CVs
                    .Include(c => c.PersonalInformation)
                    .Include(c => c.ExperienceInformation)
                    .FirstOrDefaultAsync(c=>c.Id==id);
                return new QueryResult() { Successed = true, Message = cv };
            }
            catch (Exception)
            {
                return new QueryResult() { Successed = false, Message = "حدث خطأ" };
            }
        }

        public async Task<QueryResult> CreateCVAsync(CV cv)
        {
           
            try
            {
                _context.CVs.Add(cv);
                await _context.SaveChangesAsync();
                return new QueryResult() { Successed = true, Message = cv };
            }
            catch (Exception)
            {
                return new QueryResult() { Successed = false, Message = "حدث خطأ" };
            }
        }

        public async Task<QueryResult> UpdateCVAsync(CV cv)
        {
           
            try
            {
                _context.Entry(cv).State = EntityState.Modified;
                _context.Entry(cv.ExperienceInformation).State = EntityState.Modified;
                _context.Entry(cv.PersonalInformation).State = EntityState.Modified;
                _context.Entry(cv).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new QueryResult() { Successed = true, Message = "تم تحديث السيرة الذاتية بنجاح" };
            }
            catch (Exception)
            {
                return new QueryResult() { Successed = false, Message = "حدث خطأ" };
            }
        }

        public async Task<QueryResult> DeleteCVAsync(int id)
        {
            try
            {
                var cv = await _context.CVs
                    .Include(c => c.PersonalInformation)
                    .Include(c => c.ExperienceInformation).FirstOrDefaultAsync(c=>c.Id==id);
                if (cv != null)
                {
                    _context.ExperienceInformations.Remove(cv.ExperienceInformation);
                    _context.PersonalInformations.Remove(cv.PersonalInformation);
                    _context.CVs.Remove(cv);
                    await _context.SaveChangesAsync();
                }
                return new QueryResult() { Successed = true, Message = "تم حذف السيرة الذاتية بنجاح" };
            }
            catch (Exception)
            {
                return new QueryResult() { Successed = false, Message = "حدث خطأ" };
            }
            
        }
    }
}

