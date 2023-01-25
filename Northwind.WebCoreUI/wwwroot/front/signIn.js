$(document).ready(
    function () {

        $("#btnKayıtOl").click(
            function () {

                var vm = {

                    KullaniciAdi: $("#KullaniciAdi").val(),
                    Adi: $("#Adi").val(),
                    Sifre: $("#Sifre").val(),
                    SifreTekrar: $("#SifreTekrar").val(),
                    Soyadi: $("#Soyadi").val(),
                    Email: $("#Email").val(),
                  

                }
                var token = $('input[name="__RequestVerificationToken"]').val();



                $.ajax(
                    {
                        url: "/Home/Starter",
                        method: "post",
                        data: { __RequestVerificationToken: token, vm: vm },
                        dataType: "json",
                        success: function (response) {

                            if (response.result) {
                                Swal.fire(
                                    'İşlem Başarılı',
                                    response.mesaj,
                                    'success'
                                ).then((result) => {

                                    window.location.href = "/Admin/Kullanici/Login";
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