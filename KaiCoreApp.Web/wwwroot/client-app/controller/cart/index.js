var CartController = function () {
    this.initialize = function () {
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: '/Cart/RemoveFromCart',
                type: 'POST',
                data: {
                    productId: id
                },
                success: function () {
                    kai.notify('Xoá sản phẩm khỏi giỏ hàng thành công.', 'success');
                    //loadHeaderCart();
                    loadData();
                }
            });
        });
        //Cập nhập số lượng sản phẩm
        $('body').on('keyup', '.txtQuantity', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            var q = $(this).val();
            if (q > 0) {
                $.ajax({
                    url: '/Cart/UpdateCart',
                    type: 'post',
                    data: {
                        productId: id,
                        quantity: q
                    },
                    success: function () {
                        kai.notify('Cập nhật số lượng sản phẩm thành công.', 'success');
                        //loadHeaderCart();
                        loadData();
                    }
                });
            } else {
                kai.notify('Số lượng sản phẩm không hợp lệ.', 'error');
            }
        });

        //cập nhật số lượng theo màu sắc
        $('body').on('change', '.ddlColorId', function (e) {
            e.preventDefault();
            var id = parseInt($(this).closest('tr').data('id'));
            var colorId = $(this).val();
            var q = $(this).closest('tr').find('.txtQuantity').first().val();
            var sizeId = $(this).closest('tr').find('.ddlSizeId').first().val();

            if (q > 0) {
                $.ajax({
                    url: '/Cart/UpdateCart',
                    type: 'post',
                    data: {
                        productId: id,
                        quantity: q,
                        color: colorId,
                        size: sizeId
                    },
                    success: function () {
                        kai.notify('Update quantity is successful', 'success');
                        //loadHeaderCart();
                        loadData();
                    }
                });
            } else {
                kai.notify('Your quantity is invalid', 'error');
            }
        });

        //Cập nhật số lượng theo kích thước
        $('body').on('change', '.ddlSizeId', function (e) {
            e.preventDefault();
            var id = parseInt($(this).closest('tr').data('id'));
            var sizeId = $(this).val();
            var q = parseInt($(this).closest('tr').find('.txtQuantity').first().val());
            var colorId = parseInt($(this).closest('tr').find('.ddlColorId').first().val());
            if (q > 0) {
                $.ajax({
                    url: '/Cart/UpdateCart',
                    type: 'post',
                    data: {
                        productId: id,
                        quantity: q,
                        color: colorId,
                        size: sizeId
                    },
                    success: function () {
                        kai.notify('Update quantity is successful', 'success');
                        //loadHeaderCart();
                        loadData();
                    }
                });
            } else {
                kai.notify('Your quantity is invalid', 'error');
            }
        });

        //Clear giỏ hàng
        $('#btnClearAll').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                url: '/Cart/ClearCart',
                type: 'post',
                success: function () {
                    kai.notify('Làm sạch giỏ hàng thành công.', 'success');
                    // loadHeaderCart();
                    loadData();
                }
            });
        });
    }

    //Load data
    function loadData() {
        $.ajax({
            url: '/Cart/GetCart',
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                var template = $('#template-cart').html();
                var render = "";
                var totalAmount = 0;
                $.each(response, function (i, item) {
                    render += Mustache.render(template,
                        {
                            ProductId: item.Product.Id,
                            ProductName: item.Product.Name,
                            Image: item.Product.Image,
                            Price: kai.formatNumber(item.Price, 0),
                            Quantity: item.Quantity,
                            Amount: kai.formatNumber(item.Price * item.Quantity, 0),
                            Url: '/' + item.Product.SeoAlias + "-p." + item.Product.Id + ".html"
                        });
                    totalAmount += item.Price * item.Quantity;
                });
                $('#lblTotalAmount').text(kai.formatNumber(totalAmount, 0));
                if (render !== "")
                    $('#table-cart-content').html(render);
                else
                    $('#table-cart-content').html('Không có sản phẩm nào trong giỏ hàng của bạn.');
            }
        });
        return false;
    }
}