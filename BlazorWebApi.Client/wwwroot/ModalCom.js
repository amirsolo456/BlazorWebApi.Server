function OpenModalDynamic(Id) {
    var myModal = new bootstrap.Modal(document.getElementById(Id), {
        keyboard: false
    })
    myModal.show()
}