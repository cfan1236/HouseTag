using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseTag.Model
{
    /// <summary>
    /// 楼盘搜索结果安居客
    /// </summary>
    public class SearchResult
    {
        public List<ResultList> loupan { get; set; }
    }
    public class ResultList
    {
        /// <summary>
        /// 楼盘url
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string alias { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string addrEm { get; set; }
    }
}
