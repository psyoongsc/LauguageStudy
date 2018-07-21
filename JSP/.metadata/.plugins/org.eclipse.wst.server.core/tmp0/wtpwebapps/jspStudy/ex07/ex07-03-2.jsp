<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8" import="java.sql.*"%>
    
<% request.setCharacterEncoding("UTF-8"); %>
	
<%
	String Dept_id = request.getParameter("dept_id");
	String Dept_Name = request.getParameter("dept_name");
	String Dept_Tel = request.getParameter("dept_tel");
	String url = "jdbc:mysql://127.0.0.1/ch07?useSSL=false&useUnicode=true&characterEncoding=UTF-8";
	String sql = "update ch07.department set Dept_Name = ?, Dept_Tel = ? where Dept_ID = ?";
	
	try {
		Class.forName("com.mysql.jdbc.Driver");
		Connection conn = DriverManager.getConnection(url, "root", "1122");
		PreparedStatement pstmt = conn.prepareStatement(sql);
			pstmt.setString(1, Dept_Name);
			pstmt.setString(2, Dept_Tel);
			pstmt.setString(3, Dept_id);
		pstmt.executeUpdate();
		pstmt.close();
		conn.close();
		out.println(Dept_Name + ", " + Dept_Tel + " 로 수정되었습니다.");
%>
	
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>수정폼[3]</title>
</head>
<body>
	<form method="post" action="ex07-01.jsp" name="viewresult">
		<input type="submit" name="view" value="결과보기">
	</form>
</body>
</html>

<%
	} catch (Exception e) {
		out.println(Dept_id + " 의 학과정보 수정이 실패했습니다.");
	}
%>