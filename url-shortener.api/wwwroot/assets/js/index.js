$(function() {
    $("#domain").val(window.location.hostname);
});


function getRandomShortUrl(urlObj) {
    $.ajax({
        url: '/api/generate/generate',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(longUrl),
        success: function(shortUrl) {
            var fullShortUrl = window.location.origin + '/' + shortUrl;
            $('#shorten-result').html('<p>Shortened URL: <a href="' + fullShortUrl + '">' + fullShortUrl + '</a></p>');
        },
        error: function(xhr, status, error) {
            $('#shorten-result').html('<p class="text-danger">Error: ' + error + '</p>');
        }
    });
}
