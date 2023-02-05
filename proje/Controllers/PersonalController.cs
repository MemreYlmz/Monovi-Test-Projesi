using Microsoft.AspNetCore.Mvc;
using proje.Models;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace proje.Controllers
{
    public class PersonalController : Controller
    {
        ProjeDbContext db = new ProjeDbContext();
        public IActionResult Index()
        {
            List<TblPersonal> personals= db.TblPersonals.ToList();
            return View(personals);
        }

        public IActionResult Delete(int id)
        {
            var person = db.TblPersonals.Find(id);
            db.TblPersonals.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddPersonal()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddPersonal([Bind("PersonalNumber", "Name", "Surname", "Mail", "PhoneNumber", "Title")] TblPersonal personal)
        {
            //Telefon numarası kontrolü
            long number1 = 0;
            bool validPhoneNumber = long.TryParse(personal.PhoneNumber, out number1);
            number1 = 0;
            
            //Personal numarası kontrolü
            bool validPersonalNumber= long.TryParse(personal.PersonalNumber, out number1);


            //mail kontrolü

            bool validMail = personal.Mail.Contains("@") && personal.Mail.EndsWith(".com");

            Console.WriteLine(validPhoneNumber + "   " + validPersonalNumber + " " + validPersonalNumber.ToString().Length + "   " + validPhoneNumber.ToString().Length );
            if (validPhoneNumber == true && validPersonalNumber==true && 
                personal.PhoneNumber.ToString().Length ==10 && personal.PersonalNumber.ToString().Length==8 && validMail == true ) { 

                db.TblPersonals.Add(personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                Response.WriteAsync("<script>alert(' The information you entered is incorrect. Try again ')</script>");

            return View();



        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var personal= db.TblPersonals.Find(id); 
            return View(personal);
        }

        [HttpPost]
        public IActionResult Edit(int id ,[Bind("PersonalNumber", "Name", "Surname", "Mail", "PhoneNumber", "Title")] TblPersonal personal)
        {
            var person=db.TblPersonals.Find(id);
            person.Name=personal.Name;
            person.Title=personal.Title;
            person.Surname=personal.Surname;
            person.PhoneNumber=personal.PhoneNumber;
            person.Mail=personal.Mail;
            person.PersonalNumber=personal.PersonalNumber;

            //Telefon numarası kontrolü
            long number1 = 0;
            bool validPhoneNumber = long.TryParse(personal.PhoneNumber, out number1);
            number1 = 0;

            //Personal numarası kontrolü
            bool validPersonalNumber = long.TryParse(personal.PersonalNumber, out number1);

            //mail kontrolü

            bool validMail = personal.Mail.Contains("@") && personal.Mail.EndsWith(".com");

            Console.WriteLine(validPhoneNumber + "   " + validPersonalNumber + " " + validPersonalNumber.ToString().Length + "   " + validPhoneNumber.ToString().Length);
            if (validPhoneNumber == true && validPersonalNumber == true &&
                personal.PhoneNumber.ToString().Length == 10 && personal.PersonalNumber.ToString().Length == 8 && validMail == true)
            {

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                Response.WriteAsync("<script>alert(' The information you entered is incorrect. Try again ')</script>");

            return View();

        }

       


    }
}
