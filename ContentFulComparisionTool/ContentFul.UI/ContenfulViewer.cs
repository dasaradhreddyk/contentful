using System.Data;
using System.Windows.Forms;
using ContentFulComparisionTool.Builder;
using ContentFulComparisionTool.ContentFul.Builder;
using ContentFulComparisionTool.ContentFul.Core.Exceptions;
using ContentFulComparisionTool.Models;
using ContentFulComparisionTool.Services.ContentFulFactory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ContentDisplayModelItem = GraphQL.Client.Http.ContentDisplayModelItem;
using ContentViewModel = GraphQL.Client.Http.CFContentViewModel;

namespace ContentFulComparisionTool;

public partial class ContenfulViewer : Form
{
    public bool bToggle = false;
    private readonly DataGridView _contentFulGridView = new DataGridView();
    public ContenfulViewer()
    {
        InitializeComponent();


        //Get contenttypes
        GetContentModel.GetContentModelAsync("Development");
        GetContentModel.GetContentModelAsync("UAT");

        // Set List view styles.
        if (env_dropdown.Text.Equals(""))
            collection_dropdown.Enabled = false;
        listView1.View = View.Details;
        listView1.Sort();

        Controls.Add(_contentFulGridView);

        dataGridView1.ColumnCount = 5;
        dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        string[] colNames = { "Field Name", "CBus", "Aware", "GPM", "Environment" };

        dataGridView1.Columns[0].Name = colNames[0];
        dataGridView1.Columns[0].Width = 200;
        dataGridView1.Columns[1].Name = colNames[1];
        dataGridView1.Columns[1].Width = 200;
        dataGridView1.Columns[2].Name = colNames[2];
        dataGridView1.Columns[2].Width = 300;
        dataGridView1.Columns[3].Name = colNames[3];
        dataGridView1.Columns[3].Width = 200;
        dataGridView1.Columns[4].Name = colNames[4];
        dataGridView1.Columns[4].Width = 200;
        ProgressBar.Hide();
        TagNames.InitTags();
        FundSelectionDropDown.SelectedIndex = 0;
        //env_dropdown.SelectedIndex = 0;


    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Contentful model selection / change  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private async void CollectionSelectedIndexChangedAsync(object sender, EventArgs e)
    {

        ProgressBar.Show();

        //Update model related data.

        //BuildMasterData.InitDataAsync(collection_dropdown.Text.Replace("Collection", ""));
        // BuildComparisionData.CompareUatAndDevNoFeilds("Aware");
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        //richTextBox1.Text = BuildMasterData.data.summary + "\n\r" + richTextBox1.Text;

        //clear UI controls

        comboBox1.Items.Clear();
        comboBox1.Text = " ";
        LogExceptions.ExceptionsData.Clear();

        //update search fields

        var collectionname = collection_dropdown.Text.ToLower().Replace("collection", "");
        var flds = GetContentModel.SchemaDataDev.Where(x => x.ContentModel.ToLower().Contains(collectionname)).Select(x => x.Fields).FirstOrDefault();

        if (flds != null)
        {
            foreach (string field in flds)
                comboBox1.Items.Add(field);
        }

        //Get data from GraphQL.



        await GetContentfulDataAsync();

        ProgressBar.Hide();
    }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Environment selection / change  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private async void ComboBox2_SelectedIndexChangedAsync(object sender, EventArgs e)
    {

        if (env_dropdown.Text.Length > 0)
            collection_dropdown.Enabled = true;

        if (collection_dropdown.Text.Length > 0)
        {
            await GetContentfulDataAsync();
        }
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Get conentful data using graphql   ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public async Task GetContentfulDataAsync()
    {

        //Execute qeruy     && update UI

        var graphQLResponse1 = await GetContentUsingGraphQL.ExecuteQueryAsync(env_dropdown.Text, collection_dropdown.Text, TagNames.AwareTags[0], FundNames.AwareSuper.ToString());



        var graphQLResponse2 = await GetContentUsingGraphQL.ExecuteQueryAsync(env_dropdown.Text, collection_dropdown.Text, TagNames.CbusTags[0], FundNames.CBUS.ToString());

        if (graphQLResponse2.Status == 1)
        {
            var noOfFields = graphQLResponse1.ViewModelData.Select(x => x.FieldName).Distinct().ToList();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            foreach (string fldName in noOfFields)
            {
                var obj = new GraphQL.Client.Http.ContentDisplayModelItem
                {
                    FundName = "CBU",
                    Environment = "UAT",
                    FieldName = fldName,
                    FieldValue = ""
                };
                graphQLResponse1.ViewModelData.Add(obj);
            }
        }
        var graphQLResponse3 = await GetContentUsingGraphQL.ExecuteQueryAsync(env_dropdown.Text, collection_dropdown.Text, TagNames.GpmTags[0], FundNames.GPM.ToString());

        graphQLResponse1.ViewModelData.AddRange(graphQLResponse2.ViewModelData);
        graphQLResponse1.ViewModelData.AddRange(graphQLResponse3.ViewModelData);


        //Update UI with received data from above requests

        UpdateUI(graphQLResponse1);
    }

    //v~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Display content in grid with data and differnce & Errors in Text area ~~~~~~~~~~~~~~~~~

    private void UpdateUI(ContentViewModel graphQLResponse)
    {
        //Update exception data to UI

        if (graphQLResponse.Status == 1)
        {

            try
            {
                string ErrorText = "Error:";
                ErrorText += graphQLResponse.Error;
                ErrorText += "\n";
                richTextBox1.Text = ErrorText;
                var parsedJson = JToken.Parse(graphQLResponse.Error);
                var beautified = parsedJson.ToString(Formatting.Indented);
                var minified = parsedJson.ToString(Formatting.Indented);
                richTextBox1.Text = graphQLResponse.Environment + "\n" + minified;
                //BuildComparisionData.CompareUatAndDevNoFeilds("Aware");

                //richTextBox1.Text = BuildMasterData.data.summary + "\n\r" + richTextBox1.Text;
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToLower();

            }

        }
        //Update grid with data

        var fields = graphQLResponse.ViewModelData.Select(x => x.FieldName).Distinct();

        foreach (var field in fields)
        {
            string? fieldname = field;
#pragma warning disable CS8629 // Nullable value type may be null.
            var content = graphQLResponse.ViewModelData.Where(x => (bool)(x.FieldName?.Equals(field))).Select(x => x).ToList();
            AddDatatoGrid(content, EnvironmentEnum.Development.ToString());
            AddDatatoGrid(content, EnvironmentEnum.UAT.ToString());
        }
    }
    //Add data to grid ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void AddDatatoGrid(List<ContentDisplayModelItem> content, string environment)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        if (content != null)
        {
            string fieldName = content.Select(x => x.FieldName).FirstOrDefault();

            string? cbusValue = "", aware_dev = "", gpmValue = "";
            cbusValue = content?.Where(x => x.FundName.Equals(FundNames.CBUS.ToString()) && x.Environment.Equals(environment)).Select(x => x.FieldValue).FirstOrDefault();
            aware_dev = content?.Where(x => x.FundName.Equals(FundNames.AwareSuper.ToString()) && x.Environment.Equals(environment)).Select(x => x.FieldValue).FirstOrDefault();
            gpmValue = content?.Where(x => x.FundName.Equals(FundNames.GPM.ToString()) && x.Environment.Equals(environment)).Select(x => x.FieldValue).FirstOrDefault();

            var rowNumber = dataGridView1.Rows.Add(fieldName, cbusValue, aware_dev, gpmValue, environment);

#pragma warning disable CS8604 // Possible null reference argument.
            UpdateGridCellColor(content, environment, rowNumber);


        }
    }
    //Show grid cells with differnt colors if there is differnce in UAT and Dev ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`
    //Cell color is green if field is missing in UAT &&  cell color is yellow if conent is differnt 

    private void UpdateGridCellColor(List<ContentDisplayModelItem> content, string environment, int rowNumber)
    {
        string? cbusValue = "", aware_dev = "", gpmValue = "";

        cbusValue = content?.Where(x => x.FundName.Equals(FundNames.CBUS.ToString()) && x.Environment.Equals(environment)).Select(x => x.FieldValue).FirstOrDefault();
        aware_dev = content?.Where(x => x.FundName.Equals(FundNames.AwareSuper.ToString()) && x.Environment.Equals(environment)).Select(x => x.FieldValue).FirstOrDefault();

        gpmValue = content?.Where(x => x.FundName.Equals(FundNames.GPM.ToString()) && x.Environment.Equals(environment)).Select(x => x.FieldValue).FirstOrDefault();

        if (environment.Equals(EnvironmentEnum.UAT.ToString()) && FundSelectionDropDown.Text.Equals(FundNames.AwareSuper.ToString()))
        {
            var value = content?.Where(x => x.FundName.Equals(FundNames.AwareSuper.ToString())
                 && x.Environment.Equals(EnvironmentEnum.Development.ToString())).Select(x => x.FieldValue).FirstOrDefault();
            if (value != null && aware_dev != null && !value.Equals(aware_dev))
            {
                dataGridView1.Rows[rowNumber].Cells[2].Style.BackColor = Color.Yellow;
                LogExceptions.LogException(collection_dropdown.Text, content.Select(x => x.FieldName).FirstOrDefault() + " :      Value Differnt in UAT\n\n");

            }
            if (aware_dev == null)
            {
                dataGridView1.Rows[rowNumber].Cells[2].Style.BackColor = Color.LightGreen;
                LogExceptions.LogException(collection_dropdown.Text, content.Select(x => x.FieldName).FirstOrDefault() + " :      Field does not exists in UAT\n\n");
            }
        }
        if (environment.Equals(EnvironmentEnum.UAT.ToString()) && FundSelectionDropDown.Text.Equals(FundNames.GPM.ToString()))
        {
            var value = content?.Where(x => x.FundName.Equals(FundNames.GPM.ToString())
                && x.Environment.Equals(EnvironmentEnum.Development.ToString())).Select(x => x.FieldValue).FirstOrDefault();
            if (value != null && gpmValue != null && !value.Equals(gpmValue))
            {
                dataGridView1.Rows[rowNumber].Cells[3].Style.BackColor = Color.Yellow;
                LogExceptions.LogException(collection_dropdown.Text, content.Select(x => x.FieldName).FirstOrDefault() + " :      Value Differnt in UAT\n\n");

            }
            if (gpmValue == null)
            {
                dataGridView1.Rows[rowNumber].Cells[3].Style.BackColor = Color.LightGreen;
                LogExceptions.LogException(collection_dropdown.Text, content.Select(x => x.FieldName).FirstOrDefault() + " :       Field does not exists in UAT\n\n");

            }
        }
        if (environment.Equals(EnvironmentEnum.UAT.ToString()) && FundSelectionDropDown.Text.Equals(FundNames.CBUS.ToString()))
        {
            var value = content?.Where(x => x.FundName.Equals(FundNames.CBUS.ToString())
                 && x.Environment.Equals(EnvironmentEnum.Development.ToString())).Select(x => x.FieldValue).FirstOrDefault();
            if (value != null && cbusValue != null && !value.Equals(cbusValue))
            {
                dataGridView1.Rows[rowNumber].Cells[1].Style.BackColor = Color.Yellow;
                LogExceptions.LogException(collection_dropdown.Text, content.Select(x => x.FieldName).FirstOrDefault() + " :      Value Differnt in UAT\n\n");

            }
            if (cbusValue == null)
            {
                dataGridView1.Rows[rowNumber].Cells[1].Style.BackColor = Color.LightGreen;
                LogExceptions.LogException(collection_dropdown.Text, content.Select(x => x.FieldName).FirstOrDefault() + " :      Field does not exists in UAT\n\n");

            }
        }

    }
    //-------------------------------------Fund selection / change  ------------------------------------------


    private async void FundSelectionDropDown_SelectedIndexChangedAsync(object sender, EventArgs e)
    {
#pragma warning disable IDE0058 // Expression value is never used
        if (FundSelectionDropDown.SelectedIndex == 0)
            return;
        await RefreshAsync();

    }
    private async Task<bool> RefreshAsync()
    {
        ProgressBar.Show();
        dataGridView1.Rows.Clear();
        if (env_dropdown.Text.Length > 0)
            collection_dropdown.Enabled = true;

        if (collection_dropdown.Text.Length > 0)
        {
            await GetContentfulDataAsync();
        }
        //BuildComparisionData.CompareUatAndDevNoFeilds("Aware");

        // richTextBox1.Text = BuildMasterData.data.summary + "\n\r" + richTextBox1.Text;

        richTextBox1.Text = string.Join("  ", LogExceptions.ExceptionsData.ToArray()) + "\n\r" + richTextBox1.Text;
        ProgressBar.Hide();
        return true;
    }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~SYNC popup  dialog display ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
        var popup = new PopupForm();
        popup.SelectedValues(collection_dropdown.Text);
        DialogResult dialogresult = popup.ShowDialog();
        if (dialogresult == DialogResult.OK)
        {

            Console.WriteLine("You clicked OK");
        }
        else if (dialogresult == DialogResult.Cancel)
        {
            Console.WriteLine("You clicked either Cancel or X button in the top right corner");
        }
        popup.Dispose();
    }

    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var focusedItem = listView1.FocusedItem;
            if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
            {
                menuStrip1.Show();
            }
        }
    }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Reset UI ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void Reset(object sender, EventArgs e)
    {
        listView1.Items.Clear();
        dataGridView1.Rows.Clear();
        richTextBox1.Text = "";
        env_dropdown.Text = "";
        collection_dropdown.Text = "";
        comboBox1.Text = "";
    }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Other fucnitons ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


    private void UpdateUI_Filter(ContentViewModel graphQLResponse)
    {
        foreach (var obj in graphQLResponse.ViewModelData)
        {
            //bool bDiffernt = false;
            string? fundname = obj?.FundName;
            string? fieldname = obj?.FieldName;
            string? fieldvalue = obj?.FieldValue;
            var fieldname_filter = comboBox1.Text;
            if (fieldname_filter.ToLower().Equals(obj?.FieldName?.ToLower()))
            {

                if (fundname != null && !fundname.Equals("Aware") && fieldname != null && fieldvalue != null)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { fieldname, fieldvalue, "" }));
                }
                else if (fundname != null && fieldname != null && fieldvalue != null)
                {
                    var li = new ListViewItem(new string[] { fieldname, "", fieldvalue });
                    listView1.Items.Add(li);
                }
            }
        }
    }


    private async void ComboBox1_SelectedIndexChangedAsync(object sender, EventArgs e)
    {
        //filter data.
#pragma warning disable CS8604 // Possible null reference argument.
        var respone = await GetContentModel.GetContentsAsync(collection_dropdown?.Text, env_dropdown.Text);
#pragma warning restore CS8604 // Possible null reference argument.
        listView1.Items.Clear();
        var graphQLResponse = await GetContentUsingGraphQL.ExecuteQueryAsync(env_dropdown.Text, collection_dropdown.Text, "cbus", "CBU");
        UpdateUI_Filter(graphQLResponse);

    }


    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        var collectionnames = GetContentModel.SchemaDataDev.Where(x => x.ContentModel.Contains(comboBox2.Text)).Select(x => x.ContentModel).ToList();
        collection_dropdown.Items.Clear();
        if (collectionnames != null)
        {
            foreach (string colelction in collectionnames)
            {
                string value = char.ToLowerInvariant(colelction[0]) + colelction.Substring(1) + "Collection";
                collection_dropdown.Items.Add(value);
            }
        }


    }
    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {
        if (collection_dropdown.Text.Equals(""))
        {
            MessageBox.Show("Select Collection");
            return;
        }
        var value1 = CompareContentModels.GetFieldsInUATAndNotInDev(collection_dropdown.Text);
        var value2 = CompareContentModels.GetFieldsInDevAndNotInUat(collection_dropdown.Text);
        var collectionName = collection_dropdown.Text.Replace("Collection", "").ToLower();
        var noOfFields = GetContentModel.SchemaDataDev.Where(x => x.ContentModel.ToLower().Equals(collectionName)).Select(x => x.Fields).FirstOrDefault();
        if (value1?.Count == 0 && value2?.Count == 0)
            MessageBox.Show("No of Fields in UAT and Dev are same && Total fields are " + noOfFields?.Count);

        if (value1?.Count != 0 || value2?.Count != 0)
            MessageBox.Show("No of Fields in UAT and Dev are not same  && Total fields are " +
                "\n" + "Fields in Dev and not in UAT " + value2 + "\n"
                + "Fields in Uat and not in Dev" + value1);

    }


    private void search_Click(object sender, EventArgs e)
    {
        var bs = new BindingSource
        {
            DataSource = dataGridView1.DataSource,
            Filter = "Aware like '%" + searchText.Text + "%'"
        };
        dataGridView1.DataSource = bs;
    }

    private void button7_Click(object sender, EventArgs e)
    {

    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void label7_Click(object sender, EventArgs e)
    {

    }

    private void btnNotifyTeams_Click(object sender, EventArgs e)
    {

    }
}
