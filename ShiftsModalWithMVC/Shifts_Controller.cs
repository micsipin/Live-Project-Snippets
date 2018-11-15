
namespace ScheduleUsers.Areas.Employer.Controllers
{
    
    public class ShiftController : Controller

    {
        //GET: Create/CreateScheduleForUser
        //This populates the partial, dropdownlist with shifts.

        public ActionResult ShiftModal()
        {
            var s = db.Shifts.ToList();
            List<SelectListItem> temp = new List<SelectListItem>();
            foreach (var item in s)
            {
                string timeString = item.EndTime.Value.ToShortTimeString() + "-" + item.EndTime.Value.ToShortTimeString();
                temp.Add(new SelectListItem { Text = timeString, Value = item.Id });
            }

            return PartialView("_ModalShifts", temp);

        }

        // GET: Employer/Shift/Create
        public ActionResult Create(string Id)
        {
            var StartTime = db.Shifts.Find(Id);
            var StartTimes = db.Shifts.ToList();
            var EndTime = db.Shifts.Find(Id);
            var EndTimes = db.Shifts.ToList();
            var Shift = db.Shifts.ToList();

            Shift shifts = new Shift();
            return View();
        }

        //GET: Employer/Shift/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shifts.Find(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return PartialView(shift);
        }
	}
}