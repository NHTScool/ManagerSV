using ManagerSV.Models;
namespace ManagerSV.Sevives
{
    public interface IstudentSevices
    {
        List<Student> Get();
        List<Student> GetNumber(int id);
        Student Get(string id);
        Student Create(Student student);
        Student GetByName(string name);
        List<Student> GetByNameAll(string name);
        void update(string id, Student student);
        void delete(string id);
        List<Student> GetPage(int x, int pagesize);
        public long GetTotalCount();
    }
}
