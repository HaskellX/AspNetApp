(function () {
    $('.authors').select2({
        ajax: {
            url: '/Author/AutoComplete',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    nameStartsWith: params.term
                }
            },
            processResults: function (data) {
                return {
                    results: data
                }
            },
            cache: true,
        }
    });

    $('.publishers').select2({
        ajax: {
            url: '/Publisher/AutoComplete',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    nameStartsWith: params.term
                }
            },
            processResults: function (data) {
                return {
                    results: data
                }
            },
            cache: true,
        }
    })

    $('.newspapers').select2({
        ajax: {
            url: '/Paper/AutoComplete',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    nameStartsWith: params.term
                }
            },
            processResults: function (data) {
                return {
                    results: data
                }
            },
            cache: true,
        }
    })
})()