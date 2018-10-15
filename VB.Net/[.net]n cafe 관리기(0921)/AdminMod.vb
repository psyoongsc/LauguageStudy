Imports System.IO
Module AdminMod
    Dim Winhttp As New WinHttp.WinHttpRequest
    Dim Clubids$
    Dim member$ = vbNullString
    Dim NewMember As String
    Private Property texts As String
    Private Property ListViewItem As ListViewItem

       Public Function ChangeText(SrcString As String) As String '특수문자 싹 다 짤
        Dim TrimSrcString, TempChar, TgtString As String
        Dim i, TempAscii As Integer

        TrimSrcString = Trim(SrcString)
        TgtString = ""

        For i = 1 To Len(TrimSrcString)
            TempChar = Mid(TrimSrcString, i, 1)
            TempAscii = Asc(TempChar)

            ' 전각문자의 경우 변환
            ' If TempAscii = 63 Then
            '     TgtString = TgtString & ","
            ' Else
            '     TgtString = TgtString & TempChar
            ' End If
            ' 한글만 리턴하는 경우
            If TempAscii > -22000 And TempAscii < 0 Then
                TgtString = TgtString & TempChar
            End If
        Next i

        ChangeText = TgtString
        ChangeText = Replace(ChangeText, ".", vbNullString) '.은 안된다기에 replace로 짤.
    End Function
    Public Function NewMemberCheck() As String '신규 멤버 체크
        On Error Resume Next
        Winhttp.Open("GET", "http://cafe.naver.com/CafeMemberViewNew.nhn?search.clubid=" + Clubids)
        Winhttp.Send()
        texts = (System.Text.Encoding.Default.GetString(Winhttp.ResponseBody))
        NewMember = Split(Split(texts, "<div class=""ellipsis m-tcol-c"">")(1), "</div>")(0)

        If Not member = NewMember Then
            member = NewMember
            ListViewItem = frmMain.ListView1.Items.Add("신규멤버")
            ListViewItem.SubItems.Add(NewMember + "님이 " + Now + " 에 신규가입")
           End If
    End Function
    Public Function CommentDelete(Num) As String '덧글 삭제 /게시글 번호 --> 덧글 감시(조회수 안오름)
        On Error Resume Next
        Dim Temp As String
        Dim DNum As String
        Dim DNick As String
        Dim DContent As String
        Dim DCommentid As String
        Dim Demotion As String
        Dim DID As String
        Dim Temp2 As String
        Winhttp.Open("POST", "http://cafe.naver.com/CommentView.nhn?search.clubid=" & Clubids & "&search.articleid=" & Num & "&search.lastpageview=true&lcs=Y")
        Winhttp.SetRequestHeader("Referer", "http://cafe.naver.com/ArticleRead.nhn?clubid=" & Clubids & "&boardtype=L&articleid=" & Num & "&referrerAllArticles=true")
        Winhttp.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
        Winhttp.Send("search.orderby=undefined")
        Temp = Winhttp.ResponseText

        DNum = Split(Split(Temp, "totalCount"":")(1), ",")(0)
        If DNum > "0" Then '덧글이 0개보다 많다면
            Dim i As Integer
            For i = 1 To DNum
                Temp2 = Split(Split(Temp, "{""stick")(i), ",""refComment")(0)
                DNick = Split(Split(Temp2, "writernick"":""")(1), """")(0)
                DContent = Split(Split(Temp2, "content"":""")(1), """")(0)
                DCommentid = Split(Split(Temp2, "commentid"":")(1), ",")(0)
                Demotion = Split(Split(Temp2, "emotion"":")(1), ",")(0)
                DID = Split(Split(Temp2, "writerid"":""")(1), """")(0)

                For g = 0 To frmMain.lst2.Items.Count - 1
                    If InStr(DContent, frmMain.lst2.Items(g)) > 0 Then

                        ListViewItem = frmMain.ListView1.Items.Add("댓글 - " + Num)
                        ListViewItem.SubItems.Add(DContent + " (금칙어:" + frmMain.lst2.Items(g) + ")")
                        ListViewItem.SubItems.Add(DNick & "(" & DID & ")")

                        Winhttp.Open("POST", "http://cafe.naver.com/CommentDelete.nhn")
                        Winhttp.SetRequestHeader("Referer", "http://cafe.naver.com/ArticleRead.nhn?clubid=" & Clubids & "&boardtype=L&articleid=" & Num & "&referrerAllArticles=true")
                        Winhttp.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
                        Winhttp.Send("content=&clubid=" & Clubids & "&articleid=" & Num & "&m=execute&commentid=" & DCommentid & "&refcommentid=&emotion=" & Demotion & "&orderby=asc&replyToMemberId=&replyToNick=")
                        Application.DoEvents()

                        Exit For
                    End If
                Next g
                'Application.DoEvents()
            Next i
        End If
        'Application.DoEvents()

    End Function
    Public Function ViewWriteDelete() As String '게시글 삭제/게시글번호 --> 조회수 안오름 (제목감시)
        On Error Resume Next
        Dim Temp As String
        Dim Title As String
        Dim id As String
        Dim Nick As String
        Dim Num As String
        Dim Pasing As String

        Winhttp.Open("GET", "http://cafe.naver.com/ArticleList.nhn?search.clubid=" & Clubids & "&search.boardtype=L&search.menuid=&search.questionTab=A&search.marketBoardTab=D&search.specialmenutype=&userDisplay=30")
        Winhttp.Send()

        Temp = (System.Text.Encoding.Default.GetString(Winhttp.ResponseBody))

        'System.Threading.Thread.Sleep(2000) '2초

        For i = 1 To UBound(Split(Temp, "<span class=""m-tcol-c list-count"">")) - 1

            Pasing = Split(Split(Temp, "<div class=""article-board m-tcol-c"">")(1), "<div class=""list-btn"">")(0)
            Title = Split(Split(Pasing, "class=""m-tcol-c"">")(i), "</a>")(0)

            id = Split(Split(Pasing, "onclick=""ui(event, '")(i), "',")(0)
            Nick = Split(Split(Pasing, "',3,'")(i), "',")(0)
            Num = Split(Split(Pasing, "&articleid=")(i), "&")(0)

            'Title = ChangeText(Title) '특수문자 다짜르고

            For g = 0 To frmMain.lst1.Items.Count - 1

                If InStr(Title, frmMain.lst1.Items(g)) > 0 Then  '금칙어 목록에 제목과 일치하는게 있다면

                    ListViewItem = frmMain.ListView1.Items.Add("제목 - " + Num)
                    ListViewItem.SubItems.Add(Title + " (금칙어:" + frmMain.lst1.Items(g) + ")")
                    ListViewItem.SubItems.Add(Nick & "(" & id & ")")

                    Winhttp.Open("POST", "http://cafe.naver.com/ArticleDelete.nhn")
                    Winhttp.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
                    Winhttp.SetRequestHeader("Referer", "http://cafe.naver.com/ArticleList.nhn?search.clubid=" & Clubids & "&search.boardtype=L&search.page=&userDisplay=&search.specialmenutype=")
                    Winhttp.Send("clubid=" & Clubids & "&menuid=&boardtype=L&page=1&articleid=" & Num & "&userDisplay=15")

                    Application.DoEvents()
                    Exit For
                    
                End If
            Next g
            'Application.DoEvents()

        Next i
        'Application.DoEvents()

    End Function
    Public Sub Laver_Login() '네이버 로그인
        Winhttp.Open("POST", "http://nid.naver.com/nidlogin.login")
        Winhttp.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded")
        Winhttp.SetRequestHeader("Referer", "http://static.nid.naver.com/b4/b4login.nhn?svc=d242&url=http%3A%2F%2Fsection.blog.naver.com%2FSectionMain.nhn")
        Winhttp.Send("id=" & frmMain.txtID.Text & "&pw=" & frmMain.txtPW.Text & "&saveID=0&enctp=2&smart_level=-1&svctype=0")

        If InStr(Winhttp.ResponseText, "http://static.nid.naver.com/sso/cross-domain.nhn?sid=") Then
            '--- 카페 넘버 구함
            Winhttp.Open("POST", "http://cafe.naver.com/" + frmMain.txtAddr.Text)
            Winhttp.Send()

            texts = (System.Text.Encoding.Default.GetString(Winhttp.ResponseBody)) 'UTF-8

            Dim Poss&
            Poss = InStr(texts, "clubid=")
            Poss = Poss + 7
            Clubids = Mid(texts, Poss, 8)
            frmMain.clubids = Clubids
            frmMain.Log.Items.Add("[안내] " + TimeOfDay + " - 로그인에 성공")
            frmMain.Log.Items.Add("[정보] 입력하신 카페의 뒷주소 " + frmMain.txtAddr.Text + " 의 고유번호는 [ " + Clubids + " ] 입니다.")
            frmMain.txtID.Enabled = False : frmMain.txtPW.Enabled = False : frmMain.txtAddr.Enabled = False : frmMain.NLogin.Enabled = False : frmMain.Start_Bt.Enabled = True
        Else
            frmMain.Log.Items.Add("[안내] " + TimeOfDay + " - 로그인에 실패(입력한 비밀번호 : " + frmMain.txtPW.Text + ")")
            frmMain.txtPW.Text = vbNullString
        End If
    End Sub

End Module
