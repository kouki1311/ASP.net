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
        Dim resultDt As New DataTable
        Dim sql = New System.Text.StringBuilder()



        sql.AppendLine("SELECT")
        sql.AppendLine(" *")
        sql.AppendLine("FROM 名前テーブル")
        'Access接続準備
        Dim command As New OleDbCommand
        Dim da As New OleDbDataAdapter
        Dim cnAccess As OleDbConnection = New OleDbConnection
        cnAccess.ConnectionString = My.Settings.AccesCon


        'Access接続開始
        cnAccess.Open()

        Try

            command.Connection = cnAccess
            command.CommandText = sql.ToString
            da.SelectCommand = command

            'SQL実行 結果をデータテーブルに格納
            da.Fill(resultDt)





        Catch ex As Exception
            Throw
        Finally
            command.Dispose()
            da.Dispose()
            cnAccess.Close()
        End Try

        'データテーブルの結果を表示
        For rowindex As Integer = 1 To resultDt.Rows.Count - 1
            For colindex As Integer = 1 To resultDt.Columns.Count - 1






                'GridView1.DataSource = resultDt


                'GridView1.DataBind()
            Next

        Next
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



    '検索ボタン
    Protected Sub Seach_Click(sender As Object, e As EventArgs) Handles Seach.Click





        Dim resultDt As New DataTable
        Dim sql = New System.Text.StringBuilder()



        sql.AppendLine("SELECT")
        sql.AppendLine(" *")
        sql.AppendLine("FROM 名前テーブル")
        'sql.AppendLine("WHERE id=" + TextBox1.Text + "")
        'Access接続準備
        Dim command As New OleDbCommand
        Dim da As New OleDbDataAdapter
        Dim cnAccess As OleDbConnection = New OleDbConnection
        cnAccess.ConnectionString = My.Settings.AccesCon


        'Access接続開始
        cnAccess.Open()

        Try

            command.Connection = cnAccess
            command.CommandText = sql.ToString
            da.SelectCommand = command

            'SQL実行 結果をデータテーブルに格納
            da.Fill(resultDt)

            Dim reader As OleDbDataReader = command.ExecuteReader()



            If reader.Read() Then



                TextBox1.Text = reader("id").ToString

                TextBox2.Text = reader("顧客名").ToString
                TextBox3.Text = reader("フリガナ").ToString
                TextBox4.Text = reader("性別").ToString
                TextBox5.Text = reader("会社名").ToString
                TextBox6.Text = reader("住所").ToString



            End If





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


    ''更新ボタン
    'Protected Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
    '    'SQL作成
    '    Dim sql = New System.Text.StringBuilder()


    '    sql.AppendLine("UPDATE 名前テーブル")
    '    sql.AppendLine("SET 顧客名='TextBox.text' ")

    '    sql.AppendLine("WHERE 顧客名='15'")
    '    'sql.AppendLine("SET")






    '    'Access接続準備
    '    Dim command As New OleDbCommand
    '    Dim cnAccess As OleDbConnection = New OleDbConnection
    '    cnAccess.ConnectionString = My.Settings.AccesCon


    '    'Access接続開始
    '    cnAccess.Open()

    '    Dim tran As OleDbTransaction
    '    tran = cnAccess.BeginTransaction

    '    Try

    '        command.Connection = cnAccess
    '        command.Transaction = tran

    '        command.CommandText = sql.ToString
    '        command.ExecuteNonQuery()


    '        tran.Commit()

    '    Catch ex As Exception
    '        tran.Rollback()
    '        Throw
    '    Finally
    '        command.Dispose()
    '        cnAccess.Close()
    '    End Try






    'End Sub



    ''削除ボタン

    'Protected Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click
    '    Dim DoCmd As New OleDbConnection


    '    Dim sql3 = New System.Text.StringBuilder()
    '    Dim list As New List(Of String)

    '    Dim text As Integer



    '    sql3.AppendLine("DELETE FROM  名前テーブル")
    '    '   sql3.AppendLine("WHERE ID  = '" & TextBox1.Text & "@ID ")
    '    sql3.AppendLine("ORDER BY id")
    '    'sql3.AppendLine("WHERE id LIKE CONCAT(@SearchID,'%'" & TextBox1.Text)




    '    'Access接続準備
    '    Dim command As New OleDbCommand
    '    Dim cnAccess As OleDbConnection = New OleDbConnection
    '    cnAccess.ConnectionString = My.Settings.AccesCon


    '    'Access接続開始
    '    cnAccess.Open()

    '    Dim tran As OleDbTransaction
    '    tran = cnAccess.BeginTransaction
    '    Try

    '        command.Connection = cnAccess
    '        command.Transaction = tran




    '        command.CommandText = sql3.ToString
    '        command.ExecuteNonQuery()


    '        command.Parameters.Add(New Parameter(SearchID))


    '        'Dim idx As Integer = Me.GridView1.Rows.Count - 1

    '        'For Each row As GridView In GridView1.SelectedRow


    '        '    Me.GridView1.Rows.IsReadOnly(row)
    '        'Next
    '        'Me.GridView1.EnablePersistedSelection()
    '        MsgBox(command.Parameters.Add(New Parameter(SearchID)))

    '        If TextBox1.ToString < getEncloseTxt(sql3.ToString) Then





    '            MessageBox.Show(1)


    '        End If
    '        tran.Commit()



    '        MsgBox(Delete.Text)

    '    Catch ex As Exception
    '        tran.Rollback()
    '        'Throw
    '    Finally
    '        command.Dispose()
    '        cnAccess.Close()
    '    End Try

    'End Sub




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

    'Protected Sub menu_MenuItemClick(sender As Object, e As MenuEventArgs) Handles menu.MenuItemClick
    '    Dim setting As ConnectionStringSettings =
    '   ConfigurationManager.ConnectionStrings("Test")
    '    Dim factory As DbProviderFactory =
    '        DbProviderFactories.GetFactory(setting.ProviderName)
    '    Using db As DbConnection = factory.CreateConnection()
    '        db.ConnectionString = setting.ConnectionString


    '        ' パラメータparentをキーにsitemapテーブルを検索
    '        ' （parentで指定されたURLを親に持つコンテンツを抽出）
    '        Dim comm As DbCommand = factory.CreateCommand()
    '        comm.CommandText =
    '          "SELECT * FROM 名前テーブル WHERE ID=@id"
    '        comm.Connection = db
    '        Dim param As DbParameter = factory.CreateParameter()
    '        param.ParameterName = "@id"
    '        param.Value = Parent
    '        comm.Parameters.Add(param)
    '        db.Open()
    '        Dim reader As DbDataReader = comm.ExecuteReader()

    '        ' 取得したコンテンツを新規ノードとしてメニューに追加
    '        ' その際、そのコンテンツが最末端でない（子ノードを持つ）
    '        ' 場合には、CreateItemメソッドを再帰的に呼び出し、
    '        ' 同様にノードの追加を行う
    '        Do While reader.Read()
    '            Dim item As New MenuItem()
    '            item.Name = reader.GetString(0)
    '            item.Text = reader.GetString(1)
    '            'Me(reader.GetString(0), item.Text)
    '            'Items.Add(item)
    '        Loop
    '    End Using
    'End Sub
End Class