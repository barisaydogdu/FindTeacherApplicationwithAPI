using AutoMapper;
using FindTeacherApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace FindTeacherApp.Controllers
{
    public class StudentsController : Controller
    {
        Student _oStudent = new Student();
        List<Student> _oStudents = new List<Student>();
        private readonly HttpClient _httpClient;

        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public StudentsController()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors)
                =>
            { return true; };


            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7100/"); // API'nin adresini buraya girin
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: StudentsController
        [HttpGet]
        public async Task<ActionResult> GetAllStudents()
        {
            _oStudents = new List<Student>();
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7100/api/Students"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oStudents = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }
            return View(_oStudents);
        }

        [HttpGet]
        public async Task<ActionResult> GetById(Guid studentId)
        {
            _oStudent = new Student();
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7100/api/Students/"+studentId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oStudent = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return View(_oStudents);
        }
        public ActionResult AddStudent()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> AddStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            student.UserId = Guid.NewGuid();
            try
            {
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Students", content);


                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    // Hata ayrıntılarını işleyin veya hata mesajını gösterin
                    return RedirectToAction("Error");
                }

                var result = await response.Content.ReadAsStringAsync();
                var createdStudent = JsonConvert.DeserializeObject<Student>(result);

                // Başarılı yanıtın işlenmesi

                return RedirectToAction("Index"); // İstenilen yönlendirme yapısı
            }
            catch (Exception ex)
            {
                // Hata durumunun işlenmesi
                return RedirectToAction("Error");
            }
        }

      

   
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            using (var client= new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7100/api/"); // API'nin adresini buraya girin
                var deleteTask = client.DeleteAsync("Students/" + id.ToString());
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return View();
                }
                return RedirectToAction("GetAllStudents");
            }
            ///  Student student = _oStudents.Find(s => s.Id == id);

        }

        public IActionResult UpdateStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(Student student,Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7100/api/"); // Web API'nin adresini buraya girin

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<StudentData, Student>();
                });

                // AutoMapper nesnesi oluşturulması
                var mapper = new Mapper(config);

                // API'den gelen öğrenci verileri
                var studentData = GetAllStudents();

                // Güncellenmek istenen öğrenci nesnesi
                var updatedStudent = mapper.Map<Student>(studentData);

                // Güncellenmek istenen öğrencinin bilgilerini hazırlayın
             

                // JSON formatına dönüştürülen öğrenci nesnesini içeren HTTP PUT isteği gönderin
                var response = await client.PutAsJsonAsync("Students/" + updatedStudent.Id.ToString(), updatedStudent);

                if (response.IsSuccessStatusCode)
                {
                    // Başarılı güncelleme durumunda istediğiniz işlemi yapabilirsiniz
                    return RedirectToAction("GetAllStudents");
                }
                else
                {
                    // Hata durumunda istediğiniz işlemi yapabilirsiniz
                    return RedirectToAction("Error");
                }
            }
            return RedirectToAction("GetAllStudents");
        }




        //return await AddOld(student);


        //_oStudent = new Student();
        //using (var httpClient = new HttpClient(httpClientHandler))
        //{
        //    StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");

        //    using (var response = await httpClient.PostAsync("https://localhost:7100/api/Students", content))
        //    {
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //        _oStudent = JsonConvert.DeserializeObject<Student>(apiResponse);
        //    }
        //}
        //return View(_oStudent);




        // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
