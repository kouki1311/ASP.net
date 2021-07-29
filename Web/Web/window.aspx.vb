Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Cake.Core.IO
Imports Microsoft.Office.Interop
Imports Microsoft.VisualBasic.FileIO

Public Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt1 As DataTable
        Dim dr As DataRow
        Dim i As Integer

        'データテーブル
        dt1 = New DataTable()
        dt1.Columns.Add(New DataColumn("項目1", GetType(String)))
        dt1.Columns.Add(New DataColumn("項目2", GetType(String)))
        dt1.Columns.Add(New DataColumn("項目3", GetType(String)))

        'Microsoft.VisualBasic.FileIO.TextFieldParser
        Using textParser As New TextFieldParser("C:\Users\koshi\Desktop\Web\Web\Web\App_Data\Book1.xlsx", System.Text.Encoding.GetEncoding("UTF-8"))

            'CSVファイル
            textParser.TextFieldType = FieldType.Delimited

            '区切り文字
            textParser.SetDelimiters(",")

            'ファイルの終端までループ
            While Not textParser.EndOfData
                '1行読み込み
                Dim row As String() = textParser.ReadFields()

                'DataRow作成
                i = 0
                dr = dt1.NewRow()
                For Each col As String In row
                    'dr(i) = col
                    i += 1
                Next

                'DataTableに追加
                dt1.Rows.Add(dr)
            End While
        End Using

        'GridViewに設定
        Me.GridView1.DataSource = dt1
        Me.GridView1.DataBind()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class