using CurrentTasks.Fejlesztőközpont;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FejlesztoKozpontUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("hu-HU");
            InitializeComponent();
        }

        private void btnAddGyerek_Click(object sender, EventArgs e)
        {
            AddGyerekForm newForm = new AddGyerekForm();
            newForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnumGyermek task = new EnumGyermek();
            task.Execute();
            gridGyerekek.DataSource = (from gy in task.AllGyerek
                                      where gy.BirthDay != null
                                      select new { Név=gy.Name, SzületésiIdő = gy.BirthDay, Terapeuta = gy.TerapeutaName }
                                      ).ToList();

        }
    }
}
