//adjust css margin based on class="form-control"
document.getElementsByClassName("form-control")




// The latitude and longitude for position
var position = [39.1344522, -95.6757794];
//Google Maps Background for Contact Page
function showGoogleMaps() {

    //var latLng = new google.maps.LatLng(position[0], position[1]);

    //var mapOptions = {
    //    zoom: 16, // initialize zoom level - the max value is 21
    //    streetViewControl: false, // hide the yellow Street View pegman
    //    scaleControl: true, // allow users to zoom the Google Map
    //    mapTypeId: google.maps.MapTypeId.ROADMAP,
    //    center: latLng
    //};

    //map = new google.maps.Map(document.getElementById('googlemaps'),
    //    mapOptions);

    //// Show the default red marker at the location
    //marker = new google.maps.Marker({
    //    position: latLng,
    //    map: map,
    //    draggable: false,
    //    animation: google.maps.Animation.DROP
    //});

    // Initialize and add the map
    function initMap() {
        // The location of Uluru
        const uluru = { lat: -25.344, lng: 131.036 };
        // The map, centered at Uluru
        const map = new google.maps.Map(document.getElementById("map"), {
            zoom: 4,
            center: uluru,
        });
        // The marker, positioned at Uluru
        const marker = new google.maps.Marker({
            position: uluru,
            map: map,
        });
    }
}

//google.maps.event.addDomListener(window, 'load', showGoogleMaps);

