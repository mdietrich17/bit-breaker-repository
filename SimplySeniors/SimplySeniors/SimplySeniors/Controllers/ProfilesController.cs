﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using SimplySeniors.DAL;
using SimplySeniors.Models;
using SimplySeniors.Models.ViewModel;

namespace SimplySeniors.Controllers
{
    public class ProfilesController : Controller
    {
        private ProfileContext db = new ProfileContext();
        private HobbiesContext db2 = new HobbiesContext();

     
        // GET: Profiles
        public ActionResult Index()
        {
            return View();
        }

        public FileContentResult GetFile(int id)
        {
            SqlDataReader rdr; byte[] fileContent = null;
            string mimeType = ""; string fileName = "";
            const string connect = @"Server=.\SQLExpress;Database=FileTest;Trusted_Connection=True;";

            using (var conn = new SqlConnection(connect))
            {
                var qry = "SELECT FileContent, MimeType, FileName FROM FileStore WHERE ID = @ID";
                var cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    fileContent = (byte[])rdr["FileContent"];
                    mimeType = rdr["MimeType"].ToString();
                    fileName = rdr["FileName"].ToString();
                }
            }
            return File(fileContent, mimeType, fileName);
        }

        // HTTP POST method was created for searching profiles in the Profiles/index. 
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            {
                IQueryable<Profile> products = db.Profiles;
                ViewBag.Message = "Sorry your product is not found";         // Insert message if item is not found. 

                if (!String.IsNullOrEmpty(searchString))
                {
                    products = products.Where(s => s.LASTNAME.Contains(searchString) || s.FIRSTNAME.Contains(searchString));   // Searching for matches through last name. 
                }
                return View(products.ToList());
            }
        }



        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);

            IQueryable<string> bridges = db2.HobbyBridges.Where(x => x.ProfileID.Value == id).Select(y => y.Hobby.NAME);
            string hobbies = string.Join(", ", bridges.ToList());
            PDViewModel viewModel = new PDViewModel(profile, hobbies);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
     
        // GET: Profiles/Create
        public ActionResult Create()
        { 
          
            foreach (string upload in Request.Files)
            {
               // if (!Request.Files[upload].HasFile()) continue;
                string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";
                string filename = Path.GetFileName(Request.Files[upload].FileName);
                Request.Files[upload].SaveAs(Path.Combine(path, filename));
            }

            foreach (string upload in Request.Files)
            {
               // if (!Request.Files[upload].HasFile()) continue;

                string mimeType = Request.Files[upload].ContentType;
                Stream fileStream = Request.Files[upload].InputStream;
                string fileName = Path.GetFileName(Request.Files[upload].FileName);
                int fileLength = Request.Files[upload].ContentLength;
                byte[] fileData = new byte[fileLength];
                fileStream.Read(fileData, 0, fileLength);

                const string connect = @"Server=.\SQLExpress;Database=FileTest;Trusted_Connection=True;";
                using (var conn = new SqlConnection(connect))
                {
                    var qry = "INSERT INTO FileStore (FileContent, MimeType, FileName) VALUES (@FileContent, @MimeType, @FileName)";
                    var cmd = new SqlCommand(qry, conn);
                    cmd.Parameters.AddWithValue("@FileContent", fileData);
                    cmd.Parameters.AddWithValue("@MimeType", mimeType);
                    cmd.Parameters.AddWithValue("@FileName", fileName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }


            return View();
        }
        
        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FIRSTNAME,LASTNAME,BIRTHDAY,LOCATION,VETSTATUS,OCCUPATION,FAMILY,BIO")] Profile profile)
        {
            if (!ModelState.IsValid) return View(profile);
            db.Profiles.Add(profile);
                  db.SaveChanges();
                  return RedirectToAction("Index");

        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FIRSTNAME,LASTNAME,BIRTHDAY,LOCATION,VETSTATUS,OCCUPATION,FAMILY,BIO")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
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
