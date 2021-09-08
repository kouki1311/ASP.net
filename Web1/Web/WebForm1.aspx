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

    #GridView1{
               margin:auto;
      
               padding:10px;
       
         }

   
</style>
   
     


         
    <title></title>
</head>
<body id="FpSpread1">
    <form id="form1" runat="server">
   
        <h1 ID="title" runat="server">顧客管理</h1>

      
        
   　　　

    <div>
     
      <a href="javascript:void(0);" onclick="LinkClick()">リンク</a>
    </div>
    
        <asp:Button ID="newAdd" runat="server" Text="新規追加" />
     
            検索:<asp:TextBox ID="TxtSeach" runat="server" asp-for="SearchString" ></asp:TextBox>
        <asp:Button ID="Seach" type="submit" runat="server" Text="検索" Height="27px" />
   
   


</asp:Menu>

     <p action="web.aspx"method="post"id="post" name="form1">
         
         &nbsp;</p>

        <div>

       <%-- <%

            Dim AdoCon
            AdoCon.open("Driver={Microsoft Access Driver (.accdb)};
　　　　　　　　　　　　　　　　　　　Dbq=C:\Users\koshi\Documents\Web_ASP\Web1\Web\App_Data\Test.accdb")

            Dim SqlStr = "SELECT id From Table WHERE id="
            SqlStr = SqlStr & Request.Form("ItemNum")
            Dim rs = AdoCon.execute(SqlStr)
            Dim itemid = rs.Fields("ID")




            %>

        ID：<%= ItemId %><BR>
        <%
            rs = Nothing
            Dim aocon = Nothing
            %>--%>
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
     
        <asp:GridView   ID="GridView1" runat="server"   Width="1290px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2" Height="358px" CellPadding="4" ForeColor="#333333" GridLines="None">
            
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
  
          
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
  
          
        </asp:GridView >
   

              
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" DeleteCommand="DELETE FROM [名前テーブル] WHERE [ID] = ?" InsertCommand="INSERT INTO [名前テーブル] ([ID], [顧客名], [フリガナ], [性別], [会社名], [住所]) VALUES (?, ?, ?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM [名前テーブル]" UpdateCommand="UPDATE [名前テーブル] SET [顧客名] = ?, [フリガナ] = ?, [性別] = ?, [会社名] = ?, [住所] = ? WHERE [ID] = ?">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    
                    <asp:Parameter Name="ID" Type="Int32" />

                        
                    <asp:Parameter Name="顧客名" Type="String" />
                    <asp:Parameter Name="フリガナ" Type="String" />
                    <asp:Parameter Name="性別" Type="String" />
                    <asp:Parameter Name="会社名" Type="String" />
                    <asp:Parameter Name="住所" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="顧客名" Type="String" />
                    <asp:Parameter Name="フリガナ" Type="String" />
                    <asp:Parameter Name="性別" Type="String" />
                    <asp:Parameter Name="会社名" Type="String" />
                    <asp:Parameter Name="住所" Type="String" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
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
