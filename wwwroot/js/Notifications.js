// FUNCTION TO DISPLAY NOTIFICATION MESSAGE
function showNotification(message) {
    // CREATE A NOTIFICATION ELEMENT
    var notification = document.createElement('div');
    notification.classList.add('notification');
    notification.textContent = message;

    // ADD THE NOTIFICATION TO THE DOCUMENT BODY
    document.body.appendChild(notification);

    // REMOVE THE NOTIFICATION AFTER 3 SECONDS
    setTimeout(function () {
        notification.remove();
    }, 3000);
}
