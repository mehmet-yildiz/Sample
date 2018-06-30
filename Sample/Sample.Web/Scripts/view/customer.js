//auto generated file

var Customer = {};

(function (customer) {
    customer.actions = { index: '', get: '', edit: '', del: '' }
    customer.init = function () {
        //init operations...
    };
    customer.get = function (data) {
        window.location = customer.actions.get + '/' + data.Id;
    };
    customer.edit = function (data) {
        window.location = customer.actions.edit + '/' + data.Id;
    };
    customer.delete = function (data) {
        if (confirm("are you sure?")) {

            setTimeout(function () {
                SAMPLE.Form.post(customer.actions.del, { id: data.Id }, function (data) {
                    window.location = customer.actions.index;
                });
            }, 100);
        }
    };
    customer.search = function (params) {
        //search operations
    };
})(Customer);