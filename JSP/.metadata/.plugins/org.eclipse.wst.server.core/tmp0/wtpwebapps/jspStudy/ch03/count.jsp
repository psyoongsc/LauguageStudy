<%@ page language="java" contentType="text/html; charset=UTF-8"
		pageEncoding="UTF-8" import="java.io.*" %>
<%
	File f = new File("count.txt");
	RandomAccessFile file = new RandomAccessFile(f, "rw");
	if (!f.exists())
		file.write(0);
	file.seek(0);
	int su = file.read();
	++su;
	file.seek(0);
	file.write(su);
	file.close();
%>
 당신은 <%= su %> 번째 방문자입니다!!