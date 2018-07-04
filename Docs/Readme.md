# IceKori

IceKori ��һ��Ϊ������Ϸ����ű����������߼�����ϵͳ��ʵ�ֵĿ��ӻ�������ԡ�IceKori ������ [Odin Inspector](http://sirenix.net/odininspector) ��� ��
��Ҫ˵�����ǣ� IceKori ������һ�����伴�õĲ�����䱾��ֻ�����˻����ĵ����Գ���ڵ㡣������Ϸϵͳǿ��ϵĹ�����ָ����Ҫ�����ṩ�ķ�ʽ�����ο�����

## ָ��˵��
[Command](./Command.md)

## �Զ���ָ��
[CustomCommand](./CustomCommand.md)

## IceKori Interpreter & IceKoriInterpreterComponent IceKori �������Ͷ�Ӧ���


## ȫ������
IceKori Ϊ������һ����Ŀ�ڿ���������ʵ������ͨһЩ���ݡ���ȫ�ֱ�����ȫ��ָ��ĸ�������ͨ�� Unity �½���Դ�˵�������һ�� IceKori ȫ�ֻ�������������ȫ�ֱ�����ȫ��ָ�
![GobalConfCreate](../DocRes\IceKoriGloablConfCreate.png)
![GobalConfCreate](../DocRes\IceKoriGloablConf.png)

`IceKori`��`Init`�������Զ����Դ� Resource ��������ȫ�������ļ����ļ���ӦΪ`GlobalConf`����
```c#
public static void LoadGlobalConf()
{
    var db = Resources.Load<GlobalConf>("GlobalConf");
    db.hideFlags = HideFlags.DontSaveInBuild;
    Conf = db;
}
```
## Semantic ����
IceKori ��ʵ����һ���ϸ�����С��������ִ�еġ���������˽������� IceKori ����������������ģ����Բο�������Ŀ��

+ [Understanding Computation: From Simple Machines to Impossible Programs](https://github.com/molingyu/UnderstandingComputation)

+ [����дһ��������](http://www.yinwang.org/blog-cn/2012/08/01/interpreter)

## Example ����
+ Gal-game story script

## �����﷨˵��
[Grammar](./Grammar.md)