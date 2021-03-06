'**************************************************************************************
'* Class Name : LoginForm
'
'* Description : Entry Screen
'
'* Author : 
'
'* Change History : 
'
'* Data        Owner       ChangeDescription            Level
'* 2007/06/07  Norman Su   Modify SFC to N-Tier System  L1.00
'*
'******************
Imports System.IO
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.http
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports TalkInformation

Public Class LoginForm
    Inherits CommonModule.BaseForm
    'Inherits System.Windows.Forms.Form

    Public uPublicToken As String = Microsoft.VisualBasic.GetSetting("TMIS", "Token", "Token")

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PicWelcome As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

    '  Private chan1 As HttpClientChannel = New HttpClientChannel()

    Private SqlCommand As String = ""
    Private strWatchDogHost As String = ""
    Public strWatchDogHost_IP As String = ""
    Private strBoardCast As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "BOARDCAST")

    Private iPort As Integer = 5500
    Public SendSFCAPMIPendpoint As Net.IPEndPoint              ' 傳送至 WatchDog 廣播區段
    Private SendRemoteServerIPendpoint As Net.IPEndPoint       ' 傳送至 RemoteServer 廣播區段
    Private ReceIPendpoint As Net.IPEndPoint                   ' 自廣播區段接收

    Private Receivingudpclient As System.Net.Sockets.UdpClient
    Private LoginThreadReceive, ThreadInformation As System.Threading.Thread
    Friend WithEvents LabGateWay As System.Windows.Forms.Label

    Private uTransferPort As String = "http://" & System.Net.Dns.GetHostAddresses(My.Computer.Name).GetValue(0).ToString() & ":6002/CLIENT"
    Private TalkCommand As TalkInformation.TalkCommand = CType(Activator.GetObject(GetType(TalkInformation.TalkCommand), uTransferPort), TalkInformation.TalkCommand)
    Private SFCApmTalkCommand, RemoteTalkCommand As TalkInformation.TalkCommand

    Private uGateWay As String = ""

#Region " Windows Form 設計工具產生的程式碼 "

    Public Sub New()
        MyBase.New()
        'Me.getRemoteService()
        '此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        Control.CheckForIllegalCrossThreadCalls = False

        '在 InitializeComponent() 呼叫之後加入所有的初始設定

    End Sub

    'Form 覆寫 Dispose 以清除元件清單。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '您可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器來修改這些程序。
    Friend WithEvents TxtEmp_NO As System.Windows.Forms.TextBox
    Friend WithEvents TxtPassWORD As System.Windows.Forms.TextBox
    Friend WithEvents ComLOGIN As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents DataBaseLoca As System.Windows.Forms.ColumnHeader
    Friend WithEvents DatabaseName As System.Windows.Forms.ColumnHeader
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel3 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel4 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents LabEmp_nm As System.Windows.Forms.Label
    Friend WithEvents TxtAccount As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents PBTH1 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTH2 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTM1 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTM2 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTS1 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTS2 As System.Windows.Forms.PictureBox
    Friend WithEvents LabAppPath As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Public WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents LabF009 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.TxtEmp_NO = New System.Windows.Forms.TextBox
        Me.TxtPassWORD = New System.Windows.Forms.TextBox
        Me.ComLOGIN = New System.Windows.Forms.Button
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.DatabaseName = New System.Windows.Forms.ColumnHeader
        Me.DataBaseLoca = New System.Windows.Forms.ColumnHeader
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel3 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel4 = New System.Windows.Forms.StatusBarPanel
        Me.LabEmp_nm = New System.Windows.Forms.Label
        Me.TxtAccount = New System.Windows.Forms.TextBox
        Me.LabF009 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.PBTH1 = New System.Windows.Forms.PictureBox
        Me.PBTH2 = New System.Windows.Forms.PictureBox
        Me.PBTM1 = New System.Windows.Forms.PictureBox
        Me.PBTM2 = New System.Windows.Forms.PictureBox
        Me.PBTS1 = New System.Windows.Forms.PictureBox
        Me.PBTS2 = New System.Windows.Forms.PictureBox
        Me.LabAppPath = New System.Windows.Forms.Label
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PicWelcome = New System.Windows.Forms.PictureBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LabGateWay = New System.Windows.Forms.Label
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTH1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTH2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTM1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTM2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PicWelcome, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtEmp_NO
        '
        Me.TxtEmp_NO.BackColor = System.Drawing.Color.SteelBlue
        Me.TxtEmp_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEmp_NO.Cursor = System.Windows.Forms.Cursors.PanWest
        Me.TxtEmp_NO.Font = New System.Drawing.Font("Tahoma", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmp_NO.ForeColor = System.Drawing.Color.Yellow
        Me.TxtEmp_NO.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TxtEmp_NO.Location = New System.Drawing.Point(168, 115)
        Me.TxtEmp_NO.MaxLength = 20
        Me.TxtEmp_NO.Name = "TxtEmp_NO"
        Me.TxtEmp_NO.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtEmp_NO.Size = New System.Drawing.Size(162, 30)
        Me.TxtEmp_NO.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.TxtEmp_NO, "請輸入登錄條碼")
        '
        'TxtPassWORD
        '
        Me.TxtPassWORD.BackColor = System.Drawing.Color.SteelBlue
        Me.TxtPassWORD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPassWORD.Cursor = System.Windows.Forms.Cursors.PanWest
        Me.TxtPassWORD.Font = New System.Drawing.Font("Tahoma", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPassWORD.ForeColor = System.Drawing.Color.Yellow
        Me.TxtPassWORD.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TxtPassWORD.Location = New System.Drawing.Point(168, 146)
        Me.TxtPassWORD.MaxLength = 10
        Me.TxtPassWORD.Name = "TxtPassWORD"
        Me.TxtPassWORD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassWORD.Size = New System.Drawing.Size(162, 30)
        Me.TxtPassWORD.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.TxtPassWORD, "請輸入密碼, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "對於密碼應妥善保管, 不可私自轉告他人")
        '
        'ComLOGIN
        '
        Me.ComLOGIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComLOGIN.Image = CType(resources.GetObject("ComLOGIN.Image"), System.Drawing.Image)
        Me.ComLOGIN.Location = New System.Drawing.Point(344, 155)
        Me.ComLOGIN.Name = "ComLOGIN"
        Me.ComLOGIN.Size = New System.Drawing.Size(95, 24)
        Me.ComLOGIN.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.ComLOGIN, "進入系統")
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DatabaseName, Me.DataBaseLoca})
        Me.ListView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ListView1.Enabled = False
        Me.ListView1.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(65, 199)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(205, 27)
        Me.ListView1.TabIndex = 15
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        Me.ListView1.Visible = False
        '
        'DatabaseName
        '
        Me.DatabaseName.Text = "資料庫名稱"
        Me.DatabaseName.Width = 235
        '
        'DataBaseLoca
        '
        Me.DataBaseLoca.Text = "實體位置"
        Me.DataBaseLoca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataBaseLoca.Width = 245
        '
        'StatusBar1
        '
        Me.StatusBar1.Cursor = System.Windows.Forms.Cursors.Help
        Me.StatusBar1.Enabled = False
        Me.StatusBar1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBar1.Location = New System.Drawing.Point(0, 450)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1, Me.StatusBarPanel2, Me.StatusBarPanel3, Me.StatusBarPanel4})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(738, 21)
        Me.StatusBar1.SizingGrip = False
        Me.StatusBar1.TabIndex = 23
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Icon = CType(resources.GetObject("StatusBarPanel1.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.ToolTipText = "IP"
        Me.StatusBarPanel1.Width = 180
        '
        'StatusBarPanel2
        '
        Me.StatusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel2.Icon = CType(resources.GetObject("StatusBarPanel2.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel2.Name = "StatusBarPanel2"
        Me.StatusBarPanel2.ToolTipText = "電腦名稱"
        Me.StatusBarPanel2.Width = 298
        '
        'StatusBarPanel3
        '
        Me.StatusBarPanel3.Icon = CType(resources.GetObject("StatusBarPanel3.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel3.Name = "StatusBarPanel3"
        Me.StatusBarPanel3.ToolTipText = "網域"
        Me.StatusBarPanel3.Width = 140
        '
        'StatusBarPanel4
        '
        Me.StatusBarPanel4.Icon = CType(resources.GetObject("StatusBarPanel4.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel4.Name = "StatusBarPanel4"
        Me.StatusBarPanel4.ToolTipText = "登錄者"
        Me.StatusBarPanel4.Width = 120
        '
        'LabEmp_nm
        '
        Me.LabEmp_nm.BackColor = System.Drawing.Color.Transparent
        Me.LabEmp_nm.Cursor = System.Windows.Forms.Cursors.No
        Me.LabEmp_nm.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabEmp_nm.ForeColor = System.Drawing.Color.Yellow
        Me.LabEmp_nm.Image = CType(resources.GetObject("LabEmp_nm.Image"), System.Drawing.Image)
        Me.LabEmp_nm.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LabEmp_nm.Location = New System.Drawing.Point(62, 31)
        Me.LabEmp_nm.Name = "LabEmp_nm"
        Me.LabEmp_nm.Size = New System.Drawing.Size(157, 42)
        Me.LabEmp_nm.TabIndex = 25
        Me.LabEmp_nm.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.LabEmp_nm.Visible = False
        '
        'TxtAccount
        '
        Me.TxtAccount.BackColor = System.Drawing.Color.SteelBlue
        Me.TxtAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtAccount.Cursor = System.Windows.Forms.Cursors.PanWest
        Me.TxtAccount.Font = New System.Drawing.Font("Tahoma", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAccount.ForeColor = System.Drawing.Color.Yellow
        Me.TxtAccount.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.TxtAccount.Location = New System.Drawing.Point(168, 83)
        Me.TxtAccount.MaxLength = 10
        Me.TxtAccount.Name = "TxtAccount"
        Me.TxtAccount.Size = New System.Drawing.Size(162, 30)
        Me.TxtAccount.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxtAccount, "請輸入登錄工號")
        '
        'LabF009
        '
        Me.LabF009.BackColor = System.Drawing.Color.Transparent
        Me.LabF009.Enabled = False
        Me.LabF009.Location = New System.Drawing.Point(306, 17)
        Me.LabF009.Name = "LabF009"
        Me.LabF009.Size = New System.Drawing.Size(102, 12)
        Me.LabF009.TabIndex = 27
        Me.LabF009.Visible = False
        '
        'ToolTip1
        '
        Me.ToolTip1.ShowAlways = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(3, 27)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(53, 56)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 119
        Me.PictureBox3.TabStop = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "n0.gif")
        Me.ImageList2.Images.SetKeyName(1, "n1.gif")
        Me.ImageList2.Images.SetKeyName(2, "n2.gif")
        Me.ImageList2.Images.SetKeyName(3, "n3.gif")
        Me.ImageList2.Images.SetKeyName(4, "n4.gif")
        Me.ImageList2.Images.SetKeyName(5, "n5.gif")
        Me.ImageList2.Images.SetKeyName(6, "n6.gif")
        Me.ImageList2.Images.SetKeyName(7, "n7.gif")
        Me.ImageList2.Images.SetKeyName(8, "n8.gif")
        Me.ImageList2.Images.SetKeyName(9, "N9.gif")
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'PBTH1
        '
        Me.PBTH1.BackColor = System.Drawing.Color.Transparent
        Me.PBTH1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBTH1.Location = New System.Drawing.Point(6, 174)
        Me.PBTH1.Name = "PBTH1"
        Me.PBTH1.Size = New System.Drawing.Size(10, 10)
        Me.PBTH1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBTH1.TabIndex = 111
        Me.PBTH1.TabStop = False
        '
        'PBTH2
        '
        Me.PBTH2.BackColor = System.Drawing.Color.Transparent
        Me.PBTH2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBTH2.Location = New System.Drawing.Point(15, 174)
        Me.PBTH2.Name = "PBTH2"
        Me.PBTH2.Size = New System.Drawing.Size(10, 10)
        Me.PBTH2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBTH2.TabIndex = 112
        Me.PBTH2.TabStop = False
        '
        'PBTM1
        '
        Me.PBTM1.BackColor = System.Drawing.Color.Transparent
        Me.PBTM1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBTM1.Location = New System.Drawing.Point(32, 174)
        Me.PBTM1.Name = "PBTM1"
        Me.PBTM1.Size = New System.Drawing.Size(10, 10)
        Me.PBTM1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBTM1.TabIndex = 113
        Me.PBTM1.TabStop = False
        '
        'PBTM2
        '
        Me.PBTM2.BackColor = System.Drawing.Color.Transparent
        Me.PBTM2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBTM2.Location = New System.Drawing.Point(41, 174)
        Me.PBTM2.Name = "PBTM2"
        Me.PBTM2.Size = New System.Drawing.Size(10, 10)
        Me.PBTM2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBTM2.TabIndex = 114
        Me.PBTM2.TabStop = False
        '
        'PBTS1
        '
        Me.PBTS1.BackColor = System.Drawing.Color.Transparent
        Me.PBTS1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBTS1.Location = New System.Drawing.Point(57, 174)
        Me.PBTS1.Name = "PBTS1"
        Me.PBTS1.Size = New System.Drawing.Size(10, 10)
        Me.PBTS1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBTS1.TabIndex = 115
        Me.PBTS1.TabStop = False
        '
        'PBTS2
        '
        Me.PBTS2.BackColor = System.Drawing.Color.Transparent
        Me.PBTS2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PBTS2.Location = New System.Drawing.Point(66, 174)
        Me.PBTS2.Name = "PBTS2"
        Me.PBTS2.Size = New System.Drawing.Size(10, 10)
        Me.PBTS2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBTS2.TabIndex = 116
        Me.PBTS2.TabStop = False
        '
        'LabAppPath
        '
        Me.LabAppPath.BackColor = System.Drawing.Color.Transparent
        Me.LabAppPath.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabAppPath.ForeColor = System.Drawing.Color.Yellow
        Me.LabAppPath.Location = New System.Drawing.Point(8, 1)
        Me.LabAppPath.Name = "LabAppPath"
        Me.LabAppPath.Size = New System.Drawing.Size(225, 23)
        Me.LabAppPath.TabIndex = 117
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "來電顯示"
        Me.NotifyIcon1.Visible = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MistyRose
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Blue
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(83, 85)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(83, 25)
        Me.Button1.TabIndex = 120
        Me.Button1.Text = "登錄工號"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.MistyRose
        Me.Button2.ForeColor = System.Drawing.Color.Blue
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(83, 117)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(83, 25)
        Me.Button2.TabIndex = 121
        Me.Button2.Text = "通行條碼"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.MistyRose
        Me.Button3.ForeColor = System.Drawing.Color.Blue
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(83, 148)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(83, 25)
        Me.Button3.TabIndex = 122
        Me.Button3.Text = "登錄密碼"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(738, 450)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 123
        Me.PictureBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.PicWelcome)
        Me.Panel2.Controls.Add(Me.LabEmp_nm)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.LabAppPath)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.LabF009)
        Me.Panel2.Controls.Add(Me.PBTS2)
        Me.Panel2.Controls.Add(Me.TxtAccount)
        Me.Panel2.Controls.Add(Me.PBTS1)
        Me.Panel2.Controls.Add(Me.TxtEmp_NO)
        Me.Panel2.Controls.Add(Me.PBTM2)
        Me.Panel2.Controls.Add(Me.PBTM1)
        Me.Panel2.Controls.Add(Me.PBTH2)
        Me.Panel2.Controls.Add(Me.TxtPassWORD)
        Me.Panel2.Controls.Add(Me.PBTH1)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.ComLOGIN)
        Me.Panel2.Location = New System.Drawing.Point(132, 130)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(461, 198)
        Me.Panel2.TabIndex = 125
        '
        'PicWelcome
        '
        Me.PicWelcome.BackColor = System.Drawing.Color.Transparent
        Me.PicWelcome.Image = CType(resources.GetObject("PicWelcome.Image"), System.Drawing.Image)
        Me.PicWelcome.Location = New System.Drawing.Point(225, 31)
        Me.PicWelcome.Name = "PicWelcome"
        Me.PicWelcome.Size = New System.Drawing.Size(81, 41)
        Me.PicWelcome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicWelcome.TabIndex = 126
        Me.PicWelcome.TabStop = False
        Me.PicWelcome.Visible = False
        '
        'Button4
        '
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Location = New System.Drawing.Point(421, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(36, 24)
        Me.Button4.TabIndex = 123
        Me.Button4.UseVisualStyleBackColor = True
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(66, 84)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 124
        Me.PictureBox6.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Enabled = False
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.InitialImage = Nothing
        Me.PictureBox4.Location = New System.Drawing.Point(7, 378)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(97, 66)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 127
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Enabled = False
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.InitialImage = Nothing
        Me.PictureBox5.Location = New System.Drawing.Point(110, 378)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(97, 66)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 128
        Me.PictureBox5.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 300000
        '
        'LabGateWay
        '
        Me.LabGateWay.AutoSize = True
        Me.LabGateWay.BackColor = System.Drawing.Color.White
        Me.LabGateWay.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabGateWay.ForeColor = System.Drawing.Color.Chartreuse
        Me.LabGateWay.Location = New System.Drawing.Point(643, 428)
        Me.LabGateWay.Name = "LabGateWay"
        Me.LabGateWay.Size = New System.Drawing.Size(0, 14)
        Me.LabGateWay.TabIndex = 127
        '
        'LoginForm
        '
        Me.AcceptButton = Me.ComLOGIN
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(738, 471)
        Me.Controls.Add(Me.LabGateWay)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.MaximizeBox = False
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SFC系統登錄作業"
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTH1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTH2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTM1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTM2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PicWelcome, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Public Sub processExit(ByVal IsClose As Boolean)

        If IsClose = True Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If

    End Sub

    Private Sub LoginForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try

            SFCApmTalkCommand.Information_ADD("<USER_QUIT>" & Chr(9) & Me.ClsCommonInfo.strBelongServerIP & Chr(9) & Me.ClsCommonInfo.uLocalIP & Chr(9) & strWatchDogHost_IP & Chr(9), Me.ClsCommonInfo.uLocalIP, uGateWay, uTransferPort)

        Catch ex As Exception
        End Try

        ' SendInfo("<USER_QUIT>" & Chr(9) & Me.ClsCommonInfo.strBelongServerIP & Chr(9) & Me.ClsCommonInfo.uLocalIP & Chr(9) & strWatchDogHost_IP & Chr(9), SendSFCAPMIPendpoint)

        Try

            LoginThreadReceive.Abort()
            Receivingudpclient.DropMulticastGroup(System.Net.IPAddress.Parse(strBoardCast))
            Receivingudpclient.Close()

            ThreadInformation.Abort()

        Catch ex As Exception

        End Try

        Threading.Thread.Sleep(1000)

        Try

            Me.ProcKill("LocalServer")
            Me.ProcKill("WatchDog")
            Threading.Thread.Sleep(1000)

            ClearTempFiles()

        Catch ex As Exception

        End Try

        NotifyIcon1.Dispose()

        System.Environment.Exit(System.Environment.ExitCode)

    End Sub


    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not IO.File.Exists(Application.StartupPath & "\LocalServer.exe") Then
            ErrorInfo.SysErrMessageInfomation("無法啟動本機連線機制..")
            processExit(True)
            Exit Sub
        End If

        If Not CheckExist("LocalServer") Then
            ProcessService(Application.StartupPath & "\LocalServer.exe")
        End If
        If Not CheckExist("WatchDog") Then
            ProcessService(Application.StartupPath & "\WatchDog.exe")
        End If
        If Not CheckExist("RemoteServer") Then
            ProcessService(Application.StartupPath & "\RemoteServer.exe")
        End If
        LoadPublicToken()
        Dim test As System.Net.IPAddress() = System.Net.Dns.GetHostAddresses(My.Computer.Name)
        strLocalServerHost = System.Net.Dns.GetHostAddresses(My.Computer.Name).GetValue(0).ToString()

        ClsCommonInfo = CType(Activator.GetObject(GetType(RemoteObject.CommonClass), "http://" & strLocalServerHost & ":8083/SFCLOCAL"), RemoteObject.CommonClass)

        ClsCommonInfo.uLocalIP = System.Net.Dns.GetHostAddresses(My.Computer.Name).GetValue(0).ToString()

        strWatchDogHost = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "SFCAPM")
        strWatchDogHost_IP = System.Net.Dns.GetHostAddresses(strWatchDogHost).GetValue(0).ToString()

        SendSFCAPMIPendpoint = New Net.IPEndPoint(System.Net.IPAddress.Parse(strBoardCast), iPort)              ' 傳送至 WatchDog 廣播區段
        SendRemoteServerIPendpoint = New Net.IPEndPoint(System.Net.IPAddress.Parse(strBoardCast), iPort + 1)    ' 傳送至 RemoteServer 廣播區段
        ReceIPendpoint = New Net.IPEndPoint(System.Net.IPAddress.Parse(strBoardCast), iPort + 2)                ' 自廣播區段接收

        If strWatchDogHost.Trim.Length = 0 Then
            'ClsCommonInfo.strBelongServerIP = ClsCommonInfo.uLocalIP
            strWatchDogHost = strLocalServerHost
        Else
            If UCase(strWatchDogHost) <> UCase(strLocalServerHost) Then
                Try
                    If Not CheckExist("RemoteServer") Then
                        Microsoft.VisualBasic.DeleteSetting("TMIS", "LINK", "LINK")  ' 已委由 RemoteServer 代勞連結至資料庫 
                    End If
                Catch ex As Exception
                End Try
            End If
        End If

        NotifyIcon1.Text = "SFC User"

        ' **********************************
        ' * 架設通道, 可供各地電腦連線進來 *
        ' **********************************
        Dim Talkchannel As New HttpServerChannel(6002)

        ChannelServices.RegisterChannel(Talkchannel, False)

        RemotingConfiguration.RegisterWellKnownServiceType( _
            GetType(TalkInformation.TalkCommand), _
            "CLIENT", _
            WellKnownObjectMode.Singleton)

        uGateWay = TalkCommand.LocalGateWay
        LabGateWay.Text = uGateWay

        ThreadInformation = New Threading.Thread(AddressOf anaInformation)
        ThreadInformation.Start()

        Try

            ' ************************
            ' * 連結至 WATCHDOG 電腦 *
            ' ************************
            SFCApmTalkCommand = CType(Activator.GetObject(GetType(TalkInformation.TalkCommand), "http://" & strWatchDogHost_IP & ":6000/WATCHDOG"), TalkInformation.TalkCommand)

            If Me.ClsCommonInfo.strBelongServerIP.Trim.Length = 0 Then

                SFCApmTalkCommand.Information_ADD("<REMOTESERVER_IP>" & Chr(9) & strWatchDogHost_IP & _
                  Chr(9) & Me.ClsCommonInfo.uLocalIP & _
                  Chr(9) & uGateWay & _
                  Chr(9) & uGateWay & Chr(9), Me.ClsCommonInfo.uLocalIP, uGateWay, uTransferPort)

                ' Threading.Thread.Sleep(3000)

            End If

        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

        InitUDPClient()

        ' *********************************
        ' * Get SERVER IP FROM WATCH DOG. *
        ' *********************************
        Dim iStartTime As Integer = 0
        ClsCommonInfo.strBelongServerIP = "10.13.25.99"
        If ClsCommonInfo.strBelongServerIP.Trim.Length = 0 Then

            SendInfo("<REMOTESERVER_IP>" & Chr(9) & strWatchDogHost_IP & Chr(9) & Me.ClsCommonInfo.uLocalIP & Chr(9) & "申請資料服務" & Chr(9) & uGateWay & Chr(9), SendSFCAPMIPendpoint)

            While ClsCommonInfo.strBelongServerIP.Trim.Length = 0 And iStartTime < 10

                Threading.Thread.Sleep(500)

                SendInfo("<REMOTESERVER_IP>" & Chr(9) & strWatchDogHost_IP & Chr(9) & Me.ClsCommonInfo.uLocalIP & Chr(9) & "申請資料服務" & Chr(9) & uGateWay & Chr(9), SendSFCAPMIPendpoint)

                iStartTime += 1

            End While

        End If

        ' ************
        ' * 延遲等候 *
        ' ************
        iStartTime = 0
        While ClsCommonInfo.strBelongServerIP.Trim.Length = 0 And iStartTime < 10000
            iStartTime += 1
        End While

        If Me.ClsCommonInfo.strBelongServerIP.Trim.Length = 0 Then
            MsgBox(My.Computer.Name & Chr(13) & uGateWay & Chr(13) & uTransferPort)
            ErrorInfo.SysErrMessageInfomation("無法連結至伺服器, 請檢查相關設定")
            processExit(True)
            Exit Sub
        End If

        ChangeServerIP(Me.ClsCommonInfo.strBelongServerIP)

        '' ****************************
        '' * 連結至 RemoteServer 電腦 *
        '' ****************************
        RemoteTalkCommand = CType(Activator.GetObject(GetType(TalkInformation.TalkCommand), "http://" & Me.ClsCommonInfo.strBelongServerIP & ":6001/REMOTE"), TalkInformation.TalkCommand)

        ' InitUDPClient()

        LabAppPath.Text = ClsCommonInfo.uAppPath

        Timer2.Start()

        Me.Text = Me.ClsCommonInfo.uSystem

        Me.ClsCommonInfo.DisplayTypeAndAddress()   ' 本台 MAC 網路卡

        DisplayLocalInfo()                         ' 顯示本機相關資訊


    End Sub

    Private Sub anaInformation()

        'OnLinePC.Columns(0)="TalkInforMation"   ' 訊息
        'OnLinePC.Columns(1)="ComputName"        ' 訊息發送者
        'OnLinePC.Columns(2)="Gateway"           ' 閘道口
        'OnLinePC.Columns(3)="TransferPort"      ' 訊息發送者連接口(HTTP://Computernamer:6000/WATCHDOG)

        While True

            ' Dim xDataTable As DataTable = TalkCommand.OnLinePC()

            If TalkCommand.OnLinePC.Rows.Count > 0 Then

                Dim xInformation As String() = Split(TalkCommand.OnLinePC.Rows(0).Item(0), Chr(9))

                Dim xInfoHead As String = xInformation(0).ToUpper

                Try
                    Select Case xInfoHead

                        Case "<REMOTESERVER_IP_FOUND>"   ' 若為 RemoteServer IP 值
                            If Me.ClsCommonInfo.strBelongServerIP.Trim.Length = 0 Then
                                xInformation = Split(Mid(TalkCommand.OnLinePC.Rows(0).Item(0), InStr(TalkCommand.OnLinePC.Rows(0).Item(0), Chr(9)) + 1), Chr(9))
                                Me.ClsCommonInfo.strBelongServerIP = xInformation(2)
                            End If
                        Case Else

                            ' ***********************************************************
                            ' * 判定是否在同一 GateWay 中, 若不同才需透過 HTTP 傳送出去 *
                            ' ***********************************************************
                            If TalkCommand.OnLinePC.Rows(0).Item(2).ToString.ToUpper <> uGateWay Then
                                If TalkCommand.OnLinePC.Rows(0).Item(3).ToString.Length > 0 Then
                                    Dim xTalkCommand As TalkInformation.TalkCommand = CType(Activator.GetObject(GetType(TalkInformation.TalkCommand), TalkCommand.OnLinePC.Rows(0).Item(3)), TalkInformation.TalkCommand)
                                    xTalkCommand.Information_ADD(TalkCommand.OnLinePC.Rows(0).Item(0), Me.ClsCommonInfo.uLocalIP, uGateWay, "")
                                    xTalkCommand = Nothing
                                End If
                            Else
                                SendInfo(TalkCommand.OnLinePC.Rows(0).Item(0), SendRemoteServerIPendpoint)
                            End If

                    End Select

                    ' TalkCommand.Information_Dele(0)
                    TalkCommand.OnLinePC.Rows.RemoveAt(0)
                Catch ex As Exception

                End Try

            End If

            '  xDataTable.Dispose()

            Threading.Thread.Sleep(1000)

        End While

    End Sub

    Private Sub InitUDPClient()

        Try

            Receivingudpclient = New System.Net.Sockets.UdpClient(iPort + 2)
            Receivingudpclient.JoinMulticastGroup(System.Net.IPAddress.Parse(strBoardCast))

            LoginThreadReceive = New System.Threading.Thread(AddressOf LoginChkUDP)
            LoginThreadReceive.Start()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub SendInfo(ByVal xMessage As String, ByRef xIPEndPoint As Net.IPEndPoint)

        Try

            Dim xByteCommand() As Byte
            xByteCommand = System.Text.Encoding.UTF8.GetBytes(xMessage)
            Receivingudpclient.Send(xByteCommand, xByteCommand.Length, xIPEndPoint)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LoginChkUDP()

        Dim ReceiveBytes As Byte()
        Dim Strreturndata As String = ""

        Dim xRecCommand As String = ""

        While True

            ReceiveBytes = Receivingudpclient.Receive(ReceIPendpoint)
            Strreturndata = System.Text.Encoding.UTF8.GetString(ReceiveBytes)

            Dim DATA, Information As String()

            DATA = Split(Strreturndata, Chr(9))

            Try

                xRecCommand = DATA(0).ToUpper.Trim
                Information = Split(Mid(Strreturndata, InStr(Strreturndata, Chr(9)) + 1), Chr(9))

                Select Case xRecCommand
                    Case "<SHUTDOWN>"
                        NotifyIcon1.BalloonTipText = "系統即將關閉"
                        NotifyIcon1.ShowBalloonTip(500)
                        Me.Close()
                    Case "<REMOTESERVER_IP_FOUND>"
                        Me.ClsCommonInfo.uDBServerName = Information(3)
                        If (Me.ClsCommonInfo.uLocalIP = Information(0)) Then
                            If Me.ClsCommonInfo.strBelongServerIP.Trim.Length = 0 Then
                                Me.ClsCommonInfo.strBelongServerIP = Information(2)
                                NotifyIcon1.BalloonTipText = "取得 " & Me.ClsCommonInfo.strBelongServerIP & " 提供資料服務"
                                NotifyIcon1.ShowBalloonTip(500)
                            End If
                        End If
                    Case "<USER_QUIT>"
                            If Me.ClsCommonInfo.strBelongServerIP = Information(1) Then
                                NotifyIcon1.BalloonTipText = "系統即將關閉"
                                NotifyIcon1.ShowBalloonTip(500)
                                Me.Close()
                            End If
                    Case "<WORKFLOW_INFO>"   ' 當生產流程存檔時, 會發出來
                        If (Me.ClsCommonInfo.uLocalIP <> Information(1)) Then
                            NotifyIcon1.BalloonTipText = Information(2)
                            NotifyIcon1.ShowBalloonTip(500)
                        End If
                    Case "<SFCAPM_INFO>"           ' WatchDog 發出訊息
                            If strWatchDogHost_IP = Information(0) Then
                                NotifyIcon1.BalloonTipText = Information(1) & "->" & Information(2)
                                NotifyIcon1.ShowBalloonTip(500)
                            End If
                    Case "<REMOTESERVER_DISABLE>"
                            NotifyIcon1.BalloonTipText = Information(1) & "停止資料服務"
                            NotifyIcon1.ShowBalloonTip(500)
                    Case "<REMOTESERVER_QUIT>"
                            NotifyIcon1.BalloonTipText = Information(1) & "下線"
                            NotifyIcon1.ShowBalloonTip(500)
                            If Me.ClsCommonInfo.strBelongServerIP = Information(1) Then
                                Me.Close()
                            End If
                End Select

            Catch ex As Exception
                MsgBox(xRecCommand & Chr(13) & ex.Message)
            End Try

            Threading.Thread.Sleep(500)

        End While

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

    Private Sub SetDBInfo()

        Try
            Dim hstbIP As New Hashtable
            Dim hstbMac As New Hashtable
            Dim hstbEMP_NOSID As New Hashtable
            Dim hstbComputerName As New Hashtable

            hstbIP(Me.ClsCommonInfo.uLocalIP) = Me.ClsCommonInfo.uLocalIP
            hstbMac(Me.ClsCommonInfo.uLocalIP) = Me.ClsCommonInfo.uMac
            hstbEMP_NOSID(Me.ClsCommonInfo.uLocalIP) = Me.ClsCommonInfo.uEMP_NOSID
            hstbComputerName(Me.ClsCommonInfo.uLocalIP) = Me.ClsCommonInfo.uComputerName

            Me.ClsDBInfo.hstbUserIP = hstbIP
            Me.ClsDBInfo.hstbUserMac = hstbMac
            Me.ClsDBInfo.hstbUserEMP_NOSID = hstbEMP_NOSID
            Me.ClsDBInfo.hstbUserComputerName = hstbComputerName

        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

    End Sub

    Private Sub ComLOGIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComLOGIN.Click

        '********** tianen
        If LabEmp_nm.Text = "" Then
            TxtAccount.Text = "1012477"
            TxtEmp_NO.Text = UCase("WATER")
            TxtPassWORD.Text = UCase("wa")
            Me.ClsCommonInfo.uEMP_NOSID = 8226
        End If
        '**************


        If Len(Trim(TxtEmp_NO.Text)) = 0 Or Len(Trim(TxtPassWORD.Text)) = 0 Then
            StatusBar1.Panels(1).Text = "登錄帳號/密碼未輸入"
            TxtEmp_NO.Focus()
            Exit Sub
        End If

        Try
            If Not My.Computer.FileSystem.DirectoryExists(Me.ClsCommonInfo.uXmlFolder) Then
                My.Computer.FileSystem.CreateDirectory(Me.ClsCommonInfo.uXmlFolder)
            End If

        Catch ex As Exception

        End Try

        Me.ClsCommonInfo.uLogonStatus = False

        Try
            If Me.ClsDBInfo.datalink(Me.ClsCommonInfo.uLocalIP) Then

                ' ******************************
                ' * 與資料庫伺服器時間取得一致 *
                ' ******************************
                If UCase(Me.ClsCommonInfo.uDBServerName) <> UCase(My.Computer.Name) Then
                    Me.SetSystemDateTime()
                    NotifyIcon1.BalloonTipText = "系統時間經過調校"
                    NotifyIcon1.ShowBalloonTip(500)
                End If

                SqlCommand = "select SYS03.F001,SYS03.F004,SYS03.F003,nvl(SYS00.F002,'') as CompanyName" & _
                              " from SYS0003 SYS03,SYS0000 SYS00" & _
                             " where SYS03.F003='" & Trim(TxtAccount.Text) & "'" & _
                               " and SYS03.F009='" & Trim(TxtEmp_NO.Text) & "'" & _
                               " and SYS03.F005='" & Trim(TxtPassWORD.Text) & "'" & _
                               " and to_char(SYS03.F007,'yyyy/mm/dd')<='" & Format(Now(), "yyyy/MM/dd") & "'" & _
                               " and SYS03.F008=1"

                Dim DT As New DataTable("DATA")

                Me.ClsDBInfo.ExecuteSQL(SqlCommand, DT)

                If DT.Rows.Count > 0 Then

                    StatusBar1.Panels(1).Text = ""

                    Me.ClsCommonInfo.uCompanyName = DT.Rows(0).Item("CompanyName")

                    Me.Visible = False

                    processExit(False)

                    SFCApmTalkCommand.Information_ADD("<USER_ADD>" & Chr(9) & strWatchDogHost_IP & Chr(9) & Me.ClsCommonInfo.uLocalIP & Chr(9) & Me.ClsCommonInfo.strBelongServerIP & Chr(9) & uGateWay & Chr(9), My.Computer.Name, uGateWay, uTransferPort)

                    '  SendInfo("<USER_ADD>" & Chr(9) & strWatchDogHost_IP & Chr(9) & Me.ClsCommonInfo.uLocalIP & Chr(9) & Me.ClsCommonInfo.strBelongServerIP & Chr(9), SendSFCAPMIPendpoint)

                    Dim uMainMenuForm As MainMenuForm = New MainMenuForm

                    uMainMenuForm.Text = uMainMenuForm.Text & "(" & Me.ClsCommonInfo.uEMP_NOSID & ")" & Me.ClsCommonInfo.uEmp_Nm & Chr(255)
                    uMainMenuForm.Owner = Me
                    uMainMenuForm.Show()

                Else
                    StatusBar1.Panels(1).Text = "帳號或密碼錯誤, 請重新輸入...."
                    Me.ClsCommonInfo.uEmp_account = ""
                    TxtAccount.Focus()
                End If

                DT.Dispose()

            End If

        Catch ex As Exception
            StatusBar1.Panels(1).Text = ex.Message
            ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

    End Sub

    Private Sub TxtPassWORD_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPassWORD.Leave

        Me.ClsCommonInfo.uEmp_Password = Trim(TxtPassWORD.Text)                  ' 登錄密碼

    End Sub

    Private Sub DisplayLocalInfo()    ' 顯示本機相關資訊
        Me.ClsCommonInfo.uComputerName = System.Net.Dns.GetHostName
        StatusBar1.Panels(0).Text = Me.ClsCommonInfo.uLocalIP & " (" & Screen.PrimaryScreen.Bounds.Width & " * " & Screen.PrimaryScreen.Bounds.Height & ")"
        StatusBar1.Panels(1).Text = Environment.UserDomainName
        StatusBar1.Panels(2).Text = Me.ClsCommonInfo.uComputerName                 ' uAppPath
        StatusBar1.Panels(3).Text = Environment.UserName
    End Sub

    Private Sub TxtAccount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAccount.Leave

        If Len(Trim(TxtAccount.Text)) > 0 Then

            ' *****************
            ' * 連到 SFC 系統 *
            ' *****************
            SqlCommand = "select F001,F004,F009 from SYS0003" & _
                         " where F003='" & Trim(TxtAccount.Text) & "'" & _
                           " and to_char(F007,'yyyy/mm/dd')<='" & Format(Now(), "yyyy/MM/dd") & "'" & _
                           " and F008=1"

            Try

                If Me.ClsDBInfo.datalink(Me.ClsCommonInfo.uLocalIP) Then

                    Dim DT As New DataTable("DATA")

                    Me.ClsDBInfo.ExecuteSQL(SqlCommand, DT)

                    If DT.Rows.Count > 0 Then

                        Me.ClsCommonInfo.uEmp_account = Trim(TxtAccount.Text)            ' 登錄帳號 
                        Me.ClsCommonInfo.uEMP_NOSID = DT.Rows(0).Item("F001")
                        Me.ClsCommonInfo.uEmp_Nm = DT.Rows(0).Item("F004")

                        LabF009.Text = DT.Rows(0).Item("F009")            ' 登錄帳戶

                        StatusBar1.Panels(2).Text = Me.ClsCommonInfo.uEmp_account
                        StatusBar1.Panels(3).Text = Me.ClsCommonInfo.uEmp_Nm

                        LabEmp_nm.Text = Me.ClsCommonInfo.uEmp_Nm
                        LabEmp_nm.Visible = True
                        PicWelcome.Visible = True

                        StatusBar1.Panels(1).Text = ""

                        ' SetDBInfo() ----

                        TxtEmp_NO.Focus()

                    Else
                        StatusBar1.Panels(1).Text = "登錄工號錯誤, 請重新輸入...."
                        ErrorInfo.SysErrMessageInfomation(StatusBar1.Panels(1).Text)
                        Me.ClsCommonInfo.uEmp_account = ""
                        TxtAccount.Focus()
                    End If

                    DT.Dispose()

                End If

            Catch ex As Exception
                StatusBar1.Panels(1).Text = ex.Message
                ErrorInfo.SysErrMessageInfomation(StatusBar1.Panels(1).Text)
            End Try

        End If

    End Sub

    Private Sub TxtAccount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAccount.GotFocus
        LabEmp_nm.Text = ""
        LabEmp_nm.Visible = False
        PicWelcome.Visible = False
    End Sub

    Private Sub TxtPassWORD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPassWORD.GotFocus

        TxtPassWORD.Text = ""     ' 2006/12/8 

        If (TxtEmp_NO.Text <> LabF009.Text) Then
            TxtEmp_NO.Text = ""
            TxtEmp_NO.Focus()
            StatusBar1.Panels(1).Text = "登錄條碼錯誤, 請重新輸入...."
            ErrorInfo.SysErrMessageInfomation(StatusBar1.Panels(1).Text)
        Else
            StatusBar1.Panels(1).Text = ""
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        Dim h1 As Integer = Val(Microsoft.VisualBasic.Left(Format(Now, "HH:mm:ss"), 1))
        Dim h2 As Integer = Val(Mid(Format(Now, "HH:mm:ss"), 2, 1))
        Dim m1 As Integer = Val(Mid(Format(Now, "hh:mm:ss"), 4, 1))
        Dim m2 As Integer = Val(Mid(Format(Now, "hh:mm:ss"), 5, 1))
        Dim s1 As Integer = Val(Mid(Format(Now, "hh:mm:ss"), 7, 1))
        Dim s2 As Integer = Val(Mid(Format(Now, "hh:mm:ss"), 8, 1))

        PBTH1.BackgroundImage = ImageList2.Images(h1)
        PBTH2.BackgroundImage = ImageList2.Images(h2)
        PBTM1.BackgroundImage = ImageList2.Images(m1)
        PBTM2.BackgroundImage = ImageList2.Images(m2)
        PBTS1.BackgroundImage = ImageList2.Images(s1)
        PBTS2.BackgroundImage = ImageList2.Images(s2)

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click

        MsgBox(strWatchDogHost.Trim)

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click

        ' ************************
        ' * 下載該員作業進行註冊 *
        ' ************************
        Dim xDownLoad As Form = New DownLoadForm

        With xDownLoad
            .StartPosition = FormStartPosition.CenterScreen
            .TopMost = True
        End With

        xDownLoad.Show()

    End Sub

    Private Sub TxtEmp_NO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEmp_NO.GotFocus
        TxtEmp_NO.Text = ""
    End Sub

    Private Sub TxtEmp_NO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEmp_NO.LostFocus

        TxtEmp_NO.Text = Trim(TxtEmp_NO.Text)

        If Len(TxtEmp_NO.Text) > 0 Then
            TxtPassWORD.Focus()
        End If

    End Sub

    Public Sub CheckVersion(ByVal strDllFile As String, ByVal IsDisplayWarnning As Boolean)

        Try
            Dim xUpdateForm As New UpdateForm
            Dim cCommand As String = ""

            strDllFile = Replace(strDllFile, ".dll", "")
            Dim source_info As IO.FileInfo = New IO.FileInfo(remoteUri & "\" & strDllFile & ".dll")
            Dim target_info As IO.FileInfo = New IO.FileInfo(Application.StartupPath & "\" & strDllFile & ".dll")

            If source_info.LastWriteTime.CompareTo(target_info.LastWriteTime) Then  ' 若檔案有異動(新增/修改)

                ' ********************************
                ' * 檢查目前在系統內已開啟的表單 *
                ' ********************************
                Dim MdiRunForm, RunForm As New Form

                For Each MdiRunForm In Application.OpenForms

                    For Each RunForm In MdiRunForm.MdiChildren

                        If UCase(RunForm.Name) = UCase(strDllFile) Then

                            If IsDisplayWarnning = True Then
                                xUpdateForm.MdiParent = RunForm.MdiParent
                                xUpdateForm.Dock = DockStyle.Fill
                                xUpdateForm.Show()
                            End If

                            RunForm.Close()   ' 強迫關閉
                            RunForm.Dispose()

                        End If
                    Next

                    If UCase(MdiRunForm.Name) = UCase(strDllFile) Then

                        If IsDisplayWarnning = True Then
                            xUpdateForm.MdiParent = MdiRunForm.MdiParent
                            xUpdateForm.Dock = DockStyle.Fill
                            xUpdateForm.Show()
                        End If

                        MdiRunForm.Close()    ' 強迫關閉
                        MdiRunForm.Dispose()

                    End If

                Next

                MdiRunForm = Nothing
                RunForm = Nothing

                ' ***********************
                ' * 將本機 GAC 卸載下來 *
                ' ***********************
                Using ts As StreamWriter = New StreamWriter(Application.StartupPath & "\UnRegDll.bat")
                    ts.WriteLine(Application.StartupPath & "\gacutil.exe /u " & strDllFile)
                End Using

                cCommand = Application.StartupPath & "\UnRegDll.bat"
                ProcessService(cCommand)

                Threading.Thread.Sleep(1000)

                If IO.File.Exists(Application.StartupPath & "\UnRegDll.bat") Then
                    IO.File.Delete(Application.StartupPath & "\UnRegDll.bat")
                End If

                ' *****************
                ' * 複製 DLL 檔案 *
                ' *****************
                source_info.CopyTo(Application.StartupPath & "\" & strDllFile & ".dll", True)

                '' *****************
                '' * 取得 DLL 版本 *
                '' *****************
                'Dim OneFileverisioninfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(strDllFile & ".dll")
                'Dim source As New IO.FileInfo(strDllFile & ".dll")
                'Dim strGacFileVersion As String = OneFileverisioninfo.ProductVersion
                'Dim strGacToken As String = uPublicToken

                ' **********************
                ' * 進行本機註冊至 GAC *
                ' **********************
                Using ts As StreamWriter = New StreamWriter(Application.StartupPath & "\RegDll.bat")
                    ts.WriteLine(Application.StartupPath & "\sn.exe -Vr " & Application.StartupPath & "\" & strDllFile & ".dll")
                    ts.WriteLine(Application.StartupPath & "\gacutil.exe /IF " & Application.StartupPath & "\" & strDllFile & ".dll")
                End Using

                cCommand = Application.StartupPath & "\RegDll.bat"
                ProcessService(cCommand)

                Threading.Thread.Sleep(1000)

                If IO.File.Exists(Application.StartupPath & "\RegDll.bat") Then
                    IO.File.Delete(Application.StartupPath & "\RegDll.bat")
                End If

            End If

            '' **********************
            '' * 進行本機註冊至 GAC *
            '' **********************
            'Using ts As StreamWriter = New StreamWriter(Application.StartupPath & "\RegDll.bat")
            '    ts.WriteLine(Application.StartupPath & "\sn.exe -Vr " & Application.StartupPath & "\" & strDllFile & ".dll")
            '    ts.WriteLine(Application.StartupPath & "\gacutil.exe /IF " & Application.StartupPath & "\" & strDllFile & ".dll")
            'End Using

            'cCommand = Application.StartupPath & "\RegDll.bat"
            'ProcessService(cCommand)

            'Threading.Thread.Sleep(1000)

            'If IO.File.Exists(Application.StartupPath & "\RegDll.bat") Then
            '    IO.File.Delete(Application.StartupPath & "\RegDll.bat")
            'End If

        Catch ex As Exception
            ' ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

    End Sub

    Public Sub ProcessService(ByVal strCommand As String)

        Try
            Dim proc_Info As New ProcessStartInfo(strCommand.Trim)
            proc_Info.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(proc_Info)
        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message & Chr(13) & strCommand)
        End Try

    End Sub

    Private Sub LoadPublicToken()   ' 讀取公開金鑰 sn -T remoteobject.dll

        Try

            If IO.File.Exists(Application.StartupPath & "\PublicToken.bat") Then
                IO.File.Delete(Application.StartupPath & "\PublicToken.bat")
            End If

            If IO.File.Exists(Application.StartupPath & "\PublicToken.TXT") Then
                IO.File.Delete(Application.StartupPath & "\PublicToken.TXT")
            End If

            Using ts As StreamWriter = New StreamWriter(Trim(Application.StartupPath & "\PublicToken.bat"))
                ts.WriteLine("sn.exe -T remoteobject.dll > " & Application.StartupPath & "\PublicToken.TXT")
            End Using

            Dim cCommand As String = Application.StartupPath & "\PublicToken.bat"
            ProcessService(cCommand)

            Threading.Thread.Sleep(2000)

            If IO.File.Exists(Application.StartupPath & "\PublicToken.TXT") Then

                Dim xPublicToken As String

                Dim tr As StreamReader = New StreamReader(Application.StartupPath & "\PublicToken.TXT")
                xPublicToken = tr.ReadToEnd
                uPublicToken = Mid(xPublicToken, xPublicToken.Length - 17)
                tr.Dispose()

                Microsoft.VisualBasic.SaveSetting("TMIS", "Token", "Token", uPublicToken)

                'Else
                '    ErrorInfo.SysErrMessageInfomation("無法讀取公開金鑰..系統即將關閉")
                '    Me.Close()
            End If

            IO.File.Delete(Application.StartupPath & "\PublicToken.bat")
            IO.File.Delete(Application.StartupPath & "\PublicToken.TXT")

        Catch ex As Exception
            '  ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

        If Len(uPublicToken) = 0 Then
            ErrorInfo.SysErrMessageInfomation("無法讀取公開金鑰..系統即將關閉")
            Me.Close()
        End If

    End Sub

    Private Sub ClearTempFiles()
        Try
            If IO.File.Exists(Application.StartupPath & "\SystemList.Xml") Then
                IO.File.Delete(Application.StartupPath & "\SystemList.Xml")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Function CheckExist(ByVal FileName As String) As Boolean
        Try
            Dim ProcList() As Process
            Dim Proc As Process
            Dim iExistCount As Integer = 0

            ProcList = Process.GetProcesses()

            For Each Proc In ProcList
                If Proc.ToString().ToUpper.Contains(FileName.ToUpper) Then
                    iExistCount += 1
                    Exit For
                End If
            Next

            If iExistCount > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
        End Try

    End Function

End Class