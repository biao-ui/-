using Commo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IRolelnfoBLL
    {



        /// <summary>
        /// 这是角色视图渲染
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public APIResultModel TableRoleInfo(int page, int limit, string name);
        /// <summary>
        /// 添加功能
        /// </summary>
        /// <param name="name"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public APIResultModel AddIndex(string name, string remark);
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel DeleteRoleInfo(string id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public APIResultModel BatchDeleteRoleInfo(List<string> ids);

        /// <summary>
        /// 修改页的渲染数据功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIResultModel UpdatGet(string id);
        /// <summary>
        /// 角色修改功能
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public APIResultModel UpdatRoleInfo(string id, string name, string remark);


        /// <summary>
        /// 穿梭框的获取
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetTransferOptionList(string roleId);
        /// <summary>
        /// 绑定员工
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="employeeIds"></param>
        /// <returns></returns>
        public APIResultModel BindEmployee(int index, string roleId, List<string> employeeIds);


        /// <summary>
        /// 获取穿梭框菜单信息
        /// </summary>
        /// <returns></returns>
        public APIResultModel GetMenulnfoOptionList(string roleId);
        /// <summary>
        /// 绑定炒作
        /// </summary>
        /// <param name="index"></param>
        /// <param name="roleId"></param>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public APIResultModel BinMenulnfo(int index, string roleId, List<string>? menuIds);
    }
}

