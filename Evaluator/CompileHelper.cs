using System.CodeDom.Compiler;
using System.Text.RegularExpressions;

namespace Evaluator
{
    /// <summary>
    /// C# Compile helper
    /// </summary>
    public class CompileHelper
    {
        public static string InputVariableIdentifier = "i";
        public static string OutputVariableIdentifier = "o";

        public static string GetExpressionSourceCode(string expression)
        {
            var methodCode = expression;

            var methodCodeExpanded = Regex.Replace(methodCode, $@"(?:{InputVariableIdentifier}\.)(?<name>\w+)", "_i[\"${name}\"]");
            methodCodeExpanded = Regex.Replace(methodCodeExpanded, $@"(?:{OutputVariableIdentifier}\.)(?<name>\w+)", "_o[\"${name}\"]");
            var methodCodeIndented = Regex.Replace(methodCodeExpanded, "^", "\t\t\t", RegexOptions.Multiline);

            var classCode =
                $@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Evaluator
{{ 
    public class Evaluator
    {{
        public void Eval(Dictionary<string,dynamic> _i, Dictionary<string,object> _o) 
        {{
{methodCodeIndented}
        }}
    }}
}}";
            return classCode.Replace("\t","    ");
        }

        public static CompilerResults Compile(string sourceCode)
        {

            var provider = CodeDomProvider.CreateProvider("CSharp");

            var parms = new CompilerParameters();
            parms.ReferencedAssemblies.Add("System.dll");
            parms.ReferencedAssemblies.Add("System.Core.dll");
            parms.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
            parms.GenerateInMemory = true;
            parms.TempFiles.KeepFiles = true;

            return provider.CompileAssemblyFromSource(parms, sourceCode);
        }
    }
}
