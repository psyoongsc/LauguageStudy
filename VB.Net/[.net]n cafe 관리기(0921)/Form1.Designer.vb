<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.Start_Bt = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.제작날짜ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.종료ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtPW = New System.Windows.Forms.TextBox()
        Me.txtAddr = New System.Windows.Forms.TextBox()
        Me.Log = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NowTime = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Start = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NLogin = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lst1 = New System.Windows.Forms.ListBox()
        Me.LstBt1 = New System.Windows.Forms.Button()
        Me.LstBt2 = New System.Windows.Forms.Button()
        Me.lst2 = New System.Windows.Forms.ListBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TM = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Start_Bt
        '
        Me.Start_Bt.BackColor = System.Drawing.Color.Honeydew
        Me.Start_Bt.Enabled = False
        Me.Start_Bt.ForeColor = System.Drawing.Color.Black
        Me.Start_Bt.Location = New System.Drawing.Point(18, 443)
        Me.Start_Bt.Name = "Start_Bt"
        Me.Start_Bt.Size = New System.Drawing.Size(191, 25)
        Me.Start_Bt.TabIndex = 9
        Me.Start_Bt.Text = "관리 시작"
        Me.Start_Bt.UseVisualStyleBackColor = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.제작날짜ToolStripMenuItem, Me.종료ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(767, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '제작날짜ToolStripMenuItem
        '
        Me.제작날짜ToolStripMenuItem.Name = "제작날짜ToolStripMenuItem"
        Me.제작날짜ToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.제작날짜ToolStripMenuItem.Text = "트레이"
        '
        '종료ToolStripMenuItem
        '
        Me.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem"
        Me.종료ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.종료ToolStripMenuItem.Text = "종료"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(18, 384)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 24)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "상세로그 열기"
        Me.ToolTip1.SetToolTip(Me.Button1, "프로그램의 로그를 확인할 수 있습니다.")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "안내"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(58, 56)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(94, 20)
        Me.txtID.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtID, "네이버 아이디 입력")
        '
        'txtPW
        '
        Me.txtPW.Location = New System.Drawing.Point(58, 82)
        Me.txtPW.Name = "txtPW"
        Me.txtPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPW.Size = New System.Drawing.Size(94, 20)
        Me.txtPW.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtPW, "네이버 비밀번호 입력")
        '
        'txtAddr
        '
        Me.txtAddr.Location = New System.Drawing.Point(57, 108)
        Me.txtAddr.Name = "txtAddr"
        Me.txtAddr.Size = New System.Drawing.Size(94, 20)
        Me.txtAddr.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtAddr, "카페 뒷주소를 입력해주세요")
        '
        'Log
        '
        Me.Log.FormattingEnabled = True
        Me.Log.ItemHeight = 11
        Me.Log.Location = New System.Drawing.Point(231, 56)
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(525, 125)
        Me.Log.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.Label1.Location = New System.Drawing.Point(568, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 11)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "현재 시간 "
        '
        'NowTime
        '
        Me.NowTime.Enabled = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(229, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 11)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "프로그램 관련 사용 로그"
        '
        'Start
        '
        Me.Start.Interval = 1000
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 11)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "ID :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 11)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "PW :"
        '
        'NLogin
        '
        Me.NLogin.Location = New System.Drawing.Point(156, 56)
        Me.NLogin.Name = "NLogin"
        Me.NLogin.Size = New System.Drawing.Size(54, 72)
        Me.NLogin.TabIndex = 4
        Me.NLogin.Text = "Naver Login"
        Me.NLogin.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 11)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "addr :"
        '
        'lst1
        '
        Me.lst1.FormattingEnabled = True
        Me.lst1.ItemHeight = 11
        Me.lst1.Location = New System.Drawing.Point(18, 167)
        Me.lst1.Name = "lst1"
        Me.lst1.Size = New System.Drawing.Size(191, 81)
        Me.lst1.TabIndex = 14
        '
        'LstBt1
        '
        Me.LstBt1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LstBt1.Location = New System.Drawing.Point(17, 134)
        Me.LstBt1.Name = "LstBt1"
        Me.LstBt1.Size = New System.Drawing.Size(192, 27)
        Me.LstBt1.TabIndex = 5
        Me.LstBt1.Text = "제목, 내용 리스트 불러오기"
        Me.LstBt1.UseVisualStyleBackColor = False
        '
        'LstBt2
        '
        Me.LstBt2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.LstBt2.Location = New System.Drawing.Point(18, 265)
        Me.LstBt2.Name = "LstBt2"
        Me.LstBt2.Size = New System.Drawing.Size(191, 27)
        Me.LstBt2.TabIndex = 6
        Me.LstBt2.Text = "댓글 리스트 불러오기"
        Me.LstBt2.UseVisualStyleBackColor = False
        '
        'lst2
        '
        Me.lst2.FormattingEnabled = True
        Me.lst2.ItemHeight = 11
        Me.lst2.Location = New System.Drawing.Point(18, 298)
        Me.lst2.Name = "lst2"
        Me.lst2.Size = New System.Drawing.Size(191, 81)
        Me.lst2.TabIndex = 17
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(16, 36)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(187, 15)
        Me.CheckBox2.TabIndex = 18
        Me.CheckBox2.Text = "금칙어 자동 숨기기 (Reg Save)"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(229, 195)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 11)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "관리 로그"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ListView1.Location = New System.Drawing.Point(231, 209)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(524, 189)
        Me.ListView1.TabIndex = 23
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "구분"
        Me.ColumnHeader1.Width = 74
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "내용"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 275
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "작성자"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 171
        '
        'TM
        '
        Me.TM.Interval = 1000
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(18, 414)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(191, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "관리 옵션 열기"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(229, 420)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 11)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "로드된 제목,내용 금칙어 갯수 라벨"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(229, 451)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 11)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "로드된 댓글 금칙어 갯수 라벨"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 11.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 476)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.lst2)
        Me.Controls.Add(Me.LstBt2)
        Me.Controls.Add(Me.LstBt1)
        Me.Controls.Add(Me.lst1)
        Me.Controls.Add(Me.txtAddr)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NLogin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPW)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Log)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Start_Bt)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("굴림", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "N Cafe Adm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Start_Bt As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents 제작날짜ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Log As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NowTime As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Start As System.Windows.Forms.Timer
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents txtPW As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NLogin As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAddr As System.Windows.Forms.TextBox
    Friend WithEvents lst1 As System.Windows.Forms.ListBox
    Friend WithEvents LstBt1 As System.Windows.Forms.Button
    Friend WithEvents LstBt2 As System.Windows.Forms.Button
    Friend WithEvents lst2 As System.Windows.Forms.ListBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents 종료ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents TM As System.Windows.Forms.Timer

End Class
