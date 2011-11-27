"use strict";
/*
 * Послытает http запрос, возвращает результат в callback.
 * Пример использования:
 *  makeRequest('/index.html', function(result) {
 *  	alert(result);
 *  });
 */
var makeRequest = (function() {
	function makeRequest(url, callback) {
		var httpRequest;

		if (window.XMLHttpRequest) { // Mozilla, Safari, ...
			httpRequest = new XMLHttpRequest();
			if (httpRequest.overrideMimeType) {
				httpRequest.overrideMimeType('text/xml');
				// See note below about this line
			}
		} 
		else if (window.ActiveXObject) { // IE
			try {
				httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
			} 
			catch (e) {
				try {
					httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
				} 
				catch (e) {}
			}
		}

		if (!httpRequest) {
			alert('Giving up :( Cannot create an XMLHTTP instance');
			return false;
		}
		httpRequest.onreadystatechange = function() { parseHttpRequest(httpRequest, callback); };
		httpRequest.open('GET', url, true);
		httpRequest.send('');

	}
		
	function parseHttpRequest(httpRequest, callback) {
		if (httpRequest.readyState == 4) {
			if (httpRequest.status == 200) {
				callback(httpRequest.responseText);
			} else {
				alert('There was a problem with the request.');
			}
		}
	}

	return makeRequest;
}) ();
