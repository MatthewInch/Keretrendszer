using Keretrendszer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CurrentTasks
{
    public class MessageTest : BaseNumberInput
    {
        [Input("Count:")]
        public int InputNumber { get; set; }

        public override string Execute()
        {
                Random rnd = new Random();
                for (int i=0; i< InputNumber; i++)
                {
                    Thread.Sleep(1000);
                    OnLogMessage($"A következő szám: {rnd.Next(100)}");
                }
                return "Vége a feladatnak";
        }
    }
}
