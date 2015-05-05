/*
 *  Licensed Materials - Property of IBM
 *  5725-I43 (C) Copyright IBM Corp. 2011, 2013. All Rights Reserved.
 *  US Government Users Restricted Rights - Use, duplication or
 *  disclosure restricted by GSA ADP Schedule Contract with IBM Corp.
 */

var nameSearchQuery = WL.Server.createSQLStatement("select fullname, email, phone, title, city, twitter from employees where fullname = ?");

var allRowsQuery  = WL.Server.createSQLStatement("select fullname, email, phone, title, city, twitter from employees");

function findEmployee(searchString) {
	WL.Logger.info(searchString);
	WL.Logger.info(nameSearchQuery);

	modifiedSearchString =  searchString;
	WL.Logger.info(modifiedSearchString);

	return WL.Server.invokeSQLStatement({
		preparedStatement : nameSearchQuery,
		parameters : [modifiedSearchString]
	});

function allEmployees() {

	return WL.Server.invokeSQLStatement({
		preparedStatement : nameSearchQuery
	});
	
}
