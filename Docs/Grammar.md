# Grammar 语法

本节使用扩展的 BNF 描述 IceKori 的形式语法。
```
# 节点
<Name> : 代表一个 IceKori 图形节点。
<name> : 一个中间表示。 // 并不实际存在对应的图形节点。
#Name[type] : 代表一个 C# 对象（如 int/float/string）, `[]` 内表示对应的 c# 类型。
@Name : 代表一个 c# 的枚举。

# 符号
(...) : 表示一个 IceKori 的内部结构展开。
{...} : 表示一个 c# 枚举的内部展开。

# 量词：
* ： 零个或更多。
+ ： 至少一个。
```
## Basics

```
<token> → <IceKoriString>
    | <IceKoriInt>
    | <IceKoriInt>
    | <IceKoriFloat>
    | <IceKoriBoolean>
    | <IceKoriObject>
    | <Error>

<IceKoriString> → (#Value[string])

<IceKoriInt> → (#Value[int])

<IceKoriFloat> → (#Value[float])

<IceKoriBoolean> → (#Value[bool])

<IceKoriObject> → (#Value[object])

<Error> -> (#Message[string])
```

## Expresion

```
<Expresion> → <BinaryExpression> 
    | <VariableGet> 
    | <GlobalVariableGet>
    | <token>

<BinaryExpression> → (@Operator <left> <right>)
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
<left> → <Expresion>
<right> → <Expresion>

<VariableGet> → (#Name[string])

<GlobalVariableGet> → (#Name[string])
```

## statement

```
<Statement> → <IfStatement>
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

<IfStatement> → (<test> <consequence> <alternative>*)
<test> → <Expresion>
<consequence> → <Expresion>*
<alternative> → <Expresion>*

<ForStatement> → (#Count[int] )

```

## Grammar

```
IceKori → <Statement>*
```