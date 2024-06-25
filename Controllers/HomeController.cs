using Google.Maps;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;
using tech_challenge.Data;
using tech_challenge.Models;

namespace tech_challenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext appdbcontext)
        {
            _logger = logger;
            _context = appdbcontext;
        }              

        public IActionResult Index()
        {
            var contacts = _context.tblContacts.ToList();
            //GoogleMapDataClassesDataContext db = new GoogleMapDataClassesDataContext();
            //dynamic FriendList = db.tblFriends.ToList();

            //GridView1.DataSource = FriendList;
            //GridView1.DataBind();
            foreach (var contact in contacts)
            {
                //string address = dr["Pin"].ToString();
                //string url = "https://maps.google.co.in/mavarps/api/geocode/xml?address=" + address + "&key=API_Key";
                //System.Net.WebRequest request = System.Net.WebRequest.Create(url);
                //using (System.Net.WebResponse response = (System.Net.HttpWebResponse)request.GetResponse())
                //{
                //    using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                //    {
                //        System.Data.DataSet dsResult = new System.Data.DataSet();
                //        dsResult.ReadXml(reader);
                //        System.Data.DataTable location = dsResult.Tables["location"];
                //        dr["Latitude"] = location.Rows[0]["lat"];
                //        dr["Longitude"] = location.Rows[0]["lng"];
                //    }
                //}
            }
            //rptMarkers.DataSource = dt;
            //rptMarkers.DataBind();

            return View();
        }
                
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
                
        public JsonResult GetContacts()
        {
            var contacts = _context.tblContacts.ToList();
            return Json(contacts);
        }

        [HttpPost]
        public JsonResult AddContact(Contact_Info contact)
        {
            if(ModelState.IsValid)
            {
                _context.tblContacts.Add(contact);
                _context.SaveChanges();
                return Json("New contact added successfully."); 
            }
            return Json("Data validation failed.");
        }

        [HttpGet]
        public JsonResult ModifyContact(int id)
        {
            var contact = _context.tblContacts.Find(id);            
            return Json(contact);
        }

        [HttpPost]
        public JsonResult UpdateContact(Contact_Info contact)
        {
            if (ModelState.IsValid)
            {
                _context.tblContacts.Update(contact);
                _context.SaveChanges();
                return Json("Contact updated successfully.");
            }
            return Json("Data validation failed.");
        }

        public JsonResult DeleteContact(int id)
        {
            var contact = _context.tblContacts.Find(id);
            if (contact != null)
            {
                _context.tblContacts.Remove(contact);
                _context.SaveChanges();
                return Json("Contact deleted successfully.");
            }            
            return Json("Contact not found.");
        }
    }
}
