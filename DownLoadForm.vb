Public Class DownLoadForm

    Dim ths As Threading.Thread

    Private Sub DownLoadForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not ths Is Nothing Then

            If ths.ThreadState = Threading.ThreadState.Running Then
                ths.Abort()
            End If

            ths = Nothing

        End If

        ' Threading.Thread.Sleep(3000)

        ' System.Environment.Exit(System.Environment.ExitCode)

        LoginForm.Close()

    End Sub

    Private Sub DownLoadForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ths = New Threading.Thread(AddressOf DownLoadDll)

        ths.Start()

    End Sub

    Private Sub DownLoadDll()

        Try

            Dim source_Path As New IO.DirectoryInfo(remoteUri)
            Dim UriDllFiles As IO.FileInfo() = source_Path.GetFiles("*.dll")

            With ProgressBar1
                .Value = 0
                .Maximum = UriDllFiles.Length
            End With

            Dim source_info As IO.FileInfo
            Dim StrDllName As String = ""
            For Each source_info In UriDllFiles
                StrDllName = source_info.Name.Replace(".dll", "")
                LabMessage.Text = StrDllName
                LoginForm.CheckVersion(StrDllName, False)
                ProgressBar1.Value += 1
                Threading.Thread.Sleep(2000)
            Next

        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

        Me.Close()

    End Sub

End Class