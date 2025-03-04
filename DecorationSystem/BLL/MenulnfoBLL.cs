using Commo;
using Entity;
using Entity.DTO;
using IBLL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MenulnfoBLL : IMenulnfoBLL
    {

        IMenulnfoDAL _menulnfoDAL;
        IRoleMenuDAL _roleMenuDAL;
        IEmployeeDAL _employeeDAL;
        public MenulnfoBLL(IMenulnfoDAL menulnfoDAL, IRoleMenuDAL roleMenuDAL, IEmployeeDAL employeeDAL)
        {

            _menulnfoDAL = menulnfoDAL;
            _roleMenuDAL = roleMenuDAL;
            _employeeDAL = employeeDAL;
        }

        /// <summary>
        /// 菜单视图渲染
        /// </summary>
        /// <param name="page"></param>//
        /// <param name="limit"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public APIResultModel TableMenuInfo(int page, int limit, string title)
        {


            var list = from m1 in _menulnfoDAL.GetDbSet().Where(x => x.IsDelete == false)
                       join m2 in _menulnfoDAL.GetDbSet().Where(x => x.IsDelete == false)
                       on m1.ParentId equals m2.Id into tempM2
                       from mm2 in tempM2.DefaultIfEmpty()
                       select new
                       {
                           m1.Id,
                           m1.Icon,
                           m1.Target,
                           m1.Level,
                           m1.Href,
                           m1.Title,
                           m1.Description,
                           m1.CreateTime,
                           m1.Sort,
                           PareentTitle = mm2.Title,


                       };
            if (!string.IsNullOrEmpty(title))
            {
                list = list.Where(x => x.Title.Contains(title));
            }

            List<MenuInfoModel> res = list.OrderBy(e => e.Sort).Skip((page - 1) * limit).Take(limit).Select(e => new MenuInfoModel()
            {

                CreateTime = e.CreateTime.ToString("yyyy-mm-dd HH:mm:ss"),
                Id = e.Id,
                Sort = e.Sort,
                Level = e.Level,
                Description = e.Description,
                Href = e.Href,
                Icon = e.Icon,
                ParentId = e.PareentTitle,
                Target = e.Target,
                Title = e.Title,

            }).ToList();
            int count = _menulnfoDAL.GetDbSet().Count();
            return APIResultModel.GetSuccessResultForLayui("成功", count, res);
        }


        /// <summary>
        /// 修改的递归封装方法
        /// </summary>
        /// <param name="parentMenuList"></param>
        /// <param name="allMenuList"></param>
        /// <param name="childMenuIdList"></param>
        public void GetMenuChildIdList(List<MenuInfo> parentMenuList, List<MenuInfo> allMenuList, List<string> childMenuIdList)
        {
            foreach (MenuInfo item in parentMenuList)
            {
                List<MenuInfo> childrenMenuList = allMenuList.Where(x => x.ParentId == item.Id).ToList();
                //孩子菜单那的集合
                List<string> childMenuIdList2 = childrenMenuList.Select(x => x.Id).ToList();
                childMenuIdList.AddRange(childMenuIdList2);

                if (childrenMenuList != null && childMenuIdList.Count > 0)
                {
                    GetMenuChildIdList(childrenMenuList, allMenuList, childMenuIdList);
                }

            }
        }

        /// <summary>
        /// 找出修改的下拉框找出父级
        /// </summary>
        /// <param name="numId"></param>
        /// <returns></returns>
        public APIResultModel GetLsitMenuInfo(string numId)
        {
            List<MenuInfo> allMenuList = _menulnfoDAL.GetDbSet().Where(x => !x.IsDelete).ToList();
            //把全部没有被删除的菜单都查出来
            List<MenuInfo> menuInfos = allMenuList.Where(x => x.ParentId == numId).ToList();
            //找到自己的子孙菜单有哪些
            //找自己的孩子
            List<string> childMenuInfoslist = menuInfos.Select(m => m.Id).ToList();
            GetMenuChildIdList(menuInfos, allMenuList, childMenuInfoslist);
            var arr = _menulnfoDAL.GetDbSet().Where(x => x.IsDelete == false && !childMenuInfoslist.Contains(x.Id) && x.Id != numId).Select(x => new
            {
                x.Id,
                x.Title
            }).ToList();
            return APIResultModel.GetErrorResult("成功", arr);
        }
        /// <summary>
        /// 找出添加的
        /// </summary>
        /// <returns></returns>
        public APIResultModel AddGetLsitMenuInfo()
        {
            var arr = _menulnfoDAL.GetDbSet().Where(x => x.IsDelete == false).Select(x => new
            {
                x.Id,
                x.Title
            }).ToList();
            return APIResultModel.GetErrorResult("成功", arr);
        }
        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="level"></param>
        /// <param name="sort"></param>
        /// <param name="href"></param>
        /// <param name="parentId"></param>
        /// <param name="icon"></param>
        /// <param name="target"></param>
        /// <returns></returns>

        public APIResultModel AddIndex(string title, string description, int level, int sort, string href, string parentId, string icon, string target)
        {

            MenuInfo employee = _menulnfoDAL.GetDbSet().FirstOrDefault(e => e.Title == title);
            if (employee != null)
            {

                return APIResultModel.GetErrorResult("此标题已存在");
            }
            MenuInfo enti = new MenuInfo();
            enti.Id = Guid.NewGuid().ToString();
            enti.Description = description;
            enti.Level = level;
            enti.Sort = sort;
            enti.Href = href;
            enti.ParentId = parentId;
            enti.Title = title;
            enti.Target = target;
            enti.CreateTime = DateTime.Now;
            enti.Icon = icon;
            bool set = _menulnfoDAL.Create(enti);
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

        public APIResultModel DeleteMenuInfo(string id)
        {
            MenuInfo employee = _menulnfoDAL.GetEntityById(id);
            if (employee != null)
            {
                int conunt = _menulnfoDAL.GetDbSet().Where(x => x.ParentId == employee.Id).Count();
                if (conunt > 0)
                {
                    return APIResultModel.GetErrorResult("菜单有孩子请删除完");
                }
                bool set = _menulnfoDAL.Delete1(employee.Id);
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
                return APIResultModel.GetErrorResult("查无此人");
            }
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>

        public APIResultModel BatchDeleteMenuInfo(List<string> ids)
        {
            bool set = false;
            foreach (var id in ids)
            {
                MenuInfo employee = _menulnfoDAL.GetEntityById(id);
                if (employee != null)
                {
                    int conunt = _menulnfoDAL.GetDbSet().Where(x => x.ParentId == employee.Id).Count();
                    if (conunt > 0)
                    {
                        return APIResultModel.GetErrorResult(employee.Title + "有孩子请删除完");
                    }
                    employee.IsDelete = true;
                    employee.DeleteTime = DateTime.Now;
                    set = _menulnfoDAL.Update(employee);
                }
            }
            if (set)
            {
                return APIResultModel.GetSuccessResult("删除成功");
            }
            else
            {
                return APIResultModel.GetErrorResult("删除失败");
            }


        }
        /// <summary>
        /// 修改也获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel UpdatGet(string id)
        {

            MenuInfo employee = _menulnfoDAL.GetEntityById(id);
            return APIResultModel.GetErrorResult("成功", employee);
        }
        /// <summary>
        /// 跟新自己菜单孩子
        /// </summary>
        /// <param name="allMenuList"></param>
        /// <param name="parentId"></param>
        /// <param name="parentLevel"></param>
        public void UpdateMenuChidLsit(List<MenuInfo> allMenuList, string parentId, int parentLevel)
        {
            List<MenuInfo> childMenuList2 = allMenuList.Where(x => x.ParentId == parentId).ToList();
            foreach (MenuInfo childMenu in childMenuList2)
            {
                childMenu.Level = parentLevel + 1;
                _menulnfoDAL.Update(childMenu);
                UpdateMenuChidLsit(allMenuList, childMenu.Id, childMenu.Level);
            }
        }
        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="level"></param>
        /// <param name="sort"></param>
        /// <param name="href"></param>
        /// <param name="icon"></param>
        /// <param name="target"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public APIResultModel UpdatRoleInfo(string id, string title, string description, int level, int sort, string href, string icon, string target, string parentId)
        {
            MenuInfo parentMenu = _menulnfoDAL.GetDbSet().FirstOrDefault(x => x.Id == parentId && x.IsDelete == false);
            if (parentMenu == null)
            {
                return APIResultModel.GetErrorResult("父级菜单数据未找到");
            }
            if (parentMenu.Level + 1 != level)
            {
                return APIResultModel.GetErrorResult("菜单等级请输入" + (parentMenu.Level + 1));
            }
            List<MenuInfo> allMenuList = _menulnfoDAL.GetDbSet().Where(m => m.IsDelete == false).ToList();
            UpdateMenuChidLsit(allMenuList, id, level);
            MenuInfo menuInfo = _menulnfoDAL.GetEntityById(id);
            if (menuInfo != null)
            {
                menuInfo.Description = description;
                menuInfo.Level = level;
                menuInfo.Sort = sort;
                menuInfo.Href = href;
                menuInfo.ParentId = parentId;
                menuInfo.Title = title;
                menuInfo.Target = target;

                menuInfo.Icon = icon;

                bool set = _menulnfoDAL.Update(menuInfo);
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
                return APIResultModel.GetErrorResult("查无此人");
            }
        }
        public void GetMenuChildren(List<GetMenuInfoModel> parentMentData, List<GetMenuInfoModel> meunDatas)
        {
            foreach (var item in parentMentData)
            {
                var childMentDatas = meunDatas.Where(x => x.ParentId == item.Id && x.Level == item.Level + 1).Select(x => new GetMenuInfoModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Href = x.Href,
                    Icon = x.Icon,
                    Target = x.Target,
                    Level = x.Level

                }).ToList();
                GetMenuChildren(childMentDatas, meunDatas);
                item.Child = childMentDatas;
            }
        }


        /// <summary>
        /// 首页菜单
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public object GetHomeMenuList(string employeeId)
        {
            Employee employee = _employeeDAL.GetEntityById(employeeId);
            if (employee.Account != "admin")
            {
                if (employee == null || employee.RoleId == null)
                {
                    return null;
                }
            }


            var query = _menulnfoDAL.GetDbSet().OrderBy(x => x.Sort).Where(x => x.IsDelete == false);
            if (employee.Account != "admin")
            {
                List<string> menuIdList = _roleMenuDAL.GetDbSet().Where(x => x.RoleId == employee.RoleId).Select(x => x.MenuId).ToList();
                query = query.Where(x => menuIdList.Contains(x.Id));
                //重数据库找菜单表里面的数据
            }
            //List<string> menuIdList =   _roleMenuDAL.GetDbSet().Where(x => x.RoleId == employee.RoleId).Select(x=>x.MenuId).ToList();
            //重数据库找菜单表里面的数据
            List<GetMenuInfoModel> meunDatas = query.Select(x => new GetMenuInfoModel
            {
                Id = x.Id,
                Title = x.Title,
                Href = x.Href,
                Icon = x.Icon,
                Target = x.Target,
                Level = x.Level,
                ParentId = x.ParentId

            }).ToList();
            //挑出最外一个的菜单
            List<GetMenuInfoModel> parentMentData = meunDatas.Where(x => x.Level == 1 && x.ParentId == null).Select(x => new GetMenuInfoModel
            {
                Id = x.Id,
                Title = x.Title,
                Href = x.Href,
                Icon = x.Icon,
                Target = x.Target,
                Level = x.Level
            }).ToList();
            GetMenuChildren(parentMentData, meunDatas);
            #region 为父级菜单找孩子菜单
            ////为父级菜单找孩子菜单
            //foreach (var item in parentMentData)
            //{
            //    var childMentDatas = meunDatas.Where(x => x.ParentId == item.Id && x.Level == 2).Select(x => new GetMenuInfoModel
            //    {
            //        Id = x.Id,
            //        Title = x.Title,
            //        Href = x.Href,
            //        Icon = x.Icon,
            //        Target = x.Target
            //    }).ToList();
            //    item.Child = childMentDatas;
            //}
            #endregion
            var menuList = new HomeMenuModel()
            {
                HomeInfo = new GetMenuInfoModel()
                {
                    Title = "首页",
                    Href = "/Home/WelcomeView"
                },
                LogoInfo = new GetMenuInfoModel()
                {
                    Title = "装修系统",
                    Image = "/layuimini-v2/images/logo.png",
                    Href = ""
                },
                MenuInfo = new List<GetMenuInfoModel>()
                {

                    new GetMenuInfoModel()
                    {
                        Title = "常规管理",
                        Icon = "fa fa-address-book",
                        Href = "",
                        Target = "_self",
                        Child = parentMentData

                    }
                }

            };


            return menuList;
        }

    }
}
