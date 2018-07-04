# IceKori

IceKori ��һ��Ϊ������Ϸ����ű����������߼�����ϵͳ��ʵ�ֵĿ��ӻ�������ԡ�IceKori ������ [Odin Inspector](http://sirenix.net/odininspector) ��� ��
��Ҫ˵�����ǣ� IceKori ������һ�����伴�õĲ�����䱾��ֻ�����˻����ĵ����Գ���ڵ㡣������Ϸϵͳǿ��ϵĹ�����ָ����Ҫ�����ṩ�ķ�ʽ�����ο�����

## ָ��˵��
[Command](./Command.md)

## �Զ���ָ��
[CustomCommand](./CustomCommand.md)

## IceKori ������
### ʾ�� 
```c#
using Assets.Plugins.IceKori.Syntax;

// Some code

// create a IceKori interpreter
Interpreter interpreter = new Interpreter(commonVariables, commonCommands, globalVariables, globalCommands, commands)

```

### `new Interpreter(commonVariables, commonCommands, globalVariables, globalCommands, commands)`

+ `commonVariables` Dictionary<string, BaseExpression> - ��������
+ `commonCommands` Dictionary<string, IceKoriBaseType> - ����ָ��
+ `globalVariables` Dictionary<string, List\<BaseStatement>> - ȫ�ֹ�������
+ `globalCommands` Dictionary<string, IceKoriBaseType> - ȫ�ֹ���ָ��
+ `commands` List\<BaseStatement> - ָ��

### ʵ������

#### `State` InterpreterState `enum`
��������״̬�����ĸ�ֵ��
+ `InterpreterState.Pending` ��ʾ�������մ�������δ��ʼ���С�
+ `InterpreterState.Runnig` ��ʾ�������������С�
+ `InterpreterState.Stop` ��ʾ��������������ͣ��
+ `InterpreterState.End` ��ʾ������ִ�н�����

#### `IsDebug` bool
�Ƿ����������� `Debug`����Ϊ **true** ʱ�����ִ�й���ͨ�� `UnityEngine.Debug.Log` ��ӡ������

#### `Statement` BaseStatement
ָ���������ǰ���ڹ�Լ����䡣

#### `Env` Enviroment
�������Ļ�������

#### `ErrorHandling` ErrorHandling
�������Ĵ��������

### ʵ������
#### `interpreter.Reduce`
�Խ�������ǰ�����й�Լ��

#### `interpreter.Run`
��Լ�������ֱ�����н�����

## IceKori �������
��һ���Ѿ���װ�õ� Unity ���������ͨ�� `IceKori/Interpreter` ����ӡ�
![IceKoriInterpreterComponent](../DocRes/IceKoriInterpreterComponent.png)

## ȫ������
IceKori Ϊ������һ����Ŀ�ڿ���������ʵ������ͨһЩ���ݡ���ȫ�ֱ�����ȫ��ָ��ĸ�������ͨ�� Unity �½���Դ�˵�������һ�� IceKori ȫ�ֻ�������������ȫ�ֱ�����ȫ��ָ�
![GobalConfCreate](../DocRes/IceKoriGloablConfCreate.png)
![GobalConfCreate](../DocRes/IceKoriGloablConf.png)

`IceKori`��`Init`�������Զ����Դ� Resource ��������ȫ�������ļ����ļ���ӦΪ`GlobalConf`����
```c#
public static void LoadGlobalConf()
{
    var db = Resources.Load<GlobalConf>("GlobalConf");
    db.hideFlags = HideFlags.DontSaveInBuild;
    Conf = db;
}
```
## ����
IceKori ��ʵ�����ϸ�����С��������ִ�еġ���������˽������� IceKori �����������������֪ʶ�����Բ���������Ŀ��

+ [Understanding Computation: From Simple Machines to Impossible Programs](https://github.com/molingyu/UnderstandingComputation)

+ [����дһ��������](http://www.yinwang.org/blog-cn/2012/08/01/interpreter)

## ����
+ Gal-game story script

## �����﷨˵��
[Grammar](./Grammar.md)