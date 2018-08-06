<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"
    import="ch08.LoginBean" %>
    
<jsp:useBean id="LoginBean" class="ch08.LoginBean" scope="page" />
	<jsp:setProperty name="LoginBean" property="id" />
	<jsp:setProperty name="LoginBean" property="pw" />
	
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Login 자바빈 예제</title>
</head>
<body>
	<h4> 로그인 정보 </h4>
	아 이 디 : <jsp:getProperty name="LoginBean" property="id" /><p>
	<%-- or <%= LoginBean.getId() %> --%>
	비밀번호 : <jsp:getProperty name="LoginBean" property="pw" /><p>
	<%-- or <%= LoginBean.getPw() %> --%>
</body>
</html>