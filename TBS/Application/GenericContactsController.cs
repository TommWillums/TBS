using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TBS.Domain;
using TBS.Repository;

namespace TBS.Application
{
    public class GenericClubsController : Controller
    {
        private GenericUnitOfWork uow = null;
        //
        // GET: /Clubs/

        public GenericClubsController()
        {
            uow = new GenericUnitOfWork();
        }

        public GenericClubsController(GenericUnitOfWork uow_)
        {
            this.uow = uow_;
        }

        public ActionResult Index()
        {
            return View(uow.Repository<Club>().GetAll().ToList());
        }

        //
        // GET: /Clubs/Details/5

        public ActionResult Details(int id = 0)
        {
            Club Club = uow.Repository<Club>().Get(c => c.Id == id);
            if (Club == null)
            {
                return BadRequest(ModelState);
            }
            return View(Club);
        }

        //
        // GET: /Clubs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Clubs/Create

        [HttpPost]
        public ActionResult Create(Club Club)
        {
            if (ModelState.IsValid)
            {
                uow.Repository<Club>().Add(Club);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Club);
        }

        //
        // GET: /Clubs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Club Club = uow.Repository<Club>().Get(c => c.Id == id);
            if (Club == null)
            {
                return BadRequest(ModelState);
            }
            return View(Club);
        }

        //
        // POST: /Clubs/Edit/5

        [HttpPost]
        public ActionResult Edit(Club Club)
        {
            if (ModelState.IsValid)
            {
                uow.Repository<Club>().Attach(Club);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Club);
        }

        //
        // GET: /Clubs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Club Club = uow.Repository<Club>().Get(c => c.Id == id);
            if (Club == null)
            {
                return BadRequest(ModelState);
            }
            return View(Club);
        }

        //
        // POST: /Clubs/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Club Club = uow.Repository<Club>().Get(c => c.Id == id);
            uow.Repository<Club>().Delete(Club);
            uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
