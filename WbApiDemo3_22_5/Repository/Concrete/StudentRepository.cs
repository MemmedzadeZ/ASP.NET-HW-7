using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WbApiDemo3_22_5.Data;
using WbApiDemo3_22_5.Entities;
using WbApiDemo3_22_5.Repository.Abstract;

namespace WbApiDemo3_22_5.Repository.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student entity)
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Student entity)
        {
            await Task.Run(() =>
            {
                _context.Students.Remove(entity);
            });

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return _context.Students;
            });
        }

        public async Task<Student> GetAsync(Expression<Func<Student, bool>> expression)
        {
            var item=await _context.Students.FirstOrDefaultAsync(expression);
            return item;
        }

        public async Task UpdateAsync(Student entity)
        {
            await Task.Run(() =>
            {
                _context.Students.Update(entity);
            });
            await _context.SaveChangesAsync();  
        }
    }
}
