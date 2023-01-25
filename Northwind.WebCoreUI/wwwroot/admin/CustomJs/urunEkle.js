$(document).ready(

    function () {

        $('#Aciklama').summernote({
            height: 250,   //set editable area's height
            codemirror: { // codemirror options
                theme: 'monokai'
            },
            placeholder: "Lütfen Ürün Açıklamasını yazınız."
        });

        $("#btnUrunEkle").click(
            function () {

                var vm = {

                    UrunAdi: $("#UrunAdi").val(),
                    Aciklama: $("#Aciklama").val(),
                    KategoriId: $("#KategoriId").val(),
                    BirimFiyati: $("#BirimFiyati").val(),
                    Stok: $("#Stok").val(),

                }
                var token = $('input[name="__RequestVerificationToken"]').val();



                $.ajax(
                    {
                        url: "/Admin/Urun/Ekle",
                        method: "post",
                        data: { __RequestVerificationToken: token, vm: vm },
                        dataType: "json",
                        success: function (response) {

                            if (response.result) {
                                Swal.fire(
                                    'İşlem Başarılı',
                                    "Ürün Başarıyla Eklendi.",
                                    'success'
                                ).then((result) => {

                                    window.location.href = "/Admin/Urun/Liste";
                                })
                            }
                            else {
                                Swal.fire(
                                    'İşlem Başarısız',
                                    response.mesaj,
                                    'error'
                                )
                            }

                        },
                        error: function () {

                        }
                    }
                );


            }
        );     
    }


);




