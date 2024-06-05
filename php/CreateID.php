// 아이디 받아서 user 테이블에 레코드 삽입

<?php
$servername = "localhost";
$username = "root";
$password = "1234";
$dbname = "mydb";

// POST로 받은 데이터
$id = $_POST["ID"];
// 데이터베이스 연결
$conn = new mysqli($servername, $username, $password, $dbname);

// 연결 체크
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sqlInsert = "INSERT INTO user (id) VALUES (?)";
$stmtInsert = $conn->prepare($sqlInsert);
$stmtInsert->bind_param("s", $id);

if ($stmtInsert->execute()) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sqlInsert . "<br>" . $conn->error;
}

$conn->close();
?>