using Keretrendszer.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace CurrentTasks.Fejlesztőközpont
{
    public class EnumGyermek : BaseEntity
    {
        public override string ToString()
        {
            return "Gyerekek listázása";
        }

        public List<AllGyerekData> AllGyerek { get; set; }

        public override string Execute()
        {
            var result =  base.Execute();
            if (IsValid)
            {
                using (FejlesztoKozpontDataContext context = new FejlesztoKozpontDataContext())
                {
                    AllGyerek = context.AllGyerekDatas.ToList();
                    foreach (var item in AllGyerek)
                    {
                        OnLogMessage($"Gyerek neve: {item.Name}; Terapeutája: {item.TerapeutaName}");
                    }
                }
            }
            return result;
        }

    }
}
