/*Section-User*/
var password = $("#User-UserRegister-InputPassword");

var passwordVerify = $("#User-UserRegister-InputPasswordVerify").on("input", function () {

    if (password.val() == passwordVerify.val()) {
        console.log("Opa");
        $("#User-UserRegister-SmallPasswordVerify").css('color', '#007bff');;
    }
});

$("#User-UserRegister-BtnClean").click(function () {

    $("#User-UserRegister-InputName").val("");
    $("#User-UserRegister-InputNickname").val("");
    $("#User-UserRegister-InputEmail").val("");
    $("#User-UserRegister-InputPassword").val("");
    $("#User-UserRegister-InputPasswordVerify").val("");
});

$("#User-UserDetails-BtnReset").click(function () {

    $("#User-UserDetails-InputName").val($("#User-UserDetails-Name").text().trim());
    $("#User-UserDetails-InputNickname").val($("#User-UserDetails-Nickname").text().trim());
    $("#User-UserDetails-InputEmail").val($("#User-UserDetails-Email").text().trim());
});