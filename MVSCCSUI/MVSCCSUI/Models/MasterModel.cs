using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using System.Text;

namespace MVSCCSUI.Models
{
    public class MasterModel
    {
        public async Task<SelectList> LoadCountryAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://seller.mvsccs.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/DropDown");
                if (response.IsSuccessStatusCode)
                {

                    var Product = response.Content.ReadAsStringAsync();
                    var Result = Product.Result;
                    var countries = JsonConvert.DeserializeObject<List<DropDown>>(Result);
                    System.Web.Mvc.SelectList sb = new System.Web.Mvc.SelectList(countries, "Value", "Name");
                    return sb;
                }
                else
                {
                    return null;
                }
            }
        }
        public async Task<Users> RegisterUsersAsync(Users user)
        {
            var jSettings = new JsonSerializerSettings();
            jSettings.NullValueHandling = NullValueHandling.Ignore;
            jSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
            var JsonData = JsonConvert.SerializeObject(user);
            var RoleContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://seller.mvsccs.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(user, Formatting.Indented);
                var stringContent = new StringContent(json);
                HttpResponseMessage response = await client.PostAsync("api/Registration", RoleContent);
                if (response.IsSuccessStatusCode)
                {
                    var Product = response.Content.ReadAsStringAsync();
                    var Result = Product.Result;
                    var json2 = JsonConvert.DeserializeObject<Users>(Result);
                    return json2;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}