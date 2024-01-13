function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
      sURLVariables = sPageURL.split("&"),
      sParameterName,
      i;
  
    for (i = 0; i < sURLVariables.length; i++) {
      sParameterName = sURLVariables[i].split("=");
  
      if (sParameterName[0] === sParam) {
        return sParameterName[1] === undefined
          ? true
          : decodeURIComponent(sParameterName[1]);
      }
    }
  }
  
  function updateQueryStringParameter(uri, key, value) {
    if (typeof value == "object") {
      value.join(",");
    }
    var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
    var separator = uri.indexOf("?") !== -1 ? "&" : "?";
    if (uri.match(re)) {
      return uri.replace(re, "$1" + key + "=" + value + "$2");
    } else {
      return uri + separator + key + "=" + value;
    }
  }
  
  function removeQueryStringParameters(uri, ignore) {
    var oldURL = uri;
    var index = 0;
    var newURL = oldURL;
    index = oldURL.indexOf("?");
    if (index == -1) {
      index = oldURL.indexOf("#");
    }
    if (index != -1) {
      newURL = oldURL.substring(0, index);
      if (ignore) {
        var params = oldURL.substring(index).split("&");
        params.forEach(function (e) {
          if (e.split("=")[0] == ignore) {
            newURL += "?" + ignore + "=" + e.split("=")[1];
          }
        });
      }
    }
    return newURL;
  }