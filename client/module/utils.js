/*
 * Asserts the value of expression, it must be true.
 */
function assert(expression, message) {
	if(!expression)
		throw message;
}
