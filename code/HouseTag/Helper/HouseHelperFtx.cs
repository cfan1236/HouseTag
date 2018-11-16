using Common;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using HouseTag.Model;
using HouseTag.model;

namespace HouseTag.Helper
{
    public class HouseHelperFtx
    {

        /// <summary>
        /// 实际数据结束页索引
        /// </summary>
        private static int endPageIndex = 0;

        /// <summary>
        /// 获取楼盘信息
        /// </summary>
        /// <returns></returns>
        public static List<ProjectInfo> GetProjectInfo(string city_url, string name)
        {
            if (city_url[city_url.Length - 1] != '/')
            {
                city_url += "/";
            }
            List<ProjectInfo> list = new List<ProjectInfo>();
            var url = city_url + "house/s/a9" + System.Web.HttpUtility.UrlEncode(name, System.Text.Encoding.GetEncoding("GB2312"));
            int status = 0;
            var html = NetHttpHelper.HttpGetRequest(url, out status);
            if (status == 200)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                //获取楼盘列表
                var nodes_p_list = doc.DocumentNode.SelectNodes(".//div[@class='nlc_details']");
                if (nodes_p_list != null)
                {
                    foreach (var item in nodes_p_list)
                    {
                        //楼盘名称
                        var html_name = item.SelectSingleNode(".//div[@class='nlcd_name']").SelectSingleNode(".//a");
                        var pName = html_name.InnerText.Trim().Replace("·", "");
                        var purl = "";
                        if (html_name != null)
                        {
                            foreach (var att in html_name.Attributes)
                            {
                                if (att.Name == "href")
                                {
                                    purl = att.Value;
                                    break;
                                }
                            }
                        }
                        //楼盘地址
                        var pAddress = item.SelectSingleNode(".//div[@class='address']").InnerText.Trim().Replace("\n", "").Replace("\t", "");
                        var pId = "";
                        var html_id = item.SelectSingleNode(".//div[@class='duibi']");
                        if (html_id != null)
                        {
                            foreach (var att in html_id.Attributes)
                            {
                                if (att.Name == "onclick")
                                {
                                    //按照'分割
                                    var temp = att.Value.Split('\'');
                                    if (temp.Length >= 2)
                                    {
                                        pId = temp[1];
                                    }
                                    break;
                                }
                            }
                        }
                        //评论总数
                        var html_count = item.SelectSingleNode(".//span[@class='value_num']");
                        var count = 0;
                        if (html_count != null)
                        {
                            var temp_count = html_count.InnerText;
                            var number = System.Text.RegularExpressions.Regex.Replace(temp_count, @"[^0-9]+", "");
                            int.TryParse(number, out count);
                        }
                        var price_text = "";
                        var price_html = item.SelectSingleNode(".//div[@class='nhouse_price']");
                        if (price_html != null)
                        {
                            price_text = price_html.InnerText.Replace("\n", "").Replace("\t", "");
                        }
                        list.Add(new ProjectInfo()
                        {
                            name = pName,
                            address = pAddress,
                            url = purl,
                            id = pId,
                            commentCount = count,
                            price = price_text

                        });
                    }
                }

            }

            return list;
        }

        /// <summary>
        /// 楼盘评论
        /// </summary>
        /// <param name="pUrl">楼盘url</param>
        /// <param name="pId">楼盘id</param>
        /// <param name="c_count">楼盘评论数</param>
        /// <returns></returns>
        public static List<CommentInfo> GetProjectCommenInfo(string pUrl, string pId, int c_count)
        {
            var cinfo = new List<CommentInfo>();
            if (c_count == 0)
            {
                var param = new CommentParam()
                {
                    id = pId,
                    pageIndex = 1,
                    url = pUrl,
                    maxPageIndex = 0,
                    pageSize = 80
                };
                cinfo = GetComment(param);
                return cinfo;
            }
            else
            {
                //多线程分批获取评论
                int threadCount = c_count / 1000;
                if (c_count % 1000 > 0)
                {
                    threadCount++;
                }
                threadCount = threadCount > 6 ? 6 : threadCount;
                Task[] tk = new Task[threadCount];
                //线程获取评论的当前页索引
                int pageIndex = 1;
                int maxPageIndex = 10;
                for (int i = 0; i < threadCount; i++)
                {
                    var param = new CommentParam()
                    {
                        id = pId,
                        pageIndex = pageIndex,
                        url = pUrl,
                        maxPageIndex = maxPageIndex,
                        pageSize = 80
                    };
                    //判断是否是最后一个线程
                    if (i == threadCount - 1)
                    {
                        //让最后一个线程获取后面所有评论 没有页面限制
                        param.maxPageIndex = 0;
                    }
                    tk[i] = Task.Factory.StartNew(() =>
                      {
                          cinfo.AddRange(GetComment(param));
                      });
                    pageIndex += 10;
                    maxPageIndex += 10;

                }

                Task.WaitAll(tk);
            }
            return cinfo;
        }

        /// <summary>
        /// 获取评论
        /// </summary>
        /// <param name="pUrl"></param>
        /// <param name="pId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="maxPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private static List<CommentInfo> GetComment(CommentParam param)
        {
            var cinfo = new List<CommentInfo>();
            var url = $"{param.url}house/ajaxrequest/dianpingList_201501.php";
            if (!url.Contains("https:") && !url.Contains("http:"))
            {
                if (url.Contains("//"))
                {
                    url = "https:" + url;
                }
                else
                {
                    url = "https://" + url;
                }
            }
            int pageIndex = param.pageIndex;
            //循环获取评论
            while ((pageIndex <= param.maxPageIndex) || (param.maxPageIndex == 0))
            {
                //判断是否有某些线程已经跑到了数据的最后一页 避免不必要的请求
                if (endPageIndex != 0 && pageIndex > endPageIndex)
                {
                    continue;
                }
                var postParam = $"page={pageIndex}&pagesize={param.pageSize}&dianpingNewcode={param.id}";
                int status = 0;
                var html = NetHttpHelper.HttpPostRequest(url, postParam, out status);
                if (status == 200)
                {
                    var list = JsonConvert.DeserializeObject<model.CommentResultFtx>(html);
                    if (list != null && list.list.Count > 0)
                    {
                        foreach (var item in list.list)
                        {
                            cinfo.Add(new CommentInfo
                            {
                                author = string.IsNullOrWhiteSpace(item.nickname) ? item.username : item.nickname,
                                content = item.content.Replace("&hellip;", "…").Replace("<br/>", " "), //替换部分html 关键字
                                date = item.create_time
                            });
                        }
                    }
                    else
                    {
                        endPageIndex = pageIndex;
                        break;
                    }
                }
                pageIndex++;
                Thread.Sleep(10);
            }
            return cinfo;
        }
    }
}
