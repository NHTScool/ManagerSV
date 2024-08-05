namespace ManagerSV.Models
{
    public interface IstudentStoreDatabaseSetting
    {
        String StudentCourseCollectionName { get; set; } 
        String ConnectionString { get; set; } 
        String DatabaseName { get; set; }
    }
}
