﻿
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

/*
 * Создаём сервер, выдаём файлы.
 */
http.createServer(function (request, response) {
	sys.puts('+------- User connected: ' + new Date() + '-------+');

	var uri = url.parse(request.url).pathname;
	response.writeHeader(200, {"Content-Type" : "text/plain"});

	if(uri.indexOf('/cmd/') === 0) {
		sys.puts('Special command requested: ' + uri);
		response.end('Special command requested: ' + uri);
	} else {
		load_static_file(uri, response, './client/');
	}
}).listen(2011);

console.log('Server running at http://127.0.0.1:2011/');