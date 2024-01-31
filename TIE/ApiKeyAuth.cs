using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIE
{
    public partial class ApiKeyAuth : UserControl, IAuthControl
    {
        public ApiKeyAuth()
        {
            InitializeComponent();
        }

        public string APIKey { get => txtApiKey.Text; set => txtApiKey.Text = value; }
        
        public bool IsValid() 
        { 
            bool isValid = false;

            if(txtApiKey.Text.Length > 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public string ErrorMessage()
        {
            return "API Key";
        }

        public void Clear()
        {
            txtApiKey.Text = "";
        }
    }
}
