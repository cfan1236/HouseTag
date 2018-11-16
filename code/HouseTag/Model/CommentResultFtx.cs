using System;
using System.Collections.Generic;
using System.Text;

namespace HouseTag.model
{
    /// <summary>
    /// 房天下 评论结果
    /// </summary>
    public class CommentResultFtx
    {
        /// <summary>
        /// 当前页面
        /// </summary>
        public int load_page { get; set; }
        /// <summary>
        /// z总数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 列表
        /// </summary>
        public List<CommentList> list { get; set; }
    }
    public class CommentList
    {

        public string id { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 楼盘代码
        /// </summary>
        public string newcode { get; set; }
        /// <summary>
        /// 评论渠道 手机|pc
        /// </summary>
        public string channelname { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; }


    }
}
