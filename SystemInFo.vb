Imports System.Drawing

Public Class SystemInFo

    Private Sub SystemInFo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '    ' ****************
        '    ' * 改變表單形狀 *
        '    ' ****************
        '    Dim p As New System.Drawing.Drawing2D.GraphicsPath

        '    Try
        '        p.AddString(Me.Text, New FontFamily("African"), FontStyle.Bold, 45, New Point(10, -1), StringFormat.GenericDefault)
        '        Me.Location = New Point(300, 300)
        '    Catch ex As Exception
        '        p.AddString(Me.Text, New FontFamily("Tahoma"), FontStyle.Bold, 35, New Point(5, -3), StringFormat.GenericDefault)
        '        Me.Location = New Point(340, 300)
        '    End Try

        '    Me.Region = New Region(p)

        Dim g As Graphics = Me.CreateGraphics

        Dim f As New Font("Times New Roman", 20, FontStyle.Bold)
        Dim br As New Drawing2D.HatchBrush(Drawing2D.HatchStyle.Percent05, Color.Black, Color.Red)

        g.DrawString(Me.Tag, f, br, 5, 5)

    End Sub

    Private Sub SystemInFo_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Me.Close()
    End Sub

End Class