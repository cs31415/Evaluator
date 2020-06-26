using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Evaluator
{
    public class CompileHelper
    {
        public static string InputVariableIdentifier = "i";
        public static string OutputVariableIdentifier = "o";

        public static CompilerResults Compile(string expression)
        {
            var methodCode = expression;

            var methodCodeExpanded = Regex.Replace(methodCode, $@"(?:{InputVariableIdentifier}\.)(?<name>\w+)", "input[\"${name}\"]");
            methodCodeExpanded = Regex.Replace(methodCodeExpanded, $@"(?:{OutputVariableIdentifier}\.)(?<name>\w+)", "output[\"${name}\"]");

            var classCode = @"
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text.RegularExpressions;

                namespace Evaluator
                { 
                    public class Evaluator
                    {
                        public void Eval(Dictionary<string,dynamic> input, Dictionary<string,object> output) {" +
                            methodCodeExpanded + "} } }";

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
