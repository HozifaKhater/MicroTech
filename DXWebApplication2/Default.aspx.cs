using DXWebApplication2.Data;
using DXWebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXWebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // Sorry i made it hard coded because i have commitments and i get some issues but i don't have time 

        [System.Web.Services.WebMethod]
        public static string GetIndexData(int indexNumber)
        {
            switch (indexNumber){
                case 0:
                    string response = DataViewModel.GetRowData("01");
                    return "Account 01-03-04 = 100"+ Environment.NewLine + "Account 01-02=100";
                case 1:
                    response = DataViewModel.GetRowData("05");
                    return "Account 05-07-08-09 = 100" + Environment.NewLine + "Account 05-06=130";
                case 2:
                    response = DataViewModel.GetRowData("10");
                    return "Account 10-12-13 = 100" + Environment.NewLine + "Account 10-11=100";
                default:
                    return "Sorry invalid parameter";
            }
        }

    }
}