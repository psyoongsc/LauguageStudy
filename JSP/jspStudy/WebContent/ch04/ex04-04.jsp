<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>스크립트릿을 이용한 구구단</title>
</head>
<body>
<center>
	<H4>스크립트릿을 이용한 구구단</H4>
	<table border="1" cellspacing="2">
		<% 
		int i, j, k;
		for (i = 1; i < 10; i++) {
		%>
	<tr>
		<% 
		for (j = 2; j < 10; j++) {
			k = i * j;
		%>
	<td>
		<% 
		out.println(j + " * " + i + " = " + k);
		%>
	</td>
		<%
		}
		%>
	</tr>
		<% } %>
	</table></center>
</body>
</html>