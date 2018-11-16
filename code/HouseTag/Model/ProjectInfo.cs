using System;
using System.Collections.Generic;
using System.Text;

namespace HouseTag.Model
{
    /// <summary>
    /// 楼盘信息
    /// </summary>
    public class ProjectInfo
    {
        /// <summary>
        /// 楼盘名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 楼盘url
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 楼盘评论数
        /// </summary>
        public int commentCount { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// 楼盘id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 价格 直接读取文本
        /// </summary>
        public string price { get; set; }



    }
}
