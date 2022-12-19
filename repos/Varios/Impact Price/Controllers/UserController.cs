using Impact_Price.Data;
using Impact_Price.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace  Impact_Price.Controllers
{
    public class UserController : Controller
    {
        private readonly takeawayContext _context;
        public UserController(takeawayContext context)
        {
            _context = context;
        }
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 10;
            if (pg < 1)
                pg = 1;
            int recsCount = _context.TbUsers.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recsKip = (pg - 1) * pageSize;
            List<TbUser> users = _context.TbUsers.Skip(recsKip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(users);

        }
        public IActionResult Details(int id)
        {
            TbUser _user = _context.TbUsers.Where(u => u.IdUser == id).FirstOrDefault();
            return View(_user);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            TbUser _user = _context.TbUsers.Where(u => u.IdUser == id).FirstOrDefault();
            return View(_user);
        }
        [HttpPost]
        public IActionResult Edit(TbUser user)
        {
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            TbUser _user = _context.TbUsers.Where(u => u.IdUser == id).FirstOrDefault();
            return View(_user);
        }
        [HttpPost]
        public IActionResult Delete(TbUser user)
        {
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(TbUser user)
        {
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string senha)
        {
            TbUser _user = _context.TbUsers.Where(u => u.Login == username && u.Senha == senha).FirstOrDefault();
            if (_user == null)
            {
                ViewBag.Message = "Username ou Senha errado!";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Login efetuado com sucesso!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }

}
