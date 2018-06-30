var SAMPLE = SAMPLE || {};

SAMPLE.Form = {
    post: function (url, data, func) {
        var formData = {};
        //show loader...
        $.post(url, formData, function (result) {
            if (func)
                func(result);
            //hide loader...
        });
    }
};
