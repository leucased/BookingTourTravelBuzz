
    function changeImage(imageSrc, tourName, clickedButton) {
        document.getElementById("displayedImage").src = imageSrc;

    // Xóa class 'active' khỏi tất cả button
    let buttons = document.querySelectorAll(".custom-nut");
       buttons.forEach(button => button.classList.remove("active"));

    // Thêm class 'active' cho button được chọn
    clickedButton.classList.add("active");

    // Cập nhật nội dung của infoBox
    let tourData = {
        "Phú Quốc": {
        description: "Một địa điểm tuyệt vời với biển xanh và nắng vàng.",
    duration: "3 ngày 2 đêm"
           },
    "Hạ Long": {
        description: "Di sản thiên nhiên thế giới với hàng nghìn đảo đá vôi kỳ vĩ.",
    duration: "2 ngày 1 đêm"
           },
    "Đà Nẵng": {
        description: "Thành phố biển đáng sống nhất Việt Nam với nhiều cảnh đẹp.",
    duration: "4 ngày 3 đêm"
           },
    "Đà Lạt": {
        description: "Thành phố ngàn hoa với khí hậu mát mẻ quanh năm.",
    duration: "3 ngày 2 đêm"
           }
       };

    document.getElementById("tourTitle").innerText = tourName;
    document.getElementById("tourDescription").innerText = tourData[tourName].description;
    document.getElementById("tourDuration").innerText = tourData[tourName].duration;
}

document.addEventListener("DOMContentLoaded", function () {
    let searchButton = document.getElementById("searchButton");
    if (searchButton) {
        searchButton.addEventListener("click", searchTours);
    } else {
        console.error("❌ Không tìm thấy nút tìm kiếm!");
    }
});


// 🏷 Load dữ liệu điểm đến từ database vào dropdown
function loadDropdownData() {
    let destinations = JSON.parse('@Html.Raw(Json.Serialize(_context.TOURS.Select(t => t.DESTINATION).Distinct().ToList()))');
    let destinationSelect = document.getElementById("destination");

    destinations.forEach(dest => {
        let option = new Option(dest, dest);
        destinationSelect.add(option);
    });
}

// 🎯 Xử lý click vào search box để hiển thị dropdown/input
document.querySelectorAll(".search-item").forEach(item => {
    item.addEventListener("click", function () {
        this.classList.toggle("active");
    });
});

// 🔎 Xử lý tìm kiếm tour
function searchTours() {
    console.log("🔍 Bắt đầu tìm kiếm...");

    let destinationInput = document.getElementById("destination").value.trim().toLowerCase(); // Lấy điểm đến

    if (!destinationInput) {
        alert("Vui lòng chọn điểm đến!");
        return;
    }

    let tours = @Html.Raw(Json.Serialize(_context.TOURS.ToList()));

    // Chỉ lọc theo điểm đến
    let filteredTours = tours.filter(tour =>
        tour.DESTINATION_TOUR.toLowerCase().includes(destinationInput)
    );

    console.log("🛎 Số tour tìm thấy:", filteredTours.length);
    displayResults(filteredTours);
}

// 🖥 Hiển thị kết quả tìm kiếm trong popup
function displayResults(filteredTours) {
    let resultsContainer = document.getElementById("resultsContainer");
    let popup = document.getElementById("searchResultsPopup");

    if (!popup) {
        console.error("❌ Không tìm thấy popup!");
        return;
    }

    resultsContainer.innerHTML = "";

    if (filteredTours.length === 0) {
        resultsContainer.innerHTML = "<p>Không tìm thấy tour phù hợp.</p>";
    } else {
        filteredTours.forEach(tour => {
            let tourItem = document.createElement("div");
            tourItem.classList.add("tour-item");
            tourItem.innerHTML = `
                <h3>${tour.NAME_TOUR}</h3>
                <p><strong>Điểm đến:</strong> ${tour.DESTINATION_TOUR}</p>
                <p><strong>Ngày đi:</strong> ${tour.START_DATE}</p>
                <p><strong>Giá:</strong> ${tour.PRICE_TOUR.toLocaleString()} VNĐ</p>
            `;
            resultsContainer.appendChild(tourItem);
        });
    }

    // 🔥 Đảm bảo popup hiển thị
    popup.style.display = "block";
    popup.classList.add("active");
}

// ❌ Đóng popup
function closePopup() {
    let popup = document.getElementById("searchResultsPopup");
    popup.classList.remove("active");
    setTimeout(() => {
        popup.style.display = "none";
    }, 300);
}
