$(document).ready(
    function () {
        $(".btnUrunDuzenle").click(
            function(){
                var id = $(this).attr("name");
                var token = $('input[name="__RequestVerificationToken"]').val();
                $.ajax(
                    {
                        url: "/Admin/Kategori/KategoriGetir",
                        method: "post",
                        data: { __RequestVerificationToken: token, KategoriId: id },
                        dataType: "json",
                        success: function (response) {

                            if (response.result) {


                                $("#GID").val(id);


                                $("#GKategoriAdi").val(response.kategori.kategoriAdi);
                                $("#GAciklama").val(response.kategori.aciklama);



                                $("#GUstKategoriId").html("");
                                var selects = "";
                                for (var i = 0; i < response.model.kategoriSelectList.length; i++) {

                                    if (response.model.kategoriSelectList[i].value == response.kategori.ustKategoriId) {
                                        selects += "<option selected value='" + response.model.kategoriSelectList[i].value + "'>" + response.model.kategoriSelectList[i].text + "</option>";
                                    }
                                    else {
                                        selects += "<option value='" + response.model.kategoriSelectList[i].value + "'>" + response.model.kategoriSelectList[i].text + "</option>";
                                    }
                                }
                                $("#GUstKategoriId").html(selects);



                                $("#KategoriGuncelleModal").modal("show");



                            }




                        },
                        error: function () {


                        }

                    }
                );
            }
        );
        




        $("#btnKategoriEkle").click(
            function (){
                var model =
                {
                    KategoriAdi: $("#KategoriAdi").val(),
                    Aciklama: $("#Aciklama").val(),
                    
                }

                $.ajax(
                    {
                        url: "/Admin/Kategori/Ekle",
                        dataType: "json",
                        method: "Post",
                        data: { vm: model },
                        success: function (r) {


                            if (r.result) {

                                Swal.fire(
                                    'BAŞARILI',
                                    r.mesaj,
                                    'success'
                                ).then((result) => {

                                    window.location.href = "/Admin/Kategori/Index";
                                })
                                                       
                            }

                        },
                        error: function () {



                        }
                    }
                );

            }

        );

        //---------------------------------

        $("#btnKategoriGuncelle").click(
            function () {

                var vm = {

                    KategoriId: $("#GID").val(),
                    KategoriAdi: $("#GKategoriAdi").val(),
                    Aciklama: $("#GAciklama").val()
                }
                var token = $('input[name="__RequestVerificationToken"]').val();

                $.ajax(
                    {
                        url: "/Admin/Kategori/KategoriGuncelle",
                        method: "post",
                        data: { __RequestVerificationToken: token, kat: vm },
                        dataType: "json",
                        success: function (r) {

                            if (r.result) {

                                Swal.fire({
                                    title: 'BAŞARILI',
                                    text: r.kategori.kategoriAdi + " Ürünü Başaıyla Güncellendi",
                                    icon: 'success',
                                    showCancelButton: false,
                                    confirmButtonColor: '#3085d6',
                                    confirmButtonText: 'TAMAM'
                                }).then((result) => {

                                    window.location.href = "/Admin/Kategori/Index";
                                })
                            }




                        },
                        error: function () {


                        }

                    }

                );

            }
        );
        //------------------------------------
        $(".btnKategoriSil").click(
            function () {

                var id = $(this).attr("name");

                Swal.fire({
                    title: 'DİKKAT?',
                    text: "Ürün Silinecek Emin Misiniz?",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'SİL',
                    cancelButtonText: 'VAZGEÇ'
                }).then((result) => {
                    if (result.isConfirmed) {


                        $.ajax({

                            url: "/Admin/Kategori/KategoriSil",
                            method: "Post",
                            data: { key: id },
                            success: function (r) {
                                if (r.result) {

                                    Swal.fire(
                                        'İşlem Başarılı',
                                        r.mesaj,
                                        'success'
                                    ).then((result) => {

                                        window.location.href = "/Admin/Kategori/Index";
                                    })




                                }
                                else {
                                    Swal.fire({
                                        icon: 'error',
                                        title: 'Hata',
                                        text: r.mesaj

                                    })
                                }

                            },
                            error: function () {

                                Swal.fire({
                                    icon: 'error',
                                    title: 'Hata',
                                    text: 'Hata oldu'

                                })
                            }

                        });




                    }

                });
            }
        );
    }
);
