using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Evaluator
{
    public class EvalSettings
    {
        public string Expression { get; set; }
        public Dictionary<string, string> Variables { get; set; } 
        public Point Location { get; set; }
        public Size Size { get; set; }
        public FormWindowState WindowState { get; set; }
    }
}
