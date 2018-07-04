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

## Expression

```
<Expression> �� <BinaryExpression> 
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
    | <VariableUpdate>
    | <GlobalVariableUpdate>
    | <CommandCall>
    | <GlobalCommandCall>
    | <Display>
    | <DebugPrint>
    | <TryCatch>
    | <Throw>
    | <DoNothing>

<IfStatement> �� (<condition> <consequence> <alternative>*)
<condition> �� <Expression>
<consequence> �� <Expression>*
<alternative> �� <Expression>*

<ForStatement> �� (#Count[int] <body>)
<body> �� <Statement>*

<WhileStatement> �� (<condition> <body>)

<value> �� <Expression>

<Define> �� (#Name[string] <value>)

<GobalDefine> �� (#Name[string] <value>)

<VariableUpdate> �� (#Name[string] <value>)

<GlobalVariableUpdate> �� (#Name[string] <value>)

<CommandCall> �� (#Name[string])

<GlobalCommandCall> �� (#Name[string])

<Display> �� (<value>)

<DebugPrint> �� (<value>)

<TryCatch> �� (<body> @Catch <rescue>)

@Catch {
    TypeError,
    ReferenceError,
    All
}

<Throw> �� (<Error>)

<DoNothing> �� ()
```

## Grammar

```
IceKori �� <Statement>*
```