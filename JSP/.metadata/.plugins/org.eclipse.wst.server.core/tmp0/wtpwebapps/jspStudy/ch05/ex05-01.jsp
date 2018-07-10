<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>request 내장객체를 사용한 예제</title>
</head>
<body>
	<center>
		<H4>request 내장객체를 사용한 예제</H4>
		
		<table border="1">
			<tr>
				<td>요청 메서드:</td>
				<td><%= request.getMethod() %></td></tr>
			<tr>
				<td>요청 URL:</td>
				<td><%= request.getRequestURL() %></td></tr>
			<tr>
				<td>프로토콜 종류:</td>
				<td><%= request.getProtocol() %></td></tr>
			<tr>
				<td>Server의 이름:</td>
				<td><%= request.getServerName() %></td></tr>
			<tr>
				<td>Server의 Port 번호:</td>
				<td><%= request.getServerPort() %></td></tr>
			<tr>
				<td>사용자 컴퓨터의 IP주소:</td>
				<td><%= request.getRemoteAddr() %></td></tr>
			<tr>
				<td>사용자 컴퓨터의 이름:</td>
				<td><%= request.getRemoteHost() %></td></tr>
		</table>
	</center>
</body>
</html>