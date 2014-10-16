using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zohoprojects.api;
using zohoprojects.model;
using zohoprojects.service;

namespace ProjectsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoProjects();
                service.initialize("{auth token}", "{portal id}");
                //service.initialize("af118f731121105c95e525ebd178f6ec", "38418970");
                var portalsApi = service.GetPortalsApi();
                var portals = portalsApi.GetPortals();
                foreach (var portal in portals)
                {
                    Console.WriteLine("portal id:{0}\tPortal name:{1}", portal.id, portal.name, portal.role);
                    var settigs = portal.settings;
                    var locale = portal.locale;
                    var prjcturl = portal.link.project.url;
                    Console.WriteLine("project link:{0}", prjcturl);
                    Console.WriteLine("company name:{0},website:{1}", settigs.company_name, settigs.website_url);
                    Console.WriteLine("localle\n code:{0},country:{1}", locale.code, locale.country);
                    
                }
//-----------------------------------------ProjectsApiTest-----------------------------------------------
                
                var projectsApi=service.GetProjectsApi();
                var projects = projectsApi.GetProjects(null);
                string projectId = projects[0].id.ToString();
                foreach(var prjct in projects)
                {
                    Console.WriteLine("Project id:{0},\n project name:{1}", prjct.id, prjct.name);
                    var links = prjct.link;
                    Console.WriteLine("status:{0},milestone:{1},bug:{2}", links.status.url, links.milestone.url, links.bug.url);
                    var taskcount = prjct.task_count;
                    Console.WriteLine("open tasks:{0},closed tasks:{1}",taskcount.open,taskcount.closed);
                }
                var project = projectsApi.Get(projectId);
                Console.WriteLine("Name:{0},\nstatus:{1}\ncreated date:{2}\n", project.name, project.status, project.created_date);
                var link = project.link;
                Console.WriteLine("self:{0},\nmilestone:{1},\nbug:{2},\nevent:{3}", link.self.url, link.milestone.url, link.bug.url, link.@event.url);
                Console.WriteLine("task count open:{0},close:{1}",project.task_count.open,project.task_count.closed);
                var new_info = new Project()
                {
                    name = "new project",
                    description="desc"

                };
                var new_prjct = projectsApi.Create(new_info);
                Console.WriteLine("Name:{0},\nstatus:{1}\ncreated date:{2}\n", new_prjct.name, new_prjct.status, new_prjct.created_date);
                var update_info = new Project()
                {
                    id =new_prjct.id,
                    name = "name",
                    description = "updated",
                    status = "active"
                };
                var updated = projectsApi.Update(update_info);
                Console.WriteLine("Name:{0},\nstatus:{1}\ndescription:{2}\n", updated.name, updated.status, updated.description);
                var deleteMsg = projectsApi.delete(updated.id);
                Console.WriteLine(deleteMsg);

//---------------------------------------------------DashboadApiTest---------------------------------------------------------------

                var dashboardApi = service.GetDashboardApi();
                var parameters=new Dictionary<object,object>();
                parameters.Add("index", "2");
                parameters.Add("range", "3");
                var activities = dashboardApi.GetProjectActivities(projectId, parameters);
                foreach (var activity in activities)
                    Console.WriteLine("Id:{0},\nname:{1},\nby:{2},\nfor:{3}", activity.id, activity.name, activity.activity_by, activity.activity_for);
                var statusparameters = new Dictionary<object, object>();
                statusparameters.Add("range", "1");
                var statuses = dashboardApi.GetStatus(projectId, statusparameters);
                foreach (var status in statuses)
                    Console.WriteLine("id:{0},\nposted by:{1},\ncontent:{2},\nposted person:{3}", status.id, status.posted_by, status.content, status.posted_person);
                var new_status = new Status()
                {
                    content = "hai this is hari"
                };
                var newStatus = dashboardApi.AddStatus(projectId, new_status);
                Console.WriteLine("id:{0},\nposted by:{1},\ncontent:{2},\nposted person:{3}", newStatus.id, newStatus.posted_by, newStatus.content, newStatus.posted_person);

//---------------------------------------------MilestonesApiTest-----------------------------------------------------------

                var milestonesApi = service.GetMilestonesApi();
                var milestoneParameters=new Dictionary<object,object>();
                parameters.Add("status", "notcompleted");
                var milestones = milestonesApi.GetMilestones(projectId, milestoneParameters);
                foreach(var temp in milestones)
                {
                    var templik = temp.link;
                    Console.WriteLine("Id:{0},\nname:{1},\nstatus:{2}", temp.id, temp.name, temp.status);
                    Console.WriteLine("Self link:{0},\nstatus link:{1}", templik.self.url, templik.status.url);
                }
                var milestone = milestonesApi.Get(projectId, milestones[0].id.ToString());
                var milesonelinks = milestone.link;
                Console.WriteLine("Id:{0},\nowner id:{1},\nstatus:{2}", milestone.id, milestone.owner_id, milestone.status);
                Console.WriteLine("Self link:{0},\nstatus link:{1}", milesonelinks.self.url, milesonelinks.status.url);
                var new_milestone = new Milestone()
                {
                    name="new milestone",
                    start_date="06-12-2014",
                    end_date="06-12-2014",
                    flag="internal",
                    owner_id = "{ownerId}",
                };
                var newMilestone = milestonesApi.Create(projectId, new_milestone);
                var newMilesonelinks = newMilestone.link;
                Console.WriteLine("Id:{0},\nname:{1},\nstatus:{2}", newMilestone.id, newMilestone.name, newMilestone.status);
                Console.WriteLine("Self link:{0},\nstatus link:{1}", newMilesonelinks.self.url, newMilesonelinks.status.url);
                var update_milestone_info = new Milestone()
                {
                    id = newMilestone.id,
                    name = "milestone name",
                    start_date = "06-12-2014",
                    end_date = "06-19-2014",
                    flag = "internal",
                    owner_id = "{ownerId}",
                };
                var updatedMilestone = milestonesApi.Update(projectId, update_milestone_info);
                var updatedMilesonelinks = updatedMilestone.link;
                Console.WriteLine("Id:{0},\nname:{1},\nstatus:{2}", updatedMilestone.id, updatedMilestone.name, updatedMilestone.status);
                Console.WriteLine("Self link:{0},\nstatus link:{1}", updatedMilesonelinks.self.url, updatedMilesonelinks.status.url);
                var statusUpdatedMilestone = milestonesApi.UpdateStatus(projectId, updatedMilestone.id.ToString(), 2);
                Console.WriteLine("Id:{0},\nname:{1},\nstatus:{2}", statusUpdatedMilestone.id, statusUpdatedMilestone.name, statusUpdatedMilestone.status);
                var deleteMilestone = milestonesApi.Delete(projectId, updatedMilestone.id.ToString());
                Console.WriteLine(deleteMilestone);

//------------------------------------------------TasklistsApiTest----------------------------------------------------------------------------------------

                var tasklistsApi = service.GetTasklistsApi();
                var tasklistParameters = new Dictionary<object, object>();
                parameters.Add("flag", "internal");
                var tasklists = tasklistsApi.GetTasklists(projectId, tasklistParameters);
                foreach(var tempTasklist in tasklists)
                {
                    Console.WriteLine("Id:{0},\nname:{1},\nrolled:{2},\nview type:{3}", tempTasklist.id, tempTasklist.name, tempTasklist.rolled, tempTasklist.view_type);
                    if (tempTasklist.milestone != null)
                        Console.WriteLine("milestone name:{0}", tempTasklist.milestone.name);
                }
                var newTasklistInfo = new Tasklist()
                {
                    name="tasklist four",
                    milestone = new Milestone()
                    {
                        id = milestones[0].id,
                        flag="internal"
                    },
                };
                var newTasklist = tasklistsApi.Create(projectId, newTasklistInfo);
                Console.WriteLine("Id:{0},\nname:{1},\nrolled:{2},\nview type:{3}", newTasklist.id, newTasklist.name, newTasklist.rolled, newTasklist.view_type);
                if (newTasklist.milestone != null)
                    Console.WriteLine("milestone name:{0}", newTasklist.milestone.name);
                var update_tasklist_info = new Tasklist()
                {
                    id = newTasklist.id,
                    name = "tasklist name",
                    milestone = new Milestone()
                    {
                        id = milestones[0].id,
                        flag = "external",
                        status="active"
                    },
                };
                var updatedTasklist = tasklistsApi.Update(projectId, update_tasklist_info);
                Console.WriteLine("Id:{0},\nname:{1},\nrolled:{2},\nview type:{3}", updatedTasklist.id, updatedTasklist.name, updatedTasklist.rolled, updatedTasklist.view_type);
                if (updatedTasklist.milestone != null)
                    Console.WriteLine("milestone name:{0},status:{1}", updatedTasklist.milestone.name,updatedTasklist.milestone.status);
                var deleteTasklist = tasklistsApi.Delete(projectId, updatedTasklist.id.ToString());
                Console.WriteLine(deleteTasklist);

//------------------------------------------------------TasksApiTest-----------------------------------------------------------------------------------

                var tasksApi = service.GetTasksApi();
                var taskParameters = new Dictionary<object, object>();
                taskParameters.Add("index",0);
                var tasks = tasksApi.GetTasks(projectId, taskParameters);
                foreach (var temptask in tasks)
                    Console.WriteLine("id:{0},\nPriority:{1},\name:{2}",temptask.id,temptask.priority,temptask.name);
                var tasklisttasks = tasksApi.GetTasklistTasks(projectId, tasklists[0].id.ToString(), null);
                foreach (var temptask in tasklisttasks)
                    Console.WriteLine("id:{0},\nPriority:{1},\name:{2}",temptask.id,temptask.priority,temptask.name);
                var task = tasksApi.Get(projectId, tasks[0].id.ToString());
                Console.WriteLine("id:{0},\nPriority:{1},\name:{2}", task.id, task.priority, task.name);
                var newTaskInfo = new Task()
                {
                    name="new task"
                };
                var newTask = tasksApi.Create(projectId, newTaskInfo);
                Console.WriteLine("id:{0},\nPriority:{1},\nname:{2}", newTask.id, newTask.priority, newTask.name);
                var update_task_info = new Task()
                {
                    id = newTask.id,
                    name="hari2",
                    owners = new List<Owner>()
                    {
                      new Owner(){
                          id="{ownerId}"
                      },  
                    },
                };
                var updatedTask = tasksApi.Update(projectId, update_task_info);
                Console.WriteLine("id:{0},\nPriority:{1},\nname:{2}", updatedTask.id, updatedTask.priority, updatedTask.name);
                var deleteTask = tasksApi.Delete(projectId, updatedTask.id.ToString());
                Console.WriteLine(deleteTask);

//----------------------------------------------------BugsApi Test----------------------------------------------------------
                
                 var bugsApi = service.GetBugsApi();
                var bugParameters=new Dictionary<object,object>();
                
                var bugs = bugsApi.GetBugs(projectId,bugParameters);
                var bugId = bugs[0].id;
                var bug = bugsApi.Get(projectId, bugId.ToString());
                Console.WriteLine("bug info:\n bug id:{0},\nbug title:{1},bug description:{2}", bug.id, bug.title, bug.description);
                var newBug = new Bug()
                {
                    title="bug name",
                    description="bug added by wrapper method",
                };
                var createdBug = bugsApi.Create(projectId, newBug);
                Console.WriteLine("New bug info:\n bug id:{0},\nbug title:{1},bug description:{2}", createdBug.id, createdBug.title, createdBug.description);
                var updateInfo = new Bug()
                {
                    id = createdBug.id,
                    title = "title1",
                    description="updated description"
                };
                var updatedBug = bugsApi.Update(projectId, updateInfo);
                Console.WriteLine("updatedBug info\n bug id:{0},\nbug title:{1},bug description:{2}", updatedBug.id, updatedBug.title, updatedBug.description);
                var deleteBug = bugsApi.Delete(projectId, updatedBug.id.ToString());
                Console.WriteLine(deleteBug);

//----------------------------------------------------EventsApiTest-----------------------------------------

                var eventsApi = service.GetEventsApi();
                var eventsParameters = new Dictionary<object, object>();
                var events = eventsApi.GetEvents(projectId,eventsParameters);
                foreach (var tempEvent in events)
                    Console.WriteLine("events \n event id:{0},\ntitle:{1},\npartcipant:{2}.", tempEvent.id, tempEvent.title, tempEvent.participants[0].participant_id);
                var partcipantId = events[1].participants[0].participant_id;
                var eventId = events[1].id;
                var newEventInfo = new Event()
                {
                    title="newly created event by wrapper method",
                    date="07-25-2014",
                    hour="03",
                    minutes="30",
                    ampm="pm",
                    duration_hour="01",
                    duration_minutes="30",
                    participants = new List<Participant>()
                    {
                        new Participant(){
                            participant_id=partcipantId,
                        },
                    },

                };
                var newEvent = eventsApi.Add(projectId, newEventInfo);
                var updateeventId=newEvent.id;
                Console.WriteLine("events \n event id:{0},\ntitle:{1},\npartcipant:{2}.", newEvent.id, newEvent.title, newEvent.participants[0].participant_id);
                var updateEventInfo = new Event()
                {
                    id=updateeventId,
                    title = "updated",
                    date = "06-25-2014",
                    hour = "01",
                    minutes = "30",
                    ampm = "pm",
                    duration_hour = "01",
                    duration_minutes = "03",
                    participants = new List<Participant>()
                    {
                        new Participant(){
                            participant_id=partcipantId,
                        },
                    },
                };
                var updatedEvent = eventsApi.Update(projectId, updateEventInfo);
                Console.WriteLine("events \n event id:{0},\ntitle:{1},\npartcipant:{2}.", updatedEvent.id, updatedEvent.title, updatedEvent.participants[0].participant_id);
                var deleteEvent = eventsApi.Delete(projectId, updatedEvent.id.ToString());
                Console.WriteLine(deleteEvent);

//------------------------------------------------- DocumentsApi Test ------------------------------------------------------------------------------------
                
                var documentsApi = service.GetDocumentsApi();
                var docparameters = new Dictionary<object, object>();
                var documents = documentsApi.GetDocuments(projectId, docparameters);
                var docId = documents[0].id.ToString();
                var folderId=documents[0].folder.id;
                var docparam=new Dictionary<object,object>();
                var document = documentsApi.Get(projectId, docId,docparam);
                Console.WriteLine("document details\n id:{0},\nfilename:{1},\nversionId={2}.", document.id, document.file_name, document.versions[0].id);
                var newDocumentInfo = new Document()
                {
                    uploaddoc = @"C:\Users\hari-2197\Desktop\1.jpg",
                    folder = new Folder()
                    {
                        id = folderId
                    },

                };
                var newDoc = documentsApi.Add(projectId, newDocumentInfo);
                Console.WriteLine("document details\n id:{0},\nfilename:{1},\nversionId={2}.", newDoc.id, newDoc.file_name, newDoc.versions[0].id);
                var updateDocumentInfo = new Document()
                {
                    id=newDoc.id,
                    uploaddoc = @"C:\Users\hari-2197\Desktop\1.jpg",
                    folder = new Folder()
                    {
                        id = folderId
                    },
                };
                var updatedDoc = documentsApi.Update(projectId, updateDocumentInfo);
                Console.WriteLine("document details\n id:{0},\nfilename:{1},\nversionId={2}.", updatedDoc.id, updatedDoc.file_name, updatedDoc.versions[0].id);
                var deleteDoc = documentsApi.Delete(projectId, updatedDoc.id.ToString());
                Console.WriteLine(deleteDoc);
                var folders = documentsApi.GetFolders(projectId);
                foreach (var temp in folders)
                    Console.WriteLine("folders\n name:{0},\tid:{1}", temp.name, temp.id);
                var newFolderInfo = new Folder()
                {
                    name="new folder"
                };
                var newFolder = documentsApi.AddFolder(projectId, newFolderInfo);
                Console.WriteLine("New folder\n name:{0},\tid:{1}", newFolder.name, newFolder.id);
                var updateFolderInfo = new Folder()
                {
                    id=newFolder.id,
                    name="updated name",
                };
                var updatedFolder = documentsApi.UpdateFolder(projectId, updateFolderInfo);
                Console.WriteLine("Updated folder\n name:{0},\tid:{1}", updatedFolder.name, updatedFolder.id);
                var deleteFolder = documentsApi.DeleteFolder(projectId, updatedFolder.id.ToString());
                Console.WriteLine(deleteFolder);

//--------------------------------------------ForumsApi Test------------------------------------------------------

                var forumsApi = service.GetForumsApi();
                var forumsParams = new Dictionary<object, object>();
                var forums = forumsApi.GetForums(projectId,forumsParams);
                var forumId = forums[0].id;
                var categories = forumsApi.GetCategories(projectId);
                var newCategoryInfo = new Category()
                {
                    name="new category1",
                };
                var newCategory = forumsApi.AddCategory(projectId, newCategoryInfo);
                Console.WriteLine("id:{0}\nname:{1}", newCategory.id, newCategory.name);
                var commentsParams=new Dictionary<object,object>();
                var comments = forumsApi.GetComments(projectId, forumId.ToString(), commentsParams);
                var newCommentInfo = new Comment()
                {
                    content = "comment added throw api",
                };
                var newComment = forumsApi.AddComment(projectId, forumId.ToString(), newCommentInfo);
                Console.WriteLine("new comment id:{0}\n content:{1}", newComment.id, newComment.content);
                var newForumInfo = new Forum()
                {
                    name="forum new",
                    content="second forum",
                    category_id = categories[0].id,
                    uploadfile = @"C:\Users\hari-2197\Desktop\1.jpg"
                };
                forums[0].category_id = newCategory.id;
                var newForum = forumsApi.Add(projectId, newForumInfo);
                Console.WriteLine("New created Forum\n name:{0},\nContent:{1},\nposted By:{2}", newForum.name, newForum.content, newForum.posted_by);
                var updateForumInfo = new Forum()
                {
                    id=forumId,
                    name = "updatedName",
                    content="updatedContent",
                    category_id=newCategory.id,
                    uploadfile = @"C:\Users\hari-2197\Desktop\1.jpg"
                };
                var updatedForum = forumsApi.Update(projectId, updateForumInfo);
                Console.WriteLine("updated Forum\n name:{0},\nContent:{1},\nposted By:{2}", updatedForum.name, updatedForum.content, updatedForum.posted_by);

//--------------------------------------------UsersApi Test--------------------------------------------------------------------

                var usersApi = service.GetUsersApi();
                var users = usersApi.GetUsers(projectId);
                var userId = users[0].id;
                foreach (var user in users)
                    Console.WriteLine("user name:{0},user role:{1}", user.name, user.role);

//--------------------------------------------------TimesheetsApi Test---------------------------------------------------------

                var timesheetsApi = service.GetTimesheetsApi();
                var logParameters = new Dictionary<object, object>();
                logParameters.Add("users_list", userId);
                logParameters.Add("view_type", "month");
                logParameters.Add("date", "06-18-2014");
                logParameters.Add("component_type", "bug");
                logParameters.Add("bill_status", "Billable");
                var timelogs = timesheetsApi.GetTimeLogs(projectId, logParameters);
                Console.WriteLine("role:{0},totla log time:{1}", timelogs.role, timelogs.grandtotal);
                var newTasklogInfo = new Tasklog()
                {
                    task=new Task()
                    {
                        id=tasks[0].id,
                    },
                    log_date = "06-19-2014",
                    bill_status = "Billable",
                    hours ="04:14",
                };
                var newTasklog = timesheetsApi.AddTaskLog(projectId, newTasklogInfo);
                Console.WriteLine("task log id:{0},\t bill status:{1}", newTasklog.id, newTasklog.bill_status);
                newTasklog.bill_status = "Non Billable";
                var updatedTasklog = timesheetsApi.UpdateTasklog(projectId, newTasklog);
                Console.WriteLine("updated task log id:{0},\t bill status:{1}", updatedTasklog.id, updatedTasklog.bill_status);
                var deleteTasklog = timesheetsApi.DeleteTasklog(projectId, tasks[0].id.ToString(), updatedTasklog.id.ToString());
                Console.WriteLine(deleteTasklog);
                var newBuglogInfo = new Buglog()
                {
                    bug = new Bug()
                    {
                        id = bugId,
                    },
                    log_date = "06-19-2014",
                    bill_status = "Billable",
                    hours = "04:14",
                };
                var newBuglog = timesheetsApi.AddBuglog(projectId, newBuglogInfo);
                Console.WriteLine("new bug log id:{0},\t bill status:{1}", newBuglog.id, newBuglog.bill_status);
                newBuglog.bill_status = "Non Billable";
                var updatedBuglog = timesheetsApi.UpdateBuglog(projectId, newBuglog);
                Console.WriteLine("updated bug log id:{0},\t bill status:{1}", updatedBuglog.id, updatedBuglog.bill_status);
                var deleteBuglog = timesheetsApi.DeleteBuglog(projectId, bugId.ToString(), updatedBuglog.id.ToString());
                Console.WriteLine(deleteBuglog);
                var newGenerallogInfo = new Generallog()
                {
                    name="general log for project",
                    log_date="06-16-2014",
                    bill_status="Billable",
                    hours="05:20",
                    notes="notes"
                };
                var newGenerallog = timesheetsApi.AddGenerallog(projectId, newGenerallogInfo);
                Console.WriteLine("new general log id:{0},\t bill status:{1}", newGenerallog.id, newGenerallog.bill_status);
                newGenerallog.bill_status = "Billable";
                var updatedGenerallog = timesheetsApi.UpdateGenerallog(projectId, newGenerallog);
                Console.WriteLine("updated general log id:{0},\t bill status:{1}", updatedGenerallog.id, updatedGenerallog.bill_status);
                var deleteGenerallog = timesheetsApi.DeleteGenerallog(projectId, updatedGenerallog.id.ToString());
                Console.WriteLine(deleteGenerallog);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
