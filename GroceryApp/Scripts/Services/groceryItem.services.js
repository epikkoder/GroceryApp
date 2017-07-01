var groceryItem = {
    services: {},
    handlers: {}
};

groceryItem.services.post = function (data, onSuccess, onError) {
    var url = "/api/groceryitems";
    var settings = {
        cache: false,
        contentType: "application/json",
        data: JSON.stringify(data),
        dataType: "json",
        error: onError,
        success: onSuccess,
        type: "POST",
        xhrfields: {
            withCredentials: true
        }
    };

    $.ajax(url, settings);
};

groceryItem.services.get = function (onSuccess, onError) {
    var url = "/api/groceryitems";
    var settings = {
        cache: false,
        contentType: "application/json",
        dataType: "json",
        error: onError,
        success: onSuccess,
        type: "GET",
        xhrfields: {
            withCredentials: true
        }
    };

    $.ajax(url, settings);
};

groceryItem.services.getItemTypes = function (onSuccess, onError) {
    var url = "/api/groceryitems/itemtypes";
    var settings = {
        cache: false,
        contentType: "application/json",
        dataType: "json",
        error: onError,
        success: onSuccess,
        type: "GET",
        xhrfields: {
            withCredentials: true
        }
    };

    $.ajax(url, settings);
}