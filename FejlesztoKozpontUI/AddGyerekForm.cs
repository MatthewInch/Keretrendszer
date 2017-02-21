using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using CurrentTasks.Fejlesztőközpont;

namespace FejlesztoKozpontUI
{
    public partial class AddGyerekForm : Form
    {
        class ListItem
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        public AddGyerekForm()
        {
            InitializeComponent();
        }

        private void AddGyerekForm_Load(object sender, EventArgs e)
        {
            EnumTerapeuta task = new EnumTerapeuta();
            task.Execute();
            var terapeutak = from t in task.Terapeutaks
                             select new ListItem() { Name = t.Name, ID = t.TerapeutaID };
            foreach (var item in terapeutak)
            {
                cbTerapist.Items.Add(item);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddGyermek task = new AddGyermek();
            task.Name = txtName.Text;
            task.PhoneNumber = "1111";
            task.BirthDay = dpBirthday.Value;
            task.Terapeuta = ((ListItem)cbTerapist.SelectedItem).ID;
            task.Execute();
        }
    }
}
