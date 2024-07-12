function AcceptNum(evt) {
    var nav4 = window.Event ? true : false;
    var key = nav4 ? evt.which : evt.keyCode;
    return (key >= 48 && key <= 57);
}

function validateDecimal(element) {
    element.value = element.value.replace(/(\.\d\d)\d+|([\d.]*)[^\d.]/, '$1$2');
}