Imports System.IO
Public Class frmMain
    'Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Dim Winhttp As New WinHttp.WinHttpRequest
    Dim Counts As String '불러오기시 라벨에 표시하기 위해..
    Public Property Clubids As String
    Private Property ListViewItem As ListViewItem
    Private Property Temp As String

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Log.Items.Add("[안내] " + TimeOfDay + " - 프로그램이 실행되었습니다.")
        'Me.Width = "240"
    End Sub
    Private Sub frmMain_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'sleep(1000)
        If (Button1.Text) = "상세로그 열기" Then
            Me.Width = "783"
            'Me.Height = "418"
            Button1.Text = "상세로그 닫기"
        Else
            Me.Width = "243"
            Button1.Text = "상세로그 열기"
        End If
    End Sub

    Private Sub NowTime_Tick(sender As Object, e As EventArgs) Handles NowTime.Tick
        Label1.Text = "현재시간 : " + Now
    End Sub

    Private Sub Start_Tick(sender As Object, e As EventArgs) Handles Start.Tick

    End Sub

    Private Sub NLogin_Click(sender As Object, e As EventArgs) Handles NLogin.Click
        Laver_Login()
    End Sub

    Private Sub LstBt1_Click(sender As Object, e As EventArgs) Handles LstBt1.Click '제목,내용 금칙어
        On Error Resume Next '오류 무시
        With OpenFileDialog1
            .Filter = "텍스트파일(*.TXT)|*.txt|모든파일(*.*)|*.*"
            .FilterIndex = 1
            .FileName = vbNullString
            .Title = "제목 금칙어가 포함된 텍스트파일을 선택해주세요."
            .ShowDialog()

            If (.FileName.Length = 0) Then
                MsgBox("파일이 선택되지 않았습니다", vbCritical, "Error!")
            End If
            Dim strArry As New StreamReader(OpenFileDialog1.FileName, System.Text.Encoding.Default) '한글 인코딩

            Dim FF As String

            FF = strArry.ReadLine()
            Do Until FF Is Nothing
                lst1.Items.Add(FF)
                FF = strArry.ReadLine()
            Loop
            strArry.Close()
            strArry.Dispose()

            Counts = lst1.Items.Count
            Label6.Text = (Counts + " 개의 제목,내용 금칙어가 불러오기 되었습니다.")
        End With
    End Sub

    Private Sub LstBt2_Click(sender As Object, e As EventArgs) Handles LstBt2.Click '댓글 금칙어
        On Error Resume Next '오류 무시
        With OpenFileDialog1
            .Filter = "텍스트파일(*.TXT)|*.txt|모든파일(*.*)|*.*"
            .FilterIndex = 1
            .FileName = vbNullString
            .Title = "댓글 금칙어가 텍스트파일을 선택해주세요."
            .ShowDialog()

            If (.FileName.Length = 0) Then
                MsgBox("파일이 선택되지 않았습니다", vbCritical, "Error!")
            End If
            Dim strArry As New StreamReader(OpenFileDialog1.FileName, System.Text.Encoding.Default) '한글 인코딩

            Dim FF As String '리스트 불러오기를 시작

            FF = strArry.ReadLine()
            Do Until FF Is Nothing
                lst2.Items.Add(FF)
                FF = strArry.ReadLine()
            Loop
            strArry.Close() '닫고
            strArry.Dispose() '사용한 리소스 제거

            Counts = lst2.Items.Count
            Label7.Text = (Counts + " 개의 댓글 금칙어가 불러오기 되었습니다.")

        End With
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If (CheckBox2.Checked = True) Then '체크가 되있다면
            lst1.Visible = False
            lst2.Visible = False
        Else '아닐경우는 반대로
            lst1.Visible = True
            lst2.Visible = True
        End If
    End Sub
    Private Sub Start_Bt_Click(sender As Object, e As EventArgs) Handles Start_Bt.Click
        If (Start_Bt.Text = "관리 시작") Then
            TM.Enabled = True
            Start_Bt.Text = "관리 중지"
            Log.Items.Add("[시작] " + TimeOfDay + " - 관리가 시작되었습니다.")
        Else
            TM.Enabled = False
            Start_Bt.Text = "관리 시작"
            Log.Items.Add("[시작] " + TimeOfDay + " - 관리가 중지되었습니다.")
        End If

    End Sub
    Private Sub TM_Tick(sender As Object, e As EventArgs) Handles TM.Tick 'TM의 인터벌 10000로 해놨어요.
        On Error Resume Next
        Dim Num As String = vbNullString
        Dim SN As String = vbNullString

        '최신글 30개 파싱
        Winhttp.Open("GET", "http://cafe.naver.com/ArticleList.nhn?search.clubid=" & Clubids & "&search.boardtype=L&search.menuid=&search.questionTab=A&search.marketBoardTab=D&search.specialmenutype=&userDisplay=30")
        Winhttp.Send()

        Temp = (System.Text.Encoding.Default.GetString(Winhttp.ResponseBody)) 'UTF-8

        For i = 1 To UBound(Split(Temp, "<span class=""m-tcol-c list-count"">"))
            SN = SN & Split(Split(Temp, "<span class=""m-tcol-c list-count"">")(i), "</span>")(0) & "/"
        Next i

        Dim g As Integer

        For g = 0 To UBound(Split(SN, "/")) '게시글 제목 + 댓글 관리
            Num = Split(SN, "/")(g)
            Call ViewWriteDelete() '게시글 삭제
            System.Threading.Thread.Sleep(5000) '5초
            Call CommentDelete(Num) '덧글 삭제
            ListView1.EnsureVisible(ListView1.Items.Count - 1) '자동 마우스 휠 맨 하단으로
        Next g

        NewMemberCheck() '신규멤버 체크
        System.Threading.Thread.Sleep(10000) '10초
        Application.DoEvents()
        ListView1.EnsureVisible(ListView1.Items.Count - 1) '자동 마우스 휠 맨 하단으로

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OptionFrm.Show()
    End Sub

    Private Sub Start_Tick_1(sender As Object, e As EventArgs) Handles Start.Tick
    End Sub

    Private Sub 종료ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 종료ToolStripMenuItem.Click
        End
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class
