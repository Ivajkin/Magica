// Это безопасный режим javascript, для пущей надёжности кода.
"use strict";

/*
* Это не для понта, так нужно оборачивать код для безопасности, простоты и ещё много для чего.
* Ещё функции часто выступают в роли неймспейсов.  
*/
(function() {
	function updateChat() {
		makeRequest('/cmd/chat/log.get', function(chat_messages_data) {
			$('messages').set('html', chat_messages_data);			
		});
	}
	function sendMessage(message) {
		var request = '/cmd/chat/send?text=' + message.toString();
		makeRequest(request, function(result) {
			assert(result === 'OK', 'Result from server of chat message send wrong: ' + result);
			updateChat();
		});
	}
	window.addEvent('domready', function() {
		updateChat();
		$('send-btn').addEvent('click', function() {
			sendMessage($('chat-edit').value);
		});
	});
}) ();
