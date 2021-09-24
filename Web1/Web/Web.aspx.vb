Imports System.Data.OleDb

Public Class Web
    Inherits System.Web.UI.Page
    Public IDList As List(Of String) = New List(Of String)


    Public nameList As List(Of String) = New List(Of String)
    Public furiganaList As List(Of String) = New List(Of String)
    Public companyLsit As List(Of String) = New List(Of String)
    Public GenderList As List(Of String) = New List(Of String)
    Public addressList As List(Of String) = New List(Of String)

    Public SearchID As String

    Public SearchBtn As String

    Protected Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub
    'Protected Sub BtnKensaku_Click(sender As Object, e As EventArgs) Handles BtnKensaku.Click
    '    Dim resultDt As New DataTable
    '    Dim sql = New System.Text.StringBuilder()



    '    sql.AppendLine("SELECT")
    '    sql.AppendLine(" *")
    '    sql.AppendLine("FROM 名前テーブル")
    '    'sql.AppendLine("WHERE id LIKE CONCAT(@SearchID,'%'")

    '    'Access接続準備
    '    Dim command As New OleDbCommand
    '    Dim da As New OleDbDataAdapter
    '    Dim cnAccess As OleDbConnection = New OleDbConnection
    '    cnAccess.ConnectionString = My.Settings.AccesCon
    '    'command.Parameters.Add(New Parameter("@SearchID"(SearchID)))


    '    'Access接続開始
    '    cnAccess.Open()

    '    Try

    '        command.Connection = cnAccess
    '        command.CommandText = sql.ToString
    '        da.SelectCommand = command

    '        'SQL実行 結果をデータテーブルに格納
    '        da.Fill(resultDt)

    '        'Dim reader As IDataReader = command.ExecuteReader()
    '        Using dr As OleDbDataReader = command.ExecuteReader()
    '            '取得レコード有無
    '            If dr.HasRows = True Then



    '                While dr.Read()
    '                    IDList.Add(String.Format("{0}", dr("id")))
    '                    nameList.Add(String.Format("{0}", dr("顧客名")))
    '                    furiganaList.Add(String.Format("{0}", dr("フリガナ")))
    '                    GenderList.Add(String.Format("{0}", dr("性別")))
    '                    addressList.Add(String.Format("{0}", dr("住所")))


    '                End While
    '            End If
    '        End Using



    '    Catch ex As Exception
    '        Throw
    '    Finally
    '        command.Dispose()
    '        da.Dispose()
    '        cnAccess.Close()
    '    End Try

    '    'データテーブルの結果を表示
    '    For rowindex As Integer = 1 To resultDt.Rows.Count - 1
    '        For colindex As Integer = 1 To resultDt.Columns.Count - 1


    '            TextBox1.Text = resultDt.Rows(rowindex).ItemArray(0)



    '            TextBox2.Text = resultDt.Rows(rowindex).ItemArray(1)

    '            TextBox3.Text = resultDt.Rows(rowindex).ItemArray(2)

    '            TextBox4.Text = resultDt.Rows(rowindex).ItemArray(3)
    '            TextBox5.Text = resultDt.Rows(rowindex).ItemArray(4)
    '            TextBox6.Text = resultDt.Rows(rowindex).ItemArray(5)
    '        Next

    '    Next

    '    'Dim sql3 = New System.Text.StringBuilder()
    '    'Dim list As New List(Of String)

    '    'Dim text As Integer


    '    'sql3.AppendLine("DELETE FROM 名前テーブル )
    '    'sql3.AppendLine(  WHERE ID = ' " & TextBox1.Text & " ' ")



    '    ''Access接続準備
    '    'Dim command As New OleDbCommand
    '    'Dim cnAccess As OleDbConnection = New OleDbConnection
    '    'cnAccess.ConnectionString = My.Settings.AccesCon


    '    ''Access接続開始
    '    'cnAccess.Open()

    '    'Dim tran As OleDbTransaction
    '    'tran = cnAccess.BeginTransaction
    '    'Try

    '    '    command.Connection = cnAccess
    '    '    command.Transaction = tran



    '    '    command.CommandText = sql3.ToString
    '    '    command.ExecuteNonQuery()
    '    '    list.Add(sql3.ToString)

    '    '    tran.Commit()


    '    'Catch ex As Exception
    '    '    tran.Rollback()
    '    '    Throw
    '    'Finally
    '    '    command.Dispose()
    '    '    cnAccess.Close()
    '    'End Try
    'End Sub

    'Protected Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    'End Sub

    'Protected Sub deleteBtn_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click
    '    Dim resultDt As New DataTable
    '    Dim sql = New System.Text.StringBuilder()



    '    sql.AppendLine("SELECT")
    '    sql.AppendLine(" *")
    '    sql.AppendLine("FROM 名前テーブル")
    '    'sql.AppendLine("WHERE id LIKE CONCAT(@SearchID,'%'")

    '    'Access接続準備
    '    Dim command As New OleDbCommand
    '    Dim da As New OleDbDataAdapter
    '    Dim cnAccess As OleDbConnection = New OleDbConnection
    '    cnAccess.ConnectionString = My.Settings.AccesCon
    '    'command.Parameters.Add(New Parameter("@SearchID"(SearchID)))


    '    'Access接続開始
    '    cnAccess.Open()

    '    Try

    '        command.Connection = cnAccess
    '        command.CommandText = sql.ToString
    '        da.SelectCommand = command

    '        'SQL実行 結果をデータテーブルに格納
    '        da.Fill(resultDt)

    '        'Dim reader As IDataReader = command.ExecuteReader()
    '        Using dr As OleDbDataReader = command.ExecuteReader()
    '            '取得レコード有無
    '            If dr.HasRows = True Then



    '                While dr.Read()
    '                    IDList.Add(String.Format("{0}", dr("id")))


    '                    nameList.Add(String.Format("{0}", dr("顧客名")))
    '                    nameList.Clear()

    '                    furiganaList.Add(String.Format("{0}", dr("フリガナ")))
    '                    furiganaList.Clear()

    '                    GenderList.Add(String.Format("{0}", dr("性別")))
    '                    GenderList.Clear()


    '                    addressList.Add(String.Format("{0}", dr("住所")))
    '                    addressList.Clear()



    '                End While
    '            End If
    '        End Using
    '        sql.Clear()


    '    Catch ex As Exception
    '        Throw
    '    Finally
    '        command.Dispose()
    '        da.Dispose()
    '        cnAccess.Close()
    '    End Try

    '    'データテーブルの結果を表示
    '    For rowindex As Integer = 1 To resultDt.Rows.Count - 1
    '        For colindex As Integer = 1 To resultDt.Columns.Count - 1





    '            'TextBox2.Text = resultDt.Rows(rowindex).ItemArray(1)

    '            'TextBox3.Text = resultDt.Rows(rowindex).ItemArray(2)

    '            'TextBox4.Text = resultDt.Rows(rowindex).ItemArray(3)
    '            'TextBox5.Text = resultDt.Rows(rowindex).ItemArray(4)
    '            'TextBox6.Text = resultDt.Rows(rowindex).ItemArray(5)
    '        Next

    '    Next
    'End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    'End Sub

    'Protected Sub BtnKensaku_Click(sender As Object, e As EventArgs) Handles BtnKensaku.Click

    '    Try
    '        Dim tokuisaki As New ClsTokuisaki(TxtTokuisakiCode.Text)
    '        TxtTokuisakiCode.Enabled = False
    '        LblTokuisakiMei.Text = tokuisaki.TokuisakiMei
    '        LblTokuisakiYubinBango.Text = tokuisaki.YubinBango
    '        LblTokuisakiJusho.Text = tokuisaki.TokuisakiJusho
    '        BtnKensaku.Enabled = False
    '        BtnSakujo.Enabled = True
    '        BtnSakujo.Focus()

    '    Catch ex As TokuisakiCodeException
    '        ' 得意先コード例外が発生した時の処理
    '        LblMessage.Text = ex.Message

    '    End Try
    'End Sub
    ''*******************************************************
    '' 得意先削除ボタンクリック処理
    ''*******************************************************
    'Protected Sub BtnSakujo_Click(sender As Object,
    '    ByRefe As EventArgs) Handles BtnSakujo.Click

    '    Try
    '        ' 得意先マスター表から削除
    '        Dim del As New ClsDeleteTokuisaki(TxtTokuisakiCode.Text)
    '        del.DeleteRecord()

    '        ' 正常終了メッセージ
    '        LblMessage.Text = "得意先マスター表から正常にレコード削除"

    '        ' 画面初期設定
    '        ClearForm()

    '    Catch ex As TokuisakiCodeException
    '        ' 得意先コードエラー
    '        LblMessage.Text = "得意先コード入力エラー"
    '        TxtTokuisakiCode.Focus()

    '    Catch ex As DBIOException
    '        ' DBアクセスクラス独自例外発生時
    '        LblMessage.Text = "DBIO例外発生"

    '    Catch ex As Exception
    '        ' その他例外発生時
    '        LblMessage.Text = "例外発生"

    '    End Try

    'End Sub

    ''*******************************************************
    '' クリアボタンクリック処理
    ''*******************************************************
    'Protected Sub BtnClear_Click(sender As Object,
    '    e As EventArgs) Handles BtnClear.Click

    '    ' 画面初期設定
    '    ClearForm()

    'End Sub

    ''*******************************************************
    '' 画面初期設定
    ''*******************************************************
    'Private Sub ClearForm()

    '    TxtTokuisakiCode.Text = Nothing
    '    TxtTokuisakiCode.Enabled = True
    '    TxtTokuisakiCode.Focus()
    '    LblTokuisakiMei.Text = Nothing
    '    LblTokuisakiYubinBango.Text = Nothing
    '    LblTokuisakiJusho.Text = Nothing
    '    LblMessage.Text = Nothing
    '    BtnKensaku.Enabled = True
    '    BtnSakujo.Enabled = False

    'End Sub
End Class