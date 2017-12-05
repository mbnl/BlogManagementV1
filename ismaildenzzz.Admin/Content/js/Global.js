// Route functions
function RouteEtiketDuzenle(id) {
    window.location.href = '/Etiket/Duzenle/' + id;
    //window.location.href = '@Url.Action("LogOut", "Home", new { ID = '+id+'})';
    return false;
}
function RouteKategoriDuzenle(id) {
    window.location.href = '/Kategori/Duzenle/' + id;
    //window.location.href = '@Url.Action("LogOut", "Home", new { ID = '+id+'})';
    return false;
}

function YorumSil(id) {
    $.ajax({
        url: '/Yorum/Sil/' + id,
        type: "POST",
        datatype: "json",
        success: function (response) {
            if (response.Success) {
                swal('Başarılı!', 'Yorum Silindi!', 'success');
                setTimeout(function () {
                    location.reload();
                }, 2000);

            }
            else {
                swal('Başarılı!', 'Yorum Silinemedi!', 'error');
            }
        }
    })
};
function YorumDetay(id) {
    $.ajax({
        type: "GET",
        url: "/Yorum/Detay",
        contentType: "application/json; charset=utf-8",
        data: { "id": id },
        datatype: "json",
        success: function (data) {
            debugger;
            $('#modal-content').html(data);
            $('#myModal').modal('show');

        },
        error: function () {
            alert("Popup yüklenirken bir hata oluştu.");
        }
    });


    $(".close").click(function () {
        $('#myModal').modal('hide');
    });
}
function YorumOnayla(id) {
    $.ajax({
        url: '/Yorum/Onayla/' + id,
        type: "POST",
        datatype: "json",
        success: function (response) {
            if (response.Success) {
                $.notify(response.Message, "success");
                setTimeout(function () {
                    location.reload();
                }, 2000);

            }
            else {
                $.notify(response.Message, "error");
            }
        }
    })
}
// Process functions 
//$('#myTable tbody').on('click', 'td button#etiketSil', function () {
//    var table = $("#myTable").DataTable();
//    debugger;
//    var tr = $(this).parents('tr');
//    var data = table.row(tr).data();
//    var id = data.ID;
    
//    $.ajax({
//        url: '/Etiket/Sil/' + id,
//        type: "POST",
//        datatype: "json",
//        success: function (response) {
//            if (response.Success) {
//                swal('Başarılı!', 'Etiket Silindi!', 'success');
//                table.row(tr).remove().draw();

//            }
//            else {
//                swal('Başarısız!', 'Etiket Silinemedi!', 'error');
//            }
//        }
//    })
//})
function EtiketSil(id) {
    $.ajax({
        url: '/Etiket/Sil/' + id,
        type: "POST",
        datatype: "json",
        success: function (response) {
            if (response.Success) {
                swal('Başarılı!', 'Etiket Silindi!', 'success');
                setTimeout(function () {
                    location.reload();
                }, 1000);
            }
            else {
                swal('Başarısız!', 'Etiket Silinemedi!', 'error');
            }
        }
    })
}
function EtiketDuzenle() {
    Etiket = new Object();
    Etiket.ID = $("#ID").val();
    Etiket.EtiketAdi = $("#EtiketAdi").val();
    $.ajax({
        url: "/Etiket/Duzenle",
        data: Etiket,
        type: "POST",
        datatype: "Json",
        success: function (response) {
            if (response.Success) {
                swal('Başarılı!', 'Etiket Düzenleme İşlemi Başarılı!', 'success');
                setTimeout(function () {
                    location.reload();
                }, 2000);
            }
            else {
                swal('Başarısız!', 'Etiket Düzenleme İşlemi Başarısız!', 'error');
            }
        }
    });
}
function EtiketEkle() {
    Etiket = new Object();
    Etiket.EtiketAdi = $("#EtiketAdi").val();
    $.ajax({
        url: "/Etiket/Ekle",
        data: Etiket,
        type: "POST",
        datatype: "Json",
        success: function (response) {
            if (response.Success) {
                swal('Başarılı!', 'Etiket Ekleme İşlemi Başarılı!', 'success');
                setTimeout(function () {
                    $("#EtiketAdi").val("");
                }, 1000);
            }
            else {
                swal('Başarısız!', 'Etiket Ekleme İşlemi Başarısız!', 'error');
            }
        }
    });
}

function KategoriSil(id) {
    $.ajax({
        url: '/Kategori/Sil/' + id,
        type: "POST",
        datatype: "json",
        success: function (response) {
            if (response.Success) {
                swal('Başarılı!', 'Kategori Silindi!', 'success');
                setTimeout(function () {
                    location.reload();
                }, 1000);
            }
            else {
                swal('Başarısız!', 'Kategori Silinemedi!', 'error');
            }
        }
    })
}
function KategoriEkle() {
    Kategori = new Object();
    Kategori.KategoriAdi = $("#KategoriAdi").val();
    $.ajax({
        url: "/Kategori/Ekle",
        data: Kategori,
        type: "POST",
        datatype: "Json",
        success: function (response) {
            if (response.Success) {
                swal('Başarılı!', 'Kategori Ekleme İşlemi Başarılı!', 'success');
                setTimeout(function () {
                    $("#KategoriAdi").val("");
                }, 1000);
            }
            else {
                swal('Başarısız!', 'Kategori Ekleme İşlemi Başarısız!', 'error');
            }
        }
    });
}
function KategoriDuzenle() {
    debugger;
    Kategori = new Object();
    Kategori.ID = $("#ID").val();
    Kategori.KategoriAdi = $("#KategoriAdi").val();
    $.ajax({
        url: "/Kategori/Duzenle",
        data: Kategori,
        type: "POST",
        datatype: "Json",
        success: function (response) {
            if (response.Success) {
                swal('Başarılı!', 'Kategori Düzenleme İşlemi Başarılı!', 'success');
                setTimeout(function () {
                    location.reload();
                }, 2000);
            }
            else {
                swal('Başarısız!', 'Etiket Düzenleme İşlemi Başarısız!', 'error');
            }
        }
    });
}


function BlogEkle() {
    Kategori = new Object();
    Kategori.KategoriAdi = $("#KategoriAdi").val();
    $.ajax({
        url: "/Kategori/Ekle",
        data: Kategori,
        type: "POST",
        datatype: "Json",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                })
            }
            else {
                bootbox.alert(response.Message, function () {
                    // istediğim birsey yazabiliriz.
                })
            }
        }
    });
}
function BlogDuzenle() {
    debugger;
    Kategori = new Object();
    Kategori.ID = $("#ID").val();
    Kategori.KategoriAdi = $("#KategoriAdi").val();
    $.ajax({
        url: "/Kategori/Duzenle",
        data: Kategori,
        type: "POST",
        datatype: "Json",
        success: function (response) {
            if (response.Success) {
                bootbox.alert(response.Message, function () {
                    location.reload();
                })
            }
            else {
                bootbox.alert(response.Message, function () {
                    // istediğim birsey yazabiliriz.
                })
            }
        }
    });
}
function BlogSil(id) {
    $.ajax({
        url: '/Blog/Sil/' + id,
        type: "POST",
        datatype: "json",
        success: function (response) {
            if (response.Success) {
                swal('Başarılı!', 'Blog Silindi!', 'success');
                setTimeout(function () {
                    location.reload();
                }, 1000);

            }
            else {
                swal('Başarısız!', 'Blog Silinemedi!', 'error');
            }
        }
    })
}

