<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<% request.setCharacterEncoding("UTF-8"); %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>jsp:forward와 jsp:param 태그에 대한 예제</title>
</head>
<body bgcolor="red">
	<h4> [jsp:forward와 jsp:param 태그에 대한 예제 ]</h4>
	<hr>이 파일은 ex08-04입니다. 배경색은 빨간색입니다.
	<jsp:forward page="ex08-04-1.jsp">
		<jsp:param name="url"
		value="http:/localhost:8080/jspStudy/ch08/ex08-04.jsp" />
		<jsp:param name="memo" value="JSP/Servelet 마스터하여 웹프로그래머 되자!!!" />
	</jsp:forward>
</body>
</html>