var productController = function () {
    this.initialize = function () {
        loadData();
    }

    function registerEvent() {
        //todo: binding events to controller
    }

    function loadData() {
        var template = $('#table-template').html();
        var render = '';
        $.ajax({
            type: 'GET',
            url: '/admin/product/GetAll',
            dataType: 'json',
            success: function (res) {
                $.each(res, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Image: item.Image == null ? 'img src="/admin-side/user.png" width=25px' : '<img src="' + item.Image + '" width=25px',
                        CategoryName: item.ProductCategory.Name,
                        Price: kai.formatNumber(item.Price, 0),
                        CreatedDate: kai.dateTimeFormatJson(item.CreatedDate),
                        Status: kai.getStatus(item.Status)
                    });
                    if (render != '') {
                        $('#tbl-product').html(render);
                    }
                });
            },
            error: function (status) {
                console.log(status);
                kai.notify('Load failed', 'error');
            }
        });
    }
}