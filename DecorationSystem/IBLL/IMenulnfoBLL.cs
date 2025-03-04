using Commo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IMenulnfoBLL
    {


        /// <summary>
        /// 菜单视图渲染
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public APIResultModel TableMenuInfo(int page, int limit, string title);

        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetLsitMenuInfo(string numId);
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

        public APIResultModel AddIndex(string title, string description, int level, int sort, string href, string parentId, string icon, string target);
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public APIResultModel DeleteMenuInfo(string id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>

        public APIResultModel BatchDeleteMenuInfo(List<string> ids);
        /// <summary>
        /// 修改也获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel UpdatGet(string id);

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
        public APIResultModel UpdatRoleInfo(string id, string title, string description, int level, int sort, string href, string icon, string target,string parentId);

        /// <summary>
        /// 首页菜单
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns
        public object GetHomeMenuList(string employeeId);

        /// <summary>
        /// 找出添加的下拉数据
        /// </summary>
        /// <returns></returns>
        APIResultModel AddGetLsitMenuInfo();
    }
    
}
