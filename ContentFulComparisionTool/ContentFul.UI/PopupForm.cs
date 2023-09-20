using ContentFulComparisionTool.Builder;
using ContentFulComparisionTool.ContentFul.Core.Report;
using ContentFulComparisionTool.Models;
using ContentFulComparisionTool.Services.ContentfulServices;

namespace ContentFulComparisionTool;
public partial class PopupForm : Form
{

    public PopupForm()
    {
        InitializeComponent();
        SourceDropDown.Items.Clear();
        DestinationDropDown.Items.Clear();
        ContentModel_dropdown.Items.Clear();

        var ContentModelList = GetContentModel.SchemaDataDev.Select(x => x.ContentModel).ToArray();
        foreach (var model in ContentModelList)
            ContentModel_dropdown.Items.Add(model);

        TaskDropDown.SelectedIndex = 2;

    }
    public void SelectedValues(string colleciton)
    {
        colleciton = colleciton.Replace("Collection", "");
        colleciton = char.ToUpperInvariant(colleciton[0]) + colleciton.Substring(1);
        ContentModel_dropdown.SelectedIndex = ContentModel_dropdown.Items.IndexOf(colleciton);
    }
    private void TaskDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateUIAsync();
    }
    private async void GoButton_ClickAsync(object sender, EventArgs e)
    {
        var selectedModel = await ContentFulAPIServices.GetContentModelByIdAsync("transferTestModel", "DEV");
        string selectedOption = "Merge-Model";

        switch (selectedOption)
        {
            case "Create-Model-Onestep":
                //testing done.
                var res = await ContentFulAPIServices.CreateModelAndContentsOneStepAsync("transferTestModel", selectedModel);
                break;
            case "Create-Model":
            case "Merge-Model":

                var response = await ContentFulAPIServices.CreateOrUpdateContentModelUATAsync(selectedModel, "transferTestModel");
                break;

            case "Create-Content":
                ContentFulAPIServices.createContentUAT(selectedModel, "transferTestModel");
                break;

            case "Merge-Content":
                //Testing done
                var devEntryId = SourceDropDown.Text.Split(" ");
                var uatEntryId = DestinationDropDown.Text.Split(" ");
                if (devEntryId?.Length > 0 && uatEntryId?.Length > 0)
                    res = await ContentFulAPIServices.UpdateContentUATAsync("transferTestModel", devEntryId[0], uatEntryId[0]);
                break;
            case "Delete-Content":
                break;

        }
        if (selectedOption.Equals("Merge-Content") || selectedOption.Equals("Create-Content"))
        {
            var reportData = GenerateReportForContentChanges.GenerateReportHtmlforContentChanges();
            using var fs = new FileStream(Properties.Settings.Default.ReportPath, FileMode.Append);
            using var sw = new StreamWriter(fs);
            sw.WriteLine(reportData.Result);
        }
        if (selectedOption.Equals("Merge-Model") || selectedOption.Equals("Create Content Model"))
        {
            var reportData = GenerateReportForModelChanges.GenerateReportHtmlforModelChanges();
            using var fs = new FileStream(Properties.Settings.Default.ReportPath, FileMode.Append);
            using var sw = new StreamWriter(fs);
            sw.WriteLine(reportData.Result);
        }
    }
    private async void UpdateUIAsync()
    {
        // Validations. make sure sync option selected.
        if (TaskDropDown.Text.Equals(""))
        {
            MessageBox.Show("Selection Content Model Model");
            return;
        }


        SourceDropDown.Items.Clear();
        DestinationDropDown.Items.Clear();

        //  drop down will show id and tags corresponding to each instance.

        var tagsAndIds = await GetContentModel.GetContentsAsync(ContentModel_dropdown.Text, "DEV");

        if (tagsAndIds != null)
        {
            foreach (var tagsandids in tagsAndIds)
            {
                var item = new ComboboxItem();
                if (tagsandids != null)
                {
                    string? comboboxValueText = tagsandids?.Id;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    foreach (var tags in tagsandids?.tags?.Select(x => x.sys.id).ToList())
                    {
                        comboboxValueText += " " + tags;

                    }
                    item.Text = comboboxValueText;
                    item.Value = tagsandids?.Id;
                    SourceDropDown.Items.Add(item.Text);
                }
            }
        }
        tagsAndIds = await GetContentModel.GetContentsAsync(ContentModel_dropdown.Text, "UAT");

        if (tagsAndIds != null)
        {
            foreach (var tagsandids in tagsAndIds)
            {
                var item = new ComboboxItem();
                if (tagsandids != null)
                {
                    string? comboboxValueText = tagsandids?.Id;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    foreach (var tags in tagsandids?.tags?.Select(x => x.sys.id).ToList())
                    {
                        comboboxValueText += " " + tags;

                    }
                    item.Text = comboboxValueText;
                    item.Value = tagsandids?.Id;
                    DestinationDropDown.Items.Add(item.Text);
                }
            }
        }
        if (TaskDropDown.Text.Contains("Merge Model"))
        {
            SourceDropDown.Hide();
            DestinationDropDown.Hide();
            sourcelabel.Hide();
            destinationlabel.Hide();
        }
        if (TaskDropDown.Text.Contains("Create Content"))
        {
            SourceDropDown.Show();
            sourcelabel.Show();
            DestinationDropDown.Hide();
            destinationlabel.Hide();
        }
        if (TaskDropDown.Text.Contains("Merge Content"))
        {
            SourceDropDown.Show();
            sourcelabel.Show();
            DestinationDropDown.Show();
            destinationlabel.Show();
        }
        if (TaskDropDown.Text.Contains("Delete ContentT"))
        {
            SourceDropDown.Hide();
            DestinationDropDown.Hide();
            sourcelabel.Hide();
            destinationlabel.Hide();
        }
    }

    private void ContentModel_dropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateUIAsync();
    }
}

