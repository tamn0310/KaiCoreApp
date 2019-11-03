var productCategoryController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }
    function registerEvents() {
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                txtNameM: { required: true },
                txtOrderM: { number: true },
                txtHomeOrderM: { number: true }
            }
        })
        $('#btnCreate').off('click').on('click', function () {
            initTreeDropDownCategory();
            $('#modalAddEdit').modal('show');
            
        });
        $('body').on('click', '#btnEdit', function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            $.ajax({
                type: 'GET',
                url: "/admin/productcategory/GetById",
                data: { id: that },
                dataType: 'json',
                beforeSend: function () {
                    kai.startLoading();
                },
                success: function (res) {
                    var data = res;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    initTreeDropDownCategory(data.categoryId);

                    $('#txtDescM').val(data.Description);
                    $('#txtImageM').val(data.Images);

                    $('#txtSeoKeyWordM').val(data.SeoKeyWords);
                    $('#txtSeoDescriptionM').val(data.SeoDescription);
                    $('#txtSeoaliasM').val(data.SeoAlias);
                    $('#txtSeoPageTitleM').val(data.SeoPageTitle);

                    $('#ckStatusM').prop('checked', data.Status == 0);
                    $('#ckShowHomeM').prop('checked', data.HomeFlag);
                    $('#txtOrderM').val(data.SortOrder);
                    $('#txtHomeOrderM').val(data.HomeOrder);

                    $('#modalAddEdit').modal('show');
                    kai.stopLoading();
                },
                error: function (status) {
                    console.log(status);
                    kai.notify('Có lỗi xảy ra', 'error');
                    kai.stopLoading();
                }
            });
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

        $('body').on('click','#btnDelete',function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            kai.confirm('Bạn có chắc chắn muốn xóa?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/ProductCategory/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        kai.startLoading();
                    },
                    success: function (response) {
                        kai.notify('Xóa thành công', 'success');
                        kai.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        kai.notify('Có lỗi xảy ra khi xóa', 'error');
                        kai.stopLoading();
                    }
                });
            });
        });

        $('#btnSave').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = parseInt($('#hidIdM').val());
                var name = $('#txtNameM').val();
                var parentId = $('#ddlCategoryIdM').combotree('getValue');
                var description = $('#txtDescM').val();

                var image = $('#txtImageM').val();
                var order = parseInt($('#txtOrderM').val());
                var homeOrder = $('#txtHomeOrderM').val();

                var seoKeyword = $('#txtSeoKeywordM').val();
                var seoMetaDescription = $('#txtSeoDescriptionM').val();
                var seoPageTitle = $('#txtSeoPageTitleM').val();
                var seoAlias = $('#txtSeoAliasM').val();
                var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
                var showHome = $('#ckShowHomeM').prop('checked');

                $.ajax({
                    type: "POST",
                    url: "/Admin/ProductCategory/SaveEntity",
                    data: {
                        Id: id,
                        Name: name,
                        Description: description,
                        ParentId: parentId,
                        HomeOrder: homeOrder,
                        SortOrder: order,
                        HomeFlag: showHome,
                        Images: image,
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
                        kai.notify('Thành công', 'success');
                        $('#modalAddEdit').modal('hide');

                        resetFormMaintainance();

                        kai.stopLoading();
                        loadData(true);
                    },
                    error: function (res) {
                        console.log(res);
                        kai.notify('Xảy ra lỗi', 'error');
                        kai.stopLoading();
                    }
                });
            }
            return false;

        });
    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        initTreeDropDownCategory('');

        $('#txtDescM').val('');
        $('#txtOrderM').val('');
        $('#txtHomeOrderM').val('');
        $('#txtImageM').val('');

        $('#txtMetakeywordM').val('');
        $('#txtMetaDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');

        $('#ckStatusM').prop('checked', true);
        $('#ckShowHomeM').prop('checked', false);
    }

    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: '/Admin/ProductCategory/GetAll',
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

    function loadData() {
        $.ajax({
            url: '/Admin/ProductCategory/GetAll',
            dataType: 'json',
            success: function (res) {
                var data = [];
                $.each(res, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name,
                        parentId: item.ParentId,
                        sortOrder: item.SordOrder
                    });
                });
                var treeArr = kai.unflattern(data);
                treeArr.sort(function (a, b) {
                    return a.sortOrder - b.sortOrder;
                });

                //var $tree = $('#treeProductCate');

                $('#treeProductCate').tree({
                    data: treeArr,
                    dnd: true,
                    onContextMenu: function (e, node) {
                        e.preventDefault();
                        //select the node
                        //$('tt').tree('select',node.target);
                        $('#hidIdM').val(node.id);
                        //display context menu
                        $('#contextMenu').menu('show', {
                            left: e.pageX,
                            top: e.pageY
                        });
                    },
                    onDrop: function (target, source, point) {
                        var targetNode = $(this).tree('getNode', target);
                        if (point === 'append') {
                            var children = [];
                            $.each(targetNode.children, function (i, item) {
                                children.push({
                                    key: item.id,
                                    value: i
                                });
                            });

                            //update to database
                            $.ajax({
                                url: '/admin/productcategory/UpdateParentId',
                                type: 'POST',
                                dataType: 'json',
                                data: {
                                    sourceId: source.id,
                                    targetId: targetNode.id,
                                    items: children
                                },
                                success: function (res) {
                                    loadData();
                                }
                            });
                        }
                        else if (point === 'top' || point === 'bottom') {
                            $.ajax({
                                url: '/admin/productcategory/ReOrder',
                                type: 'POST',
                                dataType: 'json',
                                data: {
                                    sourceId: source.id,
                                    targetId: targetNode.id
                                },
                                success: function (res) {
                                    loadData();
                                }
                            });
                        }
                    }
                });
            }
        });
    }
}