$(document).ready(function () {
   
});

function addToCart(id) {
    $.ajax({
        type: "POST",
        url: "/TempOrder/Create",
        dataType: "json",
        data: { id: id },
        success: function (data) {
            console.log("Add successfully !!");
        },
        error: function (data) {
            console.log("Add fail !!");
        }
    });
}