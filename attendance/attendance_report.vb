Imports MySql.Data.MySqlClient
Public Class attendance_report
    Public query As String = ""
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles id.TextChanged

    End Sub

    Private Sub attendance_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        from_date.Value = Now
        to_date.Value = Now
        load_attendance()
    End Sub

    Sub load_attendance()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim dset As New DataTable
        Dim sd = New MySqlDataAdapter
        Dim dsource = New BindingSource
        dset = New DataTable

        conn = New MySqlConnection
        query = "select ATTENDANCE_DATE as DATE, students.ID_NUMBER,SECTION,LAST_NAME,FIRST_NAME,MIDDLE_NAME,IN_AM,OUT_AM,IN_PM,OUT_PM from students,attendance where students.ID_NUMBER=attendance.ID_NUMBER and ATTENDANCE_DATE between '" & from_date.Text & "'  and '" & to_date.Text & "' ORDER by ATTENDANCE_DATE DESC"
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try
            conn.Open()
            com = New MySqlCommand(query, conn)
            sd.SelectCommand = com
            sd.Fill(dset)
            dsource.DataSource = dset
            DataGridView2.DataSource = dsource
            sd.Update(dset)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub check_section()
        section.Items.Clear()
        section.Text = ""
        Dim query1 As String
        Dim READER As MySqlDataReader
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        conn = New MySqlConnection
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try

            conn.Open()
            query1 = "SELECT * from students where course='" & course.Text & "'"
            com = New MySqlCommand(query1, conn)
            READER = com.ExecuteReader
            While READER.Read
                section.Items.Add(READER.GetString("SECTION"))
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub load_course()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim dset As New DataTable
        Dim sd = New MySqlDataAdapter
        Dim dsource = New BindingSource
        dset = New DataTable

        conn = New MySqlConnection
        query = "select ATTENDANCE_DATE as DATE, students.ID_NUMBER,SECTION,LAST_NAME,FIRST_NAME,MIDDLE_NAME,IN_AM,OUT_AM,IN_PM,OUT_PM from students,attendance where students.ID_NUMBER=attendance.ID_NUMBER and ATTENDANCE_DATE between '" & from_date.Text & "'  and '" & to_date.Text & "' and COURSE LIKE '%" & course.Text & "%' ORDER by ATTENDANCE_DATE DESC,SECTIOn ASC, LAST_NAME ASC"
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try
            conn.Open()
            com = New MySqlCommand(query, conn)
            sd.SelectCommand = com
            sd.Fill(dset)
            dsource.DataSource = dset
            DataGridView2.DataSource = dsource
            sd.Update(dset)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub load_section()
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim dset As New DataTable
        Dim sd = New MySqlDataAdapter
        Dim dsource = New BindingSource
        dset = New DataTable

        conn = New MySqlConnection
        query = "select ATTENDANCE_DATE as DATE, students.ID_NUMBER,SECTION,LAST_NAME,FIRST_NAME,MIDDLE_NAME,IN_AM,OUT_AM,IN_PM,OUT_PM from students,attendance where students.ID_NUMBER=attendance.ID_NUMBER and ATTENDANCE_DATE between '" & from_date.Text & "'  and '" & to_date.Text & "' and COURSE LIKE '%" & course.Text & "%'  and SECTION LIKE '%" & section.Text & "%' ORDER by ATTENDANCE_DATE DESC,SECTIOn ASC, LAST_NAME ASC"
        conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"
        Try
            conn.Open()
            com = New MySqlCommand(query, conn)
            sd.SelectCommand = com
            sd.Fill(dset)
            dsource.DataSource = dset
            DataGridView2.DataSource = dsource
            sd.Update(dset)
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub from_date_ValueChanged(sender As Object, e As EventArgs) Handles from_date.ValueChanged
        load_attendance()
    End Sub

    Private Sub to_date_ValueChanged(sender As Object, e As EventArgs) Handles to_date.ValueChanged
        load_attendance()
    End Sub

    Private Sub course_TextChanged(sender As Object, e As EventArgs) Handles course.TextChanged
        check_section()
        load_course()
    End Sub

    Private Sub section_TextChanged(sender As Object, e As EventArgs) Handles section.TextChanged
        load_section()
    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        print_report.ShowDialog()
    End Sub
End Class