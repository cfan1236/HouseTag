using System;
using System.Collections.Generic;
using System.Text;

namespace HouseTag.Model
{
    /// <summary>
    /// 楼盘评论
    /// </summary>
    public class CommentInfo
    {
        /// <summary>
        /// 评论内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string author { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime date { get; set; }
    }
}
