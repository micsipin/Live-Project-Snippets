
namespace ScheduleUsers.Areas.Employer.Controllers
     ///////////////////////////////////
    // GET: Employer/Schedule/Create //
   //////////////////////////////////
        public ActionResult Create(string Id)
        {
	     ////////////////////////////////////////////////////////
            //  get data re: Users and Templates from the Server  //
	   ////////////////////////////////////////////////////////
            var user = db.Users.Find(Id);
            var users = db.Users.ToList();
            var scheduleTemplates = db.ScheduleTemplates.ToList();
            ScheduleViewModel scheduleViewModel = new ScheduleViewModel();

            try
            {
                scheduleViewModel = new ScheduleViewModel(user);
            }
            catch
            {
                scheduleViewModel = new ScheduleViewModel();
                scheduleViewModel.UserId = " ";
            }
             ////////////////////////////////////////////////////////////////////////////  
  	    //  creates list of users to populate Template Selection dropdown helper  //
	   ////////////////////////////////////////////////////////////////////////////
            scheduleViewModel.Users = (from p in users
                                       select new SelectListItem
                                       {
                                           Text = p.FirstName + " " + p.LastName,
                                           Value = p.Id
                                       }
                                       ).ToList();
            
	     ////////////////////////////////////////////////////////////////////////////
            //  adds default value to top of list and "no employee selected" option   ///////////////////////
	   //  to the dropdown list for purpose of only creating a new template w/o an employee assigned  //
          /////////////////////////////////////////////////////////////////////////////////////////////////  
  	    scheduleViewModel.Users.Insert(0, new SelectListItem
            {
                Text = "Select an Employee",
                Value = "SelectEmployee"
            });
            scheduleViewModel.Users.Insert(1, new SelectListItem
            {
                Text = "New Shift Template Only",
                Value = "NewShiftOnly"
            });
            
            //  creates list of schedule templates to populate Template Selection dropdown helper
            scheduleViewModel.ScheduleTemplates = (from template in scheduleTemplates
                                                   select new SelectListItem
                                                   {
                                                       Text = template.Notes,
                                                       Value = template.Id
                                                   }).ToList();
	
             /////////////////////////////////////////////////////////////////////////////////////////
            //  adds "No Template" and "New Template" options to template selection dropdown list  //
	   /////////////////////////////////////////////////////////////////////////////////////////
            scheduleViewModel.ScheduleTemplates.Insert(0, new SelectListItem { Text = "Select a Shift Template", Value = "SelectShiftTemplate" });
            scheduleViewModel.ScheduleTemplates.Insert(1, new SelectListItem { Text = "No Template", Value = "No Template"});
            scheduleViewModel.ScheduleTemplates.Add(new SelectListItem { Text = "New Template", Value = "New Template" });

            return View(scheduleViewModel);
        }
