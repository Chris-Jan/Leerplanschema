$(".studie1").click(function () {
    window.location = $(this).find("a").attr("href");
    return false;
});

<<<<<<< HEAD
$("[class=btnModalPopup]").live("click", function () {
    $("#modal_dialog").dialog({
        title: "jQuery Modal Dialog Popup",


        modal: true
    });
    return false;
});

//$
=======

 $("[class=btnModalPopup]").live("click", function () {
            $("#modal_dialog").dialog({
                title: "Login",


                modal: true
            });
            return false;
});

>>>>>>> 24eb277e0bf848c730f225d941376aa91b57dcda
