# HouseTag

楼盘评论标签


----------
2019/1/14 新增了Web版本

[HouseTag_Web](https://github.com/cfan1236/HouseTag_Web "housetag") 升级改进版

[http://housetag.580zdh.com/](http://housetag.580zdh.com/ "housetag")


### 开发初衷
因为最近几个月一直都在看房子，因为工作在深圳想在武汉买房子(深圳的买不起……)，所以先只能通过网络找各种房子信息，找到好几个认为可以的楼盘后今年国庆就回去实地看了一下；看到了有一个还算满意的盘，当你看到一个不错的盘后就想着要了解它的各方面信息。就像喜欢一个菇凉一样你希望了解她的所有。首先就看了看这个盘的评论，发现评论还很多。然后就翻了多页，突然发现他们盘上一期开盘不久后就有业主集体维权事件。而且维权的评论占据很多条。然后立马在网上搜索这个盘维权事件，还真有此事。然后心里想着评论数据还是很有用的。所以评论还是有一定的参考价值。但是无耐评论数据少则几条多则上千条，你要是一个个的去翻看显然很耗时而且又低效，评论太多看了或者容易忘记。然后我就这想着能不能把所有评论数据都提取出来，然后提取这些评论中共同词汇(关键词)；然后进行展示；比如一个楼盘很多用户评价楼盘后面有个高架桥。显然“高架桥”就是我们需要提取的关键词；当然最终关键词肯定有很多。这样很快就知道这个盘大家都是怎样看待的。比如 高架桥、靠近铁路等等。这些信息楼盘销售是不会告诉你的。只要通过自己去发现。

### 功能
通过爬虫的方式获取安居客、房天下的完全公开的楼盘信息及评论数据；获取某个楼盘的所有公开能获取到的评论数据，然后将数据通过楼盘相关的关键词进行整理归纳。最终形成标签，通过点击标签查看该标签下的所有评论数据。  

***注意:所有数据都是从安居客、房天下两个网站获取的完全公开数据，本软件不对数据的真实性及有效性做任何保证*** 

### 使用

 1. 开发说明  
程序是使用C# winform 进行开发的;使用.NetFramework4.5


 2. 安装与使用  
双击`HouseTag.exe`即可运行该程序。  
如果程序无法运行请先下载.NetFramework4.5进行安装后再使用。下载地址:[微软官方下载](https://www.microsoft.com/en-us/download/details.aspx?id=42642)。如果是win10系统一般不需要安装。

### 项目目录

```
HouseTag
│   │
│   Data
│   │─ author_ignore.txt   //需要过的滤用户关键词;例如代抢房源、楼盘职业顾问等。
│   │─ city_url.txt      //城市url 支持哪些城市的数据添加url即可
│   │─ dic_ignore.txt    //字典数据忽略关键词评论数据的副词、量词等
│   │─ tag_dict.txt     //标签字典 楼盘相关关键词
│   │
│   Helper
│   │─ HouseHelperAjk.cs   //获取安居客楼盘及评论数据处理类。
│   │─ HouseHelperFtx.cs   //获取房天下楼盘及评论数据处理类。
│   │─ MainHelper.cs    //主业务逻辑层 由UI调用
│   │─ NetHttpHelper.cs  //网络请求处理类   
│   │
│   Model
│   │─ CommentInfo.cs.cs   //获取到的评论数据信息。
│   │─ CommentParam.cs   //获取评论时所需要的参数。
│   │─ CommentResultFtx.cs    //房天下评论数据返回实体
│   │─ ProjectInfo.cs  //楼盘信息  
│   │─ SearchResult.cs.cs  //楼盘关键字搜索结果   
│   │
│   frmMain.cs //UI窗体代码
│   │   
│   packages.config  //nuget程序包
│   │
│   Program.cs   //程序入口
│   │  

```
### 运行截图
![图1](https://github.com/cfan1236/HouseTag/blob/master/doc/img/20181116234957.png)

![图2](https://github.com/cfan1236/HouseTag/blob/master/doc/img/20181116234907.png)

![图3](https://github.com/cfan1236/HouseTag/blob/master/doc/img/20181116234947.png)
