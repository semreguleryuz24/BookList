var datatable;
$(document).ready(function (){
    loadDataTable();
});
function loadDataTable() {
    datatable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "bookName", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/BookLists/UpdateAdd?id=${data}" class='btn btn-success text-white' style='cursor:pointer;width:80px;'>
                     Düzenle </a>
                     &nbsp;
                     <a class='btn btn-danger text-white'style='cursor:pointer;width:80px;' onclick=Delete('/api/book?id='+${data}) >Sil</a> </div>`;
                }, "width": "40%"
            }


        ],
        "language": {
            "emptyTable": "Veri Bulunamadı!!"
        },
        "width": "100%"
    });
}
function Delete(url) {
    swal({
        title: "Silmek istediğinizden emin misiniz?",
        text: "İlgili veri silinirse tekrar geri döndürülmeyecektir.",
        icon: "warning",
        button: true,
        dangerMode: true
    }).then((silinecekmi) => {
        if (silinecekmi) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        DataTable.ajax.reLoad();
                    }
                    else {
                        toastr.error(data.message);

                    }
                }
            })

        }
    })
}