/*
 *  Licensed Materials - Property of IBM
 *  5725-I43 (C) Copyright IBM Corp. 2011, 2013. All Rights Reserved.
 *  US Government Users Restricted Rights - Use, duplication or
 *  disclosure restricted by GSA ADP Schedule Contract with IBM Corp.
 */

/**
 *  WL.Server.invokeHttp(parameters) accepts the following json object as an argument:
 *  
 *  {
 *  	// Mandatory 
 *  	method : 'get' , 'post', 'delete' , 'put' or 'head' 
 *  	path: value,
 *  	
 *  	// Optional 
 *  	returnedContentType: any known mime-type or one of "json", "css", "csv", "javascript", "plain", "xml", "html"  
 *  	returnedContentEncoding : 'encoding', 
 *  	parameters: {name1: value1, ... }, 
 *  	headers: {name1: value1, ... }, 
 *  	cookies: {name1: value1, ... }, 
 *  	body: { 
 *  		contentType: 'text/xml; charset=utf-8' or similar value, 
 *  		content: stringValue 
 *  	}, 
 *  	transformation: { 
 *  		type: 'default', or 'xslFile', 
 *  		xslFile: fileName 
 *  	} 
 *  } 
 */


var employeeList = [ {fullname:"John Adams",    email:"jadams@myco.com",    phone:"800-555-1111" },
					{fullname:"Jeff Thompson",  email:"jthompson@myco.com", phone:"800-555-1212" },
					{fullname:"Marcus Smith",   email:"msmith@myco.com",    phone:"800-555-1313" },
					{fullname:"Wen Li",         email:"wli@myco.com",       phone:"800-555-1414" },
					{fullname:"Klaus Herrmann", email:"kherrmann@myco.com", phone:"800-555-1515" },
					{fullname:"Anna Cristina",  email:"acristina@myco.com", phone:"800-555-1616" } ] ;


function findEmployee(empName) {
	for (var i = 0; i < employeeList.length; ++i) {
		if (employeeList[i].fullname == empName)
			return employeeList[i];
	}
	return {error:"Name not found"};
}

