using DataLayer;
using Keretrendszer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentTasks.Fejlesztőközpont
{
    public class EnumTerapeuta : TaskBase
    {
        public override string ToString()
        {
            return "Terapeuta listázása";
        }


        public List<Terapeutak> Terapeutaks { get; set; }

        public override string Execute()
        {

            using (FejlesztoKozpontDataContext context = new FejlesztoKozpontDataContext())
            {
                foreach (var item in context.Terapeutaks)
                {
                    OnLogMessage($"Terapeuta neve: {item.Name}; ID-ja: {item.TerapeutaID}");
                }
                Terapeutaks = context.Terapeutaks.ToList();


                return "Vége";
            }
        }
    }
}
