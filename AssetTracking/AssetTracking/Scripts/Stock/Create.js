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

    var productCell = "<td><input type='hidden' name='stockDetail[" + index + "].ProductID' value='" + stockDetail.productId + "' /><input type='hidden' name='stockDetail[" + index + "].Quantity' value='" + stockDetail.quantity + "' /><input type='hidden' name='StockDetails[" + index + "].UnitPrice' value='" + stockDetail.unitPrice + "' />" + stockDetail.productName +  "</td>";
    var quantityCell = "<td>" + stockDetail.quantity + stockDetail.unitPrice+ stockDetail.unitPrice*stockDetail.quantity + "</td>"+"<td><button type='button' class='btn btn-success btn-edit'>Edit</button>|<button type='button' class='btn btn-danger btn-delete'>Delete</button>"+"</td>";
                                                                                   
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



$(document).on('click', '.btn-delete', function () {
    if (confirm("Are you sure to delete?")) {
        $(this).closest('tr').remove();
    }
});