console.log("site.js loaded");
let tourData = {
    "Phú Quốc": {
        description: "Hòn đảo thiên đường với biển xanh, cát trắng và những khu nghỉ dưỡng cao cấp. Nơi đây nổi tiếng với hoàng hôn tuyệt đẹp, chợ đêm sầm uất và các hoạt động lặn biển thú vị.",
        location: "Nhiều resort cao cấp ven biển (Bãi Trường, Bãi Khem), khách sạn trung tâm Dương Đông tiện di chuyển, bungalow và homestay gần làng chài."
    },
    "Hạ Long": {
        description: "Thành phố biển nổi tiếng với Vịnh Hạ Long – kỳ quan thiên nhiên thế giới, bãi biển đẹp, khu vui chơi Sun World và những làng chài cổ kính.",
        location: "Khách sạn ven biển tại Bãi Cháy thuận tiện di chuyển, homestay gần trung tâm, du thuyền trên vịnh dành cho kỳ nghỉ sang trọng."
    },
    "Đà Nẵng": {
        description: "Thành phố biển sôi động với bãi biển Mỹ Khê tuyệt đẹp, những cây cầu biểu tượng và nền ẩm thực phong phú. Đà Nẵng còn là cửa ngõ đến Hội An và Bà Nà Hills.",
        location: "Khách sạn ven biển Mỹ Khê với view biển đẹp, resort cao cấp trên Bà Nà Hills, homestay trong trung tâm gần chợ và cầu Rồng."
    },
    "Đà Lạt": {
        description: "Thành phố ngàn hoa với không khí mát mẻ quanh năm, cảnh quan thơ mộng và kiến trúc châu Âu cổ kính. Đà Lạt thu hút du khách với những vườn hoa, đồi thông và quán cà phê đẹp.",
        location: "Homestay phong cách vintage giữa rừng thông, biệt thự cổ gần Hồ Xuân Hương, khách sạn trung tâm thuận tiện di chuyển."
    }
};

function changeImage(imageSrc, tourName, clickedButton) {
    console.log("changeImage called with:", imageSrc, tourName, clickedButton);
    let imageElement = document.getElementById("displayedImage");

    // Thêm hiệu ứng mờ dần khi thay đổi ảnh
    imageElement.style.opacity = "0";
    setTimeout(() => {
        imageElement.src = imageSrc;
        imageElement.style.opacity = "1";
    }, 300);

    console.log("Tour Data:", tourData[tourName]);

    // Cập nhật thông tin tour
    document.getElementById("tourTitle").innerText = tourName;
    document.getElementById("tourDescription").innerText = tourData[tourName].description;
    document.getElementById("tourLocation").innerText = tourData[tourName].location;

    // Loại bỏ class 'active' khỏi tất cả button và thêm vào button được chọn
    document.querySelectorAll(".custom-nut").forEach(button => button.classList.remove("active"));
    clickedButton.classList.add("active");
}

document.addEventListener("DOMContentLoaded", function () {
    let buttons = document.querySelectorAll(".custom-nut");
    console.log("Buttons found:", buttons.length); // Thêm log để kiểm tra

    buttons.forEach(button => {
        button.addEventListener("click", function () {
            let imageSrc = this.getAttribute("data-image");
            let tourName = this.getAttribute("data-tour");
            console.log("Button clicked:", imageSrc, tourName); // Thêm log để kiểm tra
            changeImage(imageSrc, tourName, this);
        });
    });
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

    let destinationInput = document.getElementById("destination").value.trim().toLowerCase();

    if (!destinationInput) {
        alert("Vui lòng chọn điểm đến!");
        return;
    }

    // Kiểm tra dữ liệu có tồn tại không
    console.log("Dữ liệu điểm đến:", destinationInput);

    let filteredTours = tours.filter(tour =>
        tour.DESTINATION_TOUR.toLowerCase().includes(destinationInput)
    );

    console.log("🛎 Số tour tìm thấy:", filteredTours.length);
    displayResults(filteredTours);
}

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

    // Hiển thị popup
    popup.style.display = "block";
}

// ❌ Đóng popup
function closePopup() {
    let popup = document.getElementById("searchResultsPopup");
    popup.classList.remove("active");
    setTimeout(() => {
        popup.style.display = "none";
    }, 300);
}

document.querySelector("input[name='QUANTITY']").addEventListener("input", function () {
    let quantity = parseInt(this.value) || 1;
    let price = parseFloat(document.getElementById("priceTour").value);
    document.getElementById("totalPrice").value = (quantity * price).toLocaleString() + " VNĐ";
});
