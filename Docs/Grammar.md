# Grammar �﷨

����ʹ����չ�� BNF ���� IceKori ����ʽ�﷨��
```
# �ڵ�
<Name> : ����һ�� IceKori ͼ�νڵ㡣
<name> : һ���м��ʾ�� // ����ʵ�ʴ��ڶ�Ӧ��ͼ�νڵ㡣
#Name[type] : ����һ�� C# ������ int/float/string��, `[]` �ڱ�ʾ��Ӧ�� c# ���͡�
@Name : ����һ�� c# ��ö�١�

# ����
(...) : ��ʾһ�� IceKori ���ڲ��ṹչ����
{...} : ��ʾһ�� c# ö�ٵ��ڲ�չ����

# ���ʣ�
* �� �������ࡣ
+ �� ����һ����
```
## Basics

```
<token> �� <IceKoriString>
    | <IceKoriInt>
    | <IceKoriInt>
    | <IceKoriFloat>
    | <IceKoriBoolean>
    | <IceKoriObject>
    | <Error>

<IceKoriString> �� (#Value[string])

<IceKoriInt> �� (#Value[int])

<IceKoriFloat> �� (#Value[float])

<IceKoriBoolean> �� (#Value[bool])

<IceKoriObject> �� (#Value[object])

<Error> -> (#Message[string])
```

## Expresion

```
<Expresion> �� <BinaryExpression> 
    | <VariableGet> 
    | <GlobalVariableGet>
    | <token>

<BinaryExpression> �� (@Operator <left> <right>)
@Operator {
    Add,
    Sub,
    Mul,
    Div,
    Mod,
    Concat,
    Less,
    LessEqual,
    Equal,
    MoreEqual,
    More,
    NotEqual,
    And,
    Or
}
<left> �� <Expresion>
<right> �� <Expresion>

<VariableGet> �� (#Name[string])

<GlobalVariableGet> �� (#Name[string])
```

## statement

```
<Statement> �� <IfStatement>
    | <ForStatement>
    | <WhileStatement>
    | <Define>
    | <GlobalDefine>
    | <CommandCall>
    | <GlobalCommandCall>
    | <VariableUpdate>
    | <GlobalVariableUpdate>
    | <Display>
    | <DebugPrint>
    | <TryCatch>
    | <Throw>
    | <DoNothing>

<IfStatement> �� (<test> <consequence> <alternative>*)
<test> �� <Expresion>
<consequence> �� <Expresion>*
<alternative> �� <Expresion>*

<ForStatement> �� (#Count[int] )

```

## Grammar

```
IceKori �� <Statement>*
```