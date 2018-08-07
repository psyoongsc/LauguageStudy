<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"
    import="ch08.LoginBean" %>
    
<jsp:useBean id="loginBean" class="ch08.LoginBean" scope="page" />
	<jsp:setProperty name="loginBean" property="id" />
	<jsp:setProperty name="loginBean" property="pw" />
	
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Login 자바빈 예제</title>
</head>
<body>
	<h4> 로그인 정보 </h4>
	아 이 디 : <jsp:getProperty name="loginBean" property="id" /><p>
	<%-- or <%= loginBean.getId() %> --%>
	비밀번호 : <jsp:getProperty name="loginBean" property="pw" /><p>
	<%-- or <%= loginBean.getPw() %> --%>
</body>
</html>