/*
 *  Licensed Materials - Property of IBM
 *  5725-I43 (C) Copyright IBM Corp. 2011, 2013. All Rights Reserved.
 *  US Government Users Restricted Rights - Use, duplication or
 *  disclosure restricted by GSA ADP Schedule Contract with IBM Corp.
 */

function getLocation(city) {
	path = getPath(city);
	
	var input = {
	    method : 'get',
	    returnedContentType : 'json',
	    path : path
	};
	
	return WL.Server.invokeHttp(input).results[0].geometry.location;
}

function getPath(city) {
	if (city == undefined || city == '') {
		city = '';
	}else {
		city = '_' + city;
	}
	return 'maps/api/geocode/json?address=' + city + '&sensor=false';
}

