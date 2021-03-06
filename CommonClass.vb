'**************************************************************************************
'* Class Name : CommonClass
'
'* Description : Server Object
'
'* Author : Norman Su
'
'* Change History : 
'
'* Data        Owner       ChangeDescription            Level
'* 2007/07/12  Norman Su   Modify SFC to N-Tier System  L1.00
'*
'**************************************************************************************

Imports System
Imports System.Runtime.InteropServices
Imports System.Data.OracleClient
Imports System.Net.NetworkInformation
Imports System.Net.Sockets                ' 通訊使用
Imports System.Net.Mail                   ' 統一用 sfc.com.tw 帳號來 mail (span.tsmt.com)
Imports System.Threading.Thread           ' 執行緒
Imports System.Text

<Serializable()> Public Class CommonClass
    Inherits MarshalByRefObject

    ' ************************
    ' * 應用系統環境變數設定 *
    ' ************************

    Public uEmp_account As String = ""                                                                   ' 登錄帳號
    Public uEmp_Password As String = ""                                                                  ' 登錄密碼
    Public uEMP_NOSID As Integer = 0                                                                     ' 登錄帳號資料識別碼
    Public uEmp_Nm As String = ""                                                                        ' 帳戶姓名
    Public uComputerName As String = ""                                                                  ' 電腦名稱
    Public uLocalIP As String = ""                                                                       ' 本機 IP 位址
    Public uMac As String = ""
    Public uLogonStatus As Boolean = False                                                               ' 是否已登錄
    Public uLoginStr As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "LINK")                ' "data source=TMIS;Initial Catalog=TMIS;integrated Security=SSPI"    ' 連至 10.0.0.21 伺服器, 使用者為 tsmtsfc
    Public uLoginSAPStr As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "SAPLINK")
    Public uLoginUserID As String = "user id=tsmtsfc"
    Public uLoginPwdstr As String = "password=TracleMis"
    Public uLoginSAPUserID As String = "user id=md_dev_ sfc"
    Public uLoginSAPPwdstr As String = "password=md_dev_ sfc"
    Public uO_IDNo As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_IDNo")                ' 作業項目編號, 需位於作業項目資料表中的資料識別碼
    Public uM_IDNo As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "M_IDNo")                ' 機台設備編號, 需位於機台設備資料表中的資料識別碼
    Public uDataBaseID As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "DataBaseID")        ' 廠區編號, 需與 TIPTOP 定義相符合(單一廠區, 對非工單而言)
    Public uCompanyName As String = ""                                                                   ' 公司名稱
    Public uAppPath As String = System.Windows.Forms.Application.StartupPath                             ' 應用系統路徑
    Public uAppName As String = "SFC"   ' Application.ProductName                                        ' 應用系統名稱
    Public uVerision As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_VERISION")          ' 應用系統版本
    Public uAttrib As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_ATTRIB")
    Public uYield As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_YIELD")                ' 不良率上限
    Public uPassFailQty As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_PassFailQty")    ' 生產過程中, 需經過多少片, 開始監控不良率
    Public uRepairControl As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_RepairControl")  ' 包裝時對維修品管控
    Public uMailServer As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_MAILSERVER")      ' MailServer
    Public uRptFolder As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_RPTPATH")          ' 應用系統報表(RPT 報表檔)路徑 2006/5/16 加入 By Chinkuo
    Public uXmlFolder As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_XMLPATH")          ' 應用系統 xml 路徑 2006/5/18 加入 By Chinkuo
    Public uSysClose As Boolean = False                                                                  ' 當子表單作業關閉後, 是否整個系統都要關閉 
    Public uIsDisplayInfo As Boolean = True                                                              ' 當使用者重設本機參數時, 是否重新顯示(MainMenuForm)
    Public uPlineSID As Integer = 0                                                                      ' 產線資料識別碼 2006/7/3 By Chinkuo
    Public uLinkSajet As Integer = 0                                                                     ' 是否有導入 Sajet 上料系統
    Public uIsReplicOpenForm As Integer = Val(Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_ReplicOpenForm"))    ' 是否可以多重開啟同一作業    
    Public dtAssemblyUpdate As New DataTable("function")                                                 ' 存放已更新的 Function Name      L1.00
    Public hstbUserAliveForm As New Hashtable                                                            ' 存放已開啟的Form                L1.00
    Public hstbVersion As New Hashtable                                                                  ' 存放GAC最新的Version            L1.00
    Public hstbToken As New Hashtable                                                                    ' 存放GAC最新的Token              L1.00    
    Public hstbUserIP As New Hashtable                                                                   ' User登錄遠端DB時的IP            L1.00
    Public hstbUserMac As New Hashtable                                                                  ' User登錄遠端DB時的Mac           L1.00
    Public hstbUserComputerName As New Hashtable                                                         ' User登錄遠端DB時的Computer Name L1.00
    Public hstbUserEMP_NOSID As New Hashtable                                                            ' User登錄遠端DB時的EMP_NOSID     L1.00 


    Public Overrides Function InitializeLifetimeService() As Object                                      ' 保留期設為無限期            L1.00
        Return Nothing
    End Function

    Public uSystem As String = "製造現場(TMIS)管理系統 " & My.Application.Info.Version.ToString & _
                           " *** " & My.Application.Info.Copyright.ToString & " *** " & _
                           Chr(255)                                                                  ' 使用者在登錄後會加上使用者主機 IP     

    Public Const FTsuccess As Integer = 87                                                               ' 電壓測試連線ok
    Public Const FTfailure As Integer = 119                                                              ' 電壓測試連線Fail
    Public uSystemDateTime As Date = Now                                                                 ' 系統主機時間  

    ' ****************************
    ' * 建立連線至 sql 資料庫 *
    ' ****************************
    Public sqlConn As System.Data.OracleClient.OracleConnection
    Public ConnTran As System.Data.OracleClient.OracleConnection
    Public CrosConn As System.Data.OracleClient.OracleConnection
    'L1.00 START
    Public ConnectionCnt As Integer = 0
    Public SqlCommandCnt As Integer = 0
    'L1.00 END
    Public OleCommand As System.Data.OracleClient.OracleCommand
    Public OleDatareader As System.Data.OracleClient.OracleDataReader
    Public OleAdapter As System.Data.OracleClient.OracleDataAdapter
    Public OleTran As OracleTransaction

    ' ******************************
    ' * 建立連線至 informix 資料庫 *
    ' ******************************
    Public IfxConn As IBM.Data.Informix.IfxConnection
    Public IfxCommand As IBM.Data.Informix.IfxCommand
    Public IfxDatareader As IBM.Data.Informix.IfxDataReader
    Public IfxAdapter As IBM.Data.Informix.IfxDataAdapter
    Public uLoginIfxStr As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "IFXLINK")

    ' ******************************
    Public SqlCommand As String = ""
    Public SqlCommand99 As String = ""
    Public uCForm As System.Windows.Forms.Form
    Public uDataBaseName As String = ""           ' 指定資料庫名稱
    Public uDataBase As String = uDataBaseID      ' 指定資料庫實體名稱   

    Public uRemoteHostName As String = Microsoft.VisualBasic.GetSetting("TMIS", "LINK", "O_REMOTEHOSTNAME")    ' 聯繫主機名稱

    ' *****************************
    ' * 報表相關設定
    ' *****************************
    Public uXmlName As String = ""
    Public uRptName As String = ""
    Private SetServerTime


    Public Sub ExecuteSQL(ByVal SQL As String, Optional ByRef dt As DataTable = Nothing)
        Try
            Dim OracleCommand As System.Data.OracleClient.OracleCommand
            Dim OracleAdapter As System.Data.OracleClient.OracleDataAdapter

            If sqlConn Is Nothing Then
                sqlConn = New System.Data.OracleClient.OracleConnection(uLoginStr)
                sqlConn.Open()
                ConnectionCnt += 1
            ElseIf sqlConn.State = ConnectionState.Closed Then
                sqlConn.Open()
            End If
            Console.WriteLine("CONNECTION OPEN :" & ConnectionCnt)
            Console.WriteLine("SQL COMMAND :" & SQL)

            If dt IsNot Nothing Then
                OracleAdapter = New System.Data.OracleClient.OracleDataAdapter(SQL, sqlConn)
                OracleAdapter.Fill(dt)
                OracleAdapter.Dispose()
                SqlCommandCnt += 1
                Console.WriteLine("SQL Execute Times :" & SqlCommandCnt)
            Else
                OracleCommand = New System.Data.OracleClient.OracleCommand(SQL, sqlConn)
                OracleCommand.ExecuteNonQuery()
                OracleCommand.Dispose()
                SqlCommandCnt += 1
                Console.WriteLine("SQL Execute Times :" & SqlCommandCnt)
            End If
        Catch ex As OracleException
            Console.WriteLine("OracleException :" & ex.Message)
            Throw ex
        Catch ex As Exception
            Console.WriteLine("Exception :" & ex.Message)
            Throw ex
        Finally
            sqlConn.Close()
            Console.WriteLine("CONNECTION CLOSE")
        End Try
    End Sub

    'ORACLE FOR SAP BY CTY 2011/8/5

    Public Sub SAPExecuteSQL(ByVal SQL As String, Optional ByRef dt As DataTable = Nothing)
        Try
            Dim OracleCommand As System.Data.OracleClient.OracleCommand
            Dim OracleAdapter As System.Data.OracleClient.OracleDataAdapter

            If sqlConn Is Nothing Then
                sqlConn = New System.Data.OracleClient.OracleConnection(uLoginSAPStr)
                sqlConn.Open()
                ConnectionCnt += 1
            ElseIf sqlConn.State = ConnectionState.Closed Then
                sqlConn.Open()
            End If
            Console.WriteLine("CONNECTION OPEN :" & ConnectionCnt)
            Console.WriteLine("SQL COMMAND :" & SQL)

            If dt IsNot Nothing Then
                OracleAdapter = New System.Data.OracleClient.OracleDataAdapter(SQL, sqlConn)
                OracleAdapter.Fill(dt)
                OracleAdapter.Dispose()
                SqlCommandCnt += 1
                Console.WriteLine("SQL Execute Times :" & SqlCommandCnt)
            Else
                OracleCommand = New System.Data.OracleClient.OracleCommand(SQL, sqlConn)
                OracleCommand.ExecuteNonQuery()
                OracleCommand.Dispose()
                SqlCommandCnt += 1
                Console.WriteLine("SQL Execute Times :" & SqlCommandCnt)
            End If
        Catch ex As OracleException
            Console.WriteLine("OracleException :" & ex.Message)
            Throw ex
        Catch ex As Exception
            Console.WriteLine("Exception :" & ex.Message)
            Throw ex
        Finally
            sqlConn.Close()
            Console.WriteLine("CONNECTION CLOSE")
        End Try
    End Sub


    Public Sub ExecuteSQL(ByVal SQL As String, ByVal CrosDB As Boolean, Optional ByRef dt As DataTable = Nothing)
        Try
            Dim OracleCommand As System.Data.OracleClient.OracleCommand
            Dim OracleAdapter As System.Data.OracleClient.OracleDataAdapter

            If CrosConn.State = ConnectionState.Closed Then
                CrosConn.Open()
            End If

            Console.WriteLine("CONNECTION OPEN :" & ConnectionCnt)
            Console.WriteLine("SQL COMMAND :" & SQL)

            If dt IsNot Nothing Then
                OracleAdapter = New System.Data.OracleClient.OracleDataAdapter(SQL, CrosConn)
                OracleAdapter.Fill(dt)
                OracleAdapter.Dispose()
                SqlCommandCnt += 1
                Console.WriteLine("SQL Execute Times :" & SqlCommandCnt)
            Else
                OracleCommand = New System.Data.OracleClient.OracleCommand(SQL, CrosConn)
                OracleCommand.ExecuteNonQuery()
                OracleCommand.Dispose()
                SqlCommandCnt += 1
                Console.WriteLine("SQL Execute Times :" & SqlCommandCnt)
            End If
        Catch ex As OracleException
            Console.WriteLine("OracleException :" & ex.Message)
            Throw ex
        Catch ex As Exception
            Console.WriteLine("Exception :" & ex.Message)
            Throw ex
        Finally
            CrosConn.Close()
            Console.WriteLine("CONNECTION CLOSE")
        End Try
    End Sub

    Public Function ExecuteTransaction(ByVal SQL As String, Optional ByVal blnUsingReader As Boolean = False) As OracleClient.OracleDataReader
        Dim DataReader As OracleClient.OracleDataReader
        Try           
            If blnUsingReader Then           
                OleCommand.CommandText = SQL
                DataReader = OleCommand.ExecuteReader()
                SqlCommandCnt += 1
                Console.WriteLine("SQL Execute Times :" & SqlCommandCnt)
                Return DataReader
            Else                
                OleCommand.CommandText = SQL
                OleCommand.ExecuteNonQuery()
                OleCommand.Dispose()
                SqlCommandCnt += 1
                Console.WriteLine("SQL Execute Times :" & SqlCommandCnt)
                Return Nothing
            End If
        Catch ex As OracleClient.OracleException            
            OleTran.Rollback()
            OleTran.Dispose()
            ConnTran.Close()           
            Throw ex
        Catch ex As Exception            
            OleTran.Rollback()
            OleTran.Dispose()
            ConnTran.Close()           
            Throw ex
        End Try
    End Function

    Public Sub OracleBeginTransaction()
        Try          
            If ConnTran Is Nothing Then
                ConnTran = New System.Data.OracleClient.OracleConnection(uLoginStr)
                ConnTran.Open()
                ConnectionCnt += 1           
            ElseIf ConnTran.State = ConnectionState.Closed Then
                ConnTran.Open()                
            End If            

            OleTran = ConnTran.BeginTransaction()            
            OleCommand = ConnTran.CreateCommand()
            OleCommand.Transaction = OleTran
            Console.WriteLine("OracleBeginTransaction ...")
        Catch ex As OracleException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'ORACLE FOR SAP BY CTY 2011/8/5

    Public Sub SAPOracleBeginTransaction()
        Try
            If ConnTran Is Nothing Then
                ConnTran = New System.Data.OracleClient.OracleConnection(uLoginSAPStr)
                ConnTran.Open()
                ConnectionCnt += 1
            ElseIf ConnTran.State = ConnectionState.Closed Then
                ConnTran.Open()
            End If

            OleTran = ConnTran.BeginTransaction()
            OleCommand = ConnTran.CreateCommand()
            OleCommand.Transaction = OleTran
            Console.WriteLine("OracleBeginTransaction ...")
        Catch ex As OracleException
            Throw ex
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub OracleCommit()
        Try
            OleTran.Commit()
            Console.WriteLine("OracleCommit ...")
        Catch ex As OracleException
            OleTran.Rollback()
            Throw ex
        Catch ex As Exception
            OleTran.Rollback()
            Throw ex
        Finally
            OleTran.Dispose()
            ConnTran.Close()           
        End Try
    End Sub

    Public Sub ExecuteInformix(ByVal SQL As String, Optional ByRef dt As DataTable = Nothing)
        Try
            If IFXlink("tsmtty") Then
                If dt IsNot Nothing Then
                    IfxAdapter = New IBM.Data.Informix.IfxDataAdapter(SQL, IfxConn)
                    IfxAdapter.Fill(dt)
                    IfxAdapter.Dispose()
                Else
                    IfxCommand = New IBM.Data.Informix.IfxCommand(SQL, IfxConn)
                    IfxCommand.ExecuteNonQuery()
                    IfxCommand.Dispose()
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            IfxConn.Close()
        End Try
    End Sub

    '************************
    '* 定義系統日期時間格式 *
    '************************
    Private Structure FSSYSTEMTIME
        Public wYear As System.Int16
        Public wMonth As System.Int16
        Public wDayofWeek As System.Int16
        Public wDay As System.Int16
        Public wHour As System.Int16
        Public wMinute As System.Int16
        Public wSecond As System.Int16
        Public wMilliseconds As System.Int16
    End Structure

    '**************************************************************
    '* 使用 windows\kernel32.dll(For 32位元) 中的設定本機時間函數 *
    '**************************************************************

    Private Declare Function SetSystemTime Lib "kernel32" Alias "SetSystemTime" (ByRef lpSystemTime As FSSYSTEMTIME) As Long

    Private Sub SetSysDatetime(ByVal newDate As Date)
        Try
            Dim lReturn As Long
            Dim LocalDatetime As Date = TimeZone.CurrentTimeZone.ToUniversalTime(newDate)
            Dim FSsystem As New FSSYSTEMTIME

            FSsystem.wYear = Convert.ToUInt16(LocalDatetime.Year)
            FSsystem.wMonth = Convert.ToUInt16(LocalDatetime.Month)
            FSsystem.wDayofWeek = Convert.ToUInt16(LocalDatetime.DayOfWeek)
            FSsystem.wDay = Convert.ToUInt16(LocalDatetime.Day)
            FSsystem.wHour = Convert.ToUInt16(LocalDatetime.Hour)
            FSsystem.wMinute = Convert.ToUInt16(LocalDatetime.Minute)
            FSsystem.wSecond = Convert.ToUInt16(LocalDatetime.Second)
            FSsystem.wMilliseconds = 0

            lReturn = SetSystemTime(FSsystem)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetSystemDateTime()
        Try
            SqlCommand = "select sysdate from dual"

            Dim dt As New DataTable("data")
            ExecuteSQL(SqlCommand, dt)

            If dt.Rows.Count > 0 Then
                uSystemDateTime = dt.Rows(0).Item(0)
                SetSysDatetime(uSystemDateTime)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetServerTime()
        Return Now
    End Function

    ' ********************************************************
    ' * 載入輸出入埠函數館 acallportio.dll, 需安裝 pro-8.exe *
    ' ********************************************************

    Declare Function WriteByte Lib "ACALLPORTIO.dll" Alias "ACALLPORTIO_WriteByte" (ByVal address As Int16, ByVal DataOut As Byte) As Int16
    Declare Function WriteWord Lib "ACALLPORTIO.dll" Alias "ACALLPORTIO_WriteWord" (ByVal address As Int16, ByVal DataOut As Int16) As Int16
    Declare Function ReadByte Lib "ACALLPORTIO.dll" Alias "ACALLPORTIO_ReadByte" (ByVal address As Int16, ByRef DataIn As Byte) As Int16
    Declare Function ReadWord Lib "ACALLPORTIO.dll" Alias "ACALLPORTIO_ReadWord" (ByVal address As Int16, ByRef DataIn As Int16) As Int16

    Declare Function DInit Lib "ACALLPORTIO.dll" Alias "ACALLPORTIO_Init" () As Int16
    Declare Function DClose Lib "ACALLPORTIO.dll" Alias "ACALLPORTIO_Close" () As Int16
    Declare Function GetDllVersion Lib "ACALLPORTIO.dll" Alias "ACALLPORTIO_GetDllVersion" (ByRef wDLLVersion As Integer) As Int16
    Declare Function GetDriverVersion Lib "ACALLPORTIO.dll" Alias "ACALLPORTIO_GetDriverVersion" (ByRef wDriverVersion As Integer) As Int16

    Public Declare Sub Sleep Lib "kernel32" (ByVal time As Integer)

    Public Sub LPTPrint(ByVal IOPortAddress As Int16, ByVal TxtFile As String)   ' 將資料直接送至印表機
        Try
            If DInit() = 0 Then
                Dim I, iRet As Integer
                For I = 1 To TxtFile.Length
                    iRet = WriteWord(IOPortAddress, Asc(Mid(TxtFile, I, 1)))
                Next
                iRet = DClose()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function LPTPrintStatus(ByVal IOPortAddress As Int16) As Byte  ' 印表機狀態
        Try
            Dim iRet As Short
            Dim BB As Byte

            If DInit() = 0 Then
                iRet = ReadByte(IOPortAddress + 1, BB)
                DClose()
            End If

            Return BB
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LPTPrintControl(ByVal IOPortAddress As Int16) As Byte ' 印表機控制
        Try
            Dim iRet As Short
            Dim BB As Byte

            If DInit() = 0 Then
                iRet = ReadByte(IOPortAddress + 2, BB)
                DClose()
            End If

            Return BB
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' ***********************************************
    ' * 2007/5/30 新增 udp 傳送訊息功能, By Chinkuo *
    ' ***********************************************
    Public Sub SendResult(ByVal xM_IDNo As String, ByVal xState As String)
        Try

            Dim xUDPclient As UdpClient = New UdpClient
            xUDPclient.Connect(uRemoteHostName, 5000)
            Dim xByteCommand As Byte() = New Byte() {}
            xByteCommand = Encoding.ASCII.GetBytes(xM_IDNo & "," & xState)
            xUDPclient.Send(xByteCommand, xByteCommand.Length)
            xUDPclient.Close()
            xUDPclient = Nothing

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' *************************************************************************************    
    Public Function datalink(ByVal strIP As String)   ' 連線至 sql 資料庫

        Dim NonErr As Boolean = False  ' 是否發生錯誤
        Dim xLoginstr As String = uLoginStr

        If InStr(uLoginStr, "user id=") = 0 Then
            xLoginstr = xLoginstr & ";" & uLoginUserID
            uLoginStr = xLoginstr                    
        End If

        If InStr(uLoginStr, "password=") = 0 Then
            If uLoginStr.EndsWith(";") Then
                xLoginstr = xLoginstr & uLoginPwdstr
                uLoginStr = xLoginstr
            Else
                xLoginstr = xLoginstr & ";" & uLoginPwdstr
                uLoginStr = xLoginstr
            End If                    
        End If

        Try
            If sqlConn Is Nothing Then              
                sqlConn = New System.Data.OracleClient.OracleConnection(xLoginstr)
                ConnectionCnt += 1
                'Console.WriteLine("CONNECTION STRING : " & xLoginstr)
            End If

            If sqlConn.State = ConnectionState.Closed Then
                sqlConn.Open()
            End If
            'Console.WriteLine("DATALINK CONNECTION OPEN :" & ConnectionCnt)

            ' **********************************
            ' * 當未登錄時, 需檢查是否被登錄過 *
            ' **********************************

            If uEMP_NOSID > 0 And Not uLogonStatus Then               
                SqlCommand99 = "begin UserLogon('" & Me.hstbUserComputerName(strIP).ToString() & "','" & Me.hstbUserIP(strIP).ToString() & "','" & Me.hstbUserMac(strIP).ToString() & "'," & Me.hstbUserEMP_NOSID(strIP).ToString() & ");end;"   'L1.00
                Me.ExecuteSQL(SqlCommand99)  'L1.00                
                uLogonStatus = True
            End If

            NonErr = True

        Catch er As OracleException         
            Throw er
        Catch er As Exception      
            Throw er
        End Try

        Return NonErr

    End Function

    Public Function datalink(ByVal xxLoginStr As String, ByVal strIP As String)   ' 連線至 sql 資料庫 (僅用於換連線時)

        Dim NonErr As Boolean = False  ' 是否發生錯誤
        Dim xLoginstr As String = xxLoginStr

        If InStr(xxLoginStr, "user id=") = 0 Then
            xLoginstr = xLoginstr & ";" & uLoginUserID
            uLoginStr = xLoginstr
        End If

        If InStr(xxLoginStr, "password=") = 0 Then
            If xxLoginStr.EndsWith(";") Then
                xLoginstr = xLoginstr & uLoginPwdstr
                uLoginStr = xLoginstr
            Else
                xLoginstr = xLoginstr & ";" & uLoginPwdstr
                uLoginStr = xLoginstr
            End If
        End If

        Try

            If CrosConn Is Nothing Then
                CrosConn = New System.Data.OracleClient.OracleConnection(xLoginstr)
                ConnectionCnt += 1
            End If

            If CrosConn.State = ConnectionState.Closed Then
                CrosConn.Open()
            End If
            'Console.WriteLine("DATALINK CONNECTION OPEN :" & ConnectionCnt)


            ' **********************************
            ' * 當未登錄時, 需檢查是否被登錄過 *
            ' **********************************
            If uEMP_NOSID > 0 Then         
                SqlCommand99 = "begin UserLogon('" & Me.hstbUserComputerName(strIP).ToString() & "','" & Me.hstbUserIP(strIP).ToString() & "','" & Me.hstbUserMac(strIP).ToString() & "'," & Me.hstbUserEMP_NOSID(strIP).ToString() & ");end;"   'L1.00
                Me.ExecuteSQL(SqlCommand99)
                uLogonStatus = False

            End If

            NonErr = True

        Catch er As OracleException        
            Throw er
        Catch er As Exception          
            Throw er
        End Try

        Return NonErr

    End Function

    '----ORACLE FOR SAP BY CTY 2011/8/5
    Public Function SAPdatalink(ByVal strIP As String)   ' 連線至 sql 資料庫

        Dim NonErr As Boolean = False  ' 是否發生錯誤
        Dim xLoginstr As String = uLoginSAPStr

        If InStr(uLoginSAPStr, "user id=") = 0 Then
            xLoginstr = xLoginstr & ";" & uLoginSAPUserID
            uLoginSAPStr = xLoginstr
        End If

        If InStr(uLoginSAPStr, "password=") = 0 Then
            If uLoginSAPStr.EndsWith(";") Then
                xLoginstr = xLoginstr & uLoginSAPPwdstr
                uLoginSAPStr = xLoginstr
            Else
                xLoginstr = xLoginstr & ";" & uLoginSAPPwdstr
                uLoginSAPStr = xLoginstr
            End If
        End If

        Try
            If sqlConn Is Nothing Then
                sqlConn = New System.Data.OracleClient.OracleConnection(xLoginstr)
                ConnectionCnt += 1
                'Console.WriteLine("CONNECTION STRING : " & xLoginstr)
            End If

            If sqlConn.State = ConnectionState.Closed Then
                sqlConn.Open()
            End If
            'Console.WriteLine("DATALINK CONNECTION OPEN :" & ConnectionCnt)

            ' **********************************
            ' * 當未登錄時, 需檢查是否被登錄過 *
            ' **********************************

            If uEMP_NOSID > 0 And Not uLogonStatus Then
                SqlCommand99 = "begin UserLogon('" & Me.hstbUserComputerName(strIP).ToString() & "','" & Me.hstbUserIP(strIP).ToString() & "','" & Me.hstbUserMac(strIP).ToString() & "'," & Me.hstbUserEMP_NOSID(strIP).ToString() & ");end;"   'L1.00
                Me.ExecuteSQL(SqlCommand99)  'L1.00                
                uLogonStatus = True
            End If

            NonErr = True

        Catch er As OracleException
            Throw er
        Catch er As Exception
            Throw er
        End Try

        Return NonErr

    End Function

    Public Function IFXlink(ByVal uXDataBase As String)   ' 連線至 InforMix 資料庫

        Dim IfxNonErr As Boolean = False  ' 是否發生錯誤

        If uLocalIP <> "127.0.0.1" And (Len(Trim(uDataBase)) > 0) Then   ' And (Len(Trim(uUserID)) > 0) And (Len(Trim(uPassword)) > 0) Then

            Try

                ' Dim IfxLoginStr As String = uLoginIfxStr & ";DATABASE=" & uDataBase & ";User ID=" & uUserID & ";Password=" & uPassword
                Dim IfxLoginStr As String = uLoginIfxStr & ";DATABASE=" & uXDataBase & ";User ID=mrpuser;Password=mrpuser"

                If Not IfxConn Is Nothing Then
                    IfxConn.Dispose()
                End If

                IfxConn = New IBM.Data.Informix.IfxConnection
                IfxConn.ConnectionString = IfxLoginStr
                IfxConn.ClientLocale() = "zh_tw.big5"       ' 設定 Client Locale   值 For Taiwan Language
                IfxConn.DatabaseLocale() = "zh_TW.57352"    ' 設定 Database Locale 值 For Taiwan Language

                IfxConn.Open()

                IfxNonErr = True

            Catch er As Exception
                Console.WriteLine(er.Message)
                Throw er                                 'L1.00                 
            End Try
        End If

        Return IfxNonErr

    End Function

    Public Function cDatetime(ByVal sDateTime As String)  ' 將日期時間字串中的上/下午及連續空白處理
        cDatetime = Replace(Replace(Replace(sDateTime, "上午", ""), "下午", ""), "  ", " ")
    End Function

    Public Function ExcelColumn(ByVal nColumn As Integer)  ' 將指定欄位數字轉成 EXCEL 欄位
        Try
            Dim __Column As String

            If nColumn > 26 Then
                __Column = Chr(64 + Int(nColumn / 26)) + Chr(64 + nColumn Mod 26)
            Else
                __Column = Chr(64 + nColumn)
            End If

            ExcelColumn = __Column
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'L1.00 START 
    'Public Sub PassFailInfomation(ByVal sMessString As String)

    '    Dim xInfoForm As System.Windows.Forms.Form

    '    xInfoForm = New PassFailInfo

    '    With xInfoForm
    '        .Tag = sMessString
    '    End With

    '    xInfoForm.Show()

    'End Sub

    'Public Sub SysErrMessageInfomation(ByVal sMessString As String)

    '    Dim xInfoForm As System.Windows.Forms.Form

    '    xInfoForm = New SysErrMessage

    '    With xInfoForm
    '        .Tag = sMessString
    '    End With

    '    xInfoForm.Show()

    'End Sub
    'L1.00 END

    Public Sub DisplayTypeAndAddress()
        Try
            Dim computerProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
            Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim adapter As NetworkInterface

            For Each adapter In nics
                uMac = adapter.GetPhysicalAddress().ToString()
                Exit For
            Next adapter
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'L1.00 START
    'Public Class ListViewItemComparer
    '    Implements IComparer

    '    Private col As Integer

    '    Public Sub New()
    '        col = 0
    '    End Sub

    '    Public Sub New(ByVal column As Integer)
    '        col = column
    '    End Sub

    '    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
    '       Implements IComparer.Compare
    '        Return [String].Compare(CType(x, Windows.Forms.ListViewItem).SubItems(col).Text, CType(y, Windows.Forms.ListViewItem).SubItems(col).Text)
    '    End Function
    'End Class   

    'Public Structure YieldColumnName
    '    Public MACHNAME As String
    '    Public PARTCODE As String
    '    Public INDATE As String
    '    Public H00_P As String
    '    Public H00_F As String
    '    Public H00_Y As String
    '    Public H02_P As String
    '    Public H02_F As String
    '    Public H02_Y As String
    '    Public H04_P As String
    '    Public H04_F As String
    '    Public H04_Y As String
    '    Public H06_P As String
    '    Public H06_F As String
    '    Public H06_Y As String
    '    Public H08_P As String
    '    Public H08_F As String
    '    Public H08_Y As String
    '    Public H10_P As String
    '    Public H10_F As String
    '    Public H10_Y As String
    '    Public H12_P As String
    '    Public H12_F As String
    '    Public H12_Y As String
    '    Public H14_P As String
    '    Public H14_F As String
    '    Public H14_Y As String
    '    Public H16_P As String
    '    Public H16_F As String
    '    Public H16_Y As String
    '    Public H18_P As String
    '    Public H18_F As String
    '    Public H18_Y As String
    '    Public H20_P As String
    '    Public H20_F As String
    '    Public H20_Y As String
    '    Public H22_P As String
    '    Public H22_F As String
    '    Public H22_Y As String
    'End Structure

    'Public Function Yield_Data(ByVal xM_IDNo As Integer) As Windows.Forms.ListView  ' 下載現行機台良率資料

    '    Dim YieldTable As Windows.Forms.ListView = New Windows.Forms.ListView

    '    YieldTable.Items.Add("0")
    '    YieldTable.Items(0).SubItems.Add("0")

    '    Dim xNow As Date = Now
    '    Dim xHour As String = "H" & Format(Math.Floor(xNow.Hour / 2) * 2, "00")
    '    Dim xYestday As Date = xNow

    '    SqlCommand = ""

    '    If datalink() Then

    '        Try

    '            If xHour >= "H08" And xHour < "H20" Then    ' 早班

    '                SqlCommand = "select" & _
    '                                   " sum(H08_P + H10_P + H12_P + H14_P + H16_P + H18_P) as Pass" & _
    '                                   ",sum(H08_F + H10_F + H12_F + H14_F + H16_F + H18_F) as Fail" & _
    '                              " from Yield_summary" & _
    '                             " where machsid=" & xM_IDNo & _
    '                               " and INDATE='" & Format(Now, "yyyyMMdd") & "'" & _
    '                             " group by machsid"
    '            Else

    '                If xHour >= "H20" Then
    '                    SqlCommand = "select" & _
    '                                       " sum(H20_P + H22_P) as Pass" & _
    '                                       ",sum(H20_F + H22_F) as Fail" & _
    '                                  " from Yield_summary" & _
    '                                 " where machsid=" & xM_IDNo & _
    '                                   " and INDATE='" & Format(Now, "yyyyMMdd") & "'" & _
    '                                 " group by machsid"
    '                Else

    '                    xYestday = DateAdd(DateInterval.Day, -1, xNow)

    '                    SqlCommand = "select sum(Pass) as Pass" & _
    '                                       ",sum(Fail) as Fail" & _
    '                                  " from (select machsid" & _
    '                                               ",(H20_P+H22_P) as Pass" & _
    '                                               ",(H20_F+H22_F) as Fail" & _
    '                                          " from Yield_summary" & _
    '                                         " where machsid=" & xM_IDNo & _
    '                                           " and INDATE='" & Format(xYestday, "yyyyMMdd") & "'" & _
    '                                         " union all" & _
    '                                        " select machsid" & _
    '                                               ",(H00_P+H02_P+H04_P+H06_P) as Pass" & _
    '                                               ",(H00_F+H02_F+H04_F+H06_F) as Fail" & _
    '                                          " from Yield_summary" & _
    '                                         " where machsid=" & xM_IDNo & _
    '                                           " and INDATE='" & Format(Now, "yyyyMMdd") & "')" & _
    '                                 " group by machsid"
    '                End If

    '            End If

    '            'OleCommand = New System.Data.OracleClient.OracleCommand(SqlCommand, sqlConn)
    '            'OleDatareader = OleCommand.ExecuteReader()

    '            'If OleDatareader.Read() Then
    '            '    YieldTable.Items(0).Text = OleDatareader.Item(0)
    '            '    YieldTable.Items(0).SubItems(1).Text = OleDatareader.Item(1)
    '            'End If

    '            'OleDatareader.Close()

    '            'L1.00 START
    '            Dim dt As New DataTable("data")
    '            Me.ExecuteSQL(SqlCommand, dt)

    '            If dt.Rows.Count > 0 Then
    '                YieldTable.Items(0).Text = dt.Rows(0).Item(0)
    '                YieldTable.Items(0).SubItems(1).Text = dt.Rows(0).Item(1)
    '            End If
    '            'L1.00 END
    '        Catch ex As OracleException
    '            Throw ex
    '        Catch ex As Exception
    '            'SysErrMessageInfomation(ex.Message)  'L1.00
    '        End Try

    '        'sqlConn.Close()

    '    End If

    '    Return YieldTable

    'End Function

    'Public Function Yield_Data(ByVal xM_IDNo As Integer, ByVal xPartSID As Integer) As Windows.Forms.ListView  ' 下載現行機台良率資料

    '    Dim YieldTable As Windows.Forms.ListView = New Windows.Forms.ListView

    '    YieldTable.Items.Add("0")
    '    YieldTable.Items(0).SubItems.Add("0")
    '    YieldTable.Items(0).SubItems.Add("0")
    '    YieldTable.Items(0).SubItems.Add("0")

    '    Dim xNow As Date = Now
    '    Dim xHour As String = "H" & Format(Math.Floor(xNow.Hour / 2) * 2, "00")
    '    Dim xYestday As Date = xNow

    '    SqlCommand = ""

    '    If datalink() Then

    '        Try

    '            If xHour >= "H08" And xHour < "H20" Then    ' 早班

    '                SqlCommand = "select" & _
    '                                   " sum(H08_P + H10_P + H12_P + H14_P + H16_P + H18_P) as Pass" & _
    '                                   ",sum(H08_F + H10_F + H12_F + H14_F + H16_F + H18_F) as Fail" & _
    '                                   ",sum(DPASS) as LPASS" & _
    '                                   ",sum(DFAIL) as LFAIL" & _
    '                              " from Yield_summary" & _
    '                             " where machsid=" & xM_IDNo & _
    '                               " and INDATE='" & Format(Now, "yyyyMMdd") & "'" & _
    '                               " and PARTSID=" & xPartSID & _
    '                             " group by machsid"
    '            Else

    '                If xHour >= "H20" Then
    '                    SqlCommand = "select" & _
    '                                       " sum(H20_P + H22_P) as Pass" & _
    '                                       ",sum(H20_F + H22_F) as Fail" & _
    '                                       ",sum(NPASS) as LPASS" & _
    '                                       ",sum(NFAIL) as LFAIL" & _
    '                                  " from Yield_summary" & _
    '                                 " where machsid=" & xM_IDNo & _
    '                                   " and INDATE='" & Format(Now, "yyyyMMdd") & "'" & _
    '                                   " and PARTSID=" & xPartSID & _
    '                                 " group by machsid"
    '                Else

    '                    xYestday = DateAdd(DateInterval.Day, -1, xNow)

    '                    SqlCommand = "select sum(Pass) as Pass" & _
    '                                       ",sum(Fail) as Fail" & _
    '                                       ",sum(NPASS) as LPASS" & _
    '                                       ",sum(NFAIL) as LFAIL" & _
    '                                  " from (select machsid" & _
    '                                               ",(H20_P+H22_P) as Pass" & _
    '                                               ",(H20_F+H22_F) as Fail" & _
    '                                               ",NPASS" & _
    '                                               ",NFAIL" & _
    '                                          " from Yield_summary" & _
    '                                         " where machsid=" & xM_IDNo & _
    '                                           " and INDATE='" & Format(xYestday, "yyyyMMdd") & "'" & _
    '                                           " and PARTSID=" & xPartSID & _
    '                                         " union all" & _
    '                                        " select machsid" & _
    '                                               ",(H00_P+H02_P+H04_P+H06_P) as Pass" & _
    '                                               ",(H00_F+H02_F+H04_F+H06_F) as Fail" & _
    '                                               ",NPASS" & _
    '                                               ",NFAIL" & _
    '                                          " from Yield_summary" & _
    '                                         " where machsid=" & xM_IDNo & _
    '                                           " and INDATE='" & Format(Now, "yyyyMMdd") & _
    '                                           " and PARTSID=" & xPartSID & "')" & _
    '                                 " group by machsid"
    '                End If

    '            End If

    '            'OleCommand = New System.Data.OracleClient.OracleCommand(SqlCommand, sqlConn)
    '            'OleDatareader = OleCommand.ExecuteReader()               

    '            'If OleDatareader.Read() Then
    '            '    YieldTable.Items(0).Text = OleDatareader.Item(0)
    '            '    YieldTable.Items(0).SubItems(1).Text = OleDatareader.Item(1)
    '            '    YieldTable.Items(0).SubItems(2).Text = OleDatareader.Item(2)
    '            '    YieldTable.Items(0).SubItems(3).Text = OleDatareader.Item(3)
    '            'End If

    '            'OleDatareader.Close()

    '            'L1.00 START
    '            Dim dt As New DataTable("data")
    '            Me.ExecuteSQL(SqlCommand, dt)

    '            If dt.Rows.Count > 0 Then
    '                YieldTable.Items(0).Text = dt.Rows(0).Item(0)
    '                YieldTable.Items(0).SubItems(1).Text = dt.Rows(0).Item(1)
    '                YieldTable.Items(0).SubItems(2).Text = dt.Rows(0).Item(2)
    '                YieldTable.Items(0).SubItems(3).Text = dt.Rows(0).Item(3)
    '            End If
    '            'L1.00 END
    '        Catch ex As OracleException
    '            Throw ex
    '        Catch ex As Exception
    '            'SysErrMessageInfomation(ex.Message)
    '            Throw ex
    '        End Try

    '        'sqlConn.Close()

    '    End If

    '    Return YieldTable

    'End Function
    'L1.00 END

   
End Class
