using Entity;
using IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL<T> : IBaseDAL<T> where T : BaseEntity
    {
        MyDbContext _dbContext;

        public BaseDAL(MyDbContext myDbContext)
        {
            _dbContext = myDbContext;
        }
        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTransaction()
        {
            var transaction = _dbContext.Database.BeginTransaction();
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
           _dbContext.Database.CommitTransaction();
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public bool Create(T entity)
        {
            //给角色数据集添加一个角色对象，目的是想给角色表加一条数据
            _dbContext.Set<T>().Add(entity);

            //更新到数据库
            int index = _dbContext.SaveChanges();

            if (index > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 通过id查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetEntityById(string id)
        {
            T entity = _dbContext.Set<T>().FirstOrDefault(e => e.Id == id);
            return entity;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);

            //更新到数据库
            int index = _dbContext.SaveChanges();

            if (index > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 真删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            Employee employee = _dbContext.Employee.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _dbContext.Employee.Remove(employee);
                //更新到数据库
                int index = _dbContext.SaveChanges();

                if (index > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 数据访问层
        /// </summary>
        /// <returns></returns>
        public DbSet<T> GetDbSet()
        {
            return _dbContext.Set<T>();
        }
    }
}
