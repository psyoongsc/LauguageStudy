Public Class OptionFrm

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If (CheckBox2.Checked = True) Then '체크2의 선택이 TRUE 이라면
            CheckBox2.Checked = False '해제한다.
        End If
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        If (CheckBox1.Checked = True) Then '체크1의 선택이 TRUE 이라면
            CheckBox1.Checked = False '해제한다.
        End If
    End Sub

    Private Sub CheckBox5_Click(sender As Object, e As EventArgs) Handles CheckBox5.Click
        If (CheckBox6.Checked = True) Then '체크6의 선택이 TRUE 이라면
            CheckBox6.Checked = False
        End If
    End Sub

    Private Sub CheckBox6_Click(sender As Object, e As EventArgs) Handles CheckBox6.Click
        If (CheckBox5.Checked = True) Then '체크5의 선택이 TRUE 이라면
            CheckBox5.Checked = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
End Class