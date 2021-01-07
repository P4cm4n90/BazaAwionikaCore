using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using BazaAwionika.Model;
using BazaAwionika.Services;
using BazaAwionika.Web.ViewModel;
using AutoMapper.Mappers;
using System.Linq;

namespace BazaAwionika.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

       //rivate MaintenanceEntities db = new MaintenanceEntities();

        // GET: User
        public IActionResult Index()
        {

            var usersModel = userService.GetUsers().ToList();
            return View(userService.GetUsers());
        }

        // GET: User/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;
            }
            UserModel userModel = userService.GetUser((int)id);
            if (userModel == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            }
            return PartialView(userModel);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] ///[Bind(Include = "Id,Name,LastName,FirstName,PasswordHash,AdditionalInformation")] 
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                UserModel userModel = AutoMapperConfiguration.Mapper.Map<UserModel>(userViewModel);
                userService.CreateUser(userModel);
                userService.SaveUser();
            }

            return View(userViewModel);
        }

        // GET: User/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;
            }
            UserModel userModel = userService.GetUser((int)id);
            UserViewModel userViewModel = AutoMapperConfiguration.Mapper.Map<UserViewModel>(userModel);
            if (userModel == null)
            {
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            }
            return View(userViewModel);
        }

        // POST: User/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] ///[Bind(Include = "Id,Name,LastName,FirstName,PasswordHash,AdditionalInformation")] 
        public IActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                UserModel userModel = userService.GetUser((int)userViewModel.Id);
               AutoMapperConfiguration.Mapper.Map(userViewModel, userModel);
                userService.UpdateUser(userModel);
                userService.SaveUser();              
            }
            return View(userViewModel);
        }

        // GET: User/Delete/5
        public IActionResult Delete(int? id) //TODO: nie wiem czy to dziala user
        {
            if (id == null)
                return new StatusCodeResult(StatusCodes.Status400BadRequest);;
            UserModel userModel = userService.GetUser((int)id);
            if (userModel == null)
                return new StatusCodeResult(StatusCodes.Status404NotFound);;
            return View(userModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(UserModel user) //TODO: nie wiem czy to dziala user
        {
            userService.DeleteUser(user);
            userService.SaveUser();
            return RedirectToAction("Index");
        }
    }
}
