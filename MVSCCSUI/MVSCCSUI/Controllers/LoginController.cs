using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVSCCSUI.Models;
using Newtonsoft.Json;

namespace MVSCCSUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://seller.mvsccs.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/Login");
                if (response.IsSuccessStatusCode)
                {
                    var Product = response.Content.ReadAsStringAsync();
                    var Result = Product.Result ;
                    //Product product = await response.Content.ReadAsAsync<Product>();
                    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }
                return View();
               }
            }
        public ActionResult Login()
        {
            return View();
        }
        public async Task<ActionResult> Signin()
        {
            //var s= await new MasterModel().LoadCountryAsync();
            Users users = new Users();
            users.sb= await new MasterModel().LoadCountryAsync();
            return View(users);
        }
        [HttpPost]
        public async Task<ActionResult> Signin(Users user,string action)
        {
            user = await new MasterModel().RegisterUsersAsync(user);
            return RedirectToAction("Signin");
            //return View();
        }  
        public async Task<ActionResult> ForgotPassword(string email_forgot)
        {

            using (var client = new HttpClient())
            {
               // client.BaseAddress = new Uri("");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("http://96.43.140.186/urlsms/index.php?uname=mediadragons&pword=123456&mobile=7905689201&msg=TEST_SMS&sid=ANKLIN&unc=0");
                if (response.IsSuccessStatusCode)
                {

                    var Product = response.Content.ReadAsStringAsync();
                    var Result = Product.Result;
                    var countries = JsonConvert.DeserializeObject<List<DropDown>>(Result);
                    System.Web.Mvc.SelectList sb = new System.Web.Mvc.SelectList(countries, "Value", "Name");
                   // return sb;
                }
                else
                {
                    return null;
                }
            }

          //  return Redirect("");
              return View();
        }
    }
}