using Keretrendszer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentTasks
{
    public class Fibonacci : TaskBase
    {
        [Input("Fibonaci szám")]
        public int InputNumber { get; set; }

        public override string Execute()
        {
            return F(InputNumber).ToString();
        }

        //az override-al "letakarom" a szülő osztályban definiált inputString property-t. Mivel nem 
        //adok meg semmilyen Attribute-ot (nincs [Input(...)] a property előtt, a keretrendszer nem fogja kirakni 
        public override string InputString
        {
            get
            {
                return base.InputString;
            }

            set
            {
                base.InputString = value;
            }
        }

        private int F(int n)
        {
            if (n == 1 || n==2)
            {
                return 1;
            }
            return F(n - 1) + F(n - 2);
        }
    }
}
