using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace TerraJSAnalyzer;

internal readonly struct EventDeclarationInfo
{
    private static SymbolDisplayFormat DisplayFormat { get; } = new SymbolDisplayFormat(
    // 设置全局命名空间的显示风格
    globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Included,
    // 配置类型名称的显示方式
    typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
    // 配置泛型参数的显示方式（包括其命名空间）
    genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters
    );


    public readonly string FieldName => FieldSymbol.Name;
    public readonly string TypeName => FieldSymbol.Type.ToDisplayString(DisplayFormat);
    public string[] Parameters { get; }
    public IFieldSymbol FieldSymbol { get; }
    public EventDeclarationInfo(IFieldSymbol fieldSymbol)
    {
        FieldSymbol = fieldSymbol;
        var attibuteData =
            fieldSymbol
            .GetAttributes()
            .FirstOrDefault(
                attributeData =>
                attributeData.AttributeClass.ToDisplayString()
                == "TerraJS.Contents.Attributes.EventDeclareAttribute"
                );
        Parameters =
            attibuteData == null
            ? []
            : [.. from value in attibuteData.ConstructorArguments.First().Values select value.ToCSharpString()];
    }
}
