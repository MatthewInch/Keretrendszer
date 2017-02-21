using Keretrendszer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentTasks
{
    public class Kecske : TaskBase
    {
        [Input("Hányszor")]
        public int Count { get; set; }

        [Input("Név")]
        public string Name { get; set; }

        [Input("DateTime")]
        public DateTime time { get; set; }

        public override string Execute()
        {
            for (int i=0; i<Count;i++)
            {
                OnLogMessage(Name);
            }
            return "Vége";
        }
    }
}
