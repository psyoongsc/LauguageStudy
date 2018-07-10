<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"
    import="java.util.Date,java.text.SimpleDateFormat"
    %>
<%
    Date d = new Date();
    SimpleDateFormat sf = new SimpleDateFormat("yyyy/MM/dd a hh:mm:ss");
    %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>page 지시어 예제</title>
</head>
<body>
	Today is : <%= d %><p>
	오늘은 : <%= sf.format(d) %> 입니다.
</body>
</html>