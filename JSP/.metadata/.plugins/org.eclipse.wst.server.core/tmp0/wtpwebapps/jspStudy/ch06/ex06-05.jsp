<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>입력 폼[3]</title>
</head>
<body>
<center>
	<h4>보고 싶은 영화제목 선택하기</h4>
	
	보고 싶은 영화를 선택해 주세요.<br>
	(여러제목을 선택할 경우에는 Ctrl키를 사용하세요.)
	
	<form method=post action=ex06-06.jsp>
		<select name=movie size=4 multiple>
			<option value="설국열차" selected>설국열차
			<option value="레드:더 레전드">레드:더 레전드
			<option value="친구">친구
			<option value="감시자들">감시자들
			<option value="피아니스트">피아니스트
			<option value="대부">대부
		</select><p>
		
		<input type=submit value=" 전 송 ">
		<input type=reset value=" 취 소 ">
	</form>
</center>
</body>
</html>