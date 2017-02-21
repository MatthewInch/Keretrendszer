using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keretrendszer.Base
{
    public class InputAttribute : Attribute
    {
        public string Label { get; private set; }
        public InputAttribute(string label)
        {
            this.Label = label;
        }
    }
}
