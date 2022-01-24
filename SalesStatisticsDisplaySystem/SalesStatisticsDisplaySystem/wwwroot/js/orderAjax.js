$(document).ready(() => {
    $("#btnRefreshTable").on("click", function () {
        fetchOrderTable();
    });
});

window.onload = function () {
    fetchOrderTable();
};

function fetchOrderTable() {
    $.ajax({
        url: "FetchOrderTableData",
        success: function (data) {
            $("tbody").empty();
            for (let i = 0; i < data.length; i++) {
                $("tbody").append(
                    `<tr><td>${data[i].id}</td><td>${data[i].date}</td><td>${data[i].sum}</td><td>${data[i].customerFullName}</td><td>${data[i].managerLastName}</td><td>${data[i].productName}</td></tr>`);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}