var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }

    var registerEvents = function () {
        $('#frmLogin').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                userName: {
                    required:true
                },
                password: {
                    required:true
                }
            }
        });
        $('#txtPassword').on('keypress', function (e) {
            if (e.which === 13) {
                e.preventDefault();
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                login(user, password);
            }
        });
        $('#btnLogin').on('click', function (e) {
            if ($('#frmLogin').valid()) {
                e.preventDefault();
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                login(user, password);
            }
        });
    }

    var login = function (user, pass) {
        $.ajax({
            type: 'POST',
            data: {
                UserName: user,
                password: pass
            },
            dateType: 'json',
            url: '/admin/login/authen',
            success: function (res) {
                if (res.Success) {
                    kai.notify("Đăng nhập thành công, chào mừng về nhà.", "success");
                    window.location.href = "/Admin/Home/Index";
                   
                }
                else {
                    kai.notify('Đăng nhập thất bại, vui lòng nhập lại tài khoản và mật khẩu.', 'error');
                }
            }
        })
    }
}