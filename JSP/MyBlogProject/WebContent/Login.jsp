<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>로그인</title>

<%-- JavaScript를 이용한 아이디, 비밀번호 공백 유무 판별 및 클릭 이벤트 처리 함수 --%>
<script language="JavaScript">
	function In_Check() {
		if (document.login.id.value="") {
			alert("아이디를 입력하세요!!!")
			return;
		}
		if (document.login.pw.value="") {
			alert("비밀번호를 입력하세요!!!")
			return;
		}
		document.login.submit();
	}
</script>
</head>
<body>
	<%-- 중앙정렬 --%>
	<center>
		<%-- 입력폼  --%>
		<form method="post" action="main.jsp" name="Login">
			<%-- 표만들기 --%>
			<table border="1" cellspacing="1">
				<tr>
					<td>아이디</td>
					<td><input type="text" name="id" size=17></td></tr>
				<tr>
					<td>비밀번호</td>
					<td><input type="text" name="pw" size=17></td></tr>
				<tr>
					<td align=center colspan="2">
						<input type="button" value="로그인" OnClick="In_Check()">
						<input type="reset" value="회원가입"></td></tr>
			</table>
		</form>
	</center>
</body>
</html>