function YorumEkle() {
    Yorum = new Object();
    Yorum.Adsoyad = $("#YorumAdSoyad").val();
    Yorum.Mail = $("#YorumMail").val();
    Yorum.Site = $("#YorumSite").val();
    Yorum.YorumMesaj = $("#YorumMesaj").val();
    if ($("#YorumAdSoyad").val() != "" && $("#YorumMail").val() != "" && $("#YorumMesaj").val() != "")
    {
        if (isEmail($("#YorumMail").val())) {
            $.ajax({
                url: "/Yorum/Ekle",
                data: Yorum,
                type: "POST",
                datatype: "Json",
                success: function (response) {
                    if (response.Success) {
                        alert('Yorum Ekleme İşlemi Başarılı!');
                        setTimeout(function () {
                            $("#YorumAdSoyad").val("");
                            $("#YorumMail").val("");
                            $("#YorumSite").val("");
                            $("#YorumMesaj").val("");
                        }, 1000);
                    }
                    else {
                        alert('Yorum Ekleme İşlemi Başarısız!');
                    }
                }
            });
        }
        else
        {
            alert('Lütfen Mailinizin doğruluğundan emin olun!');
        }
    }
    else {
        alert('Lütfen bilgileri eksiksiz doldurunuz!');
    }
}

function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}