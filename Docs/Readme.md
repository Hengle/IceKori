# IceKori

IceKori 是一个为便于游戏剧情脚本等轻量级逻辑抽象系统而实现的可视化编程语言。IceKori 依赖于 [Odin Inspector](http://sirenix.net/odininspector) 插件 。
需要说明的是， IceKori 并不是一个开箱即用的插件，其本身只包含了基本的的语言抽象节点。而与游戏系统强耦合的功能性指令需要依据提供的范式来二次开发。

## 指令说明
[Command](./Command.md)

## 自定义指令
[CustomCommand](./CustomCommand.md)

## IceKori Interpreter & IceKoriInterpreterComponent IceKori 解释器和对应组件


## 全局配置
IceKori 为方便在一个项目内跨多个解释器实例来流通一些数据。有全局变量和全局指令的概念。你可以通过 Unity 新建资源菜单来创建一个 IceKori 全局环境配置来定义全局变量和全局指令。
![GobalConfCreate](../DocRes\IceKoriGloablConfCreate.png)
![GobalConfCreate](../DocRes\IceKoriGloablConf.png)

`IceKori`的`Init`方法会自动尝试从 Resource 里加载这个全局配置文件（文件名应为`GlobalConf`）。
```c#
public static void LoadGlobalConf()
{
    var db = Resources.Load<GlobalConf>("GlobalConf");
    db.hideFlags = HideFlags.DontSaveInBuild;
    Conf = db;
}
```
## Semantic 语义
IceKori 的实现是一个严格依照小步语义来执行的。如果你想了解更多关于 IceKori 解释器是如何运作的，可以参考以下条目：

+ [Understanding Computation: From Simple Machines to Impossible Programs](https://github.com/molingyu/UnderstandingComputation)

+ [怎样写一个解释器](http://www.yinwang.org/blog-cn/2012/08/01/interpreter)

## Example 范例
+ Gal-game story script

## 附：语法说明
[Grammar](./Grammar.md)