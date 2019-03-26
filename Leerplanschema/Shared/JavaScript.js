$(".studie1").click(function () {
    window.location = $(this).find("a").attr("href");
    return false;
});

$("[class=btnModalPopup]").live("click", function () {
    $("#modal_dialog").dialog({
        title: "jQuery Modal Dialog Popup",


        modal: true
    });
    return false;
});