Public Class UpdateForm

    Private Sub UpdateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Len(Me.Tag) > 0 Then
            Timer1.Interval = 5000
            With LabMessage
                .Text = Me.Tag
                .Dock = DockStyle.Fill
                .Visible = True
            End With
        End If

        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Me.Close()

    End Sub

End Class