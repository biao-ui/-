using Commo;
using DAL;
using Entity;
using Entity.DTO;
using IBLL;
using IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RolelnfoBLL : IRolelnfoBLL
    {
        IRolelnfoDAL _rolelnfoDAL;
        IEmployeeDAL _employeeDAL;
        IMenulnfoDAL _iMenulnfoDAL;
        IRoleMenuDAL _menuDAL;
        public RolelnfoBLL(IRolelnfoDAL rolelnfoDAL, IEmployeeDAL employeeDAL, IMenulnfoDAL menulnfoDAL, IRoleMenuDAL roleMenuDAL)
        {
            _rolelnfoDAL = rolelnfoDAL;
            _employeeDAL = employeeDAL;
            _iMenulnfoDAL = menulnfoDAL;
            _menuDAL = roleMenuDAL;
        }



        /// <summary>
        /// 这是角色视图渲染
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public APIResultModel TableRoleInfo(int page, int limit, string name)
        {
            IQueryable<RoleInfo> list = _rolelnfoDAL.GetDbSet().Where(x => x.IsDelete == false);
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(x => x.Name.Contains(name));
            }

            List<RoleInfoModel> res = list.OrderByDescending(e => e.CreateTime).Skip((page - 1) * limit).Take(limit).Select(e => new RoleInfoModel()
            {

                CreateTime = e.CreateTime.ToString("yyyy-mm-dd HH:mm:ss"),
                Name = e.Name,
                Id = e.Id,
                Remark = e.Remark

            }).ToList();
            int count = _rolelnfoDAL.GetDbSet().Count();
            return APIResultModel.GetSuccessResultForLayui("成功", count, res);
        }
        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="name"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public APIResultModel AddIndex(string name, string remark)
        {
            RoleInfo employee = _rolelnfoDAL.GetDbSet().FirstOrDefault(e => e.Name == name);
            if (employee != null)
            {

                APIResultModel.GetErrorResult("账号已存在");
            }
            RoleInfo enti = new RoleInfo();
            enti.Id = Guid.NewGuid().ToString();
            enti.Remark = remark;
            enti.Name = name;
            enti.CreateTime = DateTime.Now;
            //_myDbContext.RoleInfo.Add(enti);
            //_myDbContext.SaveChanges();
            //return APIResultModel.GetSuccessResult("添加成功");
            bool set = _rolelnfoDAL.Create(enti);
            if (set)
            {
                return APIResultModel.GetSuccessResult("添加成功");
            }
            else
            {
                return APIResultModel.GetErrorResult("添加失败");
            }
        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel DeleteRoleInfo(string id)
        {

            RoleInfo employee = _rolelnfoDAL.GetEntityById(id);
            if (employee != null)
            {
                employee.IsDelete = true;
                employee.DeleteTime = DateTime.Now;
                bool set = _rolelnfoDAL.Update(employee);
                if (set)
                {
                    return APIResultModel.GetSuccessResult("删除成功");
                }
                else
                {
                    return APIResultModel.GetErrorResult("删除失败");
                }

            }
            else
            {
                return APIResultModel.GetErrorResult("删除失败");
            }

        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public APIResultModel BatchDeleteRoleInfo(List<string> ids)
        {

            foreach (var id in ids)
            {
                RoleInfo employee = _rolelnfoDAL.GetEntityById(id);
                if (employee != null)
                {
                    employee.IsDelete = true;
                    employee.DeleteTime = DateTime.Now;
                    bool set = _rolelnfoDAL.Update(employee);
                    if (set)
                    {
                        return APIResultModel.GetSuccessResult("删除成功");
                    }
                    else
                    {
                        return APIResultModel.GetErrorResult("删除失败");
                    }

                }
            }

            return APIResultModel.GetErrorResult("查无此人");
        }

        /// <summary>
        /// 修改页的渲染数据功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel UpdatGet(string id)
        {
            RoleInfo employee = _rolelnfoDAL.GetEntityById(id);
            return APIResultModel.GetErrorResult("成功", employee);
        }
        /// <summary>
        /// 角色修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public APIResultModel UpdatRoleInfo(string id, string name, string remark)
        {

            RoleInfo RoleInfo = _rolelnfoDAL.GetEntityById(id);
            if (RoleInfo != null)
            {
                RoleInfo.Name = name;
                RoleInfo.Remark = remark;

                bool set = _rolelnfoDAL.Update(RoleInfo);
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
                return APIResultModel.GetErrorResult("查无人");
            }
        }


        /// <summary>
        /// 穿梭框的获取
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetTransferOptionList(string roleId)
        {

            var list = _employeeDAL.GetDbSet().Where(x => (x.IsDelete == false && x.RoleId == null) || (x.IsDelete == false && x.RoleId == roleId)).Select(x => new
            {
                Value = x.Id,
                Title = x.Name
            }).ToList();
            //已绑定用户id
            List<string> employeeIds = _employeeDAL.GetDbSet().Where(e => e.IsDelete == false && e.RoleId == roleId).Select(e => e.Id).ToList();


            return APIResultModel.GetErrorResult("成功", new
            {
                list,
                employeeIds
            });

        }
        /// <summary>
        /// 绑定员工
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="employeeIds"></param>
        /// <returns></returns>
        public APIResultModel BindEmployee(int index, string roleId, List<string> employeeIds)
        {

            List<Employee> employees = _employeeDAL.GetDbSet().Where(x => employeeIds.Contains(x.Id)).ToList();
            //index:0是绑定,1是解绑
            if (index == 0)
            {
                bool set = false;
                foreach (Employee employee in employees)
                {
                    employee.RoleId = roleId;
                    set = _employeeDAL.Update(employee);


                }
                if (set)
                {
                    return APIResultModel.GetSuccessResult("绑定成功");
                }
                else
                {
                    return APIResultModel.GetErrorResult("绑定失败");
                }
            }
            else if (index == 1)
            {
                bool set = false;
                foreach (Employee employee in employees)
                {
                    employee.RoleId = null;
                    set = _employeeDAL.Update(employee);

                }
                if (set)
                {
                    return APIResultModel.GetSuccessResult("解绑成功");
                }
                else
                {
                    return APIResultModel.GetErrorResult("解绑失败");
                }
            }
            else
            {
                return APIResultModel.GetErrorResult("参数有误");
            }

           

        }

        public APIResultModel GetMenulnfoOptionList(string roleId)
        {
            var menuInfo = _iMenulnfoDAL.GetDbSet().Where(x => x.IsDelete == false).Select(x => new
            {
                Value = x.Id,
                Title = x.Title,
            }).ToList();
            var menuIds = _menuDAL.GetDbSet().Where(x => x.RoleId == roleId).Select(x => x.MenuId).ToList();
            return APIResultModel.GetErrorResult("成功", new
            {
                menuInfo,
                menuIds
            });
        }

        /// <summary>
        /// 绑定炒作
        /// </summary>
        /// <param name="index"></param>
        /// <param name="roleId"></param>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public APIResultModel BinMenulnfo(int index, string roleId, List<string>? menuIds)
        {
            //List<Employee> employees = _myDbContext.Employee.Where(x => employeeIds.Contains(x.Id)).ToList();
            //index:0是绑定,1是解绑
            if (index == 0)
            {
                bool set = false;
                foreach (string menuid in menuIds)
                {

                    RoleMenu roleMenu = new RoleMenu();
                    roleMenu.RoleId = roleId;
                    roleMenu.Id = Guid.NewGuid().ToString();
                    roleMenu.MenuId = menuid;
                    roleMenu.CreateTime = DateTime.Now;
                    set = _menuDAL.Create(roleMenu);
                   

                }
                if (set)
                {
                    return APIResultModel.GetSuccessResult("添加成功");
                }
                else
                {
                    return APIResultModel.GetErrorResult("添加失败");
                }

            }
            else if (index == 1)
            {

                bool set = false;
                foreach (string menuid in menuIds)
                {
                    RoleMenu roleMenu = new RoleMenu();
                    List<RoleMenu> randoms = _menuDAL.GetDbSet().Where(x => x.RoleId == roleId && menuid.Contains(x.MenuId)).ToList();
                    foreach (var item in randoms)
                    {
                        roleMenu = item;
                         set = _menuDAL.DeleteRoleMenu(item);


                    }
                }
           
                if (set)
                {
                    return APIResultModel.GetSuccessResult("解绑成功");
                }
                else
                {
                    return APIResultModel.GetErrorResult("请确定绑定");
                }

            }
            else
            {
                return APIResultModel.GetErrorResult("请确定绑定");
            }
          
        }


    }
}
