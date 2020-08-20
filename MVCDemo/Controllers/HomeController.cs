using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            EmployeeContext db = new EmployeeContext();
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();

            foreach (City city in db.Cities)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = city.Name,
                    Value = city.ID.ToString(),
                    Selected = city.IsSelected
                };
                listSelectListItems.Add(selectList);
            }

            CitiesViewModel citiesViewModel = new CitiesViewModel()
            {
                Cities = listSelectListItems
            };

            return View(citiesViewModel);
        }

        [HttpPost]
        public string Index(IEnumerable<string> selectedCities)
        {
            if (selectedCities == null)
            {
                return "No cities selected";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - " + string.Join(",", selectedCities));
                return sb.ToString();
            }
        }
    }
}
//Note: Put the templates in "Shared" folder, if you want the "Templates", to be available for all the views.