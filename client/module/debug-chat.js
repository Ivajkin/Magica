// Это безопасный режим javascript, для пущей надёжности кода.
"use strict";

/*
* Это не для понта, так нужно оборачивать код для безопасности, простоты и ещё много для чего.
* Ещё функции часто выступают в роли неймспейсов.  
*/
(function() {
	window.addEvent('domready', function() {
		makeRequest('/cmd/', function(chat_messages_data) {
			$('messages').set('html', chat_messages_data);			
		});
	});
}) ();
