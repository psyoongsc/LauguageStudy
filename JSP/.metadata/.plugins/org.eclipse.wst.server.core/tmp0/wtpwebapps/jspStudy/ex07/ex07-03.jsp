<%
 // 헤더에서 스마트폰 여부확인 후 리다이렉트
 String browser = request.getHeader("User-Agent");                    // 브라우저 구해오기
 boolean result = false;
 boolean result2 = false;
 if (browser.indexOf("Android") > 0) {                                        // 안드로이드로 접속했다면 결과값 true
  result2 = true;
 } else if (browser.indexOf("iPhone") > 0) {                               // 아이폰으로 접속했다면 결과값 true
  result = true;
 }

 if (result == true) {
  response.sendRedirect("http://172.20.10.9:8080/jspStudy/ex07/study1.jsp");                         // 안드로이드나 아이폰으로 접속했다면 모바일사이트로 이동
 } 
 if (result2 == true) {
  response.sendRedirect("http://172.20.10.9:8080/jspStudy/ex07/study2.jsp");
 }
%>



<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>수정 폼[1]</title>
<script language="JavaScript">
	function In_Check() {
		if(document.idform.dept_id.value == "") {
			alert("학과코드를 입력하세요!!!")
			return;
		}
		document.idform.submit();
	}
</script>
</head>
<body>
	<center>
		<h4>수정할 학과코드를 입력하세요</h4>
		
		<form method="post" action="ex07-03-1.jsp" name="idform">
		<table border="1" cellspacing="0" cellpadding="5">
			<tr>
				<td>학과코드</td>
				<td><input type="text" name="dept_id" size="10"></td></tr>
			<tr align="center">
				<td colspan="2">
				<input type="button" name="modify" value="수정" OnClick="In_Check()">
				<input type="reset" value="취소"></td></tr>
		</table>
		</form>
	</center>
</body>
</html>