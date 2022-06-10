var UsuarioMod = {
    var: {},
    fun: {
        init: function () {

            var url = GeneralMod.con.API_USUARIOS;
            var data = { id: 0 };
            GeneralMod.fun.ajaxCallBack(url, data, 'GET', function (rs) {              

                for (var i = 0; i < rs.Result.length; i++) {
                    var current = rs.Result[i];
                    var recibeInformacion = current.RecibeInformacion == true ? 'SI' : 'NO';
                    var registro = "<tr>"
                        + "<td>" + current.Nombre + "</td>"
                        + "<td>" + current.Apellidos + "</td>"
                        + "<td>" + current.CorreoElectronico +"</td>"
                        + "<td>" + current.Telefono + "</td>"
                        + "<td>" + current.IdPais + "</td>"
                        + "<td>" + recibeInformacion + "</td>"
                        + "<td>" + "<p><button type='button' onclick='UsuarioMod.fun.mostrarActividades(" + current.IdUsuario + ");' class='btn btn-info'>Ver Actividad</button></p>"
                        + "<p><button type='button' class='btn btn-warning'>Modificar</button></p>"
                        + "<button type='button' onclick='UsuarioMod.fun.delete(" + current.IdUsuario +");' class='btn btn-danger'>Eliminar</button>"
                        + "</td>"
                        + "</tr>";                    
                    $('#tablaUsuarios > tbody').append(registro);
                }

                $("#tablaUsuarios").DataTable();
            });
        },
        delete: function (idUsuario) {

            bootbox.confirm("Esta seguro que desea eliminar el usuario?", function (result) {
                if (result) {
                    var url = GeneralMod.con.API_USUARIOS + '/' + idUsuario;
                    var data = null;
                    GeneralMod.fun.ajaxCallBack(url, data, 'DELETE', function (rs) {
                        alert(rs.Msg);
                    });
                }
            });
        },
        add: function () {

            bootbox.confirm("Esta seguro que desea crear un usuario nuevo?", function (result) {
                if (result) {
                    var url = GeneralMod.con.API_USUARIOS;
                                var data = {
                                    IdUsuario: 0,
                                    Nombre: $("#Nombre").val(),
                                    Apellidos: $("#Apellidos").val(),
                                    CorreoElectronico: $("#CorreoElectronico").val(),
                                    FechaNacimiento: $("#FechaNacimiento").val(),
                                    Telefono: $("#Telefono").val(),
                                    IdPais: $("#IdPais option:selected").val(),
                                    RecibeInformacion: $("#RecibeInformacion-1").is(":checked") == true ? true : false,
                                    Activo: true
                                };
                    GeneralMod.fun.ajaxCallBack(url, data, 'POST', function (rs) {
                        bootbox.alert({
                            message: rs.Msg,
                            size: 'small'
                        });
                        
                    });
                }
            });
        },
        mostrarActividades: function (idUsuario) {

            var url = GeneralMod.con.API_ACTIVIDADES;
            var data = { id: idUsuario };
            GeneralMod.fun.ajaxCallBack(url, data, 'GET', function (rs) {
                var tabla = "";
                var registros = ""
                for (var i = 0; i < rs.Result.length; i++) {

                    var current = rs.Result[i];
                    var tr = "<tr>"
                        + "<td> " + current.CreateDate + " </td>"
                        + "<td> " + current.Nombre + " </td>"
                        + "<td> " + current.Actividad + " </td>"                        
                        + "</tr>";
                    registros += tr;
                }

                tabla = '<table border="2">'
                       +'<thead class="thead-dark">'
                    +' <tr>'
                    +'      <th scope="col">Fecha de Actividad</th>'
                    +'      <th scope="col">Nombre Completo</th>'
                    +'      <th scope="col">Detalle de Actividad</th>'
                    +'  </tr>'
                    +'</thead>'
                    +'<tbody id="tableBody">'
                    + registros
                    +'</tbody>'
                    + '</table >';

                bootbox.alert({
                    message: tabla,
                    size: 'large'
                });
                
            });
        }
    },       
    eve: {
            init: function () { },
        },
        val: {
            init: function () { }
        },
        con: {

        }
    };

(function () {
  
    if ($('#tablaUsuarios').val() !== undefined) {
        UsuarioMod.fun.init();
    }    
}());