
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
