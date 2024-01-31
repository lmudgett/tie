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
    public partial class ClientAppsAuth : UserControl, IAuthControl
    {
        public ClientAppsAuth()
        {
            InitializeComponent();
        }

        public string ClientId { get => txtClientId.Text; set => txtClientId.Text = value; }
        
        public string ClientSecret { get => txtClientSecret.Text; set => txtClientSecret.Text = value; }
        
        public bool IsValid()
        {
            bool isValid = false;

            if (txtClientId.Text.Length > 0 && txtClientSecret.Text.Length > 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public void Clear()
        {
            txtClientId.Text = "";
            txtClientSecret.Text = "";
        }

        public string ErrorMessage() 
        { 
            return "Client ID and Client Secret"; 
        }
    }
}
