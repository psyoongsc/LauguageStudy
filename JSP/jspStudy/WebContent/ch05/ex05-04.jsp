<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Session 내장객체 예제(1)</title>
</head>
<body>
	<h4>Sesseion 내장객체 예제(1)</h4>
	아이디를 입력하세요...
	<form method="post">
		<table border="1">
			<tr>
				<td>아이디: <input type="text" name="id">
					<input type="submit" value="로그인">
				</td>
			</tr>
		</table>
	</form>
	
	<%
		String user = "";
		if (request.getParameter("id") != null) {
			user = request.getParameter("id");
			session.setAttribute("id", user);
			response.sendRedirect("ex05-04-1.jsp");
		}
	%>
</body>
</html>