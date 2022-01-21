$(document).ready(() => {
    $("#btnRefreshTable").on("click", function () {
        fetchManagerTable();
    });
});

window.onload = function () {
    fetchManagerTable();
};

function fetchManagerTable() {
    $.ajax({
        url: "FetchManagerTableData",
        success: function (data) {
            $("tbody").empty();
            for (let i = 0; i < data.length; i++) {
                $("tbody").append(
                    `<tr><td>${data[i].id}</td><td>${data[i].lastName}</td></tr>`);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}