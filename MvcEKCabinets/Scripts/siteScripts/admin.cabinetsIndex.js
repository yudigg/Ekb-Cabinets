$(function () {

    $("#dataTable").on('click', '.add-btn', function () {
        var lineId = $(this).data('id');
        $('#styleForm').append('<input type="hidden" name="lineId" value="' + lineId + '" />');
        $('#addStyleModal').modal();
    });
    $(".view-btn").on('click', function () {
        var id = $(this).data('id');
        var lineName = $(this).data('linename');
        $.get("/Admin/ViewCabinets", { seriesId: id }, function (cabinets) {

            //var template = new EJS({ url: "/Content/Templates/viewTable.html" })
            cabinets.forEach(function (cabinet) {
                //var html = template.render(cabinet);
                //var row = $(html);
                var row = "<td>"+cabinet.Name+"></td>"
                $('#viewTable').append(row);
            });
        });
        $('#viewCabinetsModal').modal();
    });
});
//cars.forEach(function(car) {
//    var html = template.render(car);
//    var row = $(html);
//    $(".car-table").append(row);