Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class print_report
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim dset As New DataTable
    Public query As String

    Private Sub print_report_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub print_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadReport()
    End Sub
    Sub LoadReport()

        Dim rptsDP As ReportDataSource

        Try
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report2.rdlc"
                .DataSources.Clear()
            End With

            Dim da = New MySqlDataAdapter
            Dim ds As New DataSet1

            conn = New MySqlConnection
            conn.ConnectionString = "server=localhost;userid=root;password=;database=dccp_attendance"

            conn.Open()
            com = New MySqlCommand(attendance_report.query, conn)
            da.SelectCommand = com
            da.Fill(ds.Tables("attendance"))
            conn.Close()

            rptsDP = New ReportDataSource("DataSet1", ds.Tables("attendance"))
            ReportViewer1.LocalReport.DataSources.Add(rptsDP)
            '  ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = 100
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


End Class