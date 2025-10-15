using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerraJSAnalyzer;

internal struct GlobalEntityHookInfo
{
    public readonly string FieldName => FieldSymbol.Name;
    public readonly string TypeName => FieldSymbol.Type.ToDisplayString(Utils.DisplayFormat);
    public IFieldSymbol FieldSymbol { get; set; }
    public bool ManualSetDefaultValue { get; set; }
    public AttributeData AssociatedAttribute { get; set; }
}
