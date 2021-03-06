'**************************************************************************************
'* Class Name : MainMenuForm
'
'* Description : Menu Screen
'
'* Author : 
'
'* Change History : 
'
'* Data        Owner       ChangeDescription            Level
'* 2007/06/07  Norman Su   Modify SFC to N-Tier System  L1.00
'*
'**************************************************************************************
Imports System.Net.Sockets

Public Class MainMenuForm
    Inherits CommonModule.BaseForm
    'Inherits System.Windows.Forms.Form

#Region " Windows Form 設計工具產生的程式碼 "

    Public Sub New()
        MyBase.New()

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter3 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter4 As System.Windows.Forms.Splitter
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Splitter5 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter6 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter7 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter8 As System.Windows.Forms.Splitter
    Friend WithEvents StatusBarPanel6 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusDataBase As System.Windows.Forms.StatusBar
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Splitter9 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter10 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter11 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter12 As System.Windows.Forms.Splitter
    Friend WithEvents StatusBarPanel7 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel8 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents TreeViewFunction As System.Windows.Forms.TreeView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TreeViewDataBase As System.Windows.Forms.TreeView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents SysStatus As System.Windows.Forms.StatusBar
    Friend WithEvents SysStatusPanel0 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents SysStatusPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents StatusBarPanel5 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTH1 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTH2 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTM1 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTS2 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTM2 As System.Windows.Forms.PictureBox
    Friend WithEvents PBTS1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LabMAC As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents LabMessage As System.Windows.Forms.Label
    Friend WithEvents FSWdll As System.IO.FileSystemWatcher
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents LisDBInfo As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents BtnRefershFunction As System.Windows.Forms.Button
    Friend WithEvents SysStatusPanel2 As System.Windows.Forms.StatusBarPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenuForm))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.BtnRefershFunction = New System.Windows.Forms.Button
        Me.TreeViewFunction = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Splitter4 = New System.Windows.Forms.Splitter
        Me.Splitter3 = New System.Windows.Forms.Splitter
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TreeViewDataBase = New System.Windows.Forms.TreeView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Splitter8 = New System.Windows.Forms.Splitter
        Me.Splitter7 = New System.Windows.Forms.Splitter
        Me.Splitter6 = New System.Windows.Forms.Splitter
        Me.Splitter5 = New System.Windows.Forms.Splitter
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.Button2 = New System.Windows.Forms.Button
        Me.Splitter12 = New System.Windows.Forms.Splitter
        Me.Splitter11 = New System.Windows.Forms.Splitter
        Me.Splitter10 = New System.Windows.Forms.Splitter
        Me.Splitter9 = New System.Windows.Forms.Splitter
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.Button3 = New System.Windows.Forms.Button
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.LisDBInfo = New System.Windows.Forms.ListView
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusDataBase = New System.Windows.Forms.StatusBar
        Me.StatusBarPanel5 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel6 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel7 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel8 = New System.Windows.Forms.StatusBarPanel
        Me.SysStatus = New System.Windows.Forms.StatusBar
        Me.SysStatusPanel0 = New System.Windows.Forms.StatusBarPanel
        Me.SysStatusPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.SysStatusPanel2 = New System.Windows.Forms.StatusBarPanel
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PBTH1 = New System.Windows.Forms.PictureBox
        Me.PBTH2 = New System.Windows.Forms.PictureBox
        Me.PBTM1 = New System.Windows.Forms.PictureBox
        Me.PBTS2 = New System.Windows.Forms.PictureBox
        Me.PBTM2 = New System.Windows.Forms.PictureBox
        Me.PBTS1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.LabMAC = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LabMessage = New System.Windows.Forms.Label
        Me.FSWdll = New System.IO.FileSystemWatcher
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.StatusBarPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SysStatusPanel0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SysStatusPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SysStatusPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTH1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTH2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTM1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTM2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTS1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FSWdll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TabControl1.ItemSize = New System.Drawing.Size(90, 20)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.ShowToolTips = True
        Me.TabControl1.Size = New System.Drawing.Size(282, 515)
        Me.TabControl1.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.TabControl1, "  ")
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.BtnRefershFunction)
        Me.TabPage1.Controls.Add(Me.TreeViewFunction)
        Me.TabPage1.Controls.Add(Me.Splitter4)
        Me.TabPage1.Controls.Add(Me.Splitter3)
        Me.TabPage1.Controls.Add(Me.Splitter2)
        Me.TabPage1.Controls.Add(Me.Splitter1)
        Me.TabPage1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.ImageIndex = 0
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(274, 487)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "功能表"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'BtnRefershFunction
        '
        Me.BtnRefershFunction.BackgroundImage = CType(resources.GetObject("BtnRefershFunction.BackgroundImage"), System.Drawing.Image)
        Me.BtnRefershFunction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnRefershFunction.Location = New System.Drawing.Point(9, 35)
        Me.BtnRefershFunction.Name = "BtnRefershFunction"
        Me.BtnRefershFunction.Size = New System.Drawing.Size(29, 32)
        Me.BtnRefershFunction.TabIndex = 5
        Me.BtnRefershFunction.UseVisualStyleBackColor = True
        '
        'TreeViewFunction
        '
        Me.TreeViewFunction.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TreeViewFunction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeViewFunction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewFunction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeViewFunction.FullRowSelect = True
        Me.TreeViewFunction.HideSelection = False
        Me.TreeViewFunction.HotTracking = True
        Me.TreeViewFunction.ImageIndex = 0
        Me.TreeViewFunction.ImageList = Me.ImageList1
        Me.TreeViewFunction.Indent = 19
        Me.TreeViewFunction.LineColor = System.Drawing.Color.DarkGray
        Me.TreeViewFunction.Location = New System.Drawing.Point(6, 6)
        Me.TreeViewFunction.Margin = New System.Windows.Forms.Padding(1)
        Me.TreeViewFunction.Name = "TreeViewFunction"
        Me.TreeViewFunction.SelectedImageIndex = 2
        Me.TreeViewFunction.ShowNodeToolTips = True
        Me.TreeViewFunction.ShowPlusMinus = False
        Me.TreeViewFunction.Size = New System.Drawing.Size(260, 473)
        Me.TreeViewFunction.TabIndex = 4
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "bullet_ball_red.ico")
        Me.ImageList1.Images.SetKeyName(1, "bullet_ball_glass_yellow.ico")
        Me.ImageList1.Images.SetKeyName(2, "bullet_triangle_blue.ico")
        Me.ImageList1.Images.SetKeyName(3, "bullet_ball_glass_grey.ico")
        '
        'Splitter4
        '
        Me.Splitter4.BackColor = System.Drawing.Color.AliceBlue
        Me.Splitter4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter4.Enabled = False
        Me.Splitter4.Location = New System.Drawing.Point(6, 479)
        Me.Splitter4.Margin = New System.Windows.Forms.Padding(1)
        Me.Splitter4.MinExtra = 15
        Me.Splitter4.MinSize = 15
        Me.Splitter4.Name = "Splitter4"
        Me.Splitter4.Size = New System.Drawing.Size(260, 6)
        Me.Splitter4.TabIndex = 3
        Me.Splitter4.TabStop = False
        '
        'Splitter3
        '
        Me.Splitter3.BackColor = System.Drawing.Color.AliceBlue
        Me.Splitter3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter3.Enabled = False
        Me.Splitter3.Location = New System.Drawing.Point(266, 6)
        Me.Splitter3.Margin = New System.Windows.Forms.Padding(1)
        Me.Splitter3.MinExtra = 15
        Me.Splitter3.MinSize = 15
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(6, 479)
        Me.Splitter3.TabIndex = 2
        Me.Splitter3.TabStop = False
        '
        'Splitter2
        '
        Me.Splitter2.BackColor = System.Drawing.Color.AliceBlue
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter2.Enabled = False
        Me.Splitter2.Location = New System.Drawing.Point(6, 0)
        Me.Splitter2.Margin = New System.Windows.Forms.Padding(1)
        Me.Splitter2.MinExtra = 15
        Me.Splitter2.MinSize = 15
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(266, 6)
        Me.Splitter2.TabIndex = 1
        Me.Splitter2.TabStop = False
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.AliceBlue
        Me.Splitter1.Enabled = False
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(1)
        Me.Splitter1.MinExtra = 15
        Me.Splitter1.MinSize = 15
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(6, 485)
        Me.Splitter1.TabIndex = 0
        Me.Splitter1.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.Controls.Add(Me.TreeViewDataBase)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Splitter8)
        Me.TabPage2.Controls.Add(Me.Splitter7)
        Me.TabPage2.Controls.Add(Me.Splitter6)
        Me.TabPage2.Controls.Add(Me.Splitter5)
        Me.TabPage2.ImageIndex = 1
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(274, 487)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "廠區"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TreeViewDataBase
        '
        Me.TreeViewDataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeViewDataBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewDataBase.FullRowSelect = True
        Me.TreeViewDataBase.HideSelection = False
        Me.TreeViewDataBase.HotTracking = True
        Me.TreeViewDataBase.Location = New System.Drawing.Point(6, 50)
        Me.TreeViewDataBase.Name = "TreeViewDataBase"
        Me.TreeViewDataBase.Size = New System.Drawing.Size(262, 431)
        Me.TreeViewDataBase.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.TreeViewDataBase, "來自於 TIPTOP 系統的設定" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "若無法呈現時, 請檢查登錄帳戶需是 TIPTOP 合法帳戶" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    或 TIPTOP 系統暫無法連線取得, 請重新登錄或委請" & _
                "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    專人處理")
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Firebrick
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.Location = New System.Drawing.Point(6, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(262, 44)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "廠區"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Splitter8
        '
        Me.Splitter8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter8.Enabled = False
        Me.Splitter8.Location = New System.Drawing.Point(6, 481)
        Me.Splitter8.Name = "Splitter8"
        Me.Splitter8.Size = New System.Drawing.Size(262, 6)
        Me.Splitter8.TabIndex = 4
        Me.Splitter8.TabStop = False
        '
        'Splitter7
        '
        Me.Splitter7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter7.Enabled = False
        Me.Splitter7.Location = New System.Drawing.Point(268, 6)
        Me.Splitter7.Name = "Splitter7"
        Me.Splitter7.Size = New System.Drawing.Size(6, 481)
        Me.Splitter7.TabIndex = 3
        Me.Splitter7.TabStop = False
        '
        'Splitter6
        '
        Me.Splitter6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter6.Enabled = False
        Me.Splitter6.Location = New System.Drawing.Point(6, 0)
        Me.Splitter6.Name = "Splitter6"
        Me.Splitter6.Size = New System.Drawing.Size(268, 6)
        Me.Splitter6.TabIndex = 2
        Me.Splitter6.TabStop = False
        '
        'Splitter5
        '
        Me.Splitter5.Enabled = False
        Me.Splitter5.Location = New System.Drawing.Point(0, 0)
        Me.Splitter5.Name = "Splitter5"
        Me.Splitter5.Size = New System.Drawing.Size(6, 487)
        Me.Splitter5.TabIndex = 1
        Me.Splitter5.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.AutoScroll = True
        Me.TabPage3.Controls.Add(Me.TreeView1)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.Splitter12)
        Me.TabPage3.Controls.Add(Me.Splitter11)
        Me.TabPage3.Controls.Add(Me.Splitter10)
        Me.TabPage3.Controls.Add(Me.Splitter9)
        Me.TabPage3.ImageIndex = 2
        Me.TabPage3.Location = New System.Drawing.Point(4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(274, 487)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "設備"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.HideSelection = False
        Me.TreeView1.HotTracking = True
        Me.TreeView1.Location = New System.Drawing.Point(6, 50)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(262, 431)
        Me.TreeView1.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.TreeView1, "請至E005設備使用作業建立設定")
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Firebrick
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.Location = New System.Drawing.Point(6, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(262, 44)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "設備"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Splitter12
        '
        Me.Splitter12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter12.Enabled = False
        Me.Splitter12.Location = New System.Drawing.Point(6, 481)
        Me.Splitter12.Name = "Splitter12"
        Me.Splitter12.Size = New System.Drawing.Size(262, 6)
        Me.Splitter12.TabIndex = 5
        Me.Splitter12.TabStop = False
        '
        'Splitter11
        '
        Me.Splitter11.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter11.Enabled = False
        Me.Splitter11.Location = New System.Drawing.Point(268, 6)
        Me.Splitter11.Name = "Splitter11"
        Me.Splitter11.Size = New System.Drawing.Size(6, 481)
        Me.Splitter11.TabIndex = 4
        Me.Splitter11.TabStop = False
        '
        'Splitter10
        '
        Me.Splitter10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter10.Enabled = False
        Me.Splitter10.Location = New System.Drawing.Point(6, 0)
        Me.Splitter10.Name = "Splitter10"
        Me.Splitter10.Size = New System.Drawing.Size(268, 6)
        Me.Splitter10.TabIndex = 3
        Me.Splitter10.TabStop = False
        '
        'Splitter9
        '
        Me.Splitter9.Enabled = False
        Me.Splitter9.Location = New System.Drawing.Point(0, 0)
        Me.Splitter9.Name = "Splitter9"
        Me.Splitter9.Size = New System.Drawing.Size(6, 487)
        Me.Splitter9.TabIndex = 2
        Me.Splitter9.TabStop = False
        '
        'TabPage4
        '
        Me.TabPage4.AutoScroll = True
        Me.TabPage4.Controls.Add(Me.ListView1)
        Me.TabPage4.Controls.Add(Me.Button3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(274, 487)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "電腦資訊"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(0, 44)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(274, 443)
        Me.ListView1.TabIndex = 8
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "電腦名稱"
        Me.ColumnHeader1.Width = 108
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "IP位址"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "MAC"
        Me.ColumnHeader3.Width = 80
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Firebrick
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.Location = New System.Drawing.Point(0, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(274, 44)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "電腦"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.LisDBInfo)
        Me.TabPage5.Controls.Add(Me.Button4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(274, 487)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'LisDBInfo
        '
        Me.LisDBInfo.CheckBoxes = True
        Me.LisDBInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LisDBInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LisDBInfo.FullRowSelect = True
        Me.LisDBInfo.GridLines = True
        Me.LisDBInfo.Location = New System.Drawing.Point(3, 47)
        Me.LisDBInfo.Name = "LisDBInfo"
        Me.LisDBInfo.Size = New System.Drawing.Size(268, 437)
        Me.LisDBInfo.TabIndex = 9
        Me.LisDBInfo.UseCompatibleStateImageBehavior = False
        Me.LisDBInfo.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "資料庫名稱"
        Me.ColumnHeader4.Width = 108
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "空間量"
        Me.ColumnHeader5.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "已用量"
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "使用率"
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Firebrick
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.Location = New System.Drawing.Point(3, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(268, 44)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "電腦"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Chocolate
        Me.Label1.Enabled = False
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(289, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 25)
        Me.Label1.TabIndex = 107
        Me.Label1.Visible = False
        '
        'StatusDataBase
        '
        Me.StatusDataBase.Cursor = System.Windows.Forms.Cursors.Help
        Me.StatusDataBase.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusDataBase.Enabled = False
        Me.StatusDataBase.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusDataBase.Location = New System.Drawing.Point(282, 0)
        Me.StatusDataBase.Name = "StatusDataBase"
        Me.StatusDataBase.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel5, Me.StatusBarPanel6, Me.StatusBarPanel7, Me.StatusBarPanel8})
        Me.StatusDataBase.ShowPanels = True
        Me.StatusDataBase.Size = New System.Drawing.Size(653, 21)
        Me.StatusDataBase.SizingGrip = False
        Me.StatusDataBase.TabIndex = 25
        '
        'StatusBarPanel5
        '
        Me.StatusBarPanel5.Icon = CType(resources.GetObject("StatusBarPanel5.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel5.Name = "StatusBarPanel5"
        Me.StatusBarPanel5.Width = 113
        '
        'StatusBarPanel6
        '
        Me.StatusBarPanel6.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel6.Icon = CType(resources.GetObject("StatusBarPanel6.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel6.Name = "StatusBarPanel6"
        Me.StatusBarPanel6.Width = 170
        '
        'StatusBarPanel7
        '
        Me.StatusBarPanel7.Icon = CType(resources.GetObject("StatusBarPanel7.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel7.Name = "StatusBarPanel7"
        Me.StatusBarPanel7.Width = 110
        '
        'StatusBarPanel8
        '
        Me.StatusBarPanel8.Name = "StatusBarPanel8"
        Me.StatusBarPanel8.Width = 260
        '
        'SysStatus
        '
        Me.SysStatus.Location = New System.Drawing.Point(282, 493)
        Me.SysStatus.Name = "SysStatus"
        Me.SysStatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SysStatusPanel0, Me.SysStatusPanel1, Me.SysStatusPanel2, Me.StatusBarPanel1})
        Me.SysStatus.ShowPanels = True
        Me.SysStatus.Size = New System.Drawing.Size(653, 22)
        Me.SysStatus.SizingGrip = False
        Me.SysStatus.TabIndex = 27
        '
        'SysStatusPanel0
        '
        Me.SysStatusPanel0.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.SysStatusPanel0.Icon = CType(resources.GetObject("SysStatusPanel0.Icon"), System.Drawing.Icon)
        Me.SysStatusPanel0.Name = "SysStatusPanel0"
        Me.SysStatusPanel0.Width = 176
        '
        'SysStatusPanel1
        '
        Me.SysStatusPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.SysStatusPanel1.Icon = CType(resources.GetObject("SysStatusPanel1.Icon"), System.Drawing.Icon)
        Me.SysStatusPanel1.Name = "SysStatusPanel1"
        Me.SysStatusPanel1.Width = 176
        '
        'SysStatusPanel2
        '
        Me.SysStatusPanel2.Icon = CType(resources.GetObject("SysStatusPanel2.Icon"), System.Drawing.Icon)
        Me.SysStatusPanel2.Name = "SysStatusPanel2"
        Me.SysStatusPanel2.Width = 120
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.Icon = CType(resources.GetObject("StatusBarPanel1.Icon"), System.Drawing.Icon)
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Width = 180
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "0_i.gif")
        Me.ImageList2.Images.SetKeyName(1, "1_i.gif")
        Me.ImageList2.Images.SetKeyName(2, "2_i.gif")
        Me.ImageList2.Images.SetKeyName(3, "3_i.gif")
        Me.ImageList2.Images.SetKeyName(4, "4_i.gif")
        Me.ImageList2.Images.SetKeyName(5, "5_i.gif")
        Me.ImageList2.Images.SetKeyName(6, "6_i.gif")
        Me.ImageList2.Images.SetKeyName(7, "7_i.gif")
        Me.ImageList2.Images.SetKeyName(8, "8_i.gif")
        Me.ImageList2.Images.SetKeyName(9, "9_i.gif")
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(262, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 93
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "若不需要呈現時間, 請用滑鼠左鍵按一下吧!")
        '
        'PBTH1
        '
        Me.PBTH1.BackColor = System.Drawing.Color.Khaki
        Me.PBTH1.Location = New System.Drawing.Point(34, 59)
        Me.PBTH1.Name = "PBTH1"
        Me.PBTH1.Size = New System.Drawing.Size(27, 31)
        Me.PBTH1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBTH1.TabIndex = 94
        Me.PBTH1.TabStop = False
        '
        'PBTH2
        '
        Me.PBTH2.BackColor = System.Drawing.Color.Khaki
        Me.PBTH2.Location = New System.Drawing.Point(64, 59)
        Me.PBTH2.Name = "PBTH2"
        Me.PBTH2.Size = New System.Drawing.Size(27, 31)
        Me.PBTH2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBTH2.TabIndex = 95
        Me.PBTH2.TabStop = False
        '
        'PBTM1
        '
        Me.PBTM1.BackColor = System.Drawing.Color.Khaki
        Me.PBTM1.Location = New System.Drawing.Point(108, 59)
        Me.PBTM1.Name = "PBTM1"
        Me.PBTM1.Size = New System.Drawing.Size(27, 31)
        Me.PBTM1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBTM1.TabIndex = 96
        Me.PBTM1.TabStop = False
        '
        'PBTS2
        '
        Me.PBTS2.BackColor = System.Drawing.Color.Khaki
        Me.PBTS2.Location = New System.Drawing.Point(212, 59)
        Me.PBTS2.Name = "PBTS2"
        Me.PBTS2.Size = New System.Drawing.Size(27, 31)
        Me.PBTS2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBTS2.TabIndex = 99
        Me.PBTS2.TabStop = False
        '
        'PBTM2
        '
        Me.PBTM2.BackColor = System.Drawing.Color.Khaki
        Me.PBTM2.Location = New System.Drawing.Point(138, 59)
        Me.PBTM2.Name = "PBTM2"
        Me.PBTM2.Size = New System.Drawing.Size(27, 31)
        Me.PBTM2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBTM2.TabIndex = 97
        Me.PBTM2.TabStop = False
        '
        'PBTS1
        '
        Me.PBTS1.BackColor = System.Drawing.Color.Khaki
        Me.PBTS1.Location = New System.Drawing.Point(182, 59)
        Me.PBTS1.Name = "PBTS1"
        Me.PBTS1.Size = New System.Drawing.Size(27, 31)
        Me.PBTS1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PBTS1.TabIndex = 98
        Me.PBTS1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(93, 73)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 13)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 100
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(93, 62)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 13)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 101
        Me.PictureBox3.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.PictureBox7)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.LabMAC)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.PBTM1)
        Me.Panel1.Controls.Add(Me.PBTS1)
        Me.Panel1.Controls.Add(Me.PBTH1)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PBTH2)
        Me.Panel1.Controls.Add(Me.PBTS2)
        Me.Panel1.Controls.Add(Me.PBTM2)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(653, 345)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(270, 107)
        Me.Panel1.TabIndex = 105
        Me.Panel1.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PictureBox7.BackgroundImage = CType(resources.GetObject("PictureBox7.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox7.Location = New System.Drawing.Point(112, 9)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(146, 32)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 116
        Me.PictureBox7.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(167, 74)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 13)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 111
        Me.PictureBox4.TabStop = False
        '
        'LabMAC
        '
        Me.LabMAC.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.LabMAC.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabMAC.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LabMAC.Location = New System.Drawing.Point(21, 19)
        Me.LabMAC.Name = "LabMAC"
        Me.LabMAC.Size = New System.Drawing.Size(82, 15)
        Me.LabMAC.TabIndex = 111
        Me.LabMAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(167, 63)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(13, 13)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 112
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(913, 497)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 109
        Me.PictureBox6.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox6, "若需要呈現時間, 請用滑鼠左鍵按一下吧!")
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScrollBar1.Location = New System.Drawing.Point(821, 2)
        Me.HScrollBar1.Maximum = 320
        Me.HScrollBar1.Minimum = 50
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(109, 17)
        Me.HScrollBar1.TabIndex = 112
        Me.ToolTip1.SetToolTip(Me.HScrollBar1, "調整左側功能選項寬度")
        Me.HScrollBar1.Value = 282
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProgressBar1.ForeColor = System.Drawing.Color.DarkViolet
        Me.ProgressBar1.Location = New System.Drawing.Point(282, 21)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(653, 10)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 114
        Me.ToolTip1.SetToolTip(Me.ProgressBar1, "超過 5 分鐘不動, 系統自動關閉")
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(894, 497)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 116
        Me.PictureBox8.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox8, "開啟公告")
        '
        'Timer1
        '
        Me.Timer1.Interval = 300000
        '
        'LabMessage
        '
        Me.LabMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabMessage.BackColor = System.Drawing.Color.Orange
        Me.LabMessage.Image = CType(resources.GetObject("LabMessage.Image"), System.Drawing.Image)
        Me.LabMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabMessage.Location = New System.Drawing.Point(423, 2)
        Me.LabMessage.Name = "LabMessage"
        Me.LabMessage.Size = New System.Drawing.Size(138, 18)
        Me.LabMessage.TabIndex = 118
        Me.LabMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FSWdll
        '
        Me.FSWdll.EnableRaisingEvents = True
        Me.FSWdll.Filter = "*.dll"
        Me.FSWdll.NotifyFilter = System.IO.NotifyFilters.LastWrite
        Me.FSWdll.SynchronizingObject = Me
        '
        'MainMenuForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(935, 515)
        Me.Controls.Add(Me.LabMessage)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SysStatus)
        Me.Controls.Add(Me.StatusDataBase)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "MainMenuForm"
        Me.Text = "SFC製造管理系統"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.StatusBarPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SysStatusPanel0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SysStatusPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SysStatusPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTH1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTH2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTM1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTM2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTS1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FSWdll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '  Delegate Sub SetCtlCallBack(ByVal FrmName As String)
    Private Thd As Threading.Thread
    Private SqlCommand As String = ""
    Public xPublicMessage As Form

    Private AppPath As String = System.Environment.CurrentDirectory

    Private Sub MainMenuForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            If Me.ClsDBInfo.datalink(Me.ClsCommonInfo.uLocalIP) Then
                SqlCommand = "update sys9999 set F005=null where F005=" & Me.ClsCommonInfo.uEMP_NOSID & " and F003='" & Me.ClsCommonInfo.uLocalIP & "'"
                Me.ClsDBInfo.ExecuteSQL(SqlCommand)
            End If
        Catch ex As Exception
        End Try

        Me.Owner.Visible = True

    End Sub

    Private Sub MainMenuForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' ******************
        ' * 是否有上料系統 *
        ' ******************
        Try
            Me.ClsCommonInfo.uLinkSajet = Val(Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_SAJET"))
        Catch ex As Exception
        End Try

        Try

            Me.Text = Me.ClsCommonInfo.uSystem

            Panel1.Location = New System.Drawing.Point(Me.Size.Width - 280, Me.Size.Height - 165)

            Timer2.Start()

            SysStatus.Panels(2).Text = Me.ClsCommonInfo.uEmp_account & Me.ClsCommonInfo.uEmp_Nm

            ViewUserFunction()

            If Not ViewUserResource() Then  ' 使用者可使用設備
                LoginForm.Close()
                Exit Sub
            End If

            DisplayInfo()

            LabMAC.Text = Me.ClsCommonInfo.uMac

            If Not UserLogon() Then
                LoginForm.Close()
                Exit Sub
            End If

            Dim strDllName As String = "PublicMessage"

            LoginForm.CheckVersion(strDllName, False)

            ' ***********************************************************************
            Dim OneFileverisioninfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(strDllName & ".dll")
            Dim strGacFileVersion As String = OneFileverisioninfo.ProductVersion
            ' ***********************************************************************        
            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.Load(strDllName & ",Version=" & strGacFileVersion & ",Culture=neutral,PublicKeyToken=" & LoginForm.uPublicToken)
            xPublicMessage = asm.CreateInstance(strDllName & "." & strDllName, True)

            With xPublicMessage
                .MdiParent = Me
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .TopLevel = False
                .TopMost = False
                .ControlBox = False
                .Dock = DockStyle.Fill
            End With

            xPublicMessage.Show()

        Catch ex As Exception
            ' ErrorInfo.SysErrMessageInfomation(ex.Message)
            SaveErrorLogOffLine(My.Computer.Name, ex.Message, ex.StackTrace)
        End Try

        'Thd = New Threading.Thread(AddressOf CheckDll)   ' 僅針對目前登錄者的作業進行 Check
        'Thd.Start()

        'Thd.Abort()
        'Thd = Nothing

        LabMessage.Text = ""

        With ProgressBar1
            .Value = 0
            .Maximum = (Timer1.Interval / 1000) + 1
        End With

        Timer1.Start()

        FileWatchDll()

        TabControl1.TabPages(4).Text = Me.ClsCommonInfo.strBelongServerIP

        ' InitUDPClient()

    End Sub

    Public Sub SaveErrorLogOffLine(ByVal sComputerName As String, ByVal sMessage As String, ByVal sStackTrace As String)
        Try

            Dim ds As New DataSet
            Dim dr As DataRow
            If Not System.IO.Directory.Exists("c:\tmis\Log") Then
                System.IO.Directory.CreateDirectory("c:\tmis\Log")
            End If

            If Not System.IO.File.Exists("c:\tmis\Log\ErrorLog.xml") Then
                ds.Tables.Add("ErrorLog")
                If ds.Tables("ErrorLog").Rows.Count = 0 Then
                    ds.Tables("ErrorLog").Columns.Add("Computer")
                    ds.Tables("ErrorLog").Columns.Add("Time")
                    ds.Tables("ErrorLog").Columns.Add("Message")
                    ds.Tables("ErrorLog").Columns.Add("StackTrace")
                End If
            Else
                ds.ReadXml("c:\tmis\Log\ErrorLog.xml")
            End If

            dr = ds.Tables("ErrorLog").NewRow()
            dr.Item(0) = sComputerName.Trim()
            dr.Item(1) = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss")
            dr.Item(2) = sMessage.Trim()
            dr.Item(3) = sStackTrace.Trim()
            ds.Tables("ErrorLog").Rows.Add(dr)
            ds.Tables("ErrorLog").WriteXml("c:\tmis\Log\ErrorLog.xml")
            ds.Tables("ErrorLog").Clear()
            ds.Tables("ErrorLog").Dispose()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DisplayInfo()

        GetDataBaseID()
        Catch_machineID()    ' 取得機台設備資料識別碼

        Me.ClsCommonInfo.uIsDisplayInfo = False

    End Sub

    Private Sub ViewUserFunction()

        ' **************************
        ' * 連線並載入該使用者作業 *
        ' **************************

        Try
            If Me.ClsDBInfo.datalink(Me.ClsCommonInfo.uLocalIP) Then

                SqlCommand = "select distinct F002,F003,F005, 1 as effec" & _
                                    ",0 as flag" & _
                                    ",nvl(F008,F002) as F008" & _
                                    ",f006" & _
                                    ",nvl(F010,0) as F010" & _
                              " from SYS0001" & _
                             " where F007=1" & _
                               " and F005=F001" & _
                             " union all " & _
                             "select F002,F003,F005, nvl(effec,0) as effec, 1 as flag,F008,f006,nvl(F010,0) as F010" & _
                              " from SYS0003_VW0001" & _
                             " where UsrSid=" & Trim(Me.ClsCommonInfo.uEMP_NOSID) & _
                             " order by F005,flag,f006,1"

                Dim Tablename2 As New DataTable("datatable2")

                Me.ClsDBInfo.ExecuteSQL(SqlCommand, Tablename2)

                Tablename2.WriteXml(Application.StartupPath & "\SystemList.Xml")

                ' ****************************
                ' * 將作業項目建構於功能表中 *
                ' ****************************

                TreeViewFunction.BeginUpdate()
                TreeViewFunction.Nodes.Clear()

                Dim I, J, X As Integer
                Dim FuncNode As TreeNode = New TreeNode

                For I = 0 To Tablename2.Rows.Count - 1

                    FuncNode.Text = Trim(Tablename2.Rows(I).Item(0)) & " " & Trim(Tablename2.Rows(I).Item(1))
                    FuncNode.Tag = Chr(31 + Tablename2.Rows(I).Item(3)) & Trim(Tablename2.Rows(I).Item(5))         ' 程式編號別名
                    FuncNode.ImageIndex = 3

                    X = Tablename2.Rows(I).Item(2)

                    While X = Tablename2.Rows(I).Item(2)

                        If Tablename2.Rows(I).Item(4) <> 0 Then   ' 0: Menu
                            J = FuncNode.Nodes.Count
                            FuncNode.Nodes.Add(Trim(Tablename2.Rows(I).Item(0)) & " " & Trim(Tablename2.Rows(I).Item(1)) & Chr(175) & Trim(Tablename2.Rows(I).Item(7)))
                            FuncNode.Nodes(J).Tag = Chr(31 + Tablename2.Rows(I).Item(3)) & Trim(Tablename2.Rows(I).Item(5)) ' 程式編號別名
                            FuncNode.Nodes(J).ImageIndex = (Tablename2.Rows(I).Item(3))                                     ' 有無權限
                        End If

                        I += 1

                        If I = Tablename2.Rows.Count Then
                            Exit While
                        End If

                    End While

                    TreeViewFunction.Nodes.Add(FuncNode.Clone)
                    FuncNode.Nodes.Clear()

                    I -= 1

                Next

                FuncNode = Nothing
                Tablename2 = New DataTable("datatable2")
                SqlCommand = "select F002 from SYS0000 where rownum=1"
                Me.ClsDBInfo.ExecuteSQL(SqlCommand, Tablename2)

                If Tablename2.Rows.Count > 0 Then
                    Me.Text = Mid(Me.Text, 1, InStr(Me.Text, Chr(255))) & "(" & Tablename2.Rows(0).Item(0) & ") [" & Me.ClsCommonInfo.uComputerName & "]"
                End If

            End If

        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
            SaveErrorLogOffLine(My.Computer.Name, ex.Message, ex.StackTrace)
        End Try

        TreeViewFunction.EndUpdate()
        TreeViewFunction.ExpandAll()

        If TreeViewFunction.GetNodeCount(True) > 0 Then
            TreeViewFunction.SelectedNode = TreeViewFunction.Nodes(0)
        End If

    End Sub

    Private Sub GetDataBaseID()   ' 載入本機隸屬廠區

        Me.ClsDBInfo.uDataBaseID = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "DataBaseID")
        StatusDataBase.Panels(0).Text = Me.ClsDBInfo.uDataBaseID

        If Len(Me.ClsDBInfo.uDataBaseID) = 0 Then
            Connection_Ifx()
        Else
            Me.ClsDBInfo.uDataBase = Me.ClsDBInfo.uDataBaseID
        End If

    End Sub

    Private Sub Connection_Ifx()

        Try
            ' ******************************************************************
            ' * 連到 TipTop 系統, 用預設值連線, 目的是先取得該使用者資料庫權限 *
            ' ******************************************************************

            If Me.ClsDBInfo.IFXlink("ds") Then

                ' **********************************
                ' * 取得使用者目前系統擁有的資料庫 *
                ' **********************************
                TreeViewDataBase.Nodes.Clear()
                SqlCommand = "select distinct azp02,azp03" & _
                             "  from zxy_file,azp_file" & _
                             " where zxy01='" & Trim(Me.ClsCommonInfo.uEmp_account) & "'" & _
                               " and zxy03=azp01"

                Dim Tablename1 As New DataTable("datatable1")

                Me.ClsDBInfo.ExecuteInformix(SqlCommand, Tablename1)

                Dim I As Integer
                Dim NodeText As String

                For I = 0 To Tablename1.Rows.Count - 1
                    NodeText = Trim(Tablename1.Rows(I).Item("azp02"))
                    TreeViewDataBase.Nodes.Add(NodeText)
                    TreeViewDataBase.Nodes(TreeViewDataBase.GetNodeCount(True) - 1).Tag = Trim(Tablename1.Rows(I).Item("azp03"))
                Next

                ' ********************************************
                ' * 使用者在前次使用 TIPTOP 系統所用的資料庫 *
                ' ********************************************
                If Tablename1.Rows.Count > 0 Then

                    SqlCommand = "select first 1 azp02,azp03" & _
                                  " from zx_file,azp_file" & _
                                 " where zx01='" & Trim(Me.ClsCommonInfo.uEmp_account) & "'"

                    Tablename1 = New DataTable("datatable2")

                    Me.ClsDBInfo.ExecuteInformix(SqlCommand, Tablename1)

                    If Tablename1.Rows.Count > 0 Then
                        Me.ClsDBInfo.uDataBaseName = Trim(Tablename1.Rows(0).Item("azp02"))
                        Me.ClsDBInfo.uDataBase = Trim(Tablename1.Rows(0).Item("azp03"))
                        StatusDataBase.Panels(0).Text = Me.ClsDBInfo.uDataBase
                        StatusDataBase.Panels(1).Text = Me.ClsDBInfo.uDataBaseName
                    End If

                End If

                Tablename1 = Nothing

            End If
        Catch ex As IBM.Data.Informix.IfxException
            ErrorInfo.SysErrMessageInfomation(ex.Message)
        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

    End Sub

    Private Function ViewUserResource() As Boolean ' 使用者可使用設備

        Dim XcheckOk As Boolean = False

        ' ********************************
        ' * 連線並載入該使用者可使用設備 *
        ' ********************************

        Try
            If Me.ClsDBInfo.datalink(Me.ClsCommonInfo.uLocalIP) Then

                SqlCommand = "select distinct SE03.F001,SE03.F002,SE03.F003,SE03.F005,nvl(SE03.F009,0) as F009" & _
                              " from MSE0059 SE59,MSE0003 SE03" & _
                             " where SE59.F002=" & Trim(Me.ClsCommonInfo.uEMP_NOSID) & _
                               " and SE59.F003=SE03.F001" & _
                               " and SE03.F006=1" & _
                             " order by SE03.F002"

                Dim Tablename2 As New DataTable("datatable2")

                Me.ClsDBInfo.ExecuteSQL(SqlCommand, Tablename2)

                ' *********************************
                ' * 將可使用設備放置 TREEVIEW1 中 *
                ' *********************************

                TreeView1.Nodes.Clear()

                Dim I As Integer = 0

                For I = 0 To Tablename2.Rows.Count - 1
                    TreeView1.Nodes.Add(Trim(Tablename2.Rows(I).Item("F002")) & " " & _
                                        Trim(Tablename2.Rows(I).Item("F003")) & Chr(175) & _
                                        Trim(Tablename2.Rows(I).Item("F005")) & Chr(176) & _
                                        Trim(Tablename2.Rows(I).Item("F009")))                 ' 設備編號 & 設備名稱 & 設備類別
                    TreeView1.Nodes(I).Tag = Tablename2.Rows(I).Item("F001")                   ' 設備資料識別碼
                Next

                'Tablename2 = Nothing

                ' **********************
                ' * 取得本機所設定作業 *
                ' **********************
                SqlCommand = "select F001,F002,F003" & _
                              " from MSE0009" & _
                             " where F001=" & Me.ClsCommonInfo.uO_IDNo & _
                               " and F004=1"

                Tablename2 = New DataTable("Tablename2")

                Me.ClsDBInfo.ExecuteSQL(SqlCommand, Tablename2)

                If Tablename2.Rows.Count > 0 Then
                    SysStatus.Panels(0).Text = "(" & Trim(Tablename2.Rows(0).Item(0)) & ")" & Trim(Tablename2.Rows(0).Item(1)) & " " & Trim(Tablename2.Rows(0).Item(2))
                Else
                    Me.ClsCommonInfo.uM_IDNo = -1
                    Dim xWarnForm As New UpdateForm
                    With xWarnForm
                        .Tag = "本機設定作業項目無效"
                    End With
                    xWarnForm.ShowDialog()
                    Exit Try
                End If

                ' **********************
                ' * 取得本機所設定機台 *
                ' **********************
                SqlCommand = "select MSE0003.F001,MSE0003.F002,MSE0003.F003,nvl(MSE0003.F009,0) as F009, nvl(MSE0003.F014,'') as F014" & _
                              " from MSE0003,MSE0010" & _
                             " where MSE0003.F001=" & Me.ClsCommonInfo.uM_IDNo & _
                               " and MSE0003.F006=1" & _
                               " and MSE0003.F005=MSE0010.F003" & _
                               " and MSE0010.F002=" & Me.ClsCommonInfo.uO_IDNo & _
                               " and MSE0010.F005=1"

                Tablename2 = New DataTable("Tablename2")

                Me.ClsDBInfo.ExecuteSQL(SqlCommand, Tablename2)

                If Tablename2.Rows.Count > 0 Then

                    If UCase(Trim(Tablename2.Rows(0).Item(4))) = UCase(Me.ClsCommonInfo.uComputerName) Then

                        SysStatus.Panels(1).Text = "(" & Trim(Tablename2.Rows(0).Item(0)) & ")" & _
                                                   Trim(Tablename2.Rows(0).Item(1)) & " " & _
                                                   Trim(Tablename2.Rows(0).Item(2)) & Chr(176) & _
                                                   Trim(Tablename2.Rows(0).Item(3))
                    Else
                        Me.ClsCommonInfo.uM_IDNo = -1
                        Dim xWarnForm As New UpdateForm
                        With xWarnForm
                            .Tag = "本機所設定機台設備已被 " & Trim(Tablename2.Rows(0).Item(4)) & " 設定!"
                        End With

                        xWarnForm.ShowDialog()
                        Exit Try
                    End If

                Else
                    Me.ClsCommonInfo.uM_IDNo = -1
                    Dim xWarnForm As New UpdateForm
                    With xWarnForm
                        .Tag = "本機所設定機台設備無效"
                    End With

                    xWarnForm.ShowDialog()
                    Exit Try
                End If

                ' ********************
                ' * 取得連線至資料庫 *
                ' ********************
                SqlCommand = "select USERNAME,DEFAULT_TABLESPACE" & _
                              " from user_users" & _
                             " where username=(select user from dual)" & _
                               " and upper(account_status)='OPEN'" & _
                               " order by 2"

                Tablename2 = New DataTable("Tablename2")

                Me.ClsDBInfo.ExecuteSQL(SqlCommand, Tablename2)

                If Tablename2.Rows.Count > 0 Then
                    SysStatus.Panels(3).Text = Trim(Tablename2.Rows(0).Item(0)) & "@" & Trim(Tablename2.Rows(0).Item(1))
                    XcheckOk = True
                Else
                    SysStatus.Panels(1).Text = "????"
                End If

                Tablename2.Dispose()
            End If

            'Catch ex As OracleClient.OracleException
            '    If InStr(2, ex.Message, "ORA-") > 0 Then
            '        ErrorInfo.SysErrMessageInfomation(Mid(ex.Message, 1, InStr(2, ex.Message, "ORA-") - 1))
            '    Else
            '        ErrorInfo.SysErrMessageInfomation(ex.Message)
            '    End If
        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
            SaveErrorLogOffLine(My.Computer.Name, ex.Message, ex.StackTrace)
        End Try

        TreeView1.ExpandAll()

        If TreeView1.GetNodeCount(True) > 0 Then
            TreeView1.SelectedNode = TreeView1.Nodes(0)
        End If

        Return XcheckOk

    End Function

    Private Sub exit_clicked(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub MainMenuForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        LoginForm.processExit(True)
        LoginForm.Show()
    End Sub

    Private Sub TreeOpen(ByVal cProgName As String, ByVal cFormText As String, ByVal cVerision As String)

        System.Environment.CurrentDirectory = Me.ClsCommonInfo.uAppPath

        Try

            If Not ChkOpenForm(cProgName) Then

                LoginForm.CheckVersion(cProgName, False)

                ' ***********************************************************************
                Dim OneFileverisioninfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Me.ClsCommonInfo.uAppPath & "\" & cProgName & ".dll")
                'MsgBox("cprogname:" & cProgName & "  cFormText" & cFormText & "  cVersion:" & cVerision)
                Dim strGacFileVersion As String = IIf(Len(cVerision) > 0, cVerision, OneFileverisioninfo.ProductVersion)
                ' ***********************************************************************
                Dim objFORM As New Form
                'MsgBox(LoginForm.uPublicToken)
                Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.Load(cProgName & ",Version=" & strGacFileVersion & ",Culture=neutral,PublicKeyToken=" & LoginForm.uPublicToken)
                objFORM = asm.CreateInstance(cProgName & "." & cProgName, True)

                Dim intFormWidth As Integer = objFORM.Size.Width
                Dim intFormHeight As Integer = objFORM.Size.Height

                With objFORM
                    .MdiParent = Me
                    .StartPosition = FormStartPosition.CenterScreen
                    .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
                    .Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    .Icon = Me.Icon
                    .ControlBox = True
                    .MaximizeBox = False
                    .MinimizeBox = True
                    .TopMost = True
                    .Text = cFormText & " (" & .ProductVersion & ")"
                    .Size = New System.Drawing.Size(intFormWidth, intFormHeight)
                End With

                StatusDataBase.Panels(2).Text = cProgName

                LoginForm.SendInfo("<USER_ACTION>" & Chr(9) & LoginForm.strWatchDogHost_IP & Chr(9) & Me.ClsCommonInfo.uLocalIP & Chr(9) & _
                                          Me.ClsCommonInfo.uLocalIP & " 開啟: " & cFormText & Chr(9), LoginForm.SendSFCAPMIPendpoint)

                objFORM.Show()

                TreeViewFunction.SelectedNode.ToolTipText = strGacFileVersion

            Else
                StatusDataBase.Panels(2).Text = "作業不可再度被開啟.."
            End If

        Catch ex As Exception
            ' ErrorInfo.SysErrMessageInfomation(ex.Message)
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TreeViewFunction_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeViewFunction.DoubleClick

        Try

            Select Case UCase(Microsoft.VisualBasic.Left(TreeViewFunction.SelectedNode.Tag, 1))
                Case "Z"
                    StatusDataBase.Panels(2).Text = "功能選項"
                    Exit Sub
                Case Chr(31)
                    StatusDataBase.Panels(2).Text = "權限不足"
                    Exit Sub
            End Select

            Dim xNodeText As String = Mid(TreeViewFunction.SelectedNode.Text, 1, InStr(TreeViewFunction.SelectedNode.Text, Chr(175)) - 1)

            Dim xCheckOper As Integer = Val(Mid(TreeViewFunction.SelectedNode.Text, InStr(TreeViewFunction.SelectedNode.Text, Chr(175)) + 1))

            If xCheckOper > 0 AndAlso xCheckOper <> Me.ClsCommonInfo.uO_IDNo AndAlso xCheckOper <> 5 Then
                StatusDataBase.Panels(2).Text = "作業不符"
                MsgBox("環境指定作業項目與執行作業不符")
                Exit Sub
            End If
            'MsgBox("tag:" & Trim(TreeViewFunction.SelectedNode.Tag) & "  node:" & Trim(xNodeText) & "tip:" & TreeViewFunction.SelectedNode.ToolTipText)
            TreeOpen(Trim(TreeViewFunction.SelectedNode.Tag), Trim(xNodeText), Trim(TreeViewFunction.SelectedNode.ToolTipText))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TreeViewDataBase_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewDataBase.AfterSelect

        Me.ClsDBInfo.uDataBaseName = e.Node.Text
        Me.ClsDBInfo.uDataBase = e.Node.Tag
        StatusDataBase.Panels(0).Text = Me.ClsDBInfo.uDataBase
        StatusDataBase.Panels(1).Text = Me.ClsDBInfo.uDataBaseName

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Connection_Ifx()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ViewUserResource()   ' 使用者可使用設備
    End Sub

    'Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
    '    Try
    '        Dim xNodeText As String = Mid(e.Node.Text, 1, InStr(e.Node.Text, Chr(175)) - 1)
    '        StatusDataBase.Panels(3).Text = "(" & e.Node.Tag & ")" & xNodeText
    '        StatusDataBase.Text = "(" & e.Node.Tag & ")" & xNodeText
    '        'Me.ClsCommonInfo.uPlineSID = Val(Mid(xNodeText, InStr(xNodeText, Chr(176)) + 1))
    '        'Me.ClsCommonInfo.uM_IDNo = e.Node.Tag
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    Private Sub Catch_machineID()      ' 取得機台設備資料識別碼

        Me.ClsCommonInfo.uM_IDNo = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "M_IDNo")

        Try
            If Me.ClsDBInfo.datalink(Me.ClsCommonInfo.uLocalIP) Then
                SqlCommand = "select F001,F002,F003,nvl(F009,0) as F009" & _
                              " from MSE0003" & _
                             " where F001=" & Me.ClsCommonInfo.uM_IDNo & _
                               " and F006=1" & _
                               " and rownum=1"

                Dim Tablename2 As New DataTable("Tablename2")
                Me.ClsDBInfo.ExecuteSQL(SqlCommand, Tablename2)

                If Tablename2.Rows.Count > 0 Then
                    StatusDataBase.Panels(3).Text = "(" & Tablename2.Rows(0).Item(0) & ")" & _
                                                    Tablename2.Rows(0).Item(1) & " " & Tablename2.Rows(0).Item(2) & _
                                                    Chr(176) & Tablename2.Rows(0).Item("F009")
                    Me.ClsCommonInfo.uPlineSID = Tablename2.Rows(0).Item("F009")
                End If
            End If
            'Catch ex As OracleClient.OracleException
            '    If InStr(2, ex.Message, "ORA-") > 0 Then
            '        ErrorInfo.SysErrMessageInfomation(Mid(ex.Message, 1, InStr(2, ex.Message, "ORA-") - 1))
            '    Else
            '        ErrorInfo.SysErrMessageInfomation(ex.Message)
            '    End If
        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        Dim h1 As Integer = Val(Microsoft.VisualBasic.Left(Format(Now, "HH:mm:ss"), 1))
        Dim h2 As Integer = Val(Mid(Format(Now, "HH:mm:ss"), 2, 1))
        Dim m1 As Integer = Val(Mid(Format(Now, "hh:mm:ss"), 4, 1))
        Dim m2 As Integer = Val(Mid(Format(Now, "hh:mm:ss"), 5, 1))
        Dim s1 As Integer = Val(Mid(Format(Now, "hh:mm:ss"), 7, 1))
        Dim s2 As Integer = Val(Mid(Format(Now, "hh:mm:ss"), 8, 1))

        'PBTH1.BackgroundImage = ImageList2.Images(h1)
        'PBTH2.BackgroundImage = ImageList2.Images(h2)
        'PBTM1.BackgroundImage = ImageList2.Images(m1)
        'PBTM2.BackgroundImage = ImageList2.Images(m2)
        'PBTS1.BackgroundImage = ImageList2.Images(s1)
        'PBTS2.BackgroundImage = ImageList2.Images(s2)

        PBTH1.ImageLocation = "IMAGE\" & h1 & "_I.GIF"
        PBTH2.ImageLocation = "IMAGE\" & h2 & "_I.GIF"
        PBTM1.ImageLocation = "IMAGE\" & m1 & "_I.GIF"
        PBTM2.ImageLocation = "IMAGE\" & m2 & "_I.GIF"
        PBTS1.ImageLocation = "IMAGE\" & s1 & "_I.GIF"
        PBTS2.ImageLocation = "IMAGE\" & s2 & "_I.GIF"

        Dim xOperform As Integer = 0
        For Each xOperformName As Form In My.Application.OpenForms
            xOperform += 1
        Next

        If xOperform <= 2 Then
            If Not Timer1.Enabled Then
                ProgressBar1.Value = 0
                Timer1.Start()
            Else
                If ProgressBar1.Value = ProgressBar1.Maximum Then
                    ProgressBar1.Value = 0
                    Timer1.Stop()
                End If
                ProgressBar1.Value += 1
            End If
        Else
            ProgressBar1.Value = 0
            Timer1.Stop()
        End If

    End Sub

    Private Sub Label1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.TextChanged
        ViewUserFunction()
        ViewUserResource()   ' 使用者可使用設備
        DisplayInfo()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Panel1.Visible = False
        PictureBox6.Visible = True
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Panel1.Visible = True
        PictureBox6.Visible = False
    End Sub

    Private Function UserLogon() As Boolean

        Dim xOk As Boolean = False

        ' *************************************
        ' * 將此電腦資料寫入 SYS9999 資料表中 *
        ' *************************************

        Try
            If Me.ClsDBInfo.datalink(Me.ClsCommonInfo.uLocalIP) Then

                SqlCommand = "begin UserLogon('" & Trim(Me.ClsCommonInfo.uComputerName) & "'," & _
                                        "'" & Trim(Me.ClsCommonInfo.uLocalIP) & "'," & _
                                        "'" & Trim(Me.ClsCommonInfo.uMac) & "'," & Me.ClsCommonInfo.uEMP_NOSID & ");end;"

                Me.ClsDBInfo.ExecuteSQL(SqlCommand)
            End If

            xOk = True

        Catch ex As Exception
            'show lock computer name
            Dim dt As New DataTable("data")

            SqlCommand = "select f002, f003 from sys9999 where f005= '" & Me.ClsCommonInfo.uEMP_NOSID & "'"
            Me.ClsDBInfo.ExecuteSQL(SqlCommand, dt)

            MsgBox("已登錄於 [" & dt.Rows(0).Item("f002").ToString.Trim() & "]電腦，IP位置於[" & dt.Rows(0).Item("f003").ToString.Trim() & "]", MsgBoxStyle.OkOnly, "警告視窗")
        End Try

        Return xOk

    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        ListView1.Items.Clear()

        Try
            If Me.ClsDBInfo.datalink(Me.ClsCommonInfo.uLocalIP) Then

                SqlCommand = "select upper(F002) F002,nvl(f003,' ') F003,nvl(f004,' ') F004 from SYS9999 order by 1"

                Dim Tablename2 As New DataTable("datatable2")

                Me.ClsDBInfo.ExecuteSQL(SqlCommand, Tablename2)

                Dim I As Integer = 0

                For I = 0 To Tablename2.Rows.Count - 1
                    ListView1.Items.Add(Trim(Tablename2.Rows(I).Item("F002")))
                    ListView1.Items(I).SubItems.Add(Trim(Tablename2.Rows(I).Item("F003")))
                    ListView1.Items(I).SubItems.Add(Trim(Tablename2.Rows(I).Item("F004")))
                Next

                Tablename2.Dispose()

            End If
            'Catch ex As OracleClient.OracleException
            '    If InStr(2, ex.Message, "ORA-") > 0 Then
            '        ErrorInfo.SysErrMessageInfomation(Mid(ex.Message, 1, InStr(2, ex.Message, "ORA-") - 1))
            '    Else
            '        ErrorInfo.SysErrMessageInfomation(ex.Message)
            '    End If
        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll

        TabControl1.Size = New Size(HScrollBar1.Value, 515)

        ' **************************************
        ' * 對於已開啟的表單作業位置需重新調整 *
        ' **************************************
        For Each xcontrol As Form In Me.MdiChildren
            xcontrol.StartPosition = FormStartPosition.CenterScreen
            '  xcontrol.Close()
        Next

    End Sub

    Public Function ChkOpenForm(ByVal xFormName As String) As Boolean  ' 檢查是否已開啟表單

        Dim xNotOpenForm As Boolean = False

        For Each xcontrol As Form In Me.MdiChildren
            If UCase(xcontrol.Name) = UCase(xFormName) Then
                xNotOpenForm = True
                xcontrol.Focus()
                Exit For
            End If
        Next

        Return xNotOpenForm And (Me.ClsCommonInfo.uIsReplicOpenForm <> 1) ' 若要限制同一時期只能開一作業, 將此註解解開

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click

        Try

            xPublicMessage.SendToBack()

            For Each xControl As Control In xPublicMessage.Controls

                If xControl.Name.ToLower = "wbmessage" Then
                    xControl.Visible = Not xControl.Visible
                    Exit For
                End If

            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click

        'Me.Enabled = False

        ' ************************
        ' * 下載該員作業進行註冊 *
        ' ************************.
        'by tianen 2012/6/18
        'Dim xDownLoad As Form = New DownLoadForm

        'With xDownLoad
        '    .MdiParent = Me
        '    .StartPosition = FormStartPosition.CenterScreen
        '    .TopMost = True
        'End With

        'xDownLoad.Show()

    End Sub

    'Private Sub CheckDll()  ' 僅針對目前登錄者的作業進行 Check

    '    ' ************************************
    '    ' * 來自作業權限清單 (Form MainMenu) *
    '    ' ************************************
    '    Try

    '        If IO.File.Exists(Application.StartupPath & "\SystemList.Xml") Then

    '            Dim ds As DataSet = New DataSet

    '            ds.ReadXml(Application.StartupPath & "\SystemList.Xml")

    '            Dim dt As DataTable = ds.Tables(0)

    '            Dim StrDllName As String = ""
    '            Dim I As Integer
    '            For I = 0 To dt.Rows.Count - 1
    '                StrDllName = dt.Rows(I).Item(5)
    '                LabMessage.Text = StrDllName
    '                If dt.Rows(I).Item(4) = 1 Then
    '                    LoginForm.CheckVersion(StrDllName, False)
    '                    Threading.Thread.Sleep(5000)
    '                End If
    '            Next

    '            dt.Dispose()
    '            ds.Dispose()

    '        End If

    '    Catch ex As Exception
    '    End Try

    'End Sub

    Private Sub FileWatchDll()

        Try
            With FSWdll
                .Path = remoteUri
                .NotifyFilter = (IO.NotifyFilters.LastWrite Or IO.NotifyFilters.CreationTime)
                .Filter = "*.dll"
                .IncludeSubdirectories = False
                .InternalBufferSize = 4096
            End With

            AddHandler FSWdll.Changed, AddressOf FSWdll_Changed
            AddHandler FSWdll.Created, AddressOf FSWdll_Changed

            FSWdll.EnableRaisingEvents = True

        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
            SaveErrorLogOffLine(My.Computer.Name, ex.Message, ex.StackTrace)
        End Try

    End Sub

    Private Sub FSWdll_Changed(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) ' Handles FSWdll.Created, FSWdll.Changed
        Dim StrDllName As String = Replace(e.Name.ToLower, ".dll", "")
        LabMessage.Text = StrDllName
        LoginForm.CheckVersion(StrDllName, True)
    End Sub

    Private Sub CmdService(ByVal strPath As String, ByVal strArguments As String)
        Try
            Dim proc_Info As New ProcessStartInfo(strPath, strArguments)
            proc_Info.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(proc_Info)
        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

    End Sub

    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick

        Try
            If ListView1.SelectedIndices.Count > 0 Then
                Dim xUserIp As String = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(1).Text
                CmdService("vncviewer.exe", xUserIp)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        LisDBInfo.Items.Clear()
        LisDBInfo.BeginUpdate()

        Try
            If Me.ClsDBInfo.datalink(Me.ClsCommonInfo.uLocalIP) Then

                SqlCommand = "select d.tablespace_name" & _
                                   ",to_char(nvl(a.bytes / 1024 / 1024, 0), '99,999,990.900') Size_M" & _
                                   ",to_char(nvl(a.bytes - nvl(f.bytes, 0), 0) / 1024 / 1024,  '99999999.999') Used_M" & _
                                   ",to_char(nvl((a.bytes - nvl(f.bytes, 0)) / a.bytes * 100, 0),  '990.00')||'%' UsedRate" & _
                              " from sys.dba_tablespaces d" & _
                                  ",(select tablespace_name, SUM(bytes) bytes" & _
                                     " from dba_data_files" & _
                                    " group by tablespace_name) a" & _
                                  ",(select tablespace_name, SUM(bytes) bytes" & _
                                     " from dba_free_space" & _
                                   " group by tablespace_name) f" & _
                             " where d.tablespace_name = a.tablespace_name(+)" & _
                               " and d.tablespace_name = f.tablespace_name(+)" & _
                               " and not (d.extent_management like 'LOCAL' and d.contents like 'TEMPORARY')" & _
                              " union all" & _
                             " select d.tablespace_name" & _
                                    ",to_char(nvl(a.bytes / 1024 / 1024, 0), '99,999,990.900')" & _
                                    ",to_char(nvl(t.bytes, 0) / 1024 / 1024, '99999999.999')" & _
                                    ",to_char(nvl(t.bytes / a.bytes * 100, 0), '990.00')||'%'" & _
                               " from sys.dba_tablespaces d" & _
                                   ",(select tablespace_name, SUM(bytes) bytes" & _
                                      " from dba_temp_files" & _
                                     " group by tablespace_name) a" & _
                                   ",(select tablespace_name, SUM(bytes_cached) bytes" & _
                                      " from v$temp_extent_pool" & _
                                     " group by tablespace_name) t" & _
                               " where d.tablespace_name = a.tablespace_name(+)" & _
                                 " and d.tablespace_name = t.tablespace_name(+)" & _
                                 " and d.extent_management like 'LOCAL'" & _
                                 " and d.contents like 'TEMPORARY'" & _
                               " order by 4 desc"

                Dim Tablename2 As New DataTable("datatable2")

                Me.ClsDBInfo.ExecuteSQL(SqlCommand, Tablename2)

                For I As Integer = 0 To Tablename2.Rows.Count - 1
                    LisDBInfo.Items.Add(Tablename2.Rows(I).Item(0))
                    LisDBInfo.Items(I).SubItems.Add(Tablename2.Rows(I).Item(1))
                    LisDBInfo.Items(I).SubItems.Add(Tablename2.Rows(I).Item(2))
                    LisDBInfo.Items(I).SubItems.Add(Tablename2.Rows(I).Item(3))
                Next

                Tablename2.Dispose()

            End If

        Catch ex As Exception
            ErrorInfo.SysErrMessageInfomation(ex.Message)
        End Try

        LisDBInfo.EndUpdate()

    End Sub

    Private Sub BtnRefershFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefershFunction.Click
        CloseForm()
        ViewUserFunction()
    End Sub

    Public Sub CloseForm()  ' 關閉已開啟表單

        For Each xcontrol As Form In Me.MdiChildren
            If UCase(xcontrol.Name) <> "PUBLICMESSAGE" Then
                xcontrol.Close()
            End If
        Next

    End Sub
End Class

