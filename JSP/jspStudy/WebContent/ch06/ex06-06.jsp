<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<% request.setCharacterEncoding("UTF-8"); %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>배열로 전송된 값 처리</title>
</head>
<body>
	<h4>당신이 보고 싶은 영화제목으로 선택한 것은?</h4>
	
	<%
		String[] selected = request.getParameterValues("movie");
		
		for (int i=0; i<selected.length; i++) {
	%>
	<%= i+1 %>. <%= selected[i] %><br>
	<% } %>
</body>
</html>