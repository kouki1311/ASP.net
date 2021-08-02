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


    #dgvDetail{
               margin:auto;
      
               padding:10px;
       
         }


</style>
    <title></title>
</head>
<body id="FpSpread1">
    <form id="form1" runat="server">
   
        <h1 ID="title" runat="server">顧客管理</h1>



        <asp:Button ID="newAdd" runat="server" Text="新規追加" />
        <asp:Button ID="Update" runat="server" Text="更新" />
        <asp:Button ID="Delete" runat="server" Text="削除" />
     

        <asp:GridView   ID="GridView1" runat="server"   Width="484px"  AutoGenerateEditButton="true" >
  

        </asp:GridView >
            

              
            検索:<asp:TextBox ID="TxtSeach" runat="server" asp-for="SearchString" ></asp:TextBox>
        <asp:Button ID="Seach" type="submit" runat="server" Text="検索" />
   
                    
        <trace
            enabled="true"
            requestLimit="10"
            pageOutput="false"
            traceMode="SortByTime"
            localOnly="true"

        />



<%--        <asp:Button ID="Button1" runat="server" Text="Button" />
     
        
     
        <asp:GridView ID="dgvDetail" runat="server"  AllowPaging="false" AutoGenerateColumns="false" ShowHeader="true" Visible="true" ShowFooter="false" Width="431px">
          
            
            <Columns>
  
                <asp:TemplateField>
                    <HeaderTemplate>ID</HeaderTemplate>
                    <ItemTemplate>
                       
                        <p><asp:Label ID="lblNengetu" Text='<%# DataBinder.Eval(Container.DataItem, "number")%>' runat="server" /></p>
                    </ItemTemplate>
                </asp:TemplateField>

                   <asp:TemplateField>
                        <HeaderTemplate>顧客名</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:Label ID="lblPerson" Text='<%# DataBinder.Eval(Container.DataItem, "name")%>' runat="server" /></p>
                        </ItemTemplate>
                    </asp:TemplateField>


                 <asp:TemplateField>
                        <HeaderTemplate>フリガナ</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:Label ID="lblfuri" Text='<%# DataBinder.Eval(Container.DataItem, "furigna")%>' runat="server" /></p>
                        </ItemTemplate>
                    </asp:TemplateField>

                   <asp:TemplateField>
                        <HeaderTemplate>性別</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:label ID="lblGender"   Text='<%# DataBinder.Eval(Container.DataItem, "Gender")%>' runat="server" /></p>
                            
                        </ItemTemplate>
                    </asp:TemplateField>


                      <asp:TemplateField>
                        <HeaderTemplate>会社名</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:Label ID="lblcom" Text='<%# DataBinder.Eval(Container.DataItem, "com")%>' runat="server" /></p>
                        </ItemTemplate>
                    </asp:TemplateField>



                 <asp:TemplateField>
                        <HeaderTemplate>住所</HeaderTemplate>
                        <ItemTemplate>
                            <p><asp:Label ID="lbladdress" Text='<%# DataBinder.Eval(Container.DataItem, "address")%>' runat="server" Visible="True" /></p>
                        </ItemTemplate>
                    </asp:TemplateField>

            </Columns>
                </asp:GridView>--%>


     
<%--グリッド表のスタイルを定義、また、データソースとの関連付けを行う--%><%--データベース・ファイルのパスやSELECT命令を定義--%>
  


         

        <p>
            &nbsp;</p>
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
     
        <p>
            &nbsp;</p>
     
    </form>
</body>
</html>
