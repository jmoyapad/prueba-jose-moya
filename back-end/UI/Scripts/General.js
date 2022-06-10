var GeneralMod = {
    var: {},
    fun: {
        init: function () {

         
        },
        irHistorialRegistro: function (userId) {
            GeneralMod.fun.redirect('https://localhost:44386/Home/Registros/'+userId);

        },
        redirect: function (url) {
            window.location.href = url ;
        },
        ajaxCallBack: function (url, data, type, callback) {
            $.ajax({
                type: type,
                url: url,
                dataType: 'JSON',
                data: data,
                cache: false,
                success: function (response) {
                    callback(response);
                },
                error: function (response) {
                    callback(response);
                }
            });
        },  
    },
    eve: {        
    },
    con: {
        API_USUARIOS: 'https://localhost:44393/api/Usuarios',
        API_ACTIVIDADES: 'https://localhost:44393/api/Actividades'
    }
};

(function () {
    GeneralMod.fun.init();
}());