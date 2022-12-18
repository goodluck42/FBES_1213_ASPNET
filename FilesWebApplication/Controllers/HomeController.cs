using FilesWebApplication.Models;
using FilesWebApplication.Services;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

using WebApiLibrary;

namespace FilesWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private const string c_FilesFolder = "Files";
        private static TokenGenerator tokenGenerator = new();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //[HttpPost]
        //public async Task<IActionResult> AddUser(User? user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }

        //    var httpClient = new HttpClient();

        //    await httpClient.PostAsync("https://localhost:7287/api/v1/user/add", JsonContent.Create<User>(user));

        //    return Ok();
        //}

        public IActionResult Index()
        {

            HttpContext.Response.Cookies.Append("my_super_token", "1337");

            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            if (HttpContext.Request.Cookies.TryGetValue("my_super_token", out string result))
            {

            }

            return View();
        }

        //[HttpPost]
        //public IActionResult Login(User user)
        //{
        //    var token = tokenGenerator.GenerateToken(id);



            
        //}



        public async Task<IActionResult> UserList()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7287/api/v1/user/get");
            using var stream = new StreamReader(await response.Content.ReadAsStreamAsync());

            var json = await stream.ReadToEndAsync();

            var users = JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(model: users);

        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFileCollection files)
        {
            if (files.Count == 0)
            {
                return BadRequest();
            }


            foreach (var file in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), c_FilesFolder, file.FileName);
                using var stream = System.IO.File.Create(path);

                await file.CopyToAsync(stream);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile(string fileName)
        {


            var extension = Path.GetExtension(fileName);
            string? mimeType = null;
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), c_FilesFolder, fileName);
                var stream = System.IO.File.Open(path, FileMode.Open);

                switch (extension)
                {
                    case ".png":
                        mimeType = "image/png";
                        break;
                }

                if (extension == null)
                {
                    return BadRequest();
                }

                return await Task.FromResult(File(stream, mimeType, fileName));
            }
            catch
            {
                return BadRequest();
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}