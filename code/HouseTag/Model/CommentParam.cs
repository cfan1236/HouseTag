using System;
using System.Collections.Generic;
using System.Text;

namespace HouseTag.model
{
    /// <summary>
    /// 获取评论时传递的参数 
    /// </summary>
    public class CommentParam
    {
        /// <summary>
        /// 楼盘url
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 页索引
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 最大索引
        /// </summary>
        public int maxPageIndex { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public int pageSize { get; set; }
    }
}
