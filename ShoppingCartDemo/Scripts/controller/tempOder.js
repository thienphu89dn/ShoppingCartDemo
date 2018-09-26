function addToCart(id) {

    var data = {
        PID: id
    };

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Order/Create",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (data) {
            if (data.success) {
                alert("Add successfully !!");
            } else {
                alert("Add fail !!");
            }
        },
        error: function (data) {
            alert("Add fail !!");
        }
    });
}