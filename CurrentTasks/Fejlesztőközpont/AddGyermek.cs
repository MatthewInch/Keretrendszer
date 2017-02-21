using DataLayer;
using Keretrendszer.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentTasks.Fejlesztőközpont
{
    public class AddGyermek : BaseEntity
    {
        [Input("Név")]
        public string Name { get; set; }
        [Input("Szül. idő")]
        public DateTime BirthDay { get; set; }
        [Input("Cím")]
        public string Address { get; set; }
        [Input("Telefonszám")]
        public string PhoneNumber { get; set; }

        [Input("Terapeuta")]
        public int Terapeuta { get; set; }

        protected override bool CheckInput()
        {
            bool result = true;

            if (string.IsNullOrEmpty(Name))
            {
                result = false;
                ErrorMessage += "A név mező nem lehet üres \n";
            }
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                result = false;
                ErrorMessage += "A telefonszám mező nem lehet üres \n";
            }
            if (BirthDay > DateTime.Now.AddMonths(-2) || BirthDay< DateTime.Now.AddYears(-12))
            {
                result = false;
                ErrorMessage += "A gyermek legalább 2 hónapos és legfeljebb 12 éves lehet. \n";
            }
            IsValid = result;
            return result;
        }

        public override string Execute()
        {
            var result = base.Execute();
            if (IsValid)
            {
                //using (StreamWriter writer = File.AppendText(DataFilePath))
                //{
                //    writer.WriteLine("{0};{1};{2};{3}",Name, BirthDay.ToShortDateString(), PhoneNumber, Address);
                //}
                try
                {
                    using (FejlesztoKozpontDataContext context = new FejlesztoKozpontDataContext())
                    {
                        var newGyerek = new Gyerekek();
                        newGyerek.Name = this.Name;
                        newGyerek.Address = this.Address;
                        newGyerek.BirthDay = this.BirthDay;
                        newGyerek.TerapeutaID = this.Terapeuta;

                        context.Gyerekeks.InsertOnSubmit(newGyerek);

                        context.SubmitChanges();
                        result = "Kész a gyerek hozzáadás";
                    }
                }
                catch (Exception ex)
                {
                    OnLogMessage(ex.Message);
                }
            }
            return result;
        }
    }
}
