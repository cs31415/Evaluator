using System.CodeDom.Compiler;

namespace Evaluator
{
    public class CompilerErrorEx 
    {
        public CompilerError Error { get; set; }

        public CompilerErrorEx(CompilerError error)
        {
            Error = error;
        }
        public override string ToString()
        {
            return $"[{Error.Line},{Error.Column}] {Error.ErrorNumber}: {Error.ErrorText}";
        }
    }
}
