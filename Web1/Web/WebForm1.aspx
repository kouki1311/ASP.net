

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="Web.WebForm1" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<style>


    #title{
        margin:auto;
      

        font-size:30px;
     

        width:20%;
      
      


        
    }
    body{
        background-color:#EEFFFF;
        
    }

    #GridView2{
               margin:auto auto 0px auto;
      
               padding:10px;
       
         }

</style>
  
 


         
    <title></title>
</head>
<body id="FpSpread1">
    <form id="form1" runat="server">
   
        <h1 ID="title" runat="server">
            <asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Id" DataValueField="Id">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            顧客管理</h1>

      
        
   　　　

    <div>
     
      <a href="javascript:void(0);" onclick="LinkClick()">リンク</a>
    </div>
    
        <asp:Button ID="newAdd" runat="server" Text="新規追加" />
     
            検索:<asp:TextBox ID="TxtSeach" runat="server" asp-for="SearchString" ></asp:TextBox>
        <asp:Button ID="Seach" type="submit" runat="server" Text="検索" Height="27px" />
   

        <asp:Label ID="namexdata" runat="server" Text="Label"></asp:Label>
<asp:TextBox ID="namex" runat="server"></asp:TextBox>
<asp:Button ID="Button5" runat="server" Text="Button" />
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
       
         <identity impersonate="false" />
      
    
          <input type="submit" formaction="/Home/Search" name="Search" value="検索">
    <input type="submit" formaction="/Home/Clear" name="Clear" value="クリア">
    
     <p action="web.aspx"method="post"id="post" name="form1">
         
         <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="ID" DataValueField="ID">
             <asp:ListItem Selected="True"></asp:ListItem>
         </asp:DropDownList>
         <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource3">
             <asp:ListItem>ID</asp:ListItem>
             <asp:ListItem>顧客名</asp:ListItem>
             <asp:ListItem>フリガナ</asp:ListItem>
             <asp:ListItem>性別</asp:ListItem>
             <asp:ListItem>会社名</asp:ListItem>
             <asp:ListItem>住所</asp:ListItem>
         </asp:DropDownList>
        </p>
  
    
              <p>
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
        </p>
     
        <asp:GridView   ID="GridView1" runat="server"   Width="1290px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" Height="358px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            
            <Columns>

                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                  
                <asp:BoundField DataField="顧客名" HeaderText="顧客名" SortExpression="顧客名" />
                <asp:BoundField DataField="フリガナ" HeaderText="フリガナ" SortExpression="フリガナ" />
                <asp:BoundField DataField="性別" HeaderText="性別" SortExpression="性別" />
                <asp:BoundField DataField="会社名" HeaderText="会社名" SortExpression="会社名" />
                <asp:BoundField DataField="住所" HeaderText="住所" SortExpression="住所" />
            </Columns>
  
          
            <FooterStyle BackColor="#EEFFFF	" ForeColor="Black" />
            <HeaderStyle BackColor="#EEFFFF	" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#EEFFFF	" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
  
          
        </asp:GridView >
   

              
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
   

              
            <FooterStyle BackColor="#EEFFFF	" ForeColor="Black" />
            <HeaderStyle BackColor="#EEFFFF	" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#EEFFFF	" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
   

              
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Web.My.MySettings.SqlCon %>" SelectCommand="SELECT * FROM [Table] WHERE ([Id] = @Id)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" Name="Id" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
        </asp:SqlDataSource>
   

              
            
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" datasourceid="SqlDataSource3" ForeColor="#333333" GridLines="None" Height="358px" Width="1290px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="顧客名" HeaderText="顧客名" SortExpression="顧客名" />
                <asp:BoundField DataField="フリガナ" HeaderText="フリガナ" SortExpression="フリガナ" />
                <asp:BoundField DataField="性別" HeaderText="性別" SortExpression="性別" />
                <asp:BoundField DataField="会社名" HeaderText="会社名" SortExpression="会社名" />
                <asp:BoundField DataField="住所" HeaderText="住所" SortExpression="住所" />
            </Columns>
      
            <FooterStyle BackColor="#EEFFFF	" ForeColor="Black" />
            <HeaderStyle BackColor="#EEFFFF	" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#EEFFFF	" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Web.My.MySettings.AccesCon %>" ProviderName="<%$ ConnectionStrings:Web.My.MySettings.AccesCon.ProviderName %>" SelectCommand="SELECT * FROM [名前テーブル]">
        </asp:SqlDataSource>
   

              
            
        <asp:Button ID="Button1" runat="server" Text="Button" />

   

   
        <trace
            enabled="true"
            requestLimit="10"
            pageOutput="false"
            traceMode="SortByTime"
            localOnly="true"

        />


      
  

    </form>
</body>
</html>
