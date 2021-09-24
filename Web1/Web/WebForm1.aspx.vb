Imports System.Data.Common
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Cake.Core.IO
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.Office.Interop
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.AspNetCore.Mvc.Rendering

Imports System.Collections.Generic
Imports System.Data

Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Web.Mvc
Imports Microsoft.AspNetCore.Routing

<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ScriptService()>
Public Class WebForm1
    Inherits System.Web.UI.Page

    Public rtnNo As Long

    Public IDList As List(Of String) = New List(Of String)


    Public nameList As List(Of String) = New List(Of String)
    Public furiganaList As List(Of String) = New List(Of String)
    Public companyLsit As List(Of String) = New List(Of String)
    Public GenderList As List(Of String) = New List(Of String)
    Public addressList As List(Of String) = New List(Of String)

    Public SearchID As String

    Public SearchBtn As String

    'Private ReadOnly _context As RazorPagesMovie.Models.RazorPagesMovieContext

    'Public Sub indexModel(ByVal context As RazorPagesMovie.Models.RazorPagesMovieContext)
    '    _context = context

    'End Sub





    '初期化
    Public Sub Initilize()

        '登録した行番号を取得
        Dim maxRowNum As Integer
        'maxRowNum = dgvDetail.Rows.Count

        Dim dt As DataTable = New DataTable("Table")

        dt.Columns.Add("number")
        dt.Columns.Add("name")
        dt.Columns.Add("furigna")
        dt.Columns.Add("Gender")
        dt.Columns.Add("com")
        dt.Columns.Add("address")

        ''初期値
        '
        'dt.Rows.Add("1", "重田紘輝", "シゲタコウキ", "男", "フォース株式会社", "東京都神田")
        'dgvDetail.DataSource = dt
        'dgvDetail.DataBind()


        ''Me.dgvDetail.Caption = dt.Rows.Count + 1




    End Sub



    Public Sub test()

        Try
            ' ---<< データグリッドビュー列スタイル設定 >>---
            ' 列を自動生成しない
            GridView1.AutoGenerateColumns = False

            ' 列幅を自動調整する設定
            GridView1.ClientIDMode =
                DataGridViewAutoSizeColumnsMode.AllCells

            ' 列の生成
            Dim textColumn(2) As DataGridViewTextBoxColumn

            ' 【商品コード】列を作成する
            textColumn(0) = New DataGridViewTextBoxColumn()
            ' DataGridViewのヘッダータイトル設定
            textColumn(0).HeaderText = "id"

            ' 【商品名】列を作成する
            textColumn(1) = New DataGridViewTextBoxColumn()
            ' DataGridViewのヘッダータイトル設定
            textColumn(1).HeaderText = "顧客名"

            ' 【販売単価】列を作成する
            textColumn(2) = New DataGridViewTextBoxColumn()
            ' DataGridViewのヘッダータイトル設定
            textColumn(2).HeaderText = "フリガナ"
            ' セルの文字列右詰め設定
            textColumn(2).DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight

            ' 生成列をデータグリッドビューに追加する
            'GridView1.Columns.Add(textColumn)

        Catch ex As Exception
            ' 例外が発生した時の処理
            MessageBox.Show(ex.ToString)

        End Try
        'Dim resultDt As New DataTable
        'Dim sql = New System.Text.StringBuilder()



        'sql.AppendLine("SELECT")
        'sql.AppendLine(" *")
        'sql.AppendLine("FROM 名前テーブル")
        ''Access接続準備
        'Dim command As New OleDbCommand
        'Dim da As New OleDbDataAdapter
        'Dim cnAccess As OleDbConnection = New OleDbConnection
        'cnAccess.ConnectionString = My.Settings.AccesCon


        ''Access接続開始
        'cnAccess.Open()

        'Try

        '    command.Connection = cnAccess
        '    command.CommandText = sql.ToString
        '    da.SelectCommand = command

        '    'SQL実行 結果をデータテーブルに格納
        '    da.Fill(resultDt)





        'Catch ex As Exception
        '    Throw
        'Finally
        '    command.Dispose()
        '    da.Dispose()
        '    cnAccess.Close()
        'End Try

        ''データテーブルの結果を表示
        'For rowindex As Integer = 1 To resultDt.Rows.Count - 1
        '    For colindex As Integer = 1 To resultDt.Columns.Count - 1






        '        'GridView1.DataSource = resultDt


        '        'GridView1.DataBind()
        '    Next

        'Next
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




        test()
    End Sub


    '新規追加
    Protected Sub newAdd_Click(sender As Object, e As EventArgs) Handles newAdd.Click

        Dim resultDt As New DataTable
        Dim sql2 = New System.Text.StringBuilder()
        sql2.AppendLine("INSERT INTO 名前テーブル(")
        sql2.AppendLine("ID")
        sql2.AppendLine(",顧客名")
        sql2.AppendLine(",フリガナ")
        sql2.AppendLine(",性別")
        sql2.AppendLine(",会社名")
        sql2.AppendLine(",住所")

        sql2.AppendLine(")VALUES(")
        sql2.AppendLine("" + TextBox1.Text)
        sql2.AppendLine("," + TextBox2.Text)
        sql2.AppendLine(", " + TextBox3.Text)
        sql2.AppendLine("," + TextBox4.Text)
        sql2.AppendLine(", " + TextBox5.Text)
        sql2.AppendLine("," + TextBox6.Text)
        sql2.AppendLine(")")




        'Access接続準備
        Dim command As New OleDbCommand
        Dim cnAccess As OleDbConnection = New OleDbConnection
        cnAccess.ConnectionString = My.Settings.AccesCon


        'Access接続開始
        cnAccess.Open()

        Dim tran As OleDbTransaction
        tran = cnAccess.BeginTransaction
        Try

            command.Connection = cnAccess
            command.Transaction = tran



            command.CommandText = sql2.ToString
            command.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw

        Finally
            command.Dispose()
            cnAccess.Close()
        End Try

    End Sub






    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label1.Text = namex.Text


    End Sub
    Public ButtonName As String

    '検索ボタン
    Protected Sub Seach_Click(sender As Object, e As EventArgs) Handles Seach.Click
        Dim routeConext As RouteContext
        Dim actionDescripter As ActionDescriptor










        'Try
        '    GridView1.Columns.Clear()

        '    Using con As New OleDbConnection
        '        Using cmd As New OleDbCommand
        '            con.ConnectionString =
        '              "Provider=Microsoft.ACE.OLEDB.12.0" &
        '              "Data Source= |DataDirectory|" &
        '              "\Test.accdb"
        '            cmd.Connection = con

        '            'DB接続
        '            con.Open()
        '            cmd.CommandText = "SELECT ID FROM 名前テーブル OREDER BY ID"
        '            MessageBox.Show(cmd.CommandText)
        '            'レコード読込
        '            Using dr As OleDbDataReader = cmd.ExecuteReader()
        '                'レコード有無レコード
        '                If dr.HasRows = True Then
        '                    'レコードが取得できた時
        '                    While dr.Read()

        '                        If TxtSeach.Text = dr.ToString Then

        '                            MessageBox.Show(1)
        '                            Dim row As New GridView
        '                            'セルのテンプレート
        '                            Dim idx1 As Integer
        '                            idx1 = dr.GetOrdinal("id")
        '                            TextBox1.Text = dr.GetString(idx1)

        '                            Dim idx2 As Integer
        '                            idx2 = dr.GetOrdinal("顧客名")
        '                            TextBox1.Text = dr.GetString(idx2)

        '                        End If
        '                    End While
        '                Else
        '                    MessageBox.Show("レコードがありません")
        '                End If


        '            End Using



        '        End Using
        '    End Using

        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        'End Try

        Dim resultDt As New DataTable
        Dim sql = New System.Text.StringBuilder()



        sql.AppendLine("SELECT")
        sql.AppendLine(" id")
        sql.AppendLine("FROM 名前テーブル")



        'Access接続準備
        Dim command As New OleDbCommand
        Dim da As New OleDbDataAdapter
        Dim cnAccess As OleDbConnection = New OleDbConnection
        cnAccess.ConnectionString = My.Settings.AccesCon


        'Access接続開始
        cnAccess.Open()


        Try

            Dim builder As OleDbConnectionStringBuilder = New OleDbConnectionStringBuilder()





            command.Connection = cnAccess
            command.CommandText = sql.ToString
            da.SelectCommand = command

            'SQL実行 結果をデータテーブルに格納
            da.Fill(resultDt)



            Using dr As OleDbDataReader = command.ExecuteReader()
                If dr.HasRows = True Then
                    While dr.Read()
                        Dim row As New GridView


                        MessageBox.Show(1)



                        MessageBox.Show(TxtSeach.Text)
                        MessageBox.Show(dr.GetOrdinal(sql.AppendLine("id").Length))
                        'セルのテンプレート
                        Dim idx1 As Integer


                        TxtSeach.Text = dr.GetOrdinal(sql.AppendLine("id").Length)



                        row.Rows(1).Cells(0).Text = dr.GetString(idx1)


                        'Dim idx2 As Integer
                        '    idx2 = dr.GetOrdinal("顧客名")
                        '    TextBox1.Text = dr.GetString(idx2)


                    End While
                End If
            End Using






            'If Seach.ToString = reader("id").ToString Then
            '    MessageBox.Show(1)

            'End If

            'If reader.Read() Then






            '    TextBox1.Text = reader("id").ToString

            '    TextBox2.Text = reader("顧客名").ToString
            '    TextBox3.Text = reader("フリガナ").ToString
            '    TextBox4.Text = reader("性別").ToString
            '    TextBox5.Text = reader("会社名").ToString
            '    TextBox6.Text = reader("住所").ToString



            'End If





        Catch ex As Exception

            Throw
        Finally
            command.Dispose()
            da.Dispose()
            cnAccess.Close()
        End Try



        'For i As Integer = 0 To resultDt.Rows.Count - 1
        '    TextBox1.Text = GridView1.Rows(i).Cells(1).Text
        '    TextBox2.Text = GridView1.Rows(i).Cells(2).Text
        '    TextBox3.Text = GridView1.Rows(i).Cells(3).Text
        '    TextBox4.Text = GridView1.Rows(i).Cells(4).Text
        '    TextBox5.Text = GridView1.Rows(i).Cells(5).Text
        '    TextBox6.Text = GridView1.Rows(i).Cells(6).Text


        'Next
        ''データテーブルの結果を表示
        'For rowindex As Integer = 1 To resultDt.Rows.Count - 1
        '    For colindex As Integer = 1 To resultDt.Columns.Count - 1
        '        'Using dr As OleDbDataReader = command.ExecuteReader()
        '        '    '取得レコード有無
        '        '    If dr.HasRows = True Then
        '        '        While dr.Read()
        '        If Seach.Text > command.CommandText Then



        '            MsgBox(1)


        '            'テーブル作成処理
        '            Me.TextBox1.Text = GridView1.Rows(Seach.Text).Cells(1).Text
        '            Me.TextBox2.Text = GridView1.Rows(Seach.Text).Cells(2).Text
        '            Me.TextBox3.Text = GridView1.Rows(rtnNo).Cells(3).Text
        '            Me.TextBox4.Text = GridView1.Rows(rtnNo).Cells(4).Text
        '            Me.TextBox5.Text = GridView1.Rows(rtnNo).Cells(5).Text
        '            Me.TextBox6.Text = GridView1.Rows(rtnNo).Cells(6).Text

        '        End If


        '        'GridView1.DataSource = resultDt


        '        'GridView1.DataBind()
        '    Next

        'Next







    End Sub







    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click








        'Dim conn As SqlConnection = New SqlConnection(SqlDataSource1.ConnectionString)

        ''接続を開く
        'conn.Open()

        'Dim sqlQuery As String = "INSERT INTO Table1 (@id) VALUES (@id)"
        'Dim cmd As SqlCommand = New SqlCommand(sqlQuery, conn)

        'Dim contentparam As SqlParameter = New SqlParameter("@id", TextBox1.Text)

        'cmd.Parameters.Add(contentparam)
        ''コマンドを実行
        'cmd.ExecuteNonQuery()

        ''接続を閉じる
        'conn.Close()

        '接続文字列の取得
        Dim connectionString = ConfigurationManager.ConnectionStrings("Database1").ConnectionString

        Dim id As String
        Dim 顧客名 As String
        Using connection = New SqlConnection(connectionString)
            Using command = connection.CreateCommand()
                Try
                    connection.Open()
                    command.CommandText = "INSERT INTO Table(ID,顧客名)VALUES (@ID,@顧客名)"
                    command.Parameters.Add(New SqlParameter("@ID", id))
                    command.Parameters.Add(New SqlParameter("@顧客名", 顧客名))

                    'SQLの実行
                    command.ExecuteNonQuery()


                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                    Throw
                Finally
                    connection.Close()


                End Try


            End Using

        End Using

        'Dim sqlDataSource1 As SqlDataSource
        'sqlDataSource1 = New SqlDataSource()

        ''接続文字れる 
        'sqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("SqlCon").ConnectionString

        ''insert文
        'sqlDataSource1.InsertCommand = "INSERT INTO Table(ID,顧客名)VALUES(@ID,@顧客名)"

        ''パラメータセット
        'sqlDataSource1.InsertParameters.Clear()
        'sqlDataSource1.InsertParameters.Add("id", "3")
        'sqlDataSource1.InsertParameters.Add("顧客名", "名前10")

        ''insert文実行
        'sqlDataSource1.Insert()







        'Dim resultDt As New DataTable
        'Dim sql2 = New System.Text.StringBuilder()
        'sql2.AppendLine("INSERT INTO Table(")
        'sql2.AppendLine("id")
        'sql2.AppendLine(",顧客名")
        'sql2.AppendLine(",フリガナ")
        'sql2.AppendLine(",性別")
        'sql2.AppendLine(",会社名")
        'sql2.AppendLine(",住所")

        'sql2.AppendLine(")VALUES(")
        'sql2.AppendLine("" + TextBox1.Text)
        'sql2.AppendLine("," + TextBox2.Text)
        'sql2.AppendLine(", " + TextBox3.Text)
        'sql2.AppendLine("," + TextBox4.Text)
        'sql2.AppendLine(", " + TextBox5.Text)
        'sql2.AppendLine("," + TextBox6.Text)
        'sql2.AppendLine(")")




        ''Access接続準備
        'Dim command As New SqlCommand
        'Dim cnAccess As SqlConnection = New SqlConnection

        'cnAccess.ConnectionString = My.Settings.SqlCon



        ''Access接続開始
        'cnAccess.Open()

        'Dim tran As SqlTransaction
        'tran = cnAccess.BeginTransaction

        'Try

        '    command.Connection = cnAccess

        '    command.Transaction = tran




        '    command.CommandText = sql2.ToString

        '    command.ExecuteNonQuery()

        '    tran.Commit()
        'Catch ex As Exception
        '    tran.Rollback()
        '    Throw

        'Finally
        '    command.Dispose()
        '    cnAccess.Close()
        'End Try


    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
    Public Class AutoComplete
        Inherits System.Web.Services.WebService

        <WebMethod()>
        Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()

            Dim list As New List(Of String)

            Dim setting As ConnectionStringSettings =
              ConfigurationManager.ConnectionStrings("AccesCon")
            Dim factory As DbProviderFactory =
              DbProviderFactories.GetFactory(setting.ProviderName)

            Using db As DbConnection = factory.CreateConnection()

                db.ConnectionString = setting.ConnectionString
                Dim comm As DbCommand = factory.CreateCommand()

                ' パラメータprefixTextをキーに、
                ' IndexListテーブルのitemフィールドを前方一致検索
                ' （取得レコード数はパラメータcountで指定された件数で制限）
                comm.CommandText =
                  String.Format("SELECT ID  FROM 名前テーブル WHERE ID LIKE @ID", count)
                comm.Connection = db
                Dim param As DbParameter = factory.CreateParameter()
                param.ParameterName = "@item"
                param.Value = prefixText & "%"
                comm.Parameters.Add(param)
                db.Open()

                ' 取得した結果セットの内容を可変配列listに順番に追加
                Dim reader As DbDataReader = comm.ExecuteReader()
                Do While reader.Read()
                    list.Add(reader.GetString(0))
                Loop
            End Using
            Return list.ToArray()
        End Function
    End Class

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        DropDownList1.SelectedValue = TextBox1.Text

    End Sub
End Class