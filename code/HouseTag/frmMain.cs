
using HouseTag.Helper;
using HouseTag.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseTag
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        /// 城市列表控件
        private List<Label> list_city = new List<Label>();
        /// 标签列表控件
        private List<Label> list_tag = new List<Label>();
        /// 标签列表
        private Dictionary<string, List<CommentInfo>> dic_tag = new Dictionary<string, List<CommentInfo>>();
        /// 当前城市索引
        private int index_city = 0;
        /// 是否是选择的文本
        private bool is_select = false;
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                InitView();
                var city_url = MainHelper.InitData();
                InitCityList(city_url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n 请重新尝试", "异常消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtSearchProject.Enabled = false;
                btnStart.Enabled = false;
                lblStatusTips.Visible = true;
                lblStatusTips.Text = "程序初始化失败";
            }
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitView()
        {
            lstSearchResult.Visible = false;
            lblAddess.Text = "";
            lblPrice.Text = "";
            lblProjectName.Text = "";

            lblStatusTips.Visible = false;
            txtComment.ReadOnly = true;
            lblComment.Visible = false;
            txtSearchProject.Focus();

        }

        /// <summary>
        /// 初始化城市列表
        /// </summary>
        private void InitCityList(List<string> city_url)
        {
            int x = 19;
            int y = 32;
            for (int i = 0; i < city_url.Count; i++)
            {
                if (string.IsNullOrEmpty(city_url[i]))
                {
                    continue;
                }
                Label label = new Label()
                {
                    Text = city_url[i].Split(',')[0],
                    Size = new Size(42, 18),
                    Location = new Point(x, y),
                    Cursor = Cursors.Hand,
                    TabIndex = i

                };
                label.Click += new EventHandler(City_Click);
                list_city.Add(label);
                x += 50;

            }
            this.gbxCity.Controls.AddRange(list_city.ToArray());
            //默认选中第一个城市
            list_city[0].ForeColor = Color.Red;
            list_city[0].Font = new Font(list_city[0].Font, FontStyle.Underline);
        }

        /// <summary>
        /// 城市选择单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void City_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            for (int i = 0; i < list_city.Count; i++)
            {
                if (i == lbl.TabIndex)
                {
                    lbl.ForeColor = Color.Red;
                    lbl.Font = new Font(lbl.Font, FontStyle.Underline);
                    index_city = i;
                }
                else
                {
                    list_city[i].ForeColor = Color.Black;
                    list_city[i].Font = new Font(list_city[0].Font, FontStyle.Regular);
                }
            }
        }


        /// <summary>
        /// 修改楼盘输入框边框颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gbxInput_Paint(object sender, PaintEventArgs e)
        {
            Groupbox_Paint(gbxInput, e, Brushes.CadetBlue, Pens.SkyBlue);
        }


        /// <summary>
        /// 修改城市groupbox 边框颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gbxCity_Paint(object sender, PaintEventArgs e)
        {
            Groupbox_Paint(gbxCity, e, Brushes.CadetBlue, Pens.BlueViolet);

        }

        /// <summary>
        /// 修改标签groupbox 边框颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gbxLabel_Paint(object sender, PaintEventArgs e)
        {
            Groupbox_Paint(gbxLabel, e, Brushes.CadetBlue, Pens.Blue);
        }


        /// <summary>
        /// 修改评论grupbox 边框颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gbxComment_Paint(object sender, PaintEventArgs e)
        {
            Groupbox_Paint(gbxComment, e, Brushes.CadetBlue, Pens.DarkRed);
        }

        /// <summary>
        /// groubBox 重绘颜色
        /// </summary>
        /// <param name="gb"></param>
        /// <param name="e"></param>
        /// <param name="brush"></param>
        /// <param name="pen"></param>
        private void Groupbox_Paint(GroupBox gb, PaintEventArgs e, Brush brush, Pen pen)
        {
            e.Graphics.Clear(gb.BackColor);
            e.Graphics.DrawString(gb.Text, gb.Font, brush, 10, 1);
            e.Graphics.DrawLine(pen, 1, 7, 8, 7);
            e.Graphics.DrawLine(pen, e.Graphics.MeasureString(gb.Text, gb.Font).Width + 8, 7, gb.Width - 2, 7);
            e.Graphics.DrawLine(pen, 1, 7, 1, gb.Height - 2);
            e.Graphics.DrawLine(pen, 1, gb.Height - 2, gb.Width - 2, gb.Height - 2);
            e.Graphics.DrawLine(pen, gb.Width - 2, 7, gb.Width - 2, gb.Height - 2);
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            lstSearchResult.Visible = false;
            var name = txtSearchProject.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                lblStatusTips.Visible = true;
                lblStatusTips.Text = "请输入楼盘名称";
                txtSearchProject.Focus();
                return;
            }

            Reset();
            lblStatusTips.Text = "正在获取楼盘...";
            btnStart.Enabled = false;
            txtSearchProject.Enabled = false;
            new Task(() =>
            {
                try
                {
                    var pInfo = MainHelper.GetProjectInfo(index_city, name);
                    if (pInfo != null)
                    {
                        if (pInfo.address.Length > 20)
                        {
                            pInfo.address = pInfo.address.Substring(0, 20) + "...";
                        }
                        Invoke(new Action(() =>
                        {
                            lblProjectName.Text = "楼盘:[" + pInfo.name + "]";
                            lblAddess.Text = "地址:" + pInfo.address;
                            lblStatusTips.Visible = true;
                            lblStatusTips.Text = "正在获取评论...";
                            lblPrice.Text = "价格:" + (pInfo.price == "" ? "暂无" : pInfo.price);
                        }));
                        List<CommentInfo> all_comment = new List<CommentInfo>();
                        dic_tag = MainHelper.GetCommentInfo(name, out all_comment);
                        ShowTag(all_comment);
                        Invoke(new Action(() =>
                        {
                            lblStatusTips.Text = "评论获取完成";
                        }));

                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            lblStatusTips.Visible = true;
                            lblStatusTips.Text = "找不到该楼盘";
                            btnStart.Enabled = true;
                            txtSearchProject.Enabled = true;
                        }));
                    }

                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
#if DEBUG
                        MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace, "异常消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
#else
                        MessageBox.Show(ex.Message + "\r\n 请重新尝试", "异常消息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
#endif
                        btnStart.Enabled = true;
                        txtSearchProject.Enabled = true;
                        lblStatusTips.Text = "获取评论失败";

                    }));
                }
            }).Start();

        }

        /// <summary>
        /// 重置
        /// </summary>
        private void Reset()
        {
            lblStatusTips.Visible = true;
            lblStatusTips.Text = "";
            pnlLabel.Controls.Clear();
            list_tag.Clear();
            dic_tag.Clear();
            lblComment.Text = "";
            lblProjectName.Text = "";
            lblAddess.Text = "";
            txtComment.Text = "";
            lblPrice.Text = "";
        }

        /// <summary>
        /// 显示标签
        /// </summary>
        /// <param name="allComment"></param>
        private void ShowTag(List<CommentInfo> allComment)
        {
            int minCount = 5;
            int x = 8;
            int y = 3;
            int n = 0;
            dic_tag = dic_tag.OrderByDescending(p => p.Value.Count).ToDictionary(p => p.Key, o => o.Value);
            foreach (var item in dic_tag)
            {
                int count = item.Value.Count;
                if (count < minCount)
                {
                    continue;
                }
                string countStr = (count > 99) ? "(99+)" : "(" + count.ToString() + ")";
                Label label = new Label()
                {
                    Text = item.Key + countStr,
                    Location = new Point(x, y),
                    AutoSize = true,
                    Cursor = Cursors.Hand,
                    BackColor = Color.FromArgb(255, 224, 192),
                    Font = new Font("宋体", 12, FontStyle.Regular),
                    BorderStyle = BorderStyle.FixedSingle,
                    Visible = true,
                    TabIndex = n

                };
                label.Click += new EventHandler(CommentLabel_Click);
                list_tag.Add(label);
                switch (item.Key.Length)
                {
                    case 5:
                        x += 140;
                        break;
                    case 4:
                        x += 120;
                        break;
                    case 3:
                        x += 100;
                        break;

                    case 2:
                        x += 80;
                        break;
                    case 1:
                        x += 60;
                        break;
                    default:
                        x += 160;
                        break;
                }
                if (count > 99)
                {
                    x += 10;
                }
                //换行
                if (x >= 800)
                {
                    x = 8;
                    y += 25;
                }

                n++;
            }
            Invoke(new Action(() =>
            {
                if (list_tag.Count > 0)
                {
                    this.pnlLabel.Controls.AddRange(list_tag.ToArray());
                    //默认选中第一个
                    CommentLabel_Click(list_tag[0], null);
                }
                else
                {
                    int all_count = allComment.Count;

                    //动态添加控件显示提示语 重新搜索会清空pan 上所有控件
                    Label label = new Label()
                    {
                        Text = all_count > 0 ? "相同评论关键词太少无法提取标签" : "暂无评论数据",
                        Location = new Point(all_count > 0 ? 267 : 360, 35),
                        AutoSize = true,
                        ForeColor = Color.Red

                    };
                    pnlLabel.Controls.Add(label);
                    lblComment.Visible = true;
                    lblComment.Text = all_count > 0 ? "所有评论" : "";

                    if (allComment != null && allComment.Count > 0)
                    {
                        allComment = allComment.OrderByDescending(a => a.date).ToList();

                    }
                    //显示所有评论
                    foreach (var item in allComment)
                    {
                        //所有评论也过滤下代抢、楼盘顾问
                        if (MainHelper.FilterAuthor(item.author, txtSearchProject.Text))
                        {
                            continue;
                        }
                        txtComment.Text += item.author + " " + item.date.ToString("yyyy-MM-dd") + "\r\n\r\n" + item.content + "\r\n\r\n";
                    }


                }

                //启用开启按钮
                btnStart.Enabled = true;
                txtSearchProject.Enabled = true;
                txtSearchProject.Focus();
            }));

        }

        /// <summary>
        /// 评论标签单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentLabel_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            var text = "";
            for (int i = 0; i < list_tag.Count; i++)
            {
                if (i == lbl.TabIndex)
                {
                    lbl.ForeColor = Color.Red;
                    text = lbl.Text;
                }
                else
                {
                    list_tag[i].ForeColor = Color.Black;
                }
            }
            txtComment.Text = "";
            lblComment.Visible = true;
            var n = text.IndexOf("(");
            text = text.Substring(0, n);
            lblComment.Text = "[" + text + "]相关的评论";
            List<CommentInfo> list = new List<CommentInfo>();
            dic_tag.TryGetValue(text, out list);

            if (list != null)
            {
                list = list.OrderByDescending(p => p.date).ToList();
                foreach (var item in list)
                {
                    txtComment.Text += item.author + " " + item.date.ToString("yyyy-MM-dd") + "\r\n\r\n" + item.content + "\r\n\r\n";
                }
            }
            txtSearchProject.Focus();
        }

        /// <summary>
        /// 开始搜索
        /// </summary>
        /// <param name="text"></param>
        private void StartSearch(string text)
        {
            Invoke(new Action(() =>
            {
                lstSearchResult.Items.Clear();
                if (text.Length >= 1)
                {
                    var items = MainHelper.ProjectSearch(index_city, text);
                    FillSerachResult(items.ToArray());
                }
                else
                {
                    lstSearchResult.Visible = false;
                }

            }));


        }

        /// <summary>
        /// 填充搜索结果
        /// </summary>
        /// <param name="item"></param>
        private void FillSerachResult(string[] item)
        {
            if (item.Length >= 1)
            {
                Invoke(new Action(() =>
                {
                    lstSearchResult.Items.Clear();
                    lstSearchResult.Visible = true;
                    lstSearchResult.Items.AddRange(item);
                    var count = lstSearchResult.Items.Count;
                    count = count > 7 ? 7 : count;
                    if (count == 1)
                    {
                        lstSearchResult.Height = 30;
                    }
                    else
                    {
                        lstSearchResult.Height = count * 20;
                    }

                }));
            }

        }
        /// <summary>
        /// 搜索框改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchProject_TextChanged(object sender, EventArgs e)
        {
            //防止选择结果后再次进行搜索
            if (!is_select)
            {
                var text = txtSearchProject.Text.Trim();
                new Task(() =>
                {
                    Thread.Sleep(300);

                    StartSearch(text);
                }).Start();
            }
            is_select = false;
        }

        /// <summary>
        /// 鼠标滑过 用于选择滑过的项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSearchResult_MouseMove(object sender, MouseEventArgs e)
        {
            int index = ((ListBox)sender).IndexFromPoint(e.Location);
            if (index < 0) return;
            lstSearchResult.SelectedIndex = index;
        }

        /// <summary>
        ///  单击选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSearchResult_MouseClick(object sender, MouseEventArgs e)
        {
            is_select = true;
            if (lstSearchResult.SelectedItem != null)
            {
                var select_text = lstSearchResult.SelectedItem.ToString();
                select_text = select_text.Split(' ')[0];
                txtSearchProject.Text = select_text;
                lstSearchResult.Visible = false;
                txtSearchProject.Focus();
                txtSearchProject.SelectionStart = select_text.Length;
            }
        }

        /// <summary>
        /// 搜索框按键处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnStart.Enabled == true)
                {
                    btnStart_Click(sender, null);
                }
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                lstSearchResult.Focus();
                lstSearchResult.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 结果列表键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSearchResult_KeyDown(object sender, KeyEventArgs e)
        {
            //回车键
            if (e.KeyCode == Keys.Enter)
            {
                lstSearchResult_MouseClick(sender, null);
            }
            //退格键 将焦点返回到输入框
            else if (e.KeyCode == Keys.Back)
            {
                txtSearchProject.Focus();
            }

        }

        /// <summary>
        /// 评论结果ctrl+a 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtComment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x1')
            {
                ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }
    }
}
