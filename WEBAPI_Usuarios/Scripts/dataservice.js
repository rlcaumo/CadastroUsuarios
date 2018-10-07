//Encapsulates data calls to server (AJAX calls)
var dataService = new function () {
    var serviceBase = '/api/usuarios/',

        getUsuarioById = function (usuarioId, callback) {
            $.getJSON(serviceBase + 'GetUsuario', { usuarioId: usuarioId }, function (data) {
                callback(data);
            });
        },

        getUsuarios = function (callback) {
            $.getJSON(serviceBase + 'GetUsuarios', function (data) {
                callback(data);
            });
        };

    return {
        getUsuarioById: getUsuarioById,
        getUsuarios: getUsuarios,
    };

}();
