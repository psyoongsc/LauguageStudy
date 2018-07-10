<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Session 내장객체 예제(2)</title>
</head>
<body>
	<h4>Session 내장객체 예제(2)</h4>
	당신의 세션 ID는
	<%= session.getAttribute("id") %> 입니다. <br>
</body>
</html>