using BLL;
using DAL;
using Entity;
using IBLL;
using IDAL;
using Microsoft.EntityFrameworkCore;

namespace DecorationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
            });

            //BLLµÄ×¢²á
            builder.Services.AddScoped<IEmployeeBLL, EmployeeBLL>();
            builder.Services.AddScoped<MyDbContext, MyDbContext>();
            builder.Services.AddScoped<ILogInBLL, LogInBLL>();
            builder.Services.AddScoped<IRolelnfoBLL, RolelnfoBLL>();
            builder.Services.AddScoped<IMenulnfoBLL, MenulnfoBLL>();
            builder.Services.AddScoped<INoticeBLL,NoticeBLL>();
            builder.Services.AddScoped<IOrdersBLL, OrdersBLL>();
            builder.Services.AddScoped<IMaterialBLL, MaterialBLL>();
          


            //DALµÄ×¢²á
            builder.Services.AddScoped<IFileInfosDAL, FileInfosDAL>();
            builder.Services.AddScoped<IFileInfosDAL, FileInfosDAL>();
            builder.Services.AddScoped<IEmployeeDAL, EmployeeDAL>();
            builder.Services.AddScoped<IRolelnfoDAL, RolelnfoDAL>();
            builder.Services.AddScoped<IMenulnfoDAL, MenulnfoDAL>();
            builder.Services.AddScoped<IRoleMenuDAL, RoleMenuDAL>();
            builder.Services.AddScoped<INoticeDAL, NoticeDAL>();
            builder.Services.AddScoped<IMaterialDAL, MaterialDAL>();
            builder.Services.AddScoped<IOrdersDAL, OrdersDAL>();
            builder.Services.AddScoped<IOrdersMaterialDAL, OrdersMaterialDAL>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=LogIn}/{action=Index}/{id?}");

            app.Run();
        }
    }
}