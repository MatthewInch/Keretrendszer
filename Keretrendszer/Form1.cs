using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurrentTasks;
using System.Reflection;
using Keretrendszer.Base;
using System.Globalization;
using System.Threading;
using System.Configuration;

namespace Keretrendszer
{
    public partial class Form1 : Form
    {
        private List<ConnectedInput> _connectedTaskInputs  =new List<ConnectedInput>();

        /// <summary>
        /// This class connect an input field of the task with the input controls of the form.
        /// 
        /// </summary>
        protected class ConnectedInput
        {
            /// <summary>
            /// An action that can set the input field of the task with the value of the control
            /// </summary>
            public Action SetCurrentInput;
        }

        public Form1()
        {
            var settings = Properties.Settings.Default;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings.Language2);
            InitializeComponent();
            txtOutput.AppendText(Properties.Resources.Test + "\n"); 
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (cbTask.SelectedItem == null)
            {
                txtOutput.Text = "Please choose a task!";
            }
            else
            {
                TaskBase currentTask = GetCurrentTask();
                if (currentTask != null)
                {
                    //Set all active input property with the setted value
                    foreach (var connectedTaskInput in _connectedTaskInputs)
                    {
                        connectedTaskInput.SetCurrentInput();
                    }
                    //run the task
                    btnExecute.Enabled = false;
                    Task.Run(()=>
                    {
                        var output = currentTask.Execute();
                        WriteMessageToTextField( output);
                        btnExecute.Invoke((MethodInvoker)delegate { btnExecute.Enabled = true; });
                });
                }
            }
        }

        public void WriteMessageToTextField(string message)
        {
            //this is a thread safe setting mode
            txtOutput.Invoke( (MethodInvoker)delegate {
                txtOutput.AppendText(message + "\n");
            });
        }

        

        

        /// <summary>
        /// simple factory method to get the task
        /// </summary>
        /// <returns></returns>
        private TaskBase GetCurrentTask()
        {
            return cbTask.SelectedItem as TaskBase;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Get all 
            Assembly assembly = System.Reflection.Assembly.Load("CurrentTasks");
            if (assembly != null)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass && !type.IsAbstract)
                    {
                        TaskBase task = Activator.CreateInstance(type) as TaskBase;
                        if (task != null)
                        {
                            task.DefineMessage(WriteMessageToTextField);
                            cbTask.Items.Add(task);
                        }
                    }
                }
            }

        }
        
        private void cbTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTask.SelectedItem is TaskBase)
            {
                var currentTask = cbTask.SelectedItem as TaskBase;
                var inputs = currentTask.GetInputs();
                pnlInputs.Controls.Clear();
                _connectedTaskInputs.Clear();
                GenerateControls(currentTask, inputs);
            }
        }

        /// <summary>
        /// Generate all necesarry controls for task
        /// </summary>
        /// <param name="currentTask"></param>
        /// <param name="inputs"></param>
        private void GenerateControls(TaskBase currentTask, List<TaskInputType> inputs)
        {
            int i = 0;
            foreach (var input in inputs)
            {

                var label = new Label();
                label.Text = input.Label;
                label.Location = new Point(10, 30 * i);
                pnlInputs.Controls.Add(label);

                if (input.InputType == typeof(int))
                {
                    var numericUpDown = new NumericUpDown();
                    numericUpDown.Location = new Point(140, 30 * i);
                    pnlInputs.Controls.Add(numericUpDown);
                    numericUpDown.Name = input.Name;
                    i++;
                    _connectedTaskInputs.Add(new ConnectedInput()
                    {
                        SetCurrentInput = () =>
                        {
                            input.Property.SetValue(currentTask, decimal.ToInt32(numericUpDown.Value));
                        }
                    });
                } else if(input.InputType == typeof(DateTime))
                {
                    var dateTimePicker = new DateTimePicker();
                    dateTimePicker.Location = new Point(140, 30 * i);
                    pnlInputs.Controls.Add(dateTimePicker);
                    dateTimePicker.Name = input.Name;
                    i++;
                    _connectedTaskInputs.Add(new ConnectedInput()
                    {
                        SetCurrentInput = () =>
                        {
                            input.Property.SetValue(currentTask, dateTimePicker.Value);
                        }
                    });
                }
                else
                {
                    var inputTextbox = new TextBox();
                    inputTextbox.Location = new Point(140, 30 * i);
                    pnlInputs.Controls.Add(inputTextbox);
                    inputTextbox.Name = input.Name;
                    i++;

                    var defaultValue = input.Property.GetValue(currentTask);
                    if (defaultValue != null)
                        inputTextbox.Text = defaultValue.ToString();

                    _connectedTaskInputs.Add(new ConnectedInput()
                    {
                        SetCurrentInput = () =>
                        {
                            input.Property.SetValue(currentTask, inputTextbox.Text);
                        }
                    });
                }
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("en");
        }

        private void SetLanguage(string language)
        {
            //var configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //configManager.AppSettings.Settings.Remove("Language");
            //configManager.AppSettings.Settings.Add("Language", language);
            //configManager.Save();
            var settings = Properties.Settings.Default;
            settings.Language2 = language;
            settings.Save();
            Application.Restart();


        }

        private void hungarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLanguage("hu");
        }
    }
}
