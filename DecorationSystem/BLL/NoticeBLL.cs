using Commo;
using DAL;
using Entity;
using IBLL;
using IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NoticeBLL : INoticeBLL
    {

        INoticeDAL _noticeDAL;
        IEmployeeDAL _employeeDAL;


        public NoticeBLL(IEmployeeDAL employeeDAL, INoticeDAL noticeBLL)
        {

            _employeeDAL = employeeDAL;
            _noticeDAL = noticeBLL;

        }


        /// <summary>
        /// 渲染视图
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public APIResultModel TableNotice(int page, int limit, string title)
        {
            //IQueryable<Notice> list = dbContext.Notice.Where(x=>x.IsDelete ==false);
            var list = from m1 in _noticeDAL.GetDbSet().Where(x => x.IsDelete == false)
                       join m2 in _employeeDAL.GetDbSet().Where(x => x.IsDelete == false)
                       on m1.CreatorId equals m2.Id into temoM2
                       from mm2 in temoM2.DefaultIfEmpty()
                       select new
                       {
                           m1.Id,
                           m1.Title,
                           m1.CreateTime,
                           m1.Content,
                           Name = mm2.Name

                       };





            if (!string.IsNullOrEmpty(title))
            {
                list = list.Where(x => x.Title.Contains(title));
            }

            var res = list.OrderByDescending(e => e.CreateTime).Skip((page - 1) * limit).Take(limit).ToList().Select(item =>
            {
                return new
                {
                    CreateTime = item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    item.Name,
                    item.Title,
                    item.Id,
                    item.Content,

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
        public APIResultModel AddIndex(string title, string content, string creatorId)
        {
            if (string.IsNullOrEmpty(title))
            {
                return APIResultModel.GetErrorResult("标题不能为空");
            }

            if (string.IsNullOrEmpty(content))
            {
                return APIResultModel.GetErrorResult("标题不能为空");
            }
            if (string.IsNullOrEmpty(creatorId))
            {
                return APIResultModel.GetErrorResult("标题不能为空");
            }
            Notice notice = _noticeDAL.GetDbSet().Where(x => x.Title == title).FirstOrDefault();
            if (notice != null)
            {
                return APIResultModel.GetErrorResult("此标题已存在");
            }
            Notice noti = new Notice();
            noti.Title = title;
            noti.Content = content;
            noti.CreatorId = creatorId;
            noti.CreateTime = DateTime.Now;
            noti.Id = Guid.NewGuid().ToString();
            bool set = _noticeDAL.Create(noti);
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
        public APIResultModel DeleteNotice(string id)
        {
            Notice notice = _noticeDAL.GetEntityById(id);
            if (notice != null)
            {
                notice.IsDelete = true;
                notice.DeleteTime = DateTime.Now;
                bool set = _noticeDAL.Update(notice);
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
        public APIResultModel BatchDeleteNotice(List<string> ids)
        {

            foreach (var id in ids)
            {
                Notice notice = _noticeDAL.GetEntityById(id);
                if (notice != null)
                {
                    notice.IsDelete = true;
                    notice.DeleteTime = DateTime.Now;
                    bool set = _noticeDAL.Update(notice);
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
            Notice employee = _noticeDAL.GetEntityById(id);
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
        public APIResultModel UpdatNotice(string id, string title, string content)
        {
            Notice notice = _noticeDAL.GetEntityById(id);
            if (notice != null)
            {
                notice.Title = title;
                notice.Content = content;

                bool set = _noticeDAL.Update(notice);
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

        public object GetNotice(string id)
        {
            var arr = from t1 in _noticeDAL.GetDbSet().Where(x => x.IsDelete == false && x.Id == id)
                      join t2 in _employeeDAL.GetDbSet().Where(x => x.IsDelete == false)
                      on t1.CreatorId equals t2.Id
                      select new
                      {
                          t1.Id,
                          t2.Name,
                          t1.Title,
                          t1.Content,
                          CreateTime = t1.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
                      };

            var res = arr.FirstOrDefault();
            if (res != null)
            {
                string contentStr = res.Content.Replace("\n", "<br>");
                object str = new
                {
                    res.Title,
                    Content = contentStr,
                    res.CreateTime,
                    res.Name
                };
                return str;
            }
            else
            {
                return null;
            }

        }

        public APIResultModel GetWelcomeNoticeList()
        {
            DateTime starDate = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
            var datas = _noticeDAL.GetDbSet().Where(x => x.IsDelete == false && x.CreateTime > starDate && x.CreateTime < DateTime.Now).Select(n => new
            {
                n.Id,
                n.Title,
                CreateTime = n.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")
            });
            return APIResultModel.GetErrorResult("成功", datas);
        }
    }
}

