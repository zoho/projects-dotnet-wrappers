# ZohoProjects .Net Client Library

The .Net library for intigrating with ZohoProjects

## Installation

Install the latest version of the library with the following commands:

Use NuGet : [NuGet] (https://nuget.org) is a package manager for Visual Studio.

To install the ZohoBooks .Net Client Library, run the following command in the package Manager Console:

	$ Install -package ZohoProjects

If you would prefer to build it from source: 
	
	$ git clone git@git:zoho/projects-dotnet-wrappers.git

## Documentation
Refer Api Documentation from [HERE](http://cms.zohocorp.com/export/zoho/projects/help/rest-api/portals-api.html)


## Usage 

If you want to use all our Zoho Projects services API, you should have a valid authtoken which requires the Zoho username and password.

How to generate authtoken ? [Refer from Here](http://cms.zohocorp.com/export/zoho/projects/help/rest-api/get-tickets-api.html)
If you are having a valid `authtoken` , you are able to acess the ZohoProjects API Wrappers.

How to use our wrapper classes?

The following example of sample code describes the usage of the ZohoProjects .Net wrappers

You have to use the following namespaces in your project to access the ZohoProjects API services

	using zohoprojects.api;
	using zohoprojects.model;
	using zohoprojects.service;

As a part of calling the wrapper class methods first you have to intialize the ZohoProjects services by passing your authtoken and portal id(on which portal you are working now)

	ZohoProjects service = new ZohoProjects();
	service.initialize("{authtoken}", "{portal id}");

From the initialised service, your able to create the instances for the individual Apis and from its you are able to acess the methods

The follwing sample code describes to how to create the instance of the ProjectsApi which allows you to get the list of projects and to get and update or delete the specified project.

	var projectsApi=service.GetProjectsApi();

Now you are able to access the wrapper class methods by the instance projectsApi as shown below 

## To Create a project:

To create a project you have to call the `create()` method of the projectsApi instance.
For that you have to pass the Project object which contains the project information as a parameter and returns the Project object.

The following shows the how to create project object with new project information

	var newProjectInfo = new Project()
	{
		name = "new project name",
		description="description for new project"
	 };

The following line of code shows how to pass the new_info object as a parameter to the `create()`

	try
	{
		var newProject = projectsApi.Create(newProjectInfo);
	
	}

The newProject is the Project object which having the details of the newly created project by the projectsApi instance.

### To Get the details of specified project

If you want to get a particular project, you need to call `Get()` method by passing the project id as a parameter and it returns the Project object which contains the details of specified project id.
The following peice of code desribes the how to call `Get()` method 

	try
	{
		var project = projectsApi.Get(projectId);
	}
		
### Catch the exception

When calling Zoho Projects API wrappers if there is any error then the respective class throws the ProjectsException.
The ProjectsException is caught by the following way

	catch(Exception e)
	{
		Console.WriteLine(e.Message);
         }


See [Here](../../tree/master/test) for more examples.
