$(function () {
    var durum;
    var durum1;
    var success_icon = '<i class="mdi mdi-check-circle text-success"></i>';
    var danger_icon = '<i class="mdi mdi-close-circle text-danger"></i>';
    $(document).on('keyup', '#kullaniciadi', function (e) {
        var html = "";
        $('#messageusername').prop('hidden', false);

        $.ajax({
            url: '/Account/UsernameCheck',
            data: { username: $('#kullaniciadi').val() },
            dataType: 'json',
            success: function (data) {
                if (data) {
                    html = '<div class="text-danger"><div>' + danger_icon + ' Kullanıcı adı zaten kullanımda.</div></div>';
                    $('#messageusername').html(html);
                    durum = false;
                }
                else {
                    html = '<div class="text-success"><div>' + success_icon + ' Kullanıcı adı kullanılabilir.</div></div>';
                    $('#messageusername').html(html);
                    durum = true;
                }
            }
        });

        console.log(durum);
    });

    $(document).on('keyup', '#email', function (e) {
        var html = "";
        $('#messagemail').prop('hidden', false);

        $.ajax({
            url: '/Account/EmailCheck',
            data: { email: $('#email').val() },
            dataType: 'json',
            success: function (data) {
                if (data) {
                    html = '<div class="text-danger"><div>' + danger_icon + ' Email zaten kullanımda.</div></div>';
                    $('#messagemail').html(html);
                    durum1 = false;
                }
                else {
                    html = '<div class="text-success"><div>' + success_icon + ' Email kullanılabilir.</div></div>';
                    $('#messagemail').html(html);
                    durum1 = true;
                }
            }
        });
    });
    $(document).on('click', '#submit', function (e) {
        e.preventDefault();

        //TODO: burada kodlar daha iyi optimize edilebilirdi, reusable kodlar oluşturulabilirdi ama zaman kısıtlı oldugu için böyle olmak zorunda ileride kodları düzenleyen biri olursa hallediversin.

        if (!durum) {
            $('#kullaniciadi').focus();
        } else if (!durum1) {
            $('#email').focus();
        } else {
            $('#submit1').click();
        }

    });
});