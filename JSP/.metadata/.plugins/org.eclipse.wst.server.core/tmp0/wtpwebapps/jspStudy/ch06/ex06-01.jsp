<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>로그인 입력 폼</title>
</head>
<body>
	<center>로그인 입력 화면
	<form method=post action=ex06-02.jsp>
		<table border="1">
			<tr>
				<td>아이디</td>
				<td><input type=text name="id"></td></tr>
			<tr>
				<td>비밀번호</td>
				<td><input type=text name="pw"></td></tr>
			<tr align="center">
				<td colspan="4">
					<input type="submit" value="로그인">
					<input type="reset" value="취 소"></td></tr>
		</table>
	</form>
	</center>
</body>
</html>