using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PersonalAffairsManagementSystem.Models
{
    public class S_ConstantDbContext: DbContext
    {
        //添加表S_Constant实体
        public DbSet<S_Constant> s_Constants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //配置Sqlserver连接字符串
            optionsBuilder.UseSqlServer("Server=.;Database=PAMS; User=sa;Password=123sa;");

            //对于这个上下文重写此方法以配置要使用的数据库（和其他选项）。对于上下文的每个实例调用此方法创建。

            //加载appsetting.json
            //IConfiguration configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //  .AddJsonFile("appsettings.json").Build();

            //string connectionString = configuration["ConnectionStrings:SqlServer"];
            //optionsBuilder.UseSqlServer(connectionString);

            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<S_Constant>()
                .Property(b => b.CValue)
                .IsRequired();
        }
    }
}
