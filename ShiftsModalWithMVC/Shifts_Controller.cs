
namespace ScheduleUsers.Areas.Employer.Controllers
{
    
    public class ShiftController : Controller

    {
        //  GET: Create/CreateScheduleForUser  //
        //  This populates the partial, dropdownlist with shifts.  //
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
	 
        //  GET: Employer/Shift/Create  //
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
	
	//  GET: Employer/Shift/Edit/5  //
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
	
	// GET: Employer/Shift/Edit/5  //
	// public JsonResult Edit(string id)  //
	// {
        //    if (id == null)
        //    {
        //        return new JsonResult();
        //    }
        //    Shift shift = db.Shifts.Find(id);
        //    if (shift == null)
        //    {
        //        return new JsonResult();
        //    }
        //    var shiftTimes = new { start = shift.StartTime.Value.ToShortTimeString() };
        //    return Json(shiftTimes,JsonRequestBehavior.AllowGet);
        // }
	  
        // POST: Employer/Shift/Edit/5  //
	[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shift);
        }
	
	//  GET: Employer/Shift/Delete/5  //
        public ActionResult Delete(string id)
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
            return View(shift);
        }

        //  POST: Employer/Shift/Delete/5  //
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Shift shift = db.Shifts.Find(id);
            db.Shifts.Remove(shift);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
	
    }
}
