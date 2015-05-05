
function allEmployees() {
	var input = {
		method : 'get',
		returnedContentType : 'json',
		path : '/employees/_design/employeeDesignDoc/_view/last?include_docs=true'
	};
	WL.Logger.info(input);
	var response = WL.Server.invokeHttp(input);

	WL.Logger.info("=====Data Returned=====");

	if (response.statusCode == 200)
	{
		myresp = [];
		for (var i = 0; i < response.rows.length; ++i)
			myresp[i] = response.rows[i].doc;

		WL.Logger.info(myresp);
		WL.Logger.info("=====Data Collated=====");
		return { "resultSet" : myresp };
	}
	
	return [{"isSuccessful":"false"}];
}

function findEmployee(empName) {

	var input = {
		method : 'get',
		returnedContentType : 'json',
		path : '/employees/_design/employeeDesignDoc/_search/lastname?q=lastname:' + empName + '&include_docs=true'
	};
	
	WL.Logger.info(input);
	WL.Logger.info(empName);
	var response = WL.Server.invokeHttp(input);

	if (response.statusCode == 200)
	{
		WL.Logger.info(response.rows[0].doc);
		return response.rows[0].doc;
	}
	
	return [{"isSuccessful":"false"}];

}

