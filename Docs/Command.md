# Command ָ��
���ڽ������������õ� IceKori ָ�

## ���ʽ�ڵ�
**ע��**: ���еı��ʽ�ڵ㶼ֻ�ܶ�����ָ���ڲ���

### `BinaryExpression` �ڵ�
> ��Ԫ���ʽ

![BinaryExpression](../DocRes/BinaryExpression.png)
+ `Operator` BinaryOperator `enum` ��������
    + `BinaryOperator.Add` ���
    + `BinaryOperator.Sub` ���
    + `BinaryOperator.Mul` ���
    + `BinaryOperator.Div` ���
    + `BinaryOperator.Mod` ȡ��
    + `BinaryOperator.Concat` �ַ�������
    + `BinaryOperator.Less` С��
    + `BinaryOperator.LessEqual` С�ڵ���
    + `BinaryOperator.Equal` ����
    + `BinaryOperator.MoreEqual` ���ڵ���
    + `BinaryOperator.More` ����
    + `BinaryOperator.NotEqual` ������
    + `BinaryOperator.And` �߼���
    + `BinaryOperator.Or` �߼���

+ `Left` BaseExpression �������
+ `Right` BaseExpression �Ҳ�����

### �������ͽڵ�
> ��Щ�ڵ��ʾ�� IceKori ���������ͣ��䱾���Ƕ� c# ��Ӧ�����װ�䡣

#### `IceKoriInt`
![IceKoriInt](../DocRes/IceKoriInt.png)
#### `IceKoriFloat`
![IceKoriFloat](../DocRes/IceKoriFloat.png)
#### `IceBool`
![IceKoriBool](../DocRes/IceKoriBool.png)
#### `IceKoriString`
![IceKoriString](../DocRes/IceKoriString.png)
#### `IceKoriObject`
> ������װ c3 ���������͡�

**`IceKoriSprite`** Unity Sprite ����ķ�װ��

**`IceKoriTexture`** Unity Sprite ����ķ�װ��

**`IceKoriColor`** Unity Sprite ����ķ�װ��

**`IceKoriGameObject`** Unity GameObject ����ķ�װ��

### ����ڵ�
> ��ʾһ�� IceKori �Ĵ������

�ڱ��ʽ�����һ������ڵ�ʱ��Ĭ��Ϊ�׳���һ����Ӧ�Ĵ���

**`TypeError`** �����ִ�������͵���ʱ�׳����쳣��
    
**`ReferenceError`** �����ʵ�����ֵδ���壬���߶����Ѷ��������ֵʱ�׳����쳣��

### �������ʽڵ�
#### `VariableGet`
![VariableGet](../DocRes/VariableGet.png)
#### `GlobalVariableGet`
![GlobalVariableGet](../DocRes/GlobalVariableGet.png)

## �߼�ָ��
### `IfStatement`
> �����ж�ָ������Ϊ�棬ִ�� Consequence, ����ִ�� Alternative

![]()

+ `Condition` Expression ���жϵ�����
+ `Consequence` List\<BaseStatement>
+ `Alternative` List\<BaseStatement>

### `ForStatement`

### `WhileStatement`

## ����

### `TryCatch`

### `Throw`

�׳��쳣��

## ��������ָ��
### `Define`
> ����һ��������

### `GlobalDefine`
> ����һ��ȫ�ֱ�����

## ����ָ��
### `Display`

### `DebugPrint`


## gameplay ָ��

### `SetObjectActive`
> ���� GameObject ��״̬��

![SetObjectActive](../DocRes/SetObjectActive.png)

+ `Object` GameObject - ���޸ĵ� GameObject ����
+ `Status` BaseExpression - Ҫ�޸ĵ�״̬������ͨ��һ�� `IceKoriBool` �ڵ���ֱ��ָ��������ͨ����Ԫ���ʽ����ó�������߷���ĳ������/ȫ�ֱ�������Ҫע����ǣ������������Ҫȷ������ȡ����һ�� `IceKoriBool` �ڵ���󡣷���ᴥ�� `TypeError` ����

��ָ��ȼ������´��룺
```
Object.SetActive(Status)
```

## �ڲ�ָ��*
> ��Щָ��������ⲿ������ֻ���ڽ�����ʵ�����е�ʱ�򴴽��������Ը�����

### `Sequence`
> ˳�����ָ�������������е� `List<BaseSteament>` ����ת����һ�� `Sequence` ���ٽ��й�Լ��
### `EvalCallback`
> ִ�е���ָ��ʱ����������������� c# �ص�������
### `DoNothing`
> ��ʾʲô������������������ `Statement` ��һ�� `DoNothing` �ڵ�ʱ����ζ�ų������н�����