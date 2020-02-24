function formValidate() {
    if (typeof (Page_Validators) != "undefined") {
        for (var i = 0; i < Page_Validators.length; i++) {
            if (!Page_Validators[i].isvalid) {
                $('#' + Page_Validators[i].controltovalidate).css("border-color", "#b94a48");
                $('#' + Page_Validators[i].controltovalidate).css("background", "#f9e8e8");
                //$('#' + Page_Validators[i].controltovalidate + '_chzn').children('a').addClass("FieldRequired");
                $('#' + Page_Validators[i].controltovalidate + '_chzn').children('a').css("border", "1px solid #b94a48");
                $('#' + Page_Validators[i].controltovalidate + '_chzn').children('a').css("background", "#f9e8e8");
             
            }
            else {
                $('#' + Page_Validators[i].controltovalidate).css("border-color", "#B5B5B5");
                $('#' + Page_Validators[i].controltovalidate).css("background", "");
                //$('#' + Page_Validators[i].controltovalidate + '_chzn').children('a').removeClass("FieldRequired");
                $('#' + Page_Validators[i].controltovalidate + '_chzn').children('a').css("border-color", "#B5B5B5");
                $('#' + Page_Validators[i].controltovalidate + '_chzn').children('a').css("background", "");
               
            }
        }
    }
}