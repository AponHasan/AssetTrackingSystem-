window.onload = function () {
    $("#GeneralCategoryID").change(function () {
        var generalcategoryId = $("#GeneralCategoryID").val();
        if (generalcategoryId == "") {
            $("#CategoryID").empty();
            var option = "<option value=''>Select Category</option>";
            $("#CategoryID").append(option);
            return;
        }
        var jsonData = { generalcategoryId: generalcategoryId };
        $.ajax({
            url: "/GeneralCategory/GetCategoryByGeneralCategory",
            type: "POST",
            data: JSON.stringify(jsonData),
            contentType: "application/json",
            success: function (response) {
                $("#CategoryID").empty();
                var optionText = "<option value=''>Select Category</option>";
                $("#CategoryID").append(optionText);
                $.each(response, function (key, value) {
                    var optionText = "<option value='" + value.CategoryID + "'>" + value.CategoryName + "</option>";
                    $("#CategoryID").append(optionText);
                });
            }

        });
    });
    $("#CategoryID").change(function () {
        var categoryId = $("#CategoryID").val();
        if (categoryId == "") {
            $("#SubCategoryID").empty();
            var option = "<option value=''>Select Sub Category</option>";
            $("#SubCategoryID").append(option);
            return;
        }

        var jsonData = { categoryId: categoryId };
        $.ajax({
            url: "/Category/GetSubCategoryByCategory",
            type: "POST",
            data: JSON.stringify(jsonData),
            contentType: "application/json",
            success: function (response) {
                $("#SubCategoryID").empty();
                var optionText = "<option value=''>Select Sub Category</option>";
                $("#SubCategoryID").append(optionText);
                $.each(response, function (key, value) {
                    var optionText = "<option value='" + value.SubCategoryID + "'>" + value.SubCategoryName + "</option>";
                    $("#SubCategoryID").append(optionText);
                });
            }

        });
    });

        $("#SubCategoryID").change(function () {
            var subcategoryId = $("#SubCategoryID").val();
            if (subcategoryId == "") {
                $("#ProductID").empty();
                var option = "<option value=''>Select Product</option>";
                $("#ProductID").append(option);
                return;
            }

            var jsonData = { subcategoryId: subcategoryId };
            $.ajax({
                url: "/Product/GetProductBySubCategory",
                type: "POST",
                data: JSON.stringify(jsonData),
                contentType: "application/json",
                success: function (response) {
                    $("#ProductID").empty();
                    var optionText = "<option value=''>Select Product</option>";
                    $("#ProductID").append(optionText);
                    $.each(response, function (key, value) {
                        var optionText = "<option value='" + value.ProductID + "'>" + value.ProductName + "</option>";
                        $("#ProductID").append(optionText);
                    });
                }

            });
        });
    



    $("#btn_stock_add").click(function () {
        var stockDetail = getStockDetail();

        var index = $("#tbl_stock tr").length;

        var productCell = "<td><input type='hidden' name='AssetPurchaseDetails[" + index + "].ProductID' value='" + stockDetail.productId + "' /><input type='hidden' name='AssetPurchaseDetails[" + index + "].Quantity' value='" + stockDetail.quantity + "' /><input type='hidden' name='AssetPurchaseDetails[" + index + "].UnitPrice' value='" + stockDetail.unitPrice + "' />" + stockDetail.productName + "</td>";
        var quantityCell = "<td>" + stockDetail.quantity + stockDetail.unitPrice + stockDetail.unitPrice * stockDetail.quantity + "</td>" + "<td><button type='button' class='btn btn-success btn-edit'>Edit</button>|<button type='button' class='btn btn-danger btn-delete'>Delete</button>" + "</td>";

        var trItem = "<tr id='stock_" + index + "'>" + productCell + quantityCell + "</tr>";

        $("#tbl_stock").append(trItem);

    });

    function getStockDetail() {
        var productId = $("#ProductID").val();
        var quantity = $("#Quantity").val();
        var unitPrice = $("#UnitPrice").val();
        var productName = $("#ProductID option:selected").text();

        if (productId == "") {
            return null;
        }

        var stock = {
            productId: productId,
            quantity: quantity,
            unitPrice: unitPrice,
            productName: productName

        };
        return stock;

    }










    $(document).on('click', '.btn-delete', function() {
        if (confirm("Are you sure to delete?")) {
            $(this).closest('tr').remove();
        }
    });





}