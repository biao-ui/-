using Commo;
using DAL;
using Entity;
using Entity.Enums;
using IBLL;
using IDAL;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBLL : IEmployeeBLL
    {


        IEmployeeDAL _employeeDAL;
        IRolelnfoDAL _rolelnfoDAL;
        IFileInfosDAL _fileInfosDAL;
        public EmployeeBLL(IEmployeeDAL employeeDAL, IRolelnfoDAL rolelnfoDAL, IFileInfosDAL fileInfosDAL)
        {

            _employeeDAL = employeeDAL;
            _rolelnfoDAL = rolelnfoDAL;
            _fileInfosDAL = fileInfosDAL;
        }

        /// <summary>
        /// 注册功能
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public APIResultModel Employeev(string account, string password)
        {
            var arr = _employeeDAL.Employeev(account);
            if (arr != null)
            {
                return APIResultModel.GetErrorResult("此账号已存在");
            }
            string newPassword = MD5Helper.GetMD5(password);
            Employee employee = new Employee();
            employee.Id = Guid.NewGuid().ToString();
            employee.Account = account;
            employee.Password = newPassword;
            employee.Name = account;
            employee.CreateTime = DateTime.Now;

            bool set = _employeeDAL.Create(employee);
            if (set)
            {
                return APIResultModel.GetSuccessResult("注册成功");
            }
            else
            {
                return APIResultModel.GetErrorResult("注册失败");
            }




        }
        /// <summary>
        /// 渲染视图
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public APIResultModel TableEmployee(int page, int limit, string name, string account)
        {
            //IQueryable<Employee> list = dbContext.Employee.Where(x=>x.IsDelete ==false);
            var list = from e in _employeeDAL.GetDbSet().Where(x => x.IsDelete == false)
                       join r in _rolelnfoDAL.GetDbSet().Where(x => x.IsDelete == false)
                       on e.RoleId equals r.Id
                       into rempR
                       from rr in rempR.DefaultIfEmpty()
                       select new
                       {
                           e.Id,
                           e.Name,
                           e.Account,
                           e.CreateTime,
                           e.Phone,
                           RoleName = rr.Name
                       };


            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(account))
            {
                list = list.Where(x => x.Account.Contains(account));
            }
            var res = list.OrderByDescending(e => e.CreateTime).Skip((page - 1) * limit).Take(limit).ToList().Select(item =>
            {
                return new
                {
                    CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    item.Name,
                    item.Account,
                    item.Id,
                    item.RoleName,
                    item.Phone
                };

            }).ToList();
            int count = _employeeDAL.GetDbSet().Count();
            return APIResultModel.GetSuccessResultForLayui("成功", count, res);
        }
        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public APIResultModel AddIndex(string account, string password, string name, string phone, string roleId)
        {
            Employee employee = _employeeDAL.Employeev(account);
            if (employee != null)
            {

                return APIResultModel.GetErrorResult("账号已存在");
            }
            Employee employee2 = _employeeDAL.GetDbSet().Where(x => x.Phone == phone).FirstOrDefault();
            if (employee2 != null)
            {

                return APIResultModel.GetErrorResult("此号码已存在");
            }
            Employee enti = new Employee();
            enti.Id = Guid.NewGuid().ToString();
            enti.Account = account;
            enti.Password = MD5Helper.GetMD5(password);
            enti.Name = name;
            enti.Phone = phone;
            enti.RoleId = roleId;
            enti.CreateTime = DateTime.Now;
            bool set = _employeeDAL.Create(enti);
            if (set)
            {
                return APIResultModel.GetSuccessResult("添加成功");
            }
            else
            {
                return APIResultModel.GetErrorResult("注册失败");
            }
        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel DeleteEmployee(string id)
        {
            Employee employee = _employeeDAL.GetEntityById(id);
            if (employee != null)
            {
                employee.IsDelete = true;
                employee.DeleteTime = DateTime.Now;
                bool set = _employeeDAL.Update(employee);
                if (set)
                {
                    return APIResultModel.GetSuccessResult("删除成功");
                }
                else
                {
                    return APIResultModel.GetErrorResult("修改失败");
                }
            }
            else
            {
                return APIResultModel.GetErrorResult("删除失败");
            }
        }

        /// <summary>
        /// 批量删除功能
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public APIResultModel BatchDeleteEmployee(List<string> ids)
        {

            foreach (var id in ids)
            {
                Employee employee = _employeeDAL.GetEntityById(id);
                if (employee != null)
                {
                    employee.IsDelete = true;
                    employee.DeleteTime = DateTime.Now;
                    bool set = _employeeDAL.Update(employee);
                    if (set)
                    {
                        return APIResultModel.GetSuccessResult("删除成功");
                    }
                    else
                    {
                        return APIResultModel.GetErrorResult("失败成功");
                    }
                }


            }
            return APIResultModel.GetErrorResult("");

        }

        /// <summary>
        /// 渲染修改数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel UpdatGet(string id)
        {
            Employee employee = _employeeDAL.GetEntityById(id);
            return APIResultModel.GetErrorResult("成功", employee);
        }
        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public APIResultModel UpdatEmployee(string id, string name, string phone, string roleId)
        {
            Employee Employee = _employeeDAL.GetEntityById(id);
            if (Employee != null)
            {
                Employee.Name = name;
                Employee.Phone = phone;
                Employee.RoleId = roleId;
                bool set = _employeeDAL.Update(Employee);
                if (set)
                {
                    return APIResultModel.GetSuccessResult("修改成功");
                }
                else
                {
                    return APIResultModel.GetErrorResult("修改失败");
                }


            }
            else
            {
                return APIResultModel.GetErrorResult("修改失败");
            }
        }
        /// <summary>
        /// 获取下拉框功能
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetOptionList()
        {

            var list = _rolelnfoDAL.GetDbSet().Where(x => x.IsDelete == false).Select(x => new
            {
                x.Id,
                x.Name
            }).ToList();
            return APIResultModel.GetErrorResult("成功", list);
        }
        /// <summary>
        /// 修改密码功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public APIResultModel EmployeePassword(string id, string oldPassword, string newPassword)
        {

            Employee employee = _employeeDAL.GetEntityById(id);
            if (employee == null)
            {
                return APIResultModel.GetErrorResult("此人不存在");
            }
            string oldMDPassword = MD5Helper.GetMD5(oldPassword);
            if (employee.Password != oldMDPassword)
            {
                return APIResultModel.GetErrorResult("与旧密码不一致");
            }
            string newMDPassword = MD5Helper.GetMD5(newPassword);
            employee.Password = newMDPassword;

            bool set = _employeeDAL.Update(employee);
            if (set)
            {
                return APIResultModel.GetSuccessResult("修改成功");
            }
            else
            {
                return APIResultModel.GetSuccessResult("修改失败失败");
            }



        }
        /// <summary>
        /// 添加渲染
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public APIResultModel EmployeeInfo(string employeeId)
        {
            var arr = _employeeDAL.GetDbSet().Where(x => x.Id == employeeId).Select(x => new
            {
                x.Name,
                x.Phone
            }).FirstOrDefault();
            if (arr == null)
            {
                return APIResultModel.GetErrorResult("请登录");
            }
            return APIResultModel.GetErrorResult("成功", arr);
        }
        /// <summary>
        /// 基本信息的添加
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public APIResultModel EmployeeInfoAdd(string employeeId, string name, string phone)
        {
            Employee employee = _employeeDAL.GetEntityById(employeeId);
            if (employee == null)
            {
                return APIResultModel.GetErrorResult("查不到此人");
            }
            employee.Name = name;
            employee.Phone = phone;

            bool set = _employeeDAL.Update(employee);
            if (set)
            {
                return APIResultModel.GetSuccessResult("修改成功");
            }
            else
            {
                return APIResultModel.GetErrorResult("执行失败");
            }
        }
        /// <summary>
        /// 处理上传的文件
        /// </summary>
        /// <param name="uploadStream"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public APIResultModel Upload(Stream uploadStream, string oldFileNaem, string employeeId)
        {
            Entity.FileInfo fileInfos = new Entity.FileInfo();
            fileInfos.Id = Guid.NewGuid().ToString();
            fileInfos.OldFileName = oldFileNaem;

            //获取拓展名
            //int index = oldFileNaem.IndexOf(".");
            //string extend = oldFileNaem.Substring(index);
            //第二种
            string extend = Path.GetExtension(oldFileNaem);
            fileInfos.NewFileName = Guid.NewGuid().ToString() + extend;
            fileInfos.FileType = FileTypeEnum.头像;

            //获取当前路径
            string path = Directory.GetCurrentDirectory();
            //path = path + @"\wwwroot\img\头像";
            //第二种
            path = Path.Combine(path, @"wwwroot\img\头像", fileInfos.NewFileName);
            fileInfos.CreatorId = employeeId;
            fileInfos.CreateTime = DateTime.Now;
            fileInfos.Path = path;
            fileInfos.HtmlPath = @"/img/头像/" + fileInfos.NewFileName;
            bool isSuccess = _fileInfosDAL.Create(fileInfos);
            if (!isSuccess)
            {
                return APIResultModel.GetErrorResult("执行失败");
            }

            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);

            uploadStream.CopyTo(fileStream);

            fileStream.Dispose();
            uploadStream.Dispose();
            return APIResultModel.GetSuccessResult("成功");
        }
        /// <summary>
        /// 获取登录人的头像
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetEmployeePhoto(string employeeId)
        {
            var fileInfos = _fileInfosDAL.GetDbSet().Where(x => x.CreatorId == employeeId && !x.IsDelete).OrderByDescending(x => x.CreateTime).Select(x => x.HtmlPath).FirstOrDefault();
            if (fileInfos == null)
            {
                return APIResultModel.GetErrorResult("未找到数据");
            }
            else
            {
                return APIResultModel.GetErrorResult("成功", fileInfos);
            }
        }

        public Stream Dowload(string employeeId, out string oldFileNaem)
        {
            oldFileNaem = "";
            var data = _fileInfosDAL.GetDbSet().OrderByDescending(x => x.CreateTime)
                    .Where(x => x.CreatorId == employeeId && !x.IsDelete && x.FileType == FileTypeEnum.头像)
                    .Select(x => new
                    {
                        x.OldFileName,
                        x.Path
                    }).FirstOrDefault();
            if (data == null)
            {
                return null;
            }
            string path = @"D:\C#范型\DecorationSystem\DecorationSystem\wwwroot\img\touxiang.jpg";
            oldFileNaem = data.OldFileName;
            FileStream fileStream = new FileStream(data.Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            return fileStream;
        }
        /// <summary>
        /// 名单导入
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public APIResultModel Import(Stream uploadStream, string fileName)
        {
            try
            {

                IWorkbook workbook;
                if (fileName.Contains(".xlsx"))
                {
                    workbook = new XSSFWorkbook(uploadStream);
                }
                else if (fileName.Contains(".xls"))
                {
                    workbook = new XSSFWorkbook(uploadStream);
                }
                else
                {
                    return APIResultModel.GetErrorResult("请选择正确的东西上传");
                }
                ISheet sheet = workbook.GetSheetAt(0);
                IRow firsrRow = sheet.GetRow(0);
                string index = firsrRow.GetCell(0).ToString();
                string name = firsrRow.GetCell(1).ToString();
                string phone = firsrRow.GetCell(2).ToString();
                if (phone == null)
                {
                    return APIResultModel.GetErrorResult("电话不能为空");

                }
                if (index != "序号" || name != "姓名" || phone != "电话")
                {
                    return APIResultModel.GetErrorResult("请使用正确模板");
                }

                int lastRowNun = sheet.PhysicalNumberOfRows;
                _employeeDAL.BeginTransaction();
                for (int i = 1; i < lastRowNun; i++)
                {

                    IRow row = sheet.GetRow(i);

                    int lastCellNumd = row.PhysicalNumberOfCells;

                    string nameContent = row.GetCell(1).ToString();
                    string phonecContent = row.GetCell(2).ToString();
                    APIResultModel res = AddIndex(phonecContent, "123456",nameContent, phonecContent, null);

                    if (res.Code != 0)
                    {
                        _employeeDAL.RollbackTransaction();
                        string msg = $"{i + 1}行数据有误,{res.Msg}";
                        res.Msg = msg;
                        return res;
                    }
                }
                _employeeDAL.CommitTransaction();
                uploadStream.Dispose();

                return APIResultModel.GetSuccessResult("成功");
            }
            catch (Exception)
            {

                return APIResultModel.GetErrorResult("请使用正确模板");
            }
        }

        public Stream Export()
        {
            var list = _employeeDAL.GetDbSet().Where(x => !x.IsDelete).Select(x => new
            {
                x.Name,
                x.Phone,
                x.Account,
                x.CreateTime,
            }).ToList();
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("测试表");
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                IRow row = sheet.CreateRow(i);

                ICell cell1 = row.CreateCell(0);
                cell1.SetCellValue(item.Name);
                ICell cell2 = row.CreateCell(1);
                cell2.SetCellValue(item.Phone);

                ICell cell3 = row.CreateCell(2);
                cell3.SetCellValue(item.Account);

                ICell cell4 = row.CreateCell(3);
                cell4.SetCellValue(item.CreateTime);
            }
            string path = Directory.GetCurrentDirectory();
            path = @$"{path}\ExporFiles";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string[] fileNames = Directory.GetFiles(path);
            for (int i = 0; i < fileNames.Length; i++)
            {
                string fileName = fileNames[i];
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);
                DateTime dateTime = DateTime.Now.AddMinutes(-10);
                if (fileInfo.CreationTime < dateTime)
                {
                    fileInfo.Delete();
                }
            }
            path = @$"{path}\{Guid.NewGuid().ToString()}.xlsx";
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);


            workbook.Write(stream);
            FileStream filetStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            return filetStream;

        }
    }
}
