<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8" import="java.sql.*"%>
    
<%
	int i = 0;
	String sql = "select * from ch07.department";
	String url = "jdbc:mysql://127.0.0.1/ch07?useSSL=false&user=root&password=1122";
	
	try {
		Class.forName("com.mysql.jdbc.Driver");
		
		Connection conn = DriverManager.getConnection(url);
		
		Statement stmt = conn.createStatement();
		
		ResultSet rs = stmt.executeQuery(sql);
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>테이블 검색</title>
</head>
<body>
	<center>
		<h4> [[ Department 테이블 검색 ]] </h4>
		<table border="1" cellspacing="1">
			<tr>
				<b>
				<td>순번</td>
				<td>학과코드</td>
				<td>학 과 명</td>
				<td>전화번호</td>
				</b></tr>
			<tr>
				<%
					while(rs.next()) {
				%>
				<td><%= ++i %></td>
				<td><%= rs.getString(1) %></td>
				<td><%= rs.getString(2) %></td>
				<td><%= rs.getString(3) %></td><tr>
<% } %>
		</table>
		<%
			rs.close();
			stmt.close();
			conn.close();
		%>
		<h4>DB에서 정상적으로 검색 되었습니다!</h4>
		<%
	} catch(SQLException e) {
		%>
		<h4>에러가 발생 했군요. 다시 확인해 보세요!!</h4>
		<% } %>
	</center>
</body>
</html>