$(document).ready(
    function () {

        $(".btnBilgileriGetir").click(
            function () {

                var id = $(this).attr("name");

                $.ajax(
                    {
                        url: "/Admin/Urun/UrunBilgileriGetir",
                        method: "Get",
                        data: { urunid: id },
                        dataType: "json",
                        success: function (r) {
                            if (r.result) {


                                $("#baslik").text(r.u.urunAdi);
                                $("#UrunBilgileriModal #kategoriadi").text(r.k.kategoriAdi);
                                $("#UrunBilgileriModal #aciklama").text(r.k.aciklama + " " + r.u.aciklama);
                                $("#UrunBilgileriModal #hedefStokDüzeyi").text(r.u.hedefStokDuzeyi);
                                $("#UrunBilgileriModal #birimfiyati").text(r.u.birimFiyati);


                                $("#UrunBilgileriModal").modal("show");

                            }
                        },
                        error: function (r) {

                        }


                    }

                );

            }
        );
        //-----------------
        $(".btnUrunDuzenle").click(

            function () {

                var id = $(this).attr("name");

                $.ajax({

                    url: "/Admin/Urun/UrunGetir",
                    method: "post",
                    dataType: "json",
                    data: { key: id, },
                    success: function (ahmet) {
                        if (ahmet.result) {
                            $("#gUrunId").val(id);

                            $("#ModalUpdate #UtxtUrunAdi").val(ahmet.u.urunAdi);
                            $("#ModalUpdate #UtxtBirimFiyati").val(ahmet.u.birimFiyati);
                            $("#ModalUpdate #UtxtStok").val(ahmet.u.hedefStokDuzeyi);
                            $("#ModalUpdate #UtxtAciklama").text(ahmet.k.aciklama + " " + ahmet.u.aciklama);

                            var kategoriler = "";
                            for (var i = 0; i < ahmet.kategorilerList.length; i++) {


                                if (ahmet.kategorilerList[i].value == ahmet.u.kategoriID) {

                                    kategoriler += "<option selected value='" + ahmet.kategorilerList[i].value + " ' >" + ahmet.kategorilerList[i].text + "</option>";
                                }
                                else {
                                    kategoriler += "<option value=' " + ahmet.kategorilerList[i].value + " ' >" + ahmet.kategorilerList[i].text + "</option>";
                                }

                            }
                            $("#UKategoriID").html(kategoriler);

                            $("#ModalUpdate").modal("show");

                        }

                    },
                    error: function () {


                    }

                });

            }
        );



        //-----------------

        $("#btnUrunGuncelle").click(
            function () {

                var model =
                {
                    UrunID: $("#gUrunId").val(),
                    UrunAdi: $("#UtxtUrunAdi").val(),
                    HedefStokDuzeyi: $("#UtxtStok").val(),
                    BirimFiyati: $("#UtxtBirimFiyati").val(),
                    KategoriID: $("#UKategoriID").val(),
                    Aciklama: $("#UtxtAciklama").val(),

                }

                $.ajax({

                    url: "/Admin/Urun/UrunGuncelle",
                    method: "post",
                    dataType: "json",
                    data: { urun: model },
                    success: function (d) {
                        if (d.result) {

                            Swal.fire({
                                title: 'BAŞARILI',
                                text: d.u.urunAdi + " Ürünü Başaıyla Güncellendi",
                                icon: 'success',
                                showCancelButton: false,
                                confirmButtonColor: '#3085d6',
                                confirmButtonText: 'TAMAM'
                            }).then((result) => {

                                window.location.href = "/Admin/Urun/Liste";
                            })


                        }
                    },
                    error: function () {


                    }

                });









            }


        );

        $(".btnUrunSil").click(
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
                        $.ajax(
                            {
                                url: "/Admin/Urun/UrunSil",
                                method: "Post",
                                data: { urunid: id },
                                success: function (r) {
                                    if (r.result) {
                                        Swal.fire(
                                            'İşlem Başarılı',
                                            r.mesaj,
                                            'success'
                                        ).then((result) => {

                                            window.location.href = "/Admin/Urun/Liste";
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
                                error: function (r) {

                                    Swal.fire({
                                        icon: 'error',
                                        title: 'Hata',
                                        text: r.mesaj

                                    })
                                }

                            }
                        );

                    }

                });
            }
        );
    }
);
