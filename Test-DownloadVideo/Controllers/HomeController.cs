using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Test_DownloadVideo.Models;

namespace Test_DownloadVideo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var pass = Guid.NewGuid().ToString();
            Session["pass"] = pass;
            Session["time"] = DateTime.Now;
            ViewBag.OPP = pass;
            return View();
        }

        public ActionResult GetVideo()
        {
            if (string.IsNullOrEmpty(Session["pass"].ToString()))
            {
                return null;
            }
            else
            {
                string pass = Request["opp"].ToString();
                if (pass != Session["pass"].ToString())
                {
                    return null;
                }
                else
                {
                    DateTime timeNew = DateTime.Now;
                    DateTime timeOld = (DateTime)Session["time"];
                    TimeSpan diffTimeSecond = timeNew - timeOld;
                    if (diffTimeSecond.TotalSeconds > 5)
                    {
                        return null;
                    }
                }
            }

            Session.Remove("pass");
            Session.Remove("time");

            VideoVM videoVM;
            using (DBEntities db = new DBEntities())
            {
                videoVM = db.VideoSteams.Select(x => new VideoVM
                {
                    SrNo = x.SrNo,
                    FileName = x.FileName,
                    FileType = x.FileType,
                    Url = x.Url
                }).FirstOrDefault();
            }

            Stream str = System.IO.File.OpenRead(Server.MapPath("~/") + videoVM.Url);
            str.Seek(0, SeekOrigin.Begin);
            return File(str, "video/mp4");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}