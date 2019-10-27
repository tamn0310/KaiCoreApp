var productController = function () {
    this.initialize = function () {
        loadCate();
        loadData();
        registerEvent();
    }

    function registerEvent() {
        //todo: binding events to controller
        $('#ddlShowPage').on('change', function () {
            kai.configs.pageSize = $(this).val();
            kai.configs.pageIndex = 1;
            loadData(true);
        });
        $('#btnSearch').on('click', function () {
            loadData();
        });
        $('#txtSearch').on('keypress', function (e) {
            if (e.which === 13) {
                loadData();
            }
        });
    }

    function loadCate() {
        $.ajax({
            type: 'GET',
            url: '/admin/product/GetAllCategory',
            dataType: 'json',
            success: function (res) {
                var render = "<option value=''>--Chọn danh mục--</option>";
                $.each(res, function (i, item) {
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>"
                });
                $('#ddlProductCate').html(render);
            },
                error: function (status) {
                    kai.notify('Không thể tải dữ liệu của danh mục sản phẩm', 'error');
                }
            });
    }

    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = '';
        $.ajax({
            type: 'GET',
            data: {
                categoryId: $('#ddlProductCate').val(),
                search: $('#txtSearch').val(),
                page: kai.configs.pageIndex,
                pageSize: kai.configs.pageSize
            },
            url: '/admin/product/GetAllPaging',
            dataType: 'json',
            success: function (res) {
                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Image: item.Image == null ? 'img src="/admin-side/user.png" width=25px' : '<img src="' + item.Image + '" width=25px',
                        CategoryName: item.ProductCategory.Name,
                        Price: kai.formatNumber(item.Price, 0),
                        CreatedDate: kai.dateTimeFormatJson(item.CreatedDate),
                        Status: kai.getStatus(item.Status)
                    });
                    $('#lblTotalRecords').text(res.RowCount);
                    if (render != '') {
                        $('#tbl-product').html(render);
                    }
                    wrapPaging(res.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                });
            },
            error: function (status) {
                console.log(status);
                kai.notify('Không thể tải dữ liệu', 'error');
            }
        });
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / kai.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                kai.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}