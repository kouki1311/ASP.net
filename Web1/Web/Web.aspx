<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Web.aspx.vb" Inherits="Web.Web" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          






       <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="顧客名" HeaderText="顧客名" SortExpression="顧客名" />
                    <asp:BoundField DataField="フリガナ" HeaderText="フリガナ" SortExpression="フリガナ" />
                    <asp:BoundField DataField="性別" HeaderText="性別" SortExpression="性別" />
                    <asp:BoundField DataField="会社名" HeaderText="会社名" SortExpression="会社名" />
                    <asp:BoundField DataField="住所" HeaderText="住所" SortExpression="住所" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Web.My.MySettings.SqlCon %>" DeleteCommand="DELETE FROM [Table] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Table] ([Id], [顧客名], [フリガナ], [性別], [会社名], [住所]) VALUES (@Id, @顧客名, @フリガナ, @性別, @会社名, @住所)" SelectCommand="SELECT * FROM [Table] WHERE ([Id] = @Id)" UpdateCommand="UPDATE [Table] SET [顧客名] = @顧客名, [フリガナ] = @フリガナ, [性別] = @性別, [会社名] = @会社名, [住所] = @住所 WHERE [Id] = @Id">
                <DeleteParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Id" Type="Int32" />
                    <asp:Parameter Name="顧客名" Type="String" />
                    <asp:Parameter Name="フリガナ" Type="String" />
                    <asp:Parameter Name="性別" Type="String" />
                    <asp:Parameter Name="会社名" Type="String" />
                    <asp:Parameter Name="住所" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="GridView1" Name="Id" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="顧客名" Type="String" />
                    <asp:Parameter Name="フリガナ" Type="String" />
                    <asp:Parameter Name="性別" Type="String" />
                    <asp:Parameter Name="会社名" Type="String" />
                    <asp:Parameter Name="住所" Type="String" />
                    <asp:Parameter Name="Id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <br />
     
            <hr ></hr>
            <a href="WebForm1.aspx">一覧に戻る</a>


            <asp:Button ID="BtnKensaku" runat="server" Text="Button" />

            <br />
            <asp:Button ID="deleteBtn" runat="server" Text="削除" />
            <br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LabelID" runat="server" Text="ID"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="LabelName" runat="server" Text="顧客名"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Label ID="Labelfirigana" runat="server" Text="フリガナ"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Label ID="LabelGen" runat="server" Text="性別"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" Height="19px" style="margin-top: 16px" Width="166px"></asp:TextBox>
            <asp:Label ID="LabelCom" runat="server" Text="会社名"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:Label ID="Labeladdress" runat="server" Text="住所"></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>

         
            <siteMapNode title="Editing, Inserting, and Deleting"
    url="~/EditInsertDelete/Default.aspx"
    description="Samples of Reports that Provide Editing, Inserting,
                  and Deleting Capabilities">
    <siteMapNode url="~/EditInsertDelete/Basics.aspx"
        title="Basics"
        description="Examines the basics of data modification with the
                      GridView, DetailsView, and FormView controls." />
    <siteMapNode url="~/EditInsertDelete/DataModificationEvents.aspx"
        title="Data Modification Events"
        description="Explores the events raised by the ObjectDataSource
                      pertinent to data modification." />
    <siteMapNode url="~/EditInsertDelete/ErrorHandling.aspx"
        title="Error Handling"
        description="Learn how to gracefully handle exceptions raised
                      during the data modification workflow." />
    <siteMapNode url="~/EditInsertDelete/UIValidation.aspx"
        title="Adding Data Entry Validation"
        description="Help prevent data entry errors by providing validation." />
    <siteMapNode url="~/EditInsertDelete/CustomizedUI.aspx"
        title="Customize the User Interface"
        description="Customize the editing and inserting user interfaces." />
    <siteMapNode url="~/EditInsertDelete/OptimisticConcurrency.aspx"
        title="Optimistic Concurrency"
        description="Learn how to help prevent simultaneous users from
                      overwritting one another s changes." />
    <siteMapNode url="~/EditInsertDelete/ConfirmationOnDelete.aspx"
        title="Confirm On Delete"
        description="Prompt a user for confirmation when deleting a record." />
    <siteMapNode url="~/EditInsertDelete/UserLevelAccess.aspx"
        title="Limit Capabilities Based on User"
        description="Learn how to limit the data modification functionality
                      based on the user role or permissions." />
</siteMapNode>
        </div>
    </form>
</body>
</html>
