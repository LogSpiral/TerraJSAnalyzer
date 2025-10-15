using Microsoft.CodeAnalysis;

namespace TerraJSAnalyzer;

internal static class Utils
{
    public static SymbolDisplayFormat DisplayFormat { get; } = new(
        // 设置全局命名空间的显示风格
        globalNamespaceStyle: SymbolDisplayGlobalNamespaceStyle.Included,
        // 配置类型名称的显示方式
        typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
        // 配置泛型参数的显示方式（包括其命名空间）
        genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters
        );
}
