using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BazaAwionika.Web.ViewModel;
using BazaAwionika.Services;
using BazaAwionika.Model;
using Microsoft.AspNetCore.Http;

namespace BazaAwionika.Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsService settingsService;
        private readonly IUserService userService;

        public SettingsController(ISettingsService settingsService, IUserService userService)
        {
            this.settingsService = settingsService;
            this.userService = userService;
        }
        // GET: Settings
        public IActionResult Index()
        {
            var settings = settingsService.GetSettings();
            var settingsViewModel = AutoMapperConfiguration.Mapper.Map<IEnumerable<SettingsModel>, IEnumerable<SettingsViewModel>>(settings);

            return View(settingsViewModel);
        }

        // GET: Settings/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;
            SettingsModel settingsModel = settingsService.GetSettings(id);
            if (settingsModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
           

            return PartialView(settingsModel);
        }

        // GET: Settings/Create
        public IActionResult Create()
        {
            var userModels = userService.GetUsers();
            ViewBag.UserId = new SelectList(userModels, "Id", "Name");
            return View();
        }

        // POST: Settings/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SettingsViewModel settingsViewModel)
        {
            if (ModelState.IsValid)
            {
                SettingsModel settingsModel = AutoMapperConfiguration.Mapper.Map<SettingsModel>(settingsViewModel);

                settingsService.CreateSettings(settingsModel);
                settingsService.SaveSettings();
                return RedirectToAction("Index");
            }
            var userModels = userService.GetUsers();
            ViewBag.UserId = new SelectList(userModels, "Id", "Name");
            return View(settingsViewModel);

        }

        // GET: Settings/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;

            SettingsModel settingsModel = settingsService.GetSettings(id);
            SettingsViewModel settingsViewModel = AutoMapperConfiguration.Mapper.Map<SettingsViewModel>(settingsModel);
 
            if (settingsModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            var userModels = userService.GetUsers();
            ViewBag.UserId = new SelectList(userModels, "Id", "Name",settingsViewModel.UserId);
            return View(settingsViewModel);
        }

        // POST: Settings/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SettingsViewModel settingsViewModel)
        {
            if (ModelState.IsValid)
            {
                SettingsModel settingsModel = settingsService.GetSettings(settingsViewModel.Id);
                AutoMapperConfiguration.Mapper.Map(settingsViewModel, settingsModel);
                settingsService.SaveSettings();
                return RedirectToAction("Index");
            }
            var userModels = userService.GetUsers();
            ViewBag.UserId = new SelectList(userModels, "Id", "Name", settingsViewModel.UserId);
            return View(settingsViewModel);
        }


        // POST: Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            SettingsModel settingsModel = settingsService.GetSettings(id);
            settingsService.DeleteSettings(settingsModel);
            return RedirectToAction("Index");
        }
    }
}
