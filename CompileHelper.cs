using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Evaluator
{
    public class CompileHelper
    {
        public static CompilerResults Compile(string expression)
        {
            List<string> lines = expression.Split(new[] { ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var lastLine = $"return {lines.Last()};";
            var methodCode = lines.Take(lines.Count - 1).Aggregate("", (r, i) => r + i + ";");
            methodCode = $"{methodCode}{lastLine}";

            var classCode = @"
                using System;
                using System.Collections.Generic; 
                namespace Evaluator
                { 
                    public class Evaluator
                    {
                        public dynamic Eval(Dictionary<string,dynamic> input) {" +
                            Regex.Replace(methodCode, @"(?:input\.)(?<name>\w+)", "input[\"${name}\"]") + "} } }";

            var provider = CodeDomProvider.CreateProvider("CSharp");

            var parms = new CompilerParameters();
            parms.ReferencedAssemblies.Add("System.dll");
            parms.ReferencedAssemblies.Add("System.Core.dll");
            parms.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
            parms.GenerateInMemory = true;

            return provider.CompileAssemblyFromSource(parms, classCode);
        }
    }
}
