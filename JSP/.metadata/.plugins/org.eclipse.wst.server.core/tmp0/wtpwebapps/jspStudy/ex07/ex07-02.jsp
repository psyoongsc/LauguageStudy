<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>테이블 행 추가 폼</title>
<script language="JavaScript">
	function In_Check() {
		if (document.deptinput.dept_id.value == "") {
			alert("학과코드를 입력하세요!!!");
			return;
		}
		if (document.deptinput.dept_name.value == "") {
			alert("학과명을 입력하세요!!!");
			return;
		}
		document.deptinput.submit();
	}
</script>
</head>
<body>
	<center>
		<h3> 학과 정보 입력 화면 </h3>
		<form method="post" action="ex07-02-1.jsp" name="deptinput">
			<table border="1" cellspcing="1">
				<tr>
					<td>학과코드 : </td>
					<td><input type="text" name="dept_id"></td></tr>
				<tr>
					<td>힉 과 명 : </td>
					<td><input type="text" name="dept_name"></td></tr>
				<tr>
					<td>전화번호 : </td>
					<td><input type="text" name="dept_tel"></td></tr>
				<tr align="center">
					<td colspan="2">
					<input type="button" name="confirm" value="등   록" OnClick="In_Check()">
					<input type="reset" name="reset" value="취   소">
					</td></tr>
			</table>
		</form>
	</center>
</body>
</html>