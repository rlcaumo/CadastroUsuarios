var ViewModel = function () {
    var self = this;
    self.usuarios = ko.observableArray([]);
    self.error = ko.observable();
    self.detail = ko.observable();
    self.newUsuario = {
        Nome: ko.observable(),
        Sobrenome: ko.observable(),
        Email: ko.observable(),
        Telefone: ko.observable(),
        Endereco: ko.observable()
    }
    self.updUsuario = {
        Id: ko.observable(),
        Nome: ko.observable(),
        Sobrenome: ko.observable(),
        Email: ko.observable(),
        Telefone: ko.observable(),
        Endereco: ko.observable()
    }

    var usuariosUri = '/api/usuarios/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllUsuarios() {
        ajaxHelper(usuariosUri, 'GET').done(function (data) {
            self.usuarios(data);
        });
    }

    self.getUsuario = function (item) {
        ajaxHelper(usuariosUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.addUsuario = function (formElement) {
        var usuario = {
            Nome: self.newUsuario.Nome(),
            Sobrenome: self.newUsuario.Sobrenome(),
            Email: self.newUsuario.Email(),
            Telefone: self.newUsuario.Telefone(),
            Endereco: self.newUsuario.Endereco()
        };

        ajaxHelper(usuariosUri, 'POST', usuario).done(function (item) {
            self.usuarios.push(item);
        });
    }

    self.updateUsuario = function (formElement) {
        var usuario = {
            Id: self.updUsuario.Id(),
            Nome: self.updUsuario.Nome(),
            Sobrenome: self.updUsuario.Sobrenome(),
            Email: self.updUsuario.Email(),
            Telefone: self.updUsuario.Telefone(),
            Endereco: self.updUsuario.Endereco()
        };

        ajaxHelper(usuariosUri + item.Id, 'PUT', usuario).done(function (item) {
            self.usuarios.push(item);
        });
    }

    // Fetch the initial data.
    getAllUsuarios();
};

ko.applyBindings(new ViewModel());
