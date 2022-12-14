$(function () {

    var userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);
    function onUserLoginClick() {

        var antiForgeryToken = $("#UserLoginModal input[name='__RequestVerificationToken']").val();

        var email = $("#UserLoginModal input[name = 'Email']").val();
        var password = $("#UserLoginModal input[name = 'Password']").val();
        var logininvalid = $("#UserLoginModal input[name = 'LoginInValid']").val("false");
        var loginfailedmessage = $("UserLoginModal input[name= 'LoginFailedMessage']").val("");

        var rememberMe = $("#UserLoginModal input[name = 'RememberMe']").prop('checked');

        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            RememberMe: rememberMe,
            LoginFailedMessage: "empty",
            LoginInValid: "false"
        };

        $.ajax({
            type: 'POST',
            url: 'UserAuth/Login',
            data: userInput,
            success: function (data) {

                var parsed = $.parseHTML(data);
                var hasErrors = $(parsed).find("input[name='LoginInValid']").val() == "true";
                var role = $(parsed).find("input[name='_role']").val();



                if (hasErrors == true) {
                    $("#UserLoginModal").html(data);

                    userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);

                    var form = $("#UserLoginForm");

                    $(form).removeData("validator");

                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);
                }
                else {
                    //let url = role == "Admin" ? 'Home/AdminDashboard' : 'Home/UserDashboard';
                    //location.href = url;
                    location.href = 'Home/Dashboard'; 
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                console.log(errorText);

                // PresentClosableBootstrapAlert("#alert_placeholder_login", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
});