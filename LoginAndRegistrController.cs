using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yogagym.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Yogagym.Controllers
{
    public class LoginAndRegistrController : Controller
    {
        private readonly ModelContext _context;

        public LoginAndRegistrController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string FirstName, string LastName,  string Email, string Username, string Password, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                string imageFilePath = null;
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                    var filePath = Path.Combine(uploads, fileName);

                    // Ensure the directory exists
                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    imageFilePath = "/images/" + fileName;  // Save relative path to database
                }

                // Create Member object
                Member member = new Member
                {
                    Fname = FirstName,
                    Lname = LastName,
                    Email = Email,
                    Imagepath = imageFilePath  // Store the path in the database
                };

                _context.Add(member);      
                await _context.SaveChangesAsync();
                
                // Create Userlogin object
                Userlogin login = new Userlogin
                {
                    Username = Username,
                    Password = Password,
                    Roleid = 3 ,
                    Memberid = member.Memberid
                };


				_context.Add(login);
				await _context.SaveChangesAsync();

				// Redirect to Login page after successful registration
				return RedirectToAction("Login", "LoginAndRegistr");
			}

			return View();
		}

		public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Username,Password")] Userlogin userlogin)
        {
           

            var auth = _context.Userlogins
                .Where(x => x.Username == userlogin.Username && x.Password == userlogin.Password)
                .SingleOrDefault();

            if (auth != null)
            {
                // إعداد الجلسة بناءً على الدور
                switch (auth.Roleid)
                {
                    case 1: // Admin
                        HttpContext.Session.SetString("AdminName", auth.Username);
                        HttpContext.Session.SetInt32("AdminId", (int)auth.Adminid);
                        return RedirectToAction("Index", "AdminAssest");

                   
                    case 2: // Trainer
                        HttpContext.Session.SetString("TrainerName", auth.Username);
                        HttpContext.Session.SetInt32("TrainerId", (int)auth.Trainerid);
                        return RedirectToAction("Index", "Trainerdash");

                    case 3: // Member
                        HttpContext.Session.SetString("MemberName", auth.Username);
                        HttpContext.Session.SetInt32("MemberId",(int)auth.Memberid);
                        return RedirectToAction("MemberHome", "Home");


                    default:
                        ViewBag.ErrorMessage = "Role not recognized.";
                        return View();
                }


            }


            // If authentication fails
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }



    }
}


