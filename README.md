# ZohoProjects .Net Client Library

The .Net library for integrating with the Zoho Projects API. Use this .Net wrapper to easily integrate Zoho Projects modules like portals, projects, milestones,tasklists, events etc. into your application.

## Installation

To install the ZohoProjects .Net Client Library, run the following command in [NuGet's](https://www.nuget.org/) console.  

$ Install -package ZohoProjects

To build the project from source, run the following command: 
	
	$ git clone git@git:zoho/projects-dotnet-wrappers.git

<Note:> NuGet is the package manager for Microsoft Visual Studio.


## Documentation
[API Reference](http://cms.zohocorp.com/export/zoho/projects/help/rest-api/portals-api.html)


## Usage 

In order to access the Zoho Projects APIs, users need to have a valid Zoho account and a valid Auth Token.
 
###Sign up for a Zoho Account:

For setting up a Zoho account, access the Zoho Projects [Sign Up](https://www.zoho.com/projects/zp-signup.html) page and enter the requisite details - email address and password.
 
###Generate Auth Token:
 
To generate the Auth Token, you need to send an authentication request to Zoho Accounts in a prescribed URL format. [Refer here](https://www.zoho.com/projects/help/rest-api/get-tickets-api.html) 

###How to access the Zoho Projects APIs through .Net wrapper classes?
 
Below is the sample code for accessing the Projects APIs through .Net wrapper classes. You can use the following namespaces in your project:

	using zohoprojects.api;
	using zohoprojects.model;
	using zohoprojects.service;

###Create Service API Instance:

Create an instance of ZohoProjects and intialise the service by passing authtoken and poratal id.

Sample code:

	ZohoProjects service = new ZohoProjects();
	service.initialize("{authtoken}", "{portal id}");

###.Net Wrappers - Sample

####List all Projects:

If you wish to get the list of all projects from the portal, first you need to create the instance for the ProjectsApi, then call the GetProjects() method in the following format:

	var projectsApi=service.GetProjectsApi();
	var projects = projectsApi.GetProjects(parameters);

It returns the List of Project object as a response.

####Create a new Project:

To create a new project for the specific portal, you need to call the create() method of the projectsApi instance. 

Proceed with creating a new project by passing the project object, which contains the project information, as a parameter. It returns the project object as a response.

	var newProjectInfo = new Project()
	{
		name = "new project name",
		description="description for new project"
	 };

To pass the newProjectInfo object as a parameter in the create() method, use the following sample code:

	try
	{
		var newProject = projectsApi.Create(newProjectInfo);
	
	}

<Note:> The newProject is the actual Project object here. It carries all the details of the newly created project from the projectsApi instance. 

####Get Project details:

In order to get the details of a particular project, you need to call the get() method by passing a projectId as parameter.

It returns the Project object, which contains details of the specific project. See the sample code below:

	try
	{
		var project = projectsApi.Get(projectId);
	}
		
####Catch Exceptions:

If there is any error encountered while calling the .Net wrappers of Zoho Projects API, the respective class will throw the ProjectsException. Use the below mentioned code to catch the ProjectsException:

	catch(Exception e)
	{
		Console.WriteLine(e.Message);
        }


For a full set of examples, click [here](../../tree/master/test).
