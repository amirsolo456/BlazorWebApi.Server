window.toastrService = {
    success: function (message, title) {
        toastr.success(message, title);
    },
    error: function (message, title) {
        toastr.error(message, title);
    }
};