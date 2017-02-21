using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Keretrendszer.Base
{
    public abstract class TaskBase
    {


        [Input("Standard input")]
        public virtual string InputString { get; set; }

        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        private Action<string> _logAction;

        public void DefineMessage(Action<string> logger)
        {
            _logAction = logger;
        }
        protected void OnLogMessage(string message)
        {
            if (_logAction != null)
            {
                _logAction(message);
            }
        }

        public virtual string Execute()
        {
            if (CheckInput())
                return "Feladat vége.";
            else
                return ErrorMessage;
        }

        protected virtual bool CheckInput()
        {
            if (string.IsNullOrEmpty(InputString))
            {
                IsValid = false;
                ErrorMessage = "The input parameter is empty!";
                return false;
            }
            IsValid = true;
            return true;
        }

        /// <summary>
        /// Get all property which has "input" attribute
        /// </summary>
        /// <returns></returns>
        public List<TaskInputType> GetInputs()
        {
            var type = this.GetType();
            var properties = type.GetProperties();
            var inputProperties = properties
                .Where(p => p.GetCustomAttributes(false).Any(a => a.GetType() == typeof(InputAttribute)))
                .Select(p => new TaskInputType(p.GetInputLabel(), p.Name, p.PropertyType, p));
            return inputProperties.ToList();
           
        }

        public override string ToString()
        {
            var name = base.ToString();
            return name.Split('.').Last();
        }
    }
}
