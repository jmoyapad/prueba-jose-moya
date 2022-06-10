var UsuarioMod = {
    var: {},
    fun: {
        init: function () {

            var url = GeneralMod.con.API_USUARIOS;
            var data = { id: 0 };
            GeneralMod.fun.ajaxCallBack(url, data, 'GET', function (rs) {
                console.log(JSON.stringify(rs));

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
                        + "<td>" + "<button type='button' onclick='GeneralMod.fun.irHistorialRegistro(" + current.IdUsuario+");' class='btn btn-info'><i class='icon-pencil icon-2x'></i>Ver</button>"
                                 + "<button type='button' class='btn btn-warning'>Modificar</button>"
                        + "<button type='button' onclick='UsuarioMod.fun.delete(" + current.IdUsuario +");' class='btn btn-danger'>Eliminar</button>"
                        + "</td>"
                        + "</tr>";
                    console.log(registro);
                    $('#tablaUsuarios > tbody').append(registro);
                }


                $("#tablaUsuarios").DataTable();
            });
        },
        delete: function (idUsuario) {

            if (confirm("Esta seguro que desea eliminar?") == true) {
                var url = GeneralMod.con.API_USUARIOS +'/'+idUsuario;
                var data = null;
                GeneralMod.fun.ajaxCallBack(url, data, 'DELETE', function (rs) {
                    alert(rs.Msg);
                });
            }


            

        },
        add: function () {
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

                alert(rs.Msg);
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