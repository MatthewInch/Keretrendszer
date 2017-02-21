using CurrentTasks.Fejlesztőközpont;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FejlesztokozpontWeb
{
    public partial class AddGyerek : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EnumTerapeuta task = new EnumTerapeuta();
            task.Execute();
            var terapeutak = from t in task.Terapeutaks
                             select new ListItem(t.Name,t.TerapeutaID.ToString() );
            foreach (var item in terapeutak)
            {
                //cbTerapist.Items.Add(item);
                ddlTerapeutak.Items.Add(item);
            }
        }
    }
}