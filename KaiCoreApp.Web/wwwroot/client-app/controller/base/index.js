var BaseController = function () {
    this.initialize = function () {
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btn-cart', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: '/Cart/AddToCart',
                type: 'post',
                data: {
                    productId: id,
                    quantity: 1
                },
                success: function (response) {
                    kai.notify('Sản phẩm đã được thêm vào giỏ', 'success');
                    //loadHeaderCart();
                    loadMyCart();
                }
            });
        });

        $('body').on('click', '.remove-cart', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                url: '/Cart/RemoveFromCart',
                type: 'post',
                data: {
                    productId: id
                },
                success: function (response) {
                    kai.notify('Sản phẩm đã được xóa.', 'success');
                    //loadHeaderCart();
                    //loadMyCart();
                }
            });
        });
    }

    //function loadHeaderCart() {
    //    $("#headerCart").load("/AjaxContent/HeaderCart");
    //}

    //function loadMyCart() {
    //    $("#sidebarCart").load("/AjaxContent/MyCart");
    //}
}