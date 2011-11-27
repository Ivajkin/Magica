/*
 * Created at 25.09.2011
 */

/*
 * Asserts the value of expression, it must be true.
 */
function assert(expression, message) {
	if(!expression)
		throw message;
}

/*
 * Get cookie by specified offset.
 */
function getValue (offset) { 
		var strEnd = document.cookie.indexOf (";", offset); 
		if (strEnd == -1) 
			strEnd = document.cookie.length; 
		return unescape(document.cookie.substring(offset, strEnd)); 
} 

/*
 * Get cookie by name.
 */
function getCookie(name) { 
		var key = name + "="; 
		var i = 0; 
		while (i < document.cookie.length) { 
			var j = i + key.length; 
			if (document.cookie.substring(i, j) == key) 
				return getValue (j); 
			i = document.cookie.indexOf(" ", i) + 1; 
			if (i == 0) 
				break; 
		} 
		return null; 
} 

/*
 * Set cookie by name.
 */
function setCookie (name, value) { 
		var argv = setCookie.arguments; 
		var argc = setCookie.arguments.length; 
		var expires = (argc > 2) ? argv[2] : null; 
		var path = (argc > 3) ? argv[3] : null; 
		var domain = (argc > 4) ? argv[4] : null; 
		var secure = (argc > 5) ? argv[5] : false; 
		document.cookie = name + "=" + escape (value) + 
			((expires == null) ? "" : ("; expires=" + 
			expires.toGMTString())) + 
			((path == null) ? "" : ("; path=" + path)) + 
			((domain == null) ? "" : ("; domain=" + domain)) + 
			((secure == true) ? "; secure" : "");
}
