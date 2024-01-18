Imports MySql.Data.MySqlClient
Public Class Form1
    Dim count As Integer = 0
    Dim am_pm As String
    Dim hh As Integer
    Dim att_count As Integer = 0
    Sub Insert_Attendance()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim query As String
        Dim READER As MySqlDataReader
        conn = New MySqlConnection
        '  If att_count = 0 Then
        query = "Insert into attendance(ID_NUMBER, ATTENDANCE_DATE, IN_AM, COUNT) values ('" & Label2.Text & "','" & DateTimePicker1.Text & "','" & time_stat.Text & "',1)"
        '     ElseIf att_count = 1 Then

        '   End If
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try
            conn.Open()

            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            conn.Close()
            '  MsgBox("ATTENDANCE RECORD IS ADDED...", vbInformation)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Update2()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim query As String
        Dim READER As MySqlDataReader
        conn = New MySqlConnection

        query = "update attendance set OUT_AM='" & time_stat.Text & "', COUNT=2 where ID_NUMBER='" & TextBox2.Text & "' and ATTENDANCE_DATE = '" & DateTimePicker1.Text & "'"
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try
            conn.Open()

            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            conn.Close()

            'MsgBox("ATTENDANCE RECORD IS UPDATED 2...", vbInformation)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Update3()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim query As String
        Dim READER As MySqlDataReader
        conn = New MySqlConnection

        query = "update attendance set IN_PM='" & time_stat.Text & "', COUNT=3 where ID_NUMBER='" & TextBox2.Text & "' and ATTENDANCE_DATE = '" & DateTimePicker1.Text & "'"
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try
            conn.Open()

            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            conn.Close()
            '   MsgBox("ATTENDANCE RECORD IS UPDATED 3...", vbInformation)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Update4()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim query As String
        Dim READER As MySqlDataReader
        conn = New MySqlConnection

        query = "update attendance set OUT_PM='" & time_stat.Text & "', COUNT=4 where ID_NUMBER='" & TextBox2.Text & "' and ATTENDANCE_DATE = '" & DateTimePicker1.Text & "'"
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try
            conn.Open()

            com = New MySqlCommand(query, conn)
            READER = com.ExecuteReader
            conn.Close()
            '  MsgBox("ATTENDANCE RECORD IS UPDATED 4...", vbInformation)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub check_student()
        Dim query1 As String
        Dim count_1 As Integer
        Dim ln As String = ""
        Dim fn As String = ""
        'Dim ID As String = ""
        Dim sec As String = ""
        Dim READER As MySqlDataReader
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try
            count_1 = 0
            conn.Open()
            query1 = "SELECT * from students where ID_NUMBER='" & TextBox2.Text & "'"
            com = New MySqlCommand(query1, conn)
            READER = com.ExecuteReader
            While READER.Read
                count_1 = count_1 + 1
                ln = READER.GetString("LAST_NAME")
                fn = READER.GetString("FIRST_NAME")
                sec = READER.GetString("SECTION")
            End While
            If count_1 >= 1 Then
                Label2.Text = TextBox2.Text
                Label3.Text = fn & " " & ln
                Label4.Text = sec
                Label2.BackColor = Color.Green
                Label3.BackColor = Color.Green
                Label4.BackColor = Color.Green

                check_attendance()
            Else
                Label2.Text = ""
                Label3.Text = ""
                Label4.Text = ""
                Label2.BackColor = Color.Red
                Label3.BackColor = Color.Red
                Label4.BackColor = Color.Red
            End If
            TextBox2.Text = ""
            conn.Close()
            Timer2.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub check_attendance()
        Dim query1 As String
        Dim count_1 As Integer
        Dim count_2 As Integer
        Dim ln As String = ""
        Dim fn As String = ""
        'Dim ID As String = ""
        Dim sec As String = ""
        Dim s1 As String = ""
        Dim s2 As String = ""
        Dim s3 As String = ""
        Dim READER As MySqlDataReader
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try
            Timer2.Enabled = False
            count = 0
            count_1 = 0
            conn.Open()
            query1 = "SELECT * from attendance where ID_NUMBER='" & TextBox2.Text & "' and ATTENDANCE_DATE ='" & DateTimePicker1.Text & "'"
            com = New MySqlCommand(query1, conn)
            READER = com.ExecuteReader
            While READER.Read
                count_1 = count_1 + 1
                count_2 = READER.GetString("COUNT")

            End While

            If count_1 >= 1 Then
                If count_2 = 1 Then
                    ' MsgBox(s1)
                    '  MsgBox(time_stat.Text)
                    s1 = READER.GetString("IN_AM").ToString
                    If time_dif(time_stat.Text, s1) >= 1 Then
                        '  MsgBox(time_dif(s1, time_stat.Text))
                        Update2()
                    Else
                        Label2.Text = "WAIT FOR " & 1 - time_dif(time_stat.Text, s1) & " MINUTES"
                        Label3.Text = ""
                        Label4.Text = ""
                        Label2.BackColor = Color.Red
                        Label3.BackColor = Color.Red
                        Label4.BackColor = Color.Red
                    End If
                ElseIf count_2 = 2 Then
                    s1 = READER.GetString("OUT_AM").ToString
                    If time_dif(time_stat.Text, s1) >= 1 Then
                        '  MsgBox(time_dif(s1, time_stat.Text))
                        Update3()
                    Else
                        Label2.Text = "WAIT FOR " & 1 - time_dif(time_stat.Text, s1) & " MINUTES"
                        Label3.Text = ""
                        Label4.Text = ""
                        Label2.BackColor = Color.Red
                        Label3.BackColor = Color.Red
                        Label4.BackColor = Color.Red
                    End If
                ElseIf count_2 = 3 Then
                    s1 = READER.GetString("IN_PM").ToString
                    If time_dif(time_stat.Text, s1) >= 1 Then
                        ' MsgBox(time_dif(s1, time_stat.Text))
                        Update2()
                    Else
                        Label2.Text = "WAIT FOR " & 1 - time_dif(time_stat.Text, s1) & " MINUTES"
                        Label3.Text = ""
                        Label4.Text = ""
                        Label2.BackColor = Color.Red
                        Label3.BackColor = Color.Red
                        Label4.BackColor = Color.Red
                    End If
                End If
                load_attendance()
            Else
                Insert_Attendance()
                load_attendance()
            End If
            TextBox2.Text = ""
            conn.Close()
            Timer2.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        dd.Text = Now.Month & "/" & Now.Day & "/" & Now.Year
        date_stat.Text = Now.Year & "-" & Now.Month & "-" & Now.Day
        If Val(Now.Hour) >= 13 Then
            hh = Val(Now.Hour) - 12
            am_pm = "PM"
        Else
            hh = Now.Hour
            am_pm = "AM"
        End If
        time_stat.Text = hh & ":" & Now.Minute & " " & am_pm
        tt.Text = hh & ":" & Now.Minute & " " & am_pm
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TextBox1.Focus()
        TextBox2.Focus()
        DateTimePicker1.Value = Now
       
    End Sub
    Public Function time_dif(d1 As String, d2 As String)
        Dim n As TimeSpan

        Dim dtTime As DateTime = Convert.ToDateTime(d1)
        Dim dtTime2 As DateTime = Convert.ToDateTime(d2)
        n = dtTime2 - dtTime
        Dim tm = Math.Abs(n.Hours) * 60 + Math.Abs(n.Minutes)
        Return tm
    End Function


    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' DataGridView1.Rows.Clear()
            check_student()
        End If
        If e.KeyCode = Keys.F1 Then
            barcode_generator.ShowDialog()
        End If
        If e.KeyCode = Keys.F2 Then
            attendance_report.ShowDialog()
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
            count = count + 1
        If count >= 10 Then
            count = 0

            Label2.Text = ""
            Label3.Text = ""
            Label4.Text = ""
            Label2.BackColor = Color.Silver
            Label3.BackColor = Color.Silver
            Label4.BackColor = Color.Silver
            Timer2.Enabled = False
            DataGridView1.DataSource = Nothing
            DataGridView1.Refresh()
            ' DataGridView1.DataSource = vbNull
            '  DataGridView1.Rows.Clear()
        End If
    End Sub
    Sub load_attendance()
        Dim sd = New MySqlDataAdapter
        Dim dsource = New BindingSource
        Dim dset As New DataTable
        dset = New DataTable
        Dim query As String
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        conn = New MySqlConnection
        query = "SELECT ID_NUMBER, ATTENDANCE_DATE as DATE,IN_AM,OUT_AM,IN_PM,OUT_PM from attendance where ID_NUMBER='" & TextBox2.Text & "' and ATTENDANCE_DATE ='" & DateTimePicker1.Text & "'"
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try
            conn.Open()
            com = New MySqlCommand(query, conn)
            sd.SelectCommand = com
            sd.Fill(dset)
            dsource.DataSource = dset
            DataGridView1.DataSource = dsource
            sd.Update(dset)
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Sub checktime_diff(d1 As String, d2 As String)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
