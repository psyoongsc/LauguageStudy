<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>입력 폼[2]</title>
</head>
<body>
	<h4>성별과 좋아하는 과목 조사</h4>
	
	<form method=post action=ex06-04.jsp>
		1.성별을 선택하세요.[Radio버튼]<br>
		<input type=radio name=sex value="남자" checked>남자
		<input type=radio name=sex value="여자">여자<p>
		
		2.좋아하는 과목을 선택하세요.[Checkbox]<br>
		<input type=checkbox name=subj value="SQL응용" checked>SQL 응용<br>
		<input type=checkbox name=subj value="DB개발도구">DB개발도구<br>
		<input type=checkbox name=subj value="JSP" checked>JSP<br>
		<input type=checkbox name=subj value="오라클실무">오라클실무<br>
		<input type=checkbox name=subj value="ERP구축">ERP구축<p>
		<input type=submit value="확 인">
		<input type=submit value="취 소">
	</form>
</body>
</html>