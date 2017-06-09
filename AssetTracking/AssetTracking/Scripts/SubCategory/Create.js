window.onload = function() {
    $("#GeneralCategoryID").change(function() {
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
            success: function(response) {
                $("#CategoryID").empty();
                var optionText = "<option value=''>Select Category</option>";
                $("#CategoryID").append(optionText);
                $.each(response, function(key, value) {
                    var optionText = "<option value='" + value.CategoryID + "'>" + value.CategoryName + "</option>";
                    $("#CategoryID").append(optionText);
                });
            }

        });
    });
};