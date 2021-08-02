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
            Public Sub Task()





            End Sub

            '検索ボタン
            Protected Sub Seach_Click(sender As Object, e As EventArgs) Handles Seach.Click
                Dim resultDt As New DataTable


                Dim sql = New System.Text.StringBuilder()



                sql.AppendLine("SELECT")
                sql.AppendLine("*")
                sql.AppendLine("FROM 名前テーブル")


        'Access接続準備
        Dim command As New OleDbCommand
                Dim da As New OleDbDataAdapter
                Dim cnAccess As OleDbConnection = New OleDbConnection
                Dim returnValue As Object
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


                'For i As Integer = 1 To resultDt.Rows.Count - 1
                '    For j As Integer = 1 To resultDt.Columns("ID").MaxLength



                'テーブル作成処理
                Me.TextBox2.Text = GridView1.Rows(rtnNo).Cells(2).ToString
                Me.TextBox3.Text = GridView1.Rows(rtnNo).Cells(3).ToString
                Me.TextBox4.Text = GridView1.Rows(rtnNo).Cells(4).ToString
                Me.TextBox5.Text = GridView1.Rows(rtnNo).Cells(5).ToString
                Me.TextBox6.Text = GridView1.Rows(rtnNo).Cells(6).ToString

                Me.TextBox1.Text = GridView1.Rows(rowindex).Cells(rowindex).Text.Count + 1






                GridView1.DataSource = resultDt

                GridView1.DataBind()



                    Next

                Next


    End Sub


    '更新ボタン
    Protected Sub Update_Click(sender As Object, e As EventArgs) Handles Update.Click
                'SQL作成
                Dim sql = New System.Text.StringBuilder()


        sql.AppendLine("UPDATE 名前テーブル")
        sql.AppendLine("SET 顧客名='TextBox.text' ")

        sql.AppendLine("WHERE 顧客名='15'")
        'sql.AppendLine("SET")






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
                sql3.AppendLine("WHERE  ID=TextBox1.Text" + TextBox1.Text)
                'sql3.AppendLine("SET")




                'sql3.AppendLine("  ID = '" & TextBox1.Text & "'")
                'sql3.AppendLine(" 　顧客名 = '" & TextBox2.Text & "'")
                'sql3.AppendLine("  フリガナ = '" & TextBox3.Text & "'")
                'sql3.AppendLine("  性別 = '" & TextBox4.Text & "'")
                'sql3.AppendLine("  会社名 = '" & TextBox5.Text & "'")
                'sql3.AppendLine("  住所 = '" & TextBox6.Text & "'")

                'sql3.AppendLine("WHERE")


                'sql3.AppendLine("  ID = '" & TextBox1.Text & "'")
                'sql3.AppendLine(" 　顧客名 = '" & TextBox2.Text & "'")
                'sql3.AppendLine("  フリガナ = '" & TextBox3.Text & "'")
                'sql3.AppendLine("  性別 = '" & TextBox4.Text & "'")
                'sql3.AppendLine("  会社名 = '" & TextBox5.Text & "'")
                'sql3.AppendLine("  住所 = '" & TextBox6.Text & "'")

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


End Class