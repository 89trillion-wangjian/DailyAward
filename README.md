# 每日精选&宝箱 -- 技术文档

## 1. 整体框架
每日精选&宝箱，通过滑动列表实现页面，每个精选item/宝箱item单独实现，控制自己的行为，并派发事件加金币或钻石等
## 2. 目录结构
* Scene
   * MainScene
* Resources
   * Coins           ---获取种类
   * Cards           ---卡牌
   * Awards        ---奖励
   * Effect           ---特效
* Scripts
   * Controller
   * Entity
   * Model
   * Utils
   * View
* SimpleJSON
* Plugins            ------插件（doTween）
* Res                  ------部分静态资源
* Data                ------数据

## 3.代码逻辑分层
|文件夹        |主要职责                  |
|-----------   |----------              |
|Controller     |处理逻辑，读取数据                  |
|Entity       |静态类，枚举等              |
|Model       |存放玩家数据            |
|Utils          |事件传递脚本，工具  |
|View         |ui类              |

## 4. 序列图
![sequence](https://github.com/89trillion-wangjian/DailyAward/blob/master/seq.png)
## 5.todo
事件传递方式：可以用委托实现一个全局事件传递，弃用现用的脚本传递方式，解耦
分层：由于时间问题，没有采用mvc分层，健壮性不强
