using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JPFinancial.Web.Models;
using PagedList;
using PagedList.Mvc;

namespace JPFinancial.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private JPFinancialContext db = new JPFinancialContext();

        // GET: Companies
        public ActionResult Index(string searchBy, string search, int? page)
        {
            var company = db.Companies.Include(c => c.Sector).Include(c => c.Industry);

            if (searchBy == "name")
            {
                return View(company.Where(c => c.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
            else if (searchBy == "ticker")
            {
                return View(company.Where(c => c.Ticker.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
            else if (searchBy == "sector")
            {
                return View(company.Where(c => c.Sector.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
            else if (searchBy == "industry")
            {
                return View(company.Where(c => c.Industry.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
            else
            {
                return View(company.ToList().ToPagedList(page ?? 1, 5));
            }
        }

        // GET: Companies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await db.Companies.FindAsync(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.IndustryID = new SelectList(db.Industries, "ID", "Name").ToList();
            ViewBag.SectorID = new SelectList(db.Sectors, "ID", "Name").ToList();
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Ticker,Address,City,State,Zipcode,Phone,Email,SectorID,IndustryID")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IndustryID = new SelectList(db.Industries, "ID", "Name", company.IndustryID);
            ViewBag.SectorID = new SelectList(db.Sectors, "ID", "Name", company.SectorID);
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await db.Companies.FindAsync(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.IndustryID = new SelectList(db.Industries, "ID", "Name", company.IndustryID);
            ViewBag.SectorID = new SelectList(db.Sectors, "ID", "Name", company.SectorID);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Ticker,Address,City,State,Zipcode,Phone,Email,SectorID,IndustryID")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IndustryID = new SelectList(db.Industries, "ID", "Name", company.IndustryID);
            ViewBag.SectorID = new SelectList(db.Sectors, "ID", "Name", company.SectorID);
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await db.Companies.FindAsync(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Company company = await db.Companies.FindAsync(id);
            db.Companies.Remove(company);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GetStockInfo(int? companyId)
        {

            if (companyId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockInfo stock = await db.StockInfoes.FindAsync(companyId);
            if (companyId == null)
            {
                return HttpNotFound();
            }

            return View(stock);
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
