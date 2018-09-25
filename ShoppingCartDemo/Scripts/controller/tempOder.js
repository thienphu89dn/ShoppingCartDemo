function addToCart(id) {

    var data = {
        PID: id
    };

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/TempOrder/Create",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (data) {
            alert(data);
        },
        error: function (data) {
            alert("Add fail !!");
        }
    });
}