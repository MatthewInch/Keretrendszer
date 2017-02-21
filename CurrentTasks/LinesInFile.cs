using Keretrendszer.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentTasks
{
    public class LinesInFile : TaskBase
    {
        protected override bool CheckInput()
        {
            base.CheckInput();
            if (IsValid)
            {
                if (!File.Exists(InputString))
                {
                    ErrorMessage = "A megadott fájlt nem találom. (béna vagyok, bocsika)";
                    IsValid = false;
                }
            }
            return IsValid;
        }

        public override string Execute()
        {
            base.Execute();
            if (IsValid)
            {
                var inputFile = File.ReadLines(InputString);
                return inputFile.Count().ToString();
            }
            else
            {
                return ErrorMessage;
            }
        }
    }
}
