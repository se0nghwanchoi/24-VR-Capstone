<?php
$servername = "localhost";
$username = "root";
$password = "1234";
$dbname = "mydb";

// POST로 받은 데이터
$recordID = $_POST['recordID'];
$time = $_POST['time']; // 실제 시간 값

// 데이터베이스 연결
$conn = new mysqli($servername, $username, $password, $dbname);

// 연결 체크
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// 특정 recordID를 가진 레코드의 time 필드 업데이트
$sqlUpdate = "UPDATE record SET time = ? WHERE recordID = ?";
$stmtUpdate = $conn->prepare($sqlUpdate);
$stmtUpdate->bind_param("si", $time, $recordID);

if ($stmtUpdate->execute()) {
    echo "Record updated successfully with time: " . $time;
} else {
    echo "Error updating record: " . $stmtUpdate->error;
}

$stmtUpdate->close();
$conn->close();
?>