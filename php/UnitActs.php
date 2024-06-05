<?php
$servername = "localhost";
$username = "root";
$password = "1234";
$dbname = "mydb";

// 데이터베이스 연결
$conn = new mysqli($servername, $username, $password, $dbname);

// 연결 체크
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// POST로 받은 데이터
$recordID = $_POST['recordID'];
$doCode = $_POST['doCode'];
$interactionTime = $_POST['interactionTime'];
$useStatus = $_POST['useStatus'];

// 데이터베이스에 데이터 삽입
$sql = "INSERT INTO checking (recordID, Do_code, interact_time, use_status) VALUES (?, ?, ?, ?)";
$stmt = $conn->prepare($sql);
$stmt->bind_param("iisi", $recordID, $doCode, $interactionTime, $useStatus);

if ($stmt->execute()) {
    echo "New interaction time recorded successfully";
} else {
    echo "Error: " . $stmt->error;
}

$stmt->close();
$conn->close();
?>