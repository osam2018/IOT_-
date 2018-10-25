<html>
<head>
<meta charset="UTF-8" />
<title>초 허접 게시판</title>
<style>

select {
    width: 100px;
    height: 20px;
    padding-left: 0px;
    font-size: 12px;
    color: black;
    font-weight: bold;
    border: 1px solid #006fff;
    border-radius: 3px;
}
input {
    height: 20px;
    font-size: 12px;
    color: black;
    font-weight: bold;
    border: 1px solid #006fff;
    border-radius: 3px;
}
   body{
      background: white;
      font-family:'Malgun Gothic';
   }
<!--
td { font-size : 12pt; }
A:link { font : 9pt; color : black; text-decoration : none; 
font-family : "맑은 고딕"; font-size : 9pt; }
A:visited { text-decoration : none; color : black; font-size : 9pt; }
A:hover { text-decoration : underline; color : black; 
font-size : 9pt; }
-->
</style>
</head>

<body topmargin=0 leftmargin=0 text=#464646>
<center>
<BR>
<!-- 입력된 값을 다음 페이지로 넘기기 위해 FORM을 만든다. -->
<form action=insert.php method=post>
<table width=580 border=0 cellpadding=2 cellspacing=1>
    <tr>
        <td height=20 align=center bgcolor=white>
        <select name="taskOption">
            <option value="1">근무</option>
            <option value="2">인간관계</option>
            <option value="3">집가고싶다</option>
            <option value="4">죽고싶다</option>
        </select>
    
        
        <font color=black><B>로 힘들어 하고있을 용사에게 응원의 메시지 부탁드립니다!</B></font>
        </td>
    </tr>
    <!-- 입력 부분 -->
    <tr>
        <td bgcolor=white>&nbsp;
        <table>
            <tr>
                <td width=40 align=left ><b>이 름</b></td>
                <td align=left >
                    <INPUT type=text name=gnum size=20 maxlength=10>
                </td>
            </tr>
            <tr>
                <td width=40 align=left ><b>내 용</b></td>
                <td align=left >
                    <INPUT type=text name=title size=60 maxlength=35>
                </td>
            </tr>
            <tr>
                <td width=50 colspan=10 align=center>
                    <input type=submit value="메시지 보내기">
                    &nbsp;&nbsp;
                    <input type=reset value="다시 쓰기">
                    &nbsp;&nbsp;
                    <input type=button value="첫 화면으로" 
                    onclick="location.href='index.html'"> 
                </td>
                    <!--버튼이 클릭되었을때 발생하는 이벤트로 자바스크립트를 실행함. 이렇게 하면 바로 이전페이지로 감-->
            </tr>
        </TABLE>
</td>
</tr>
<!-- 입력 부분 끝 -->
</table>
</form>
</center>
</body>
</html>
</html>