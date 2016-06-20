namespace DBConnectSample.DBContext
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“StudentContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“DBConnectSample.DBContext.StudentContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“StudentContext”
        //连接字符串。
        public StudentContext()
            : base("name=StudentContext")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentInfo> StudentInfos { get; set; }
    }
}