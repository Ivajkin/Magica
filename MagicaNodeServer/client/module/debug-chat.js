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
	function sendMessage(username, message) {
		var request = '/cmd/chat/send?username=' + username + '&text=' + message.toString();
		makeRequest(request, function(result) {
			assert(result === 'OK', 'Result from server of chat message send wrong: ' + result);
			updateChat();
		});
	}
	var user_info = {
		setName: function(name) {
			setCookie('user-name', name);
		},
		getName: function() {
			return getCookie('user-name');
		}
	};
	window.addEvent('domready', function() {
		updateChat();

		var username = user_info.getName();
		if(username) {
			$('chat-user-name').value = username;
		}

		$('send-btn').addEvent('click', function() {
			var username = $('chat-user-name').value,
				message = $('chat-edit').value;
			user_info.setName(username);
			sendMessage(username, message);
		});
	});
}) ();
