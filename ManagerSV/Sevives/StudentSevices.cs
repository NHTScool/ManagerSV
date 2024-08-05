using ManagerSV.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ManagerSV.Sevives
{

        public class StudentSevices : IstudentSevices
        {
            private readonly IMongoCollection<Student> _students;

            public StudentSevices(IstudentStoreDatabaseSetting settings, IMongoClient mongoClient)
            {
                var databse = mongoClient.GetDatabase(settings.DatabaseName);
                _students = databse.GetCollection<Student>(settings.StudentCourseCollectionName);
            }
            public Student Create(Student student)
            {
                _students.InsertOne(student);
                return student;
            }

            public void delete(string id)
            {
                _students.DeleteOne(student => student.Id == id);
            }

            public Student Get(string id)
            {
                return _students.Find(Student => Student.Id == id).FirstOrDefault();
            }

            public List<Student> Get()
            {
                return _students.Find(student => true).ToList();
            }
            public List<Student> GetNumber(int x)
            {
                return _students.Find(student => true).Limit(x).ToList();
            }
            public Student GetByName(string name)
            {
                var filter = Builders<Student>.Filter.Regex("Name", new BsonRegularExpression(name, "i"));
                return _students.Find(filter).FirstOrDefault();
            }
            public List<Student> GetByNameAll(string name)
            {
                var filter = Builders<Student>.Filter.Regex("Name", new BsonRegularExpression(name, "i"));
                return _students.Find(filter).ToList();
            }
            public void update(string id, Student student)
            {
                _students.ReplaceOne(student => student.Id == id, student);
            }
            public List<Student> GetPage(int x, int pagesize)
            {
                return _students.Find(student => true).Skip(x).Limit(pagesize).ToList();
            }
        public long GetTotalCount()
        {
            // Lấy tổng số sinh viên
            return _students.CountDocuments(student => true);
        }
    }

}
