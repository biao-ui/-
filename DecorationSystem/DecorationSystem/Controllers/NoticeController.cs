using BLL;
using Commo;
using Entity;
using Entity.DTO;
using IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Numerics;

namespace DecorationSystem.Controllers
{
    public class NoticeController : Controller
    {
        IEmployeeBLL _employeeBLL;
        INoticeBLL _oticeBLL;
        public NoticeController(IEmployeeBLL employeeBLL, INoticeBLL noticeBLL)
        {
            _employeeBLL = employeeBLL;
            _oticeBLL = noticeBLL;
        }


        /// <summary>
        /// 视图页
        /// </summary>
        /// <returns></returns>
        public IActionResult TableNoticeIndex()
        {
            return View();
        }
        /// <summary>
        /// 添加页
        /// </summary>
        /// <returns></returns>
        public IActionResult AddIndex()
        {
            return View();
        }
        /// <summary>
        /// 员工修改页
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateNoticeView()
        {
            return View();
        }
        /// <summary>
        /// 详细页面
        /// </summary>
        /// <returns></returns>
        public IActionResult DetailView()
        {
            return View();
        }

          /// <summary>
          /// 试图的渲染
          /// </summary>
          /// <param name="page"></param>
          /// <param name="limit"></param>
          /// <param name="name"></param>
          /// <param name="account"></param>
          /// <returns></returns>
          public APIResultModel TableNotice(int page, int limit, string title)
        {
            if (page <= 0)
            {
                APIResultModel.GetErrorResult("页码有误");
            }

            if (limit <= 0)
            {
                APIResultModel.GetErrorResult("数量有误");
            }

            return _oticeBLL.TableNotice(page, limit, title);


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
        [HttpPost]
        public APIResultModel AddIndex(string title, string content, string creatorId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                APIResultModel.GetErrorResult("标题不能为空");
            }
            if (string.IsNullOrWhiteSpace(content))
            {
                APIResultModel.GetErrorResult("内容不能为空");
            }
            if (string.IsNullOrWhiteSpace(creatorId))
            {
                APIResultModel.GetErrorResult("创建人不能为空");
            }
            //MyDbContext dbContext = new MyDbContext();
            //Notice employee = dbContext.Notice.FirstOrDefault(e => e.Account == account);
            //if (employee != null)
            //{

            //    APIResultModel.GetErrorResult("账号已存在");
            //}
            //Notice enti = new Notice();
            //enti.Id = Guid.NewGuid().ToString();
            //enti.Account = account;
            //enti.Password = password;
            //enti.Name = name;
            //enti.Phone = phone;
            //enti.RoleId = roleId;
            //enti.CreateTime = DateTime.Now;
            //dbContext.Notice.Add(enti);
            //dbContext.SaveChanges();
            //return APIResultModel.GetSuccessResult("添加成功");
            return _oticeBLL.AddIndex(title, content, creatorId);

        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public APIResultModel DeleteNotice(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id有误");
            }
            //MyDbContext dbContext = new MyDbContext();
            //Notice employee = dbContext.Notice.FirstOrDefault(e => e.Id == id);
            //if (employee != null)
            //{
            //    employee.lsDelete = true;
            //    employee.DeleteTime = DateTime.Now;
            //    dbContext.SaveChanges();
            //    return APIResultModel.GetSuccessResult("删除成功");
            //}
            //else
            //{
            //    return APIResultModel.GetErrorResult("删除失败");
            //}

            return _oticeBLL.DeleteNotice(id);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public APIResultModel BatchDeleteNotice(List<string> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return APIResultModel.GetErrorResult("ids参数有误");
            }
            return _oticeBLL.BatchDeleteNotice(ids);
        }

        /// <summary>
        /// 员工修改页渲染数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel UpdatGet(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id参数有误");
            }
            //MyDbContext dbContext = new MyDbContext();
            //Notice employee = dbContext.Notice.FirstOrDefault(x => x.Id == id);
            //return APIResultModel.GetErrorResult("成功", employee);
            return _oticeBLL.UpdatGet(id);
        }
        /// <summary>
        /// 修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        public APIResultModel UpdatNotice(string id, string title, string content)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("id参数有误");
            }
            if (string.IsNullOrEmpty(title))
            {
                return APIResultModel.GetErrorResult("名字不能为空");
            }
            if (string.IsNullOrEmpty(content))
            {
                return APIResultModel.GetErrorResult("内容不能为空");
            }
            return _oticeBLL.UpdatNotice(id, title, content);

            //MyDbContext dbContext = new MyDbContext();
            //Notice Notice = dbContext.Notice.FirstOrDefault(x => x.Id == id);
            //if (Notice != null)
            //{
            //    Notice.Name = name;
            //    Notice.Phone = phone;
            //    Notice.RoleId = roleId;
            //    dbContext.SaveChanges();
            //    return APIResultModel.GetSuccessResult("修改成功");

            //}
            //else
            //{
            //    return APIResultModel.GetErrorResult("修改失败");
            //}
        }

        /// <summary>
        /// 下拉框的获取数据
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetOptionList()
        {
            //MyDbContext dbContext = new MyDbContext();
            //var list = dbContext.RoleInfo.Where(x => x.IsDelete == false).Select(x => new
            //{
            //    x.Id,
            //    x.Name
            //}).ToList();
            //return APIResultModel.GetErrorResult("成功", list);
            return _employeeBLL.GetOptionList();
        }

        public APIResultModel GetNotice(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return APIResultModel.GetErrorResult("编号不能为空");
            }
             object data  = _oticeBLL.GetNotice(id);
            return APIResultModel.GetErrorResult("成功", data);
        }
        public APIResultModel GetWelcomeNoticeList()
        {
            return _oticeBLL.GetWelcomeNoticeList();
        }

    }
}
