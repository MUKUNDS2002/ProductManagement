// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).ready(function () {
    const modal = $("#Modal");

    $("#addNew").click(function () {
        // Clear form for new entry
        clearModal();
        modal.find("#exampleModalLabel").text("Add New Product");
        $("#submitBtn").text("Add");
        modal.modal('show');
    });

    $(".edit-btn").click(function () {
        // Get the data attributes from the clicked button
        const SN = $(this).data("sn");
        const Product = $(this).data("product");
        const Description = $(this).data("description");
        const Created = $(this).data("created");

        // Populate the modal fields with the data
        $("#Hiddenid").val(SN);
        $("#Product").val(Product);
        $("#Description").val(Description);
        $("#Created").val(Created);

        // Change modal title and button text
        modal.find("#exampleModalLabel").text("Edit Product");
        $("#submitBtn").text("Update");

        modal.modal('show');
    });

    // Handle form submission
    $("#ProductForm").submit(function (e) {
        e.preventDefault(); // Prevent default form submission

        const SN = $("#Hiddenid").val();
        const Product = $("#Product").val();
        const Description = $("#Description").val();
        const Created = $("#Created").val();

        $.ajax({
            url: SN ? "/Product/Update" : "/Product/Add",
            type: "POST",
            data: {
                __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val(), // CSRF token
                SN: SN,
                Product: Product,
                Description: Description,
                Created: Created
            },
            success: function () {
                window.location.reload();
            },
            error: function () {
                alert("An error occurred while saving the Product. Please try again.");
            }
        });
    });

    function clearModal() {
        $("#Hiddenid").val('');
        $("#Product").val('');
        $("#Description").val('');
        $("#Created").val('');
    }
});
