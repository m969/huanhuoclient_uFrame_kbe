#项目简介：
基于Unity3d 5.6

视频地址：
[演示视频（Youku）](http://v.youku.com/v_show/id_XMjg3NzMxNDAwOA==.html?spm=a2h3j.8428770.3416059.1)

github地址：
客户端：https://github.com/m969/huanhuoclient
服务端：https://github.com/m969/huanhuoserver

#游戏简介：
游戏名称：《幻火》
游戏类型：多人角色扮演网络游戏;
游戏风格：第三人称3D古风;
游戏平台：PC;

背景简介：故事发生在木灵村，为找回被恶人盗走了的圣火，主角踏上了冒险之路;
角色系统：玩家将会扮演一个异世界的历练者;
技能系统：玩家初始会拥有几个技能;
商店Npc系统：每个地图会有一个商店Npc，允许玩家购买游戏物品;
任务Npc系统：玩家可与Npc对话并领取任务;
背包系统：角色会有一个背包携带随身物品;
Monster系统：玩家击杀怪物可完成任务、获得经验;
Monster Boss系统：更强大的怪物首领;
聊天框功能：玩家聊天;
好友系统：添加好友、保存好友;
灵力系统：角色等级随灵力增加等级提升;
重生功能：玩家死亡可以重生;
场景传送功能：角色在不同场景之间传送;

#客户端核心代码概述：
##订阅/取消订阅通道：
我在Entity外封装了一个Model类，这个Model除了是Entity外它还提供了 订阅 和 取消订阅 接口，
并保存了所有订阅了它的属性更新和方法调用的委托，当有 属性/方法 更新/调用 的时候，fireOut一个 OnUpdatePropertys/onRemoteMethodCall_（这里通过修改kbe插件实现），
并由世界中介器 WorldMediator 接收处理，WorldMediator 通过 属性名/方法名 找到对应的委托列表进行调用，这样就免去了许多重复的代码。

#服务端核心代码概述：
##任务的数据结构
[任务Npc名称，任务索引，是否完成，是否已提交]

每个任务会有一个对应的任务监视脚本来检测任务的完成进度。

![输入图片说明](https://git.oschina.net/uploads/images/2017/0708/141406_21179a87_548730.png "在这里输入图片标题")
![输入图片说明](https://git.oschina.net/uploads/images/2017/0708/141551_67329105_548730.png "在这里输入图片标题")
![输入图片说明](https://git.oschina.net/uploads/images/2017/0708/141606_270ebfd3_548730.png "在这里输入图片标题")
![输入图片说明](https://git.oschina.net/uploads/images/2017/0708/141624_325a0cb2_548730.png "在这里输入图片标题")
![输入图片说明](https://git.oschina.net/uploads/images/2017/0708/141635_f02893bf_548730.png "在这里输入图片标题")
![输入图片说明](https://git.oschina.net/uploads/images/2017/0708/141643_22bc09a6_548730.png "在这里输入图片标题")