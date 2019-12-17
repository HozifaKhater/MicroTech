<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DXWebApplication2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MicroTech Task</title>
    <script type="text/javascript">
        function showIndexData(indexNumber) {
            PageMethods.GetIndexData(indexNumber, OnSuccess);
        }
        function OnSuccess(response, userContext, methodName) {
            alert(response);
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
         <br />  
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"  EnableTheming="True" Theme="Aqua" DataSourceID="ObjectDataSource1">
                <ClientSideEvents RowDblClick="function(s, e) {
var indexNumber = e.visibleIndex;
showIndexData(indexNumber );
}
" />
                <SettingsEditing Mode="Inline">
                </SettingsEditing>
                <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
<SettingsPopup>
<HeaderFilter MinHeight="140px"></HeaderFilter>
</SettingsPopup>

                <Columns>
                    <dx:GridViewDataTextColumn FieldName="Acc_Number" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Balance" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="DXWebApplication2.Data.Account" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="Select" TypeName="DXWebApplication2.AccountDataSource" UpdateMethod="Update"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
