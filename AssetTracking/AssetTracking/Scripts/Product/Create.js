$("#CategoryID").change(function() {
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
            $.each(response, function (key, value) {
                var optionText = "<option value='" + value.SubCategoryID + "'>" + value.SubCategoryName + "</option>";
                $("#SubCategoryID").append(optionText);
            });
        }

    });
});