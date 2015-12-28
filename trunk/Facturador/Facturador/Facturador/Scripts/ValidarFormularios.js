
function foco(elemento) {
    elemento.style.border = "1px solid #DFBA78";
}

function no_foco(elemento) {
    elemento.style.border = "1px solid #CCCCCC";

}

function NoValido(elemento) {
    elemento.style.border = '2px solid red';
    elemento.focus();
}
function Valido(elemento) {
    elemento.style.border = '1px solid #CCCCCC';

}




function valida_envia() {

    var pasavalidaciones;
    pasavalidaciones = true;

    //valido el nombre
    Valido(document.aspnetForm.RegistroContent_txtNombre);
    if (document.aspnetForm.RegistroContent_txtNombre.value.length == 0) {
        NoValido(document.aspnetForm.RegistroContent_txtNombre);
        pasavalidaciones = false;

    }


    //validamos correo
    Valido(document.aspnetForm.Correo);
    var RegExPattern = /[\w-\.]{3,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
    if ((document.aspnetForm.Correo.value.match(RegExPattern)) && (document.aspnetForm.Correo.value != '')) {
    } else {
        NoValido(document.aspnetForm.Correo);
        pasavalidaciones = false;
    }


    var RegExPattern1 = /^([0-9])*$/;
    if ((document.aspnetForm.Lada.value.match(RegExPattern1)) && (document.aspnetForm.Lada.value != '')) {
    } else {
        NoValido(document.aspnetForm.Lada);
        pasavalidaciones = false;
    }


    var RegExPattern2 = /^([0-9])*$/;
    if ((document.aspnetForm.Telefono.value.match(RegExPattern2)) && (document.aspnetForm.Telefono.value != '')) {
    } else {
        NoValido(document.aspnetForm.Telefono);
        pasavalidaciones = false;
    }

    return pasavalidaciones;


}


$(document).ready(function () {

    $('form#aspnetForm').submit(function () {

        $('#ctl00_ContentPlaceHolder1_btnRegistrar').attr('disabled', 'disabled');
        MostrarMensajeFiel();
    });

});

function MostrarMensajeFiel() {
    $("#Registro").hide();
    $("#divSplash").show();
}

