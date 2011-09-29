// Это безопасный режим javascript, для пущей надёжности кода.
"use strict";

/*
* Это не для понта, так нужно оборачивать код для безопасности, простоты и ещё много для чего.
* Ещё функции часто выступают в роли неймспейсов.  
*/
(function() {
	var sys = require('util'),
		http = require('http'),
		url = require('url'),
		path = require('path'),
		fs = require('fs'),
		events = require('events'),
		querystring = require('querystring');
	
	
	function load_static_file(uri, response, working_directory) {
		if(uri === '/')
			uri = '/index.html'
	
		uri = path.join(working_directory, uri);

		var filename = path.join(process.cwd(), uri);
		sys.puts("Loading static file: " + filename);
		path.exists(filename, function(exists) {
			if(!exists) {
				sys.puts('! Error 404 no file. Path: ' + filename);
				response.writeHeader(404, {"Content-Type": "text/plain"});
				response.write("404 Not Found\n");
				response.end();
				return;
			}
		
			fs.readFile(filename, "binary", function(err, file) {
				if(err) {
					response.writeHeader(500, {"Content-Type": "text/plain"});
					response.write(err + "\n");
					response.end();
					return;
				}
			
				response.writeHeader(200);
				response.write(file, "binary");
				response.end();
			});
		});
	}
	
	// Путь к и название файла чата.	
	var chat = {
		dir: './server/debug/',
		file: 'chat.log'
	};

	/*
	 * Специальные комманды к серверу и их результаты.
	 */
	var commands = {
		// Название.
		"chat/log.get - Getting the chat log": {
			// Регулярное выражение для парсинга.
			regex: /chat\/log\.get/,
			// То, что сделаем если найдём регулярное выражение.
			// Обязательно должен вызывать callback, даже после ошибки.
			// Специально посылаю regex в функцию вместо использования this.regex, так как контекст выполнения может быть изменён.
			result: function(response, command, regex, callback) {
				load_static_file(chat.file, response, chat.dir);
				callback();
			}
		},
		// Название.
		"chat/send - Send text to the chat": {
			// Регулярное выражение для парсинга.
			regex: /chat\/send\?username=(.+)&text=(.+)/,
			// То, что сделаем если найдём регулярное выражение.
			// Обязательно должен вызывать callback, даже после ошибки.
			// Специально посылаю regex в функцию вместо использования this.regex, так как контекст выполнения может быть изменён.
			result: function(response, command, regex, callback) {
				var message_info = regex.exec(command);
				// Превращаем %20 и тому подобное в нормальные символы.
				var name = decodeURI(message_info[1]),
					message = decodeURI(message_info[2]);
				sys.puts('Name: ' + name + ', message: ' + message);
				var text = '\n' + '<p>' + name + ': ' + message + '</p>';

				sys.puts('Text to send to chat: ' + text);

				var chat_path = path.join(process.cwd(), chat.dir);
				chat_path = path.join(chat_path, chat.file);
				// Читаем то что есть в чатлоге.
				fs.readFile(chat_path, function (err, data) {
					if (err) throw err;
					sys.puts('Loaded old chatlog: ' + data);
					fs.writeFile(chat_path, data + text, function (err) {
						if (err) throw err;
						console.log('It\'s changed and saved!');
						response.writeHeader(200, {'Content-Type': 'text/plain'});
						response.write('OK');
						response.end();
						sys.puts('Good work - chat message deployed!');
						callback();
					});
				});
			}
		}
	};

	/*
	 * Создаём сервер, выдаём файлы.
	 */
	http.createServer(function (request, response) {
		// Сообщаем о подключении (http запрос) и выдаём текщую дату.
		sys.puts('+------- User connected: ' + new Date() + '-------+');
		
		// Из url вырегаем важную часть - путь к файлу.
		var uri = unescape(url.parse(request.url).pathname);
		
		// Если это специальная команда, а не запрос к файлу.
		if(uri.indexOf('/cmd/') === 0) {
			sys.puts('Special command requested: ' + request.url);
			for(var key in commands) {
				if(commands[key].regex.test(request.url)) {
					sys.puts('Special command: ' + key);
					commands[key].result(response, request.url, commands[key].regex, function() {
					});
				}
			}
		} else {
			// Загружаем файл с диска. Если запрос к "/", то получаем "index.html".
			load_static_file(uri, response, './client/');
		}
	}).listen(2011);

	console.log('Server running at http://127.0.0.1:2011/');
}) ();
