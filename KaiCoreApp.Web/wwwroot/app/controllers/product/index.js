var productController = function () {
    this.initialize = function () {
        loadCate();
        loadData();
        registerEvent();
        registerControls();
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
                }
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

        $('#btnCreate').on('click', function (e) {
            resetFormMaintainance();
            initTreeDropDownCategory();
            $('#modalAddOrEdit').modal('show');
        });

        $('#btnSelectImg').on('click', function () {
            $('#fileInputImage').click();
        });
        $("#fileInputImage").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/Admin/Upload/UploadImages",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    $('#txtImageM').val(path);
                    kai.notify('Tải ảnh lên thành công', 'success');

                },
                error: function () {
                    kai.notify('có lỗi xảy ra khi tải ảnh lên', 'error');
                }
            });
        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $.ajax({
                type: 'GET',
                url: "/Admin/Product/GetById",
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

        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            kai.confirm('Bạn có chắc chắn muốn xóa?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Product/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        kai.startLoading();
                    },
                    success: function (response) {
                        kai.notify('Xoá thành công', 'success');
                        kai.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        kai.notify('Có lỗi xảy ra khi thực hiện xóa', 'error');
                        kai.stopLoading();
                    }
                });
            });
        });

        $('#btnSave').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = $('#hidIdM').val();
                var name = $('#txtNameM').val();
                var categoryId = $('#ddlCategoryIdM').combotree('getValue');

                var description = $('#txtDescM').val();
                var unit = $('#txtUnitM').val();

                var price = $('#txtPriceM').val();
                var originalPrice = $('#txtOriginalPriceM').val();
                var promotionPrice = $('#txtPromotionPriceM').val();

                var image = $('#txtImageM').val();

                var tags = $('#txtTagM').val();
                var seoKeyword = $('#txtMetakeywordM').val();
                var seoMetaDescription = $('#txtMetaDescriptionM').val();
                var seoPageTitle = $('#txtSeoPageTitleM').val();
                var seoAlias = $('#txtSeoAliasM').val();

                var content = CKEDITOR.instances.txtContentM.getData();
                var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
                var hot = $('#ckHotM').prop('checked');
                var showHome = $('#ckShowHomeM').prop('checked');

                $.ajax({
                    type: "POST",
                    url: "/Admin/Product/SaveEntity",
                    data: {
                        Id: id,
                        Name: name,
                        CategoryID: categoryId,
                        Image: image,
                        Price: price,
                        OriginalPrice: originalPrice,
                        PromotionPrice: promotionPrice,
                        Description: description,
                        Content: content,
                        HomeFlag: showHome,
                        HotFlag: hot,
                        Tags: tags,
                        Unit: unit,
                        Status: status,
                        SeoPageTitle: seoPageTitle,
                        SeoAlias: seoAlias,
                        SeoKeywords: seoKeyword,
                        SeoDescription: seoMetaDescription
                    },
                    dataType: "json",
                    beforeSend: function () {
                        kai.startLoading();
                    },
                    success: function (response) {
                        kai.notify('Cập nhật sản phẩm có tên là' + {  name  }+ 'thành công', 'success');
                        $('#modalAddOrEdit').modal('hide');
                        resetFormMaintainance();

                        kai.stopLoading();
                        loadData(true);
                    },
                    error: function (res) {
                        console.log(res);
                        kai.notify('Đã có lỗi xảy ra trong quá trình cập nhật sản phẩm', 'error');
                        kai.stopLoading();
                    }
                });
                return false;
            }
        });
    }

    function registerControls() {
        CKEDITOR.replace('txtContentM', {});
        //Fix: cannot click on element ck in modal
        $.fn.modal.Constructor.prototype.enforceFocus = function () {
            $(document)
                .off('focusin.bs.modal') // guard against infinite focus loop
                .on('focusin.bs.modal', $.proxy(function (e) {
                    if (
                        this.$element[0] !== e.target && !this.$element.has(e.target).length
                        // CKEditor compatibility fix start.
                        && !$(e.target).closest('.cke_dialog, .cke').length
                        // CKEditor compatibility fix end.
                    ) {
                        this.$element.trigger('focus');
                    }
                }, this));
        };
    }

    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: "/Admin/ProductCategory/GetAll",
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (res) {
                var data = [];
                $.each(res, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name,
                        parentId: item.ParentId,
                        sortOrder: item.SortOrder
                    });
                });
                var arr = kai.unflattern(data);
                $('#ddlCategoryIdM').combotree({
                    data: arr
                });
                if (selectedId != undefined) {
                    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                }
            }
        });
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        initTreeDropDownCategory('');

        $('#txtDescM').val('');
        $('#txtUnitM').val('');

        $('#txtPriceM').val('');
        $('#txtOriginalPriceM').val('');
        $('#txtPromotionPriceM').val('');

        $('#txtImageM').val('');

        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');
        $('#txtMetakeywordM').val('');

        $('#txtMetaDescriptionM').val('');
        $('#txtTagM').val('');

        $('#txtContentM').val('');

        $('#ckStatusM').prop('checked', false);
        $('#ckHotM').prop('checked', false);
        $('#ckShowHomeM').prop('checked', false);
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
                        Image: item.Image == null ? '<img src="/admin-side/not-product.png" width=25px />' : '<img src="' + item.Image + '" width=25px',
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