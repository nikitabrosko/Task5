$(document).ready(() => {
    $("#btnRefreshTable").on("click", function () {
        fetchProductTable();
    });
});

window.onload = function () {
    fetchProductTable();
};

function fetchProductTable() {
    $.ajax({
        url: "FetchProductTableData",
        success: function (data) {
            $("tbody").empty();
            for (let i = 0; i < data.length; i++) {
                $("tbody").append(
                    `<tr><td>${data[i].id}</td><td>${data[i].name}</td><td>${data[i].price}</td></tr>`);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}