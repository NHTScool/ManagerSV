namespace ManagerSV.Models
{
    public class StudentStoreDatabaseSetting:IstudentStoreDatabaseSetting
    {
        public String StudentCourseCollectionName { get; set; } =string.Empty;
        public String ConnectionString { get; set; } = string.Empty;
        public String DatabaseName { get; set; } = string.Empty;
    }
}
