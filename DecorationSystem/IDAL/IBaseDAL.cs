using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IBaseDAL<T> where T : class
    {
        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTransaction()
        {
          
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
      
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
   
        }


        /// <summary>
        /// 通过id查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntityById(string id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool Create(T entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Update(T entity);

        /// <summary>
        /// 真删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id);
       

        /// <summary>
        /// 数据访问层
        /// </summary>
        /// <returns></returns>
        public DbSet<T> GetDbSet();

    }
}
