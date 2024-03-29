<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8" import="java.sql.*"%>
<% request.setCharacterEncoding("UTF-8"); %>

<%
	String Dept_ID = 	request.getParameter("dept_id");
	String Dept_Name = 	request.getParameter("dept_name");
	String Dept_Tel = 	request.getParameter("dept_tel");
	
	String sql = "INSERT INTO ch07.Department (Dept_ID, Dept_Name, Dept_Tel) values (?,?,?)";
	
	try {
		Class.forName("com.mysql.jdbc.Driver");
		Connection conn = DriverManager.getConnection("jdbc:mysql://127.0.0.1/ch07?useSSL=false&useUnicode=true&characterEncoding=UTF-8", "root", "1122");
	
		PreparedStatement pstmt = conn.prepareStatement(sql);
			pstmt.setString(1, Dept_ID);
			pstmt.setString(2, Dept_Name);
			pstmt.setString(3, Dept_Tel);
		
		pstmt.executeUpdate();
		pstmt.close();
		conn.close();
	
		out.println("<h4>Department 테이블에 한 행이 저장되었습니다!!!</h4> ");
		
	} catch (SQLException e) {
		out.println("<h4>에러가 발행 했군요. 다시 확인해 보세요!!!</h4>");
	} %>