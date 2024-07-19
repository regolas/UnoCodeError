//using Microsoft.UI.Xaml.Controls;
//using Microsoft.UI.Xaml;

namespace tUNO;

public sealed partial class MainPage : Page
{
    int iPC;
    int iNS;
    int iSS;
    int iBS;
    int iMP;
    double iP;
    double iSV;
    bool tbl1;

    public MainPage()
    {
        this.InitializeComponent();
    }
    private async void OnHZClicked(object sender, EventArgs e)
    {
        string invalidFields = "";
        tbl1 = false;

        if (!int.TryParse(PC.Text, out iPC))
        {
            invalidFields += "PC, ";
        }
        if (!int.TryParse(NS.Text, out iNS))
        {
            invalidFields += "NS, ";
        }
        if (!int.TryParse(SS.Text, out iSS))
        {
            invalidFields += "SS, ";
        }
        if (!int.TryParse(BS.Text, out iBS))
        {
            invalidFields += "BS, ";
        }
        if (!int.TryParse(MP.Text, out iMP))
        {
            invalidFields += "MP, ";
        }
        
        if(invalidFields.Length > 0)
        {
            invalidFields = invalidFields.Substring(0, invalidFields.Length - 2);
            await ShowMessageDialog("Error", $"{invalidFields} require a valid entry", "OK");
        }
        else
        {
            string outText = "Figure 1";

            await ShowMessageDialog("HZA", outText, "OK");
            tbl1 = true;
        }
    }
    private async void OnMOClicked(object sender, EventArgs e)
    {
        if (!tbl1)
        {
            await ShowMessageDialog("Error", "Click HZ button first", "OK");
        }
        else
        {
            string invalidFields = "";

            if (!int.TryParse(PC.Text, out iPC))
            {
                invalidFields += "PC, ";
            }
            if (!int.TryParse(NS.Text, out iNS))
            {
                invalidFields += "NS, ";
            }
            if (!int.TryParse(SS.Text, out iSS))
            {
                invalidFields += "SS, ";
            }
            if (!int.TryParse(BS.Text, out iBS))
            {
                invalidFields += "BS, ";
            }
            if (!int.TryParse(MP.Text, out iMP))
            {
                invalidFields += "MP, ";
            }
            bool iTP1 = double.TryParse(P.Text, out iP);
            bool iTP2 = double.TryParse(SV.Text, out iSV);

            if ((!iTP1 && !iTP2))
            {
                invalidFields += "Enter P OR SV, ";
            }

            if (invalidFields.Length > 0)
            {
                invalidFields = invalidFields.Substring(0, invalidFields.Length - 2);
                await ShowMessageDialog("Error", $"{invalidFields} require a valid entry", "OK");
            }
            else
            {
                string outText = "Figure 2";

                await ShowMessageDialog("MOA", outText, "OK");
            }
        }
    }
    private async Task ShowMessageDialog(string title, string content, string btnTxt)
    {
        ContentDialog dialog = new ContentDialog
        {
            Title = title,
            Content = content,
            CloseButtonText = btnTxt
        };

        await dialog.ShowAsync();
    }
}
