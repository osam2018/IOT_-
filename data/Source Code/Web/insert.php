<head>
	<meta charset="UTF-8" />
<style>
   body{
      background-color: white
   }
</style>
</head>

<?php
	//데이터 베이스 연결하기
	include "db_info.php";

    $gnum = $_POST[gnum];
    $title = $_POST[title];
    $task = (int)$_POST[taskOption];
    
    $query = "UPDATE board SET name='$gnum', message='$title' WHERE type = $task";
    #$query = "INSERT INTO board (id, gnum, title, wdate, ip, view, task)
    #VALUES ('', '$gnum', '$title', now(), '$REMOTE_ADDR', 0, $task)";
    $result=mysqli_query($conn, $query);

    //데이터베이스와의 연결 종료
    mysqli_close($conn);

    // 새 글 쓰기인 경우 리스트로..
    echo ("<meta http-equiv='Refresh' content='1; URL=arrive.php'>");
    //1초후에 list.php로 이동함.
?>
<center>
<font size=5>응원 메시지 가는 중...</font>