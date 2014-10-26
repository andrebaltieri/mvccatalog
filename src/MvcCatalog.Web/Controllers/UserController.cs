using MvcCatalog.Domain;
using MvcCatalog.Domain.Repositories;
using MvcCatalog.Web.Models;
using System;
using System.Web.Mvc;

namespace MvcCatalog.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult Index()
        {
            var users = _repository.Get();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EditorUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var user = new User(model.Name, model.Email, model.Username, model.Password);
                user.Register(model.Name, model.Email, model.Username, model.Password, model.ConfirmPassword);
                _repository.SaveOrUpdate(user);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DefaultErrorMessage", ex.Message);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return HttpNotFound();

            var user = _repository.Get(id);
            if (user == null)
                return HttpNotFound();

            return View(new EditorUserViewModel
            {
                ConfirmPassword = "",
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Password = "",
                Username = user.Username
            });
        }

        [HttpPost]
        public ActionResult Edit(EditorUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var user = _repository.Get(model.Id);
                user.UpdateInfo(model.Name, model.Email, model.Username, model.Password, model.ConfirmPassword);
                _repository.SaveOrUpdate(user);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DefaultErrorMessage", ex.Message);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_repository.Get(id));
        }

        public ActionResult Delete(int id)
        {
            return View(_repository.Get(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                _repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DefaultErrorMessage", ex.Message);
                return View(_repository.Get(id));
            }
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
    }
}