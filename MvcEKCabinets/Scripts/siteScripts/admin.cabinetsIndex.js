$(function () {

    $("#seriesTable").on('click', '.add-btn', function () {
        var lineId = $(this).data('id');
        $('#addStyleForm').append('<input type="hidden" name="lineId" value="' + lineId + '" />');
        $('#addStyleModal').modal();
    });

    $(".portfolio-btn").on('click', function () {
        var lineId = $(this).data('id');
        $('#portfolioForm').append('<input type="hidden" name="lineId" value="' + lineId + '" />');
        $('#portfolioModal').modal();
    });

    $(".view-btn").on('click', function () {
        var id = $(this).data('id');
        var lineName = $(this).data('linename');
        $.get("/Admin/ViewCabinets", { seriesId: id }, function (cabinets) {
            $('#viewTable').find('tbody').remove();
            var template = new EJS({ url: "/Content/Templates/viewTable.html" })
            cabinets.forEach(function (cabinet) {
                var html = template.render(cabinet);
                var row = $(html);
                $('#viewTable').append(row);/////need to  fix multiple tbody
            });
        });
        $('#viewCabinetsModal').modal();
    });
    $("#viewTable").on('click', '.edit-style', function () {
        $('#viewCabinetsModal').modal('hide');
        var id = $(this).data('id');
        var name = $(this).data('name');
        var lineId = $(this).data('lineid')
        $('#editForm').append('<input type="hidden" name="LineId" value="' + lineId + '" />');
        $('#editForm').append('<input type="hidden" name="Id" value="' + id + '" />');
        $('#edit-name').val(name);
        $('#editModal').modal();       
    })
    $("#viewTable").on('click', '.delete', function () {
        $('#viewCabinetsModal').modal('hide');
        var id = $(this).data('id');
        var name = $(this).data('name');
        var row = $(this).parent().parent();
        if (confirm('Are you sure you want to delete ' + name + '?')) {
            $.post('/admin/DeleteCabinet', { cabinetId: id }, function () {
                row.remove();
            });
        };
      
    });
});
