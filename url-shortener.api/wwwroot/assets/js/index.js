$(function() {
    $("#domain").val(window.location.hostname);
});

function onSubmit(event) {
    console.log("hitting");
    let alias = $("#alias").val();
    let url = $("#longUrl").val();
    if (alias == undefined || alias == null || alias == "") {
        let urlObj = {
            url : url
        };
        getRandomShortUrl(urlObj);
    } else {
        let customUrlObj = {
            shortUrl: alias,
            url: url
        }
        getCustomShortUrl(customUrlObj)
    }
    event.preventDefault();
}

function getRandomShortUrl(urlObj) {
    $.ajax({
        url: '/api/generator/Generate',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(urlObj),
        success: function(result) {
            console.log(result);
            alert(result);
        },
        error: function(xhr, status, error) {
            console.error(error);
        }
    });
}

function getCustomShortUrl(customUrlObj) {
    $.ajax({
        url: '/api/generator/GenerateCustom',
        type: 'POST',
        contentType: 'application/json',
        data: customUrlObj,
        success: function(result) {
            console.log(result);
            alert(result);
        },
        error: function(xhr, status, error) {
            console.error(error);
        }
    });
}

function copyToClipboard() {
    // Get the text box element
    var shortLink = document.getElementById("shortLink");
    shortLink.select(); // Select the text
    shortLink.setSelectionRange(0, 99999); // For mobile devices

    // Copy the text to clipboard
    navigator.clipboard.writeText(shortLink.value).then(() => {
        alert("Link copied to clipboard!");
    }).catch((err) => {
        alert("Failed to copy the link. Please try again.");
    });
}
