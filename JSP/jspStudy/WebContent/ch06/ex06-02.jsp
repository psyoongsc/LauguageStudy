<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<h3>로그인 입력 화면에서</h3>
	전송된 아이디와 비밀번호는<br>
	<%= request.getParameter("id") %> <%= request.getParameter("pw") %> 입니다.
</body>
</html>