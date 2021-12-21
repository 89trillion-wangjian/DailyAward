# 每日精选&宝箱 -- 技术文档

## 1. 整体框架
每日精选&宝箱，通过滑动列表实现页面，每个精选item/宝箱item单独实现，控制自己的行为，并派发事件加金币或钻石等
## 2. 目录结构
* Scene
   * MainScene
* Resources
   * coins
   * cards
   * awards
* Scripts
   * MainView
   * CoinCtrl
   * DailyJuwelCtrl
   * DailyNodeView
   * MyAssetsCtrl
   * SolderView
* SimpleJSON

## 3.代码逻辑分层
|文件夹        |主要职责                  |
|-----------   |----------              |
|Resources     |存放资源                  |
|Scripts       |存放脚本文件              |
|Prefabs       |存放预制体资源            |
|data          |存放本地存放的json数据等  |
|Scene         |存放场景文件              |
|SimpleJSON    |存放解析json的工具        |

##4.1. 序列图
![sequence](https://github.com/89trillion-wangjian/DailyAward/blob/master/seq.png)
##5.todo
事件传递方式：可以用委托实现一个全局事件传递，弃用现用的脚本传递方式，解耦
分层：由于时间问题，没有采用mvc分层，健壮性不强
