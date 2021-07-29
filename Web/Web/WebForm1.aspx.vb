Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Cake.Core.IO
Imports Microsoft.Office.Interop
Imports Microsoft.VisualBasic.FileIO

Public Class WebForm1
    Inherits System.Web.UI.Page

    Public rtnNo As Long
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




                GridView1.DataSource = resultDt


                GridView1.DataBind()
            Next

        Next
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Initilize()

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



        'sql2.AppendLine("6")

        'sql2.AppendLine(",'田中'")
        'sql2.AppendLine(",'シゲタコウキ'")
        'sql2.AppendLine(",170")
        'sql2.AppendLine(",170")

        'sql2.AppendLine(",170")
        'sql2.AppendLine(")")



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
    Public Sub Task()





    End Sub

    '検索ボタン
    Protected Sub Seach_Click(sender As Object, e As EventArgs) Handles Seach.Click


        'SQL作成
        Dim resultDt As New DataTable
        Dim sql = New System.Text.StringBuilder()
        sql.AppendLine("SELECT")
        sql.AppendLine("  *")
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

            TxtSeach.Text = Seach.Text

            TxtSeach.Text = TextBox1.Text


   



        Catch ex As Exception
            Throw
        Finally
            command.Dispose()
            da.Dispose()
            cnAccess.Close()
        End Try

        'データテーブルの結果を表示
        For rowindex As Integer = 0 To resultDt.Rows.Count - 1
            For colindex As Integer = 0 To resultDt.Columns.Count - 1

                GridView1.DataSource = resultDt




                GridView1.DataBind()
            Next
            Console.WriteLine()
        Next


    End Sub
    '更新ボタン
    Protected Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
        'SQL作成
        Dim sql = New System.Text.StringBuilder()
        sql.AppendLine("UPDATE 名前テーブル")
        sql.AppendLine("SET 動物 = 'ANIMAL'")
        sql.AppendLine("WHERE 名前 = '伊藤'")

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

            command.CommandText = sql.ToString
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
    '削除ボタン
    Protected Sub Delete_Click(sender As Object, e As EventArgs) Handles Delete.Click




        Dim sql3 = New System.Text.StringBuilder()
        sql3.AppendLine("DELETE FROM 名前テーブル")

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



            command.CommandText = sql3.ToString
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

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class