///  <reference path="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js" />
//  XML reference gives us intellisense for jQuery

//  Below is a fully-qualified ready function
//  It waits for HTML and CSS to load before executing the code inside of the function

jQuery(document).ready(function () {
    console.log("Hello World jQuery");
});

///////////// Lightbox Code //////////////
//  When a user clicks on a thumbnail image, display the lightbox container and insert an <img> tag, and allow user to clock off the lightbox
$(".thumb").on("click", function () {

    // display the lightbox container
    $("#lightbox-container").fadeIn(500);

    // insert an image tag
    $("#lightbox-content").html('<img src="' + $(this).attr("src") + '" class="img-fluid" />');

    // click off the lightbox
    $("#lightbox-container").on("click", function () {
        $(this).fadeOut(500);
    });

})