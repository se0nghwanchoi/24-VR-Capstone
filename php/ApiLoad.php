<?php
// 데이터베이스 설정
$servername = "localhost";
$username = "root";
$password = "1234";
$dbname = "mydb";

// 데이터베이스 연결
$conn = new mysqli($servername, $username, $password, $dbname);

// 연결 에러 확인
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// 입력 파라미터 가져오기
$recordID = isset($_GET['recordID']) ? $_GET['recordID'] : '';

// SQL 쿼리 작성
$sql = "SELECT r.ID, r.disaster_id, r.recordID, r.time, c.Do_code, c.interact_time, c.use_status
        FROM record r
        LEFT JOIN checking c ON r.recordID = c.recordID
        WHERE r.recordID = ? 
        ORDER BY c.Do_code ASC"; // ORDER BY 구문 추가

// SQL 쿼리 준비
$stmt = $conn->prepare($sql);
$stmt->bind_param("i", $recordID);
$stmt->execute();
$result = $stmt->get_result();

// 결과를 JSON 형식으로 변환
$response = array("items" => array());
$currentRecordID = null;
$currentItem = null;

while ($row = $result->fetch_assoc()) {
    if ($row['recordID'] != $currentRecordID) {
        if ($currentItem) {
            $response["items"][] = $currentItem;
        }
        $currentRecordID = $row['recordID'];
        $currentItem = array(
            "ID" => $row["ID"],
            "disaster_id" => $row["disaster_id"],
            "recordID" => $row["recordID"],
            "time" => $row["time"],
            "DoCodes" => array()
        );
    }

    if ($row['Do_code']) { // Do_code 정보 추가
        $currentItem["DoCodes"][] = array(
            "Do_code" => $row["Do_code"],
            "interact_time" => $row["interact_time"],
            "use_status" => $row["use_status"]
        );
    }
}

// Add the last item if it exists
if ($currentItem) {
    $response["items"][] = $currentItem;
}

echo json_encode($response);

// 자원 정리
$stmt->close();
$conn->close();
?>