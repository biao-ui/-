using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commo
{
    public class APIResultModel
    {

        /// <summary>
        /// 0:成功
        /// 1:失败
        /// </summary>

        public int Code { get; set; }
        public string Msg { get; set; }

        public int Count {get; set; }
        public object Data { get; set; }

        /// <summary>
        /// 0:成功
        /// 1:失败
        /// 这个是0
        /// </summary>
        public static APIResultModel GetSuccessResult(string msg)
        {
            APIResultModel res = new APIResultModel();
            res.Msg = msg;
            res.Code = 0;
           return res;
        }

        /// <summary>
        /// 0:成功
        /// 1:失败
        /// 这个是1
        /// </summary>
        public static APIResultModel GetErrorResult(string msg)
        {
            APIResultModel res = new APIResultModel();
            res.Msg = msg;
            res.Code = 1;
            return res; 
        }
        /// <summary>
        /// 这个获取数据
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static APIResultModel GetErrorResult(string msg ,object data)
        {
            APIResultModel res = new APIResultModel();
            res.Msg = msg;
            res.Code = 0;
            res.Data = data;
            return res;
        }
        /// <summary>
        /// 视图的渲染
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="count"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static APIResultModel GetSuccessResultForLayui(string msg, int count, object data)
        {
            return new APIResultModel() { Code = 0, Msg = msg, Data = data, Count = count };
        }


    }
}
