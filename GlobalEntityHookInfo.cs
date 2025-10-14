using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerraJSAnalyzer;

internal struct GlobalEntityHookInfo
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
    public IFieldSymbol FieldSymbol { get; set; }
    public bool ManualSetDefaultValue { get; set; }
    public AttributeData AssociatedAttribute { get; set; }
}
