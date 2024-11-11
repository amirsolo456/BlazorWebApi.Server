function OpenModalByID(Id) {
    var myModal = new bootstrap.Modal(document.getElementById(Id), {
        keyboard: false
    })
    myModal.show()
}

//window.OpenModalByID = (modalId) => {
//    var modal = new bootstrap.Modal(document.getElementById(modalId));
//    modal.show();
//};
