using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Keretrendszer.Base
{
    public class TaskInputType
    {
        public string Label { get; private set; }
        public string Name { get; private set; }
        public Type InputType { get; private set; }

        public PropertyInfo Property { get; private set; }

        internal TaskInputType(string label, string name, Type type, PropertyInfo property)
        {
            Label = label;
            Name = name;
            InputType = type;
            Property = property;
        }
    }
}
