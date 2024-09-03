using System.Linq.Expressions;
using WbApiDemo3_22_5.Entities;
using WbApiDemo3_22_5.Repository.Abstract;
using WbApiDemo3_22_5.Services.Abstract;

namespace WbApiDemo3_22_5.Services.Concrete
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task AddAsync(Student entity)
        {
            await _studentRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Student entity)
        {
            await _studentRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student> GetAsync(Expression<Func<Student, bool>> predicate)
        {
            return await _studentRepository.GetAsync(predicate);
        }

        public async Task UpdateAsync(Student entity)
        {
            await _studentRepository.UpdateAsync(entity);
        }
    }
}