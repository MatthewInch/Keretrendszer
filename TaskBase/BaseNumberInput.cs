using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keretrendszer.Base
{
    public class BaseNumberInput : TaskBase
    {
        protected int _inputNumber;
        protected override bool CheckInput()
        {
            if (base.CheckInput())
            {
                if (int.TryParse(InputString, out _inputNumber))
                {
                    IsValid = true;
                    return true;
                }
                else
                {
                    ErrorMessage = "A bemeneti érték nem szám.";
                    IsValid = false;
                    return false;
                }
            }
            else
                return false;
        }
    }
}
