using Commo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IEmployeeBLL
    {

        /// <summary>
        /// 注册功能
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public APIResultModel Employeev(string account, string password);
        /// <summary>
        /// 渲染视图
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public APIResultModel TableEmployee(int page, int limit, string name, string account);
        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public APIResultModel AddIndex(string account, string password, string name, string phone, string roleId);
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel DeleteEmployee(string id);
        /// <summary>
        /// 批量删除功能
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public APIResultModel BatchDeleteEmployee(List<string> ids);
        /// <summary>
        /// 渲染修改数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel UpdatGet(string id);
        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public APIResultModel UpdatEmployee(string id, string name, string phone, string roleId);
        /// <summary>
        /// 获取下拉框功能
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetOptionList();
        /// <summary>
        /// 修改密码功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public APIResultModel EmployeePassword(string id, string oldPassword, string newPassword);

        /// <summary>
        /// 基本信息渲染
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public APIResultModel EmployeeInfo(string employeeId);

        /// <summary>
        /// 基本信息的添加
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public APIResultModel EmployeeInfoAdd(string employeeId, string name, string phone);
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="uploadStream"></param>
        /// <returns></returns>
        public APIResultModel Upload(Stream uploadStream, string oldFileNaem, string employeeId);

        /// <summary>
        /// 获取登录人的头像
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetEmployeePhoto(string employeeId);

        /// <summary>
        /// 下载头像
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="oldFileNaem"></param>
        /// <returns></returns>
        public Stream Dowload(string employeeId, out string oldFileNaem);

        /// <summary>
        /// 名单导入
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public APIResultModel Import(Stream uploadStream, string fileName);
        public Stream Export();
    }
}

