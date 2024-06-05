<?php
$servername = "localhost";
$username = "root";
$password = "1234";
$dbname = "mydb";

// POST로 받은 데이터
$disasterName = $_POST["disaster"];
$id = $_POST["ID"];
// 데이터베이스 연결
$conn = new mysqli($servername, $username, $password, $dbname);

// 연결 체크
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// disasterName으로부터 disaster_id 찾기
$sql = "SELECT disaster_id FROM disaster WHERE disasterName = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $disasterName);
$stmt->execute();
$result = $stmt->get_result();

if ($result->num_rows > 0) {
    $row = $result->fetch_assoc();
    $disasterId = $row['disaster_id'];
    
    // disasterId를 사용하여 record 테이블에 데이터 삽입
    $sqlInsert = "INSERT INTO record (id, disaster_id) VALUES (?, ?)";
    $stmtInsert = $conn->prepare($sqlInsert);
    $stmtInsert->bind_param("si", $id, $disasterId); // 'i'는 변수 타입이 정수(integer)임을 의미합니다.
    
    if ($stmtInsert->execute()) {
        $record_id = $conn->insert_id;
        echo json_encode(array("recordID" => $record_id));
    } else {
        echo "Error: " . $stmtInsert->error;
    }
} else {
    echo "No disaster found with the name: $disasterName";
}

$conn->close();
?>