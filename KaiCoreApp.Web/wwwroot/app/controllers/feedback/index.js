var feedbackController = function () {
    this.initialize = function () {
        loadData();
        registerEvent();
    }

    function registerEvent() {
        //Init validation
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                txtNameM: { required: true },
                ddlCategoryIdM: { required: true },
                txtPriceM: {
                    required: true,
                    number: true
                },
                txtTagM: { required: true }
            }
        });
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

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $.ajax({
                type: 'GET',
                url: "/Admin/Feedback/GetById",
                data: { id: that },
                dataType: 'json',
                beforeSend: function () {
                    kai.startLoading();
                },
                success: function (res) {
                    var data = res;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    initTreeDropDownCategory(data.CategoryID);

                    $('#txtDescM').val(data.Description);
                    $('#txtUnitM').val(data.Unit);

                    $('#txtPriceM').val(data.Price);
                    $('#txtOriginalPriceM').val(data.OriginalPrice);
                    $('#txtPromotionPriceM').val(data.PromotionPrice);

                    $('#txtImageM').val(data.Image);

                    $('#txtSeoPageTitleM').val(data.SeoPageTitle);
                    $('#txtSeoAliasM').val(data.SeoAlias);
                    $('#txtMetakeywordM').val(data.SeoKeyWords);

                    $('#txtMetaDescriptionM').val(data.Description);
                    $('#txtTagM').val(data.Tags);

                    CKEDITOR.instances.txtContentM.setData(data.Content);

                    $('#ckStatusM').prop('checked', data.Status == 1);
                    $('#ckHotM').prop('checked', data.HotFlag);
                    $('#ckShowHomeM').prop('checked', data.HomeFlag);

                    $('#modalAddOrEdit').modal('show');
                    kai.stopLoading();
                },
                error: function (status) {
                    kai.notify('Có lỗi xảy ra khi thực thi', 'error');
                    kai.stopLoading();
                }
            });
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
            url: '/admin/feedback/GetAllPaging',
            dataType: 'json',
            success: function (res) {
                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Email: item.Email,
                        Message: item.Message,
                        CreatedDate: item.CreatedDate,
                        Status: kai.getStatus(item.Status)
                    });
                });
                $('#lblTotalRecords').text(res.RowCount);
                if (render != '') {
                    $('#tbl-product').html(render);
                }
                wrapPaging(res.RowCount, function () {
                    loadData();
                }, isPageChanged);
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