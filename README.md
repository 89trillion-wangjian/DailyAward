# 每日精选&宝箱 -- 技术文档

## 1. 整体框架
model存储玩家金币数量，设置委托，ui类设置委托监听，当model中的数据改变时，ui执行对应的刷新方法
每个item设置单独的view/controller脚本控制逻辑与显示。
## 2. 目录结构
* Scene
   * MainScene
* Resources
   * Coins           #货币种类
   * Cards           #卡牌
   * Awards          #奖励
   * Effect          #特效
* Scripts            #脚本
* Plugins            #插件（doTween）
* Res                #部分静态资源
* Data               #数据

## 3.代码逻辑分层
|文件夹        |主要职责                  |
|-----------   |----------              |
|Controller     |处理逻辑                 |
|Entity       |静态类，枚举等              |
|Model       |存放玩家数据，设置委托            |
|Utils          |事件传递脚本，工具  |
|View         |委托事件绑定，处理ui显示              |
|SimpleJSON    |解析json工具              |

## 4. 序列图
![sequence](https://github.com/89trillion-wangjian/DailyAward/blob/master/seq.png)
