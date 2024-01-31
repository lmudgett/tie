
namespace TIE
{
    public partial class frmEnv : Form
    {
        private List<Environment> _envList;
        private bool _changed = false;
        private IAuthControl _authControl;

        public event EventHandler CloseEnvironmentalForm;

        public frmEnv()
        {
            InitializeComponent();
            _authControl = apiKeyAuth;

        }

        internal List<Environment> EnvironmentalList { get => _envList; set => _envList = value; }

        internal bool Changed { set => _changed = value; get => _changed; }

        private void frmEnv_Load(object sender, EventArgs e)
        {
            ReloadList();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text.Length > 0 && txtName.Text.Length > 0
                && _authControl.IsValid() && cboMax.SelectedItem.ToString().Length > 0)
            {
                if (lstEnvs.SelectedIndex >= 0)
                {
                    Environment ev = _envList[lstEnvs.SelectedIndex];
                    ev.Max = cboMax.SelectedItem.ToString();
                    ev.Name = txtName.Text;
                    ev.Url = txtUrl.Text;
                    if(rdoAuth.Checked)
                    {
                        ev.ApiKey = apiKeyAuth.APIKey;
                    }
                    else
                    {
                        ev.ClientId = clientAppsAuth.ClientId;
                        ev.ClientSecret = clientAppsAuth.ClientSecret;
                        ev.ApiKey = default;
                    }
                }
                else
                {
                    Environment ev;
                    if (rdoClientApps.Checked)
                    {
                        ev = new(txtName.Text, txtUrl.Text, cboMax.SelectedItem.ToString())
                        {
                            ClientId = clientAppsAuth.ClientId,
                            ClientSecret = clientAppsAuth.ClientSecret,
                            ApiKey = default
                        };
                    }
                    else
                    {
                        ev = new(txtName.Text, txtUrl.Text, cboMax.SelectedItem.ToString())
                        {
                            ClientId = default,
                            ClientSecret = default,
                            ApiKey = apiKeyAuth.APIKey
                        };
                    }
                    _envList.Add(ev);
                }
                _changed = true;
                ReloadList();
                ClearSelectedEnvList();
            }
            else
            {
                MessageBox.Show($"You must provide a name, URL, {_authControl.ErrorMessage()} and max number of results in order to create a new environment!",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (lstEnvs.SelectedIndex >= 0)
            {
                _envList.Remove(_envList[lstEnvs.SelectedIndex]);
                _changed = true;
                ReloadList();
                ClearSelectedEnvList();
            }
            else
            {
                MessageBox.Show("You must select an environment in order to delete it!",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            CloseEnvironmentalForm?.Invoke(this, EventArgs.Empty);
            ClearSelectedEnvList();
            this.Hide();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            ClearSelectedEnvList();
        }

        private void lstEnvs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEnvs.SelectedIndex >= 0)
            {
                Environment ev = _envList[lstEnvs.SelectedIndex];

                for (var i = 0; i < cboMax.Items.Count; i++)
                {
                    if (cboMax.Items[i].ToString() == ev.Max)
                    {
                        cboMax.SelectedIndex = i;
                        break;
                    }
                }

                txtName.Text = ev.Name;
                if(ev.ApiKey != default)
                {
                    apiKeyAuth.APIKey = ev.ApiKey;
                    rdoAuth.Checked = true;
                }
                else
                {
                    clientAppsAuth.ClientId = ev.ClientId;
                    clientAppsAuth.ClientSecret = ev.ClientSecret;
                    rdoClientApps.Checked = true;
                }
                txtUrl.Text = ev.Url;
            }
        }
        private void ReloadList()
        {
            lstEnvs.Items.Clear();
            
            foreach (Environment ev in _envList)
            {
                lstEnvs.Items.Add(ev);
            }
        }
        private void ClearSelectedEnvList()
        {
            cboMax.SelectedIndex = -1;
            lstEnvs.ClearSelected();
            txtName.Text = default;
            _authControl.Clear();
            txtUrl.Text = default;
            clientAppsAuth.ClientSecret = default;
            clientAppsAuth.ClientId = default;
            apiKeyAuth.APIKey = default;
            rdoAuth.Select();
        }

        private void rdoAuth_CheckedChanged(object sender, EventArgs e)
        {
            clientAppsAuth.Visible = false;
            apiKeyAuth.Visible = true;
            _authControl = apiKeyAuth;
            //clientAppsAuth.ClientId = default;
            //clientAppsAuth.ClientSecret = default;
        }

        private void rdoClientApps_CheckedChanged(object sender, EventArgs e)
        {
            apiKeyAuth.Visible = false;
            clientAppsAuth.Visible = true;
            _authControl = clientAppsAuth;            
            //apiKeyAuth.APIKey = default;
        }
    }
}
