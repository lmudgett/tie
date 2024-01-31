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
    public partial class frmTokenManager : Form
    {
        private JSonTokens _jsonTokens;
        private List<string> _selectedList; //this is to never to be init since it holds the reference of the list to be modified
        private bool _changed = false;

        public frmTokenManager()
        {
            InitializeComponent();
        }

        internal JSonTokens JsonTokens { get => _jsonTokens; set => _jsonTokens = value; }

        internal bool Changed { set => _changed = value; get => _changed; }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            ClearTokens();
            this.Hide();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (cboTokenType.SelectedIndex >= 0 && txtToken.Text != "")
            {
                if (lstTokens.SelectedIndex >= 0)
                {
                    _selectedList[lstTokens.SelectedIndex] = txtToken.Text;
                    lstTokens.Items.Clear();
                }
                else
                {
                    _selectedList.Add(txtToken.Text);
                }
                UpdateList();
                txtToken.Text = "";
                _changed = true;
            }
            else
            {
                MessageBox.Show("Please select a token type and be sure to enter a token value before trying to add / update a token",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTokenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTokenType.SelectedIndex >= 0)
            {
                //set the reference of the list to be modified
                switch (cboTokenType.SelectedItem.ToString())
                {
                    case "Package Tokens":
                        _selectedList = _jsonTokens.PackageTokens;
                        break;
                    case "Document Tokens":
                        _selectedList = _jsonTokens.DocumentTokens;
                        break;
                    case "Search Tokens":
                        _selectedList = _jsonTokens.SearchTokens;
                        break;
                    default:
                        MessageBox.Show("Undefined token type selected, please revise your selection",
                            "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                UpdateList();
            }
        }

        private void lstTokens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstTokens.SelectedIndex >= 0)
            {
                txtToken.Text = lstTokens.SelectedItem.ToString();
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (cboTokenType.SelectedIndex >= 0 && lstTokens.SelectedIndex >= 0)
            {
                _selectedList.RemoveAt(lstTokens.SelectedIndex);
                UpdateList();
                txtToken.Text = "";
                _changed = true;
            }
            else
            {
                MessageBox.Show("You must select a token type and a token from the list in order to delete it!",
                        "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            ClearTokens();
        }

        private void ClearTokens()
        {
            cboTokenType.SelectedIndex = -1;
            lstTokens.Items.Clear();
            txtToken.Text = "";
        }

        private void UpdateList()
        {
            lstTokens.Items.Clear();
            foreach (var token in _selectedList)
            {
                lstTokens.Items.Add(token);
            }
        }
    }
}
