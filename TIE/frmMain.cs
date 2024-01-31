using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.CodeAnalysis;
using System.Resources;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TIE
{
    public partial class frmMain : Form
    {
        private const string CACHE_FOLDER_NAME = "cache/";
        private const string JSON_PAYLOAD_FILE = "payload.json";
        private const string TOKENS_DATA_FILE = "tokens.json";
        private const string ENVIRONMENTS_DATA_FILE = "environments.dat";
        private const string FILE_EXTENSION = ".pdf";
        private const string GET_TEMPLATES_URI = "{env}a/api/packages?type=TEMPLATE&from=1&to={max}&sort=updated&dir=desc";
        private readonly frmEnv _frmEnv;
        private readonly frmAbout _frmAbout;
        private readonly frmTokenManager _frmTokenManager;
        private List<Environment> _envList = [];
        private JSonTokens _jsonTokens;
        private string _templatePayload;
        private string _aesKey;
        //client id: 18d465c1a0a0a5a712d58cf7ccb
        //client secret: 68796472615a4bf27203ebbffbc52bcf0715e112f209beb066304530efd44a4bde1002482e

        /*
         * 
         * NOTES/TODOS
         * TODO: need to check for closure classes 
         * 
         */

        struct Doc(string name, string id)
        {
            public string Name = name, Id = id;
        }

        public frmMain()
        {
            InitializeComponent();
            this._jsonTokens = new();
            this._frmAbout = new();
            this._frmEnv = new();
            this._frmTokenManager = new();
        }

        /*
         * 
         * FORM EVENTS
         * 
         */

        private void frmMain_Load(object sender, EventArgs e)
        {
            //add event listener for the closing of the environmental form to rebuild envlist
            _frmEnv.CloseEnvironmentalForm += frmEnv_Closing;

            //get aes key
            _aesKey = (System.Environment.MachineName + 
                Utils.ConvertBitmapToBase64(Properties.Resources.unnamed)).Substring(0, 32);


            //check if cache folder exists
            if (!Directory.Exists(CACHE_FOLDER_NAME))
            {
                Directory.CreateDirectory(CACHE_FOLDER_NAME);
            }

            //read from environments.json
            try
            {
                string buffer = File.ReadAllText(ENVIRONMENTS_DATA_FILE);
                buffer = Utils.Decrypt(buffer, _aesKey);

                _envList = JsonConvert.DeserializeObject<List<Environment>>(buffer);
                foreach (Environment ev in _envList)
                {
                    cboFrom.Items.Add(ev);
                }
            }
            catch 
            {
                MessageBox.Show($"Unable to load {ENVIRONMENTS_DATA_FILE}. Please add at least 2 evironments in the File->Environments screen!",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _frmEnv.EnvironmentalList = _envList;

            //read from tokens .json
            try
            {
                string buffer = default;
                if (!File.Exists(TOKENS_DATA_FILE))
                {
                    buffer = Properties.Resources.default_tokens;
                    _frmTokenManager.Changed = true;
                    MessageBox.Show($"{TOKENS_DATA_FILE} was not found, loading system default tokens! Please go to Edit->Token Manager to review the default tokens and make the nessary changes!",
                        "Default Tokens Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    buffer = File.ReadAllText(TOKENS_DATA_FILE);
                }
                _jsonTokens = JsonConvert.DeserializeObject<JSonTokens>(buffer);
                _frmTokenManager.JsonTokens = _jsonTokens;
            }
            catch
            {
                MessageBox.Show($"Unable to load {TOKENS_DATA_FILE}, or the default tokens. Please validate your install directory!",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEnv_Closing(object sender, EventArgs e)
        {
            //clean up the main form after looking at the envs
            ClearForm();
            foreach (Environment ev in _envList)
            {
                cboFrom.Items.Add(ev);
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (_frmTokenManager.Changed)
                {
                    string so = JsonConvert.SerializeObject(_jsonTokens, Formatting.Indented);      
                    File.WriteAllText(TOKENS_DATA_FILE, so);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to write " + TOKENS_DATA_FILE + ", details:" + ex.Message,
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (_frmEnv.Changed)
                {
                    string so = JsonConvert.SerializeObject(_envList, Formatting.Indented);
                    so = Utils.Encrypt(so, _aesKey);
                    File.WriteAllText(ENVIRONMENTS_DATA_FILE, so);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to write " + ENVIRONMENTS_DATA_FILE + ", details:" + ex.Message,
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * 
         * MENU ITEM EVENTS
         * 
         */

        private void mniEnv_Click(object sender, EventArgs e)
        {
            //_frmEnv.Changed = false;
            _frmEnv.Visible = true;
        }

        private void mniAbout_Click(object sender, EventArgs e)
        {
            _frmAbout.Visible = true;
        }
        private void mniTokenManager_Click(object sender, EventArgs e)
        {
            //_frmTokenManager.Changed = false;
            _frmTokenManager.Visible = true;
        }
        private void mniClearCache_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.Delete(CACHE_FOLDER_NAME, true);
                Directory.CreateDirectory(CACHE_FOLDER_NAME);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to clear the cache folder, details: {ex}", "ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mniExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*
         * 
         * FORM CONTROL EVENTS
         * 
         */

        private void cboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTo.Items.Clear();
            lstTo.Items.Clear();
            GetTemplates(_envList[cboFrom.SelectedIndex], lstFrom);
            //populate the cboTo with every environment except the selected 1
            for (int i = 0; i < _envList.Count; i++)
            {
                if (i != cboFrom.SelectedIndex)
                {
                    cboTo.Items.Add(_envList[i]);
                }
            }
            grpTo.Enabled = true;
        }

        private void cboTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstTo.Items.Clear();

            if (cboTo.SelectedIndex > -1)
            {
                GetTemplates((Environment)cboTo.SelectedItem, lstTo);
            }   
        }

        /// <summary>
        /// transfer 1 template from one account/environment to another
        /// 1. get the json payload from OSS using the selected list GUID
        /// 2. parse the json payload and remove any account specific details/settings
        /// 3. check if the folder exists if so re-create it else 
        ///     create a directory in the cache folder using the template GUID
        /// 4. write the parsed json payload to the folder
        /// 5. download the documents in the the new folder
        /// 6. create the template in the to environment/account using the files in the new folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cmdTransfer_Click(object sender, EventArgs e)
        {
            cmdTransfer.Enabled = false;
            if (lstFrom.SelectedItems != null && cboTo.SelectedItem != null)
            {
                List<Doc> docList = [];
                try
                {
                    Environment envFrom = (Environment)cboFrom.SelectedItem;
                    Environment envTo = (Environment)cboTo.SelectedItem;
                    /********************
                     *template manipulation 
                     ********************/
                    string templateId = (lstFrom.SelectedItem as string).Split("|")[1].Trim();
                    
                    if(templateId == null || templateId == "")
                    {
                        throw new Exception("template id is null, please be sure to select a valid template");
                    }

                    await GetTemplate(templateId, envFrom);
                    JObject template = JObject.Parse(_templatePayload); //_templatePayload is populated from GetTemplate
                    if (IsTemplateValid(template))
                    {
                        foreach (var token in _jsonTokens.PackageTokens)
                        {
                            template?.Remove(token);
                        }

                        foreach (var token in _jsonTokens.SearchTokens)
                        {   
                            template.SelectToken(token)?.Remove();
                        }

                        foreach (JObject doc in template["documents"].Cast<JObject>())
                        {
                            Doc d = new(doc.SelectToken("name").ToString(),
                                doc.SelectToken("id").ToString()); //grab the id before any chance of removal
                            docList.Add(d); 
                            foreach (var token in _jsonTokens.DocumentTokens)
                            {
                                doc?.Remove(token);
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid template selected");
                    }

                    /********************
                     *IO section 
                     ********************/
                    //setup directories
                    if (Directory.Exists($"{CACHE_FOLDER_NAME}{templateId}"))
                    {
                        Directory.Delete($"{CACHE_FOLDER_NAME}{templateId}", true);
                    }
                    Directory.CreateDirectory($"{CACHE_FOLDER_NAME}{templateId}");
                    File.WriteAllText($"{CACHE_FOLDER_NAME}{templateId}/{JSON_PAYLOAD_FILE}",
                        template.ToString());

                    //download files
                    List<Task> dt = new List<Task>();
                    foreach (var docId in docList)
                    {
                        Task d = Task.Run(async () =>
                        {
                            await DownloadDocument(envFrom, templateId, docId);
                        });
                        dt.Add(d);
                    }

                    await Task.WhenAll(dt);

                    //attempt to transfer template to new env
                    await TransferTemplate(envTo, CACHE_FOLDER_NAME + templateId, docList);
                    GetTemplates(envTo, lstTo);
                }
                catch (Exception ex)
                {
                    tslMain.Text = "";
                    tspBar.Value = 0;
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
            else
            {
                MessageBox.Show("Please select a template from the From destination and a To destination from the drop down list before attempting to transfer",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmdTransfer.Enabled = true;
        }

        /// <summary>
        /// validate that the JObject has the basic structure
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsTemplateValid([NotNullWhen(true)] JObject obj)
            => obj is not null
                && obj["documents"] is not null
                && obj["roles"] is not null;

        /// <summary>
        /// reset the form
        /// </summary>
        private void ClearForm()
        {
            cboFrom.Items.Clear();
            cboFrom.SelectedIndex = -1;
            lstFrom.Items.Clear();
            grpTo.Enabled = false;
            lstTo.Items.Clear();
            cboTo.Items.Clear();
            tslMain.Text = "";
            tspBar.Value = 0;
        }

        /*
         * 
         * AYSNC METHODS
         * 
         */

        /// <summary>
        /// get a list of template for a given OSS account/environment
        /// </summary>
        /// <param name="env">environment/account to get the templates from</param>
        /// <param name="lst">the listbox to populate the results with</param>
        private async void GetTemplates(Environment env, ListBox lst)
        {
            lst.Items.Clear();
            if (lst.Name == "lstFrom")
            {
                tslMain.Text = "Fetching List for From Env";
            }
            else
            {
                tslMain.Text = "Fetching List for To Env";
            }
            tspBar.Value = 0;

            try
            {
                if (env == null)
                {
                    throw new Exception("unable to get templates from environment, environment was null");
                }

                //get the sender session id
                string jsonRes;
                using (HttpClient client = new())
                {
                    await SetHttpAuthorization(env, client);
                    //HttpResponseMessage res = await client.GetAsync(env.Url + "api/sessions");
                    HttpResponseMessage res = await client.PostAsync(env.Url + "api/sessions", null);
                    res.EnsureSuccessStatusCode();
                    jsonRes = await res.Content.ReadAsStringAsync();
                }

                var id = JObject.Parse(jsonRes).SelectToken("sessionToken") ??
                     throw new Exception("unable to get session id");

                //get the list of templates
                HttpClientHandler handler = new() { CookieContainer = new() };
                using (HttpClient client = new(handler) { BaseAddress = 
                    new($"{GET_TEMPLATES_URI.Replace("{env}", env.Url).Replace("{max}", env.Max)}") })
                {
                    //client.DefaultRequestHeaders.Add("Authorization", $"Basic {env.ApiKey}");
                    handler.CookieContainer.Add(client.BaseAddress, new Cookie("ESIGNLIVE_SESSION_ID", id.ToString()));
                    HttpResponseMessage res = await client.GetAsync(client.BaseAddress);
                    res.EnsureSuccessStatusCode();
                    jsonRes = await res.Content.ReadAsStringAsync();
                }

                JToken templates = JObject.Parse(jsonRes).SelectToken("results") ??
                     throw new Exception("unable to get templates");

                foreach (JObject obj in templates.Cast<JObject>())
                {
                    lst.Items.Add($"{obj.SelectToken("name")} | {obj.SelectToken("id")}");                
                }
                tspBar.Value = 100;
                tslMain.Text = "Fetching List Complete";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to get templates for environment {env.Name}, please check your configuration! details: {ex.Message}", 
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// returns the json payload for a give template/transaction 
        ///     NOTE: this is using a global var to hold the payload due to the async method wait time        
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="env"></param>
        /// <returns></returns>
        private async Task GetTemplate(string guid, Environment env)
        {
            _templatePayload = default;
            using HttpClient client = new();
            await SetHttpAuthorization(env, client);
            HttpResponseMessage res = await client.GetAsync($"{env.Url}/api/packages/{guid}");
            res.EnsureSuccessStatusCode();
            _templatePayload = await res.Content.ReadAsStringAsync();         
        }

        /// <summary>
        /// download document from a given template and write it to disk. the path folder is built from default cache folder name,
        ///     the guid is the folder name and the doc name is the file name withe the .pdf extension
        /// </summary>
        /// <param name="env">which OSS environment to down the document from</param>
        /// <param name="guid">package id or GUID of the template</param>
        /// <param name="doc">document id and document name</param>
        /// <returns></returns>
        private async Task DownloadDocument(Environment env, string guid, Doc doc)
        {
            byte[] buffer = [];
            using (HttpClient client = new())
            {
                await SetHttpAuthorization(env, client);
                UriBuilder uriBuilder = new(env.Url) { Path = $"/api/packages/{guid}/documents/{doc.Id}/original" };
                MemoryStream ms = new();
                Stream res = await client.GetStreamAsync(uriBuilder.Uri);

                await res.CopyToAsync(ms);
                buffer = ms.ToArray();
            }

            if (buffer.Length > 1)
            {
                FileStream fs = new(Path.Combine(CACHE_FOLDER_NAME, guid, doc.Name + FILE_EXTENSION), FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
            else
            {
                throw new Exception($"Retrieved file {doc.Name} {doc.Id} has zero bytes, please be sure this is a true file!");
            }
            
        }

        /// <summary>
        /// transfer the template from disk to the cloud
        /// </summary>
        /// <param name="toEnv"></param>
        /// <param name="path"></param>
        /// <param name="docList"></param>
        /// <returns></returns>
        private async Task TransferTemplate(Environment toEnv, string path, List<Doc> docList)
        {
            tslMain.Text = "Transferring Template...";
            tspBar.Value = 0;
            
            MultipartFormDataContent content = [];
            string payloadBuffer = File.ReadAllText($"{path}/{JSON_PAYLOAD_FILE}");
            content.Add(new StringContent(payloadBuffer), "payload");
            foreach (Doc d in docList)
            {
                var stream = new FileStream($"{path}/{d.Name}{FILE_EXTENSION}", FileMode.Open);
                content.Add(new StreamContent(stream), "file", Path.GetFileNameWithoutExtension(d.Name));
            }

            using HttpClient client = new();
            await SetHttpAuthorization(toEnv, client);
            HttpResponseMessage res = await client.PostAsync($"{toEnv.Url}/api/packages/", content);
            res.EnsureSuccessStatusCode();
            string ss = await res.Content.ReadAsStringAsync();
            tspBar.Value = 100;
            tslMain.Text = "Transferring Template Complete";
            MessageBox.Show($"Template transfer complete, response: {ss}", "GUID", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task SetHttpAuthorization(Environment env, HttpClient client)
        {
            if (env.IsClientAppAuth())
            {
                await GenerateClientAppToken(env);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {env.ClientToken}");
            }
            else
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Basic {env.ApiKey}");
            }
        }

        private async Task GenerateClientAppToken(Environment env)
        {
            if(env.HasClientTokenExpired())
            {
                StringContent content = new StringContent(env.ClientPayload, Encoding.UTF8, "application/json");
                using HttpClient client = new();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                string url = $"{env.Url}apitoken/clientApp/accessToken";
                HttpResponseMessage res = await client.PostAsync(url, content);
                res.EnsureSuccessStatusCode();
                string ss = await res.Content.ReadAsStringAsync();

                JToken accessToken = JObject.Parse(ss).SelectToken("accessToken") ??
                         throw new Exception("unable to get client app access token");

                JToken expiresAt = JObject.Parse(ss).SelectToken("expiresAt") ??
                         throw new Exception("unable to get client app access token");

                env.ClientToken = accessToken.ToString();
                env.ClientTokenExpiresAt = long.Parse(expiresAt.ToString());
            }
        }
    }
}
