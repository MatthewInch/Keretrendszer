using Keretrendszer.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentTasks.Fejlesztőközpont
{

    public abstract class BaseEntity: TaskBase
    {

        [Input("Adatfájl neve")]
        public string DataFilePath { get; set; }

        //elrejtése az InputString-nek
        public override string InputString { get; set; }


        public BaseEntity()
        {
            DataFilePath = "gyerekek.csv";
        }
        protected override bool CheckInput()
        {
            bool result = true;
            if (!File.Exists(DataFilePath))
            {
                if (string.IsNullOrEmpty(DataFilePath))
                {
                    result = false;
                    ErrorMessage += "Az adatfájl megadása kötelező.";
                }
                else
                {
                    try
                    {
                        using (StreamWriter writer = File.AppendText(DataFilePath))
                        {
                            writer.WriteLine($"Név;Születési Idő;Telefonszám;Cím");
                        }
                    }
                    catch (Exception ex)
                    {
                        result = false;
                        ErrorMessage += "Hiba az adatfájl létrehozásánál!";
                    }
                }
            }
            IsValid = result;
            return result;
        }



    }
}
