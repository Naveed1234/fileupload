using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class CarrerController : Controller
    {
        // GET: Carrer
        public ActionResult SubmitCV()
        {
            return View();
        }
        [HttpPost]

              public ActionResult SubmitCV(Carrer c,HttpPostedFileBase file)
        {
            if (file == null)
            {
                ModelState.AddModelError("CustomError", "Please select cv");

                return View();
            }
            if (!(file.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" ||
         file.ContentType == "application/pdf"))
            {
                ModelState.AddModelError("CustomError", "Only .docx and .pdf file allowed");
                return View();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    //file.SaveAs(System.IO.Path.Combine(Server.MapPath("~/UploadedCV"), fileName));
                    using (MyDatabaseEntities dc = new MyDatabaseEntities())
                    {
                       // c.CV = fileName;
                        dc.Carrers.Add(c);
                        dc.SaveChanges();
                    }
                    ModelState.Clear();
                    c = null;
                    ViewBag.Message = "Successfully Done";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error! Please try again";
                    return View();
                }
            }
            return View();
        }
    }

    }
