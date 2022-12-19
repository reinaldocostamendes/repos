using Impact_Price.Data;
using Impact_Price.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Impact_Price.Controllers
{
    public class TipoServicoController : Controller
    {
        private readonly takeawayContext _context;
        public TipoServicoController(takeawayContext context)
        {
            _context = context;
        }
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 10;
            if (pg < 1)
                pg = 1;
            int recsCount = _context.TbTipoServicos.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recsKip = (pg - 1) * pageSize;
            List<TbTipoServico> tipoServicos = _context.TbTipoServicos.Skip(recsKip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(tipoServicos);

        }
        public IActionResult Details(int id)
        {
            TbTipoServico tipoServico = _context.TbTipoServicos.Where(ts => ts.IdTipo == id).FirstOrDefault();
            return View(tipoServico);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            TbTipoServico tipoServico = _context.TbTipoServicos.Where(ts => ts.IdTipo == id).FirstOrDefault();
            return View(tipoServico);
        }
        [HttpPost]
        public IActionResult Edit(TbTipoServico tipoServico)
        {
            _context.Attach(tipoServico);
            _context.Entry(tipoServico).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            TbTipoServico tipoServico = _context.TbTipoServicos.Where(ts => ts.IdTipo == id).FirstOrDefault();
            return View(tipoServico);
        }
        [HttpPost]
        public IActionResult Delete(TbTipoServico tipoServico)
        {
            _context.Attach(tipoServico);
            _context.Entry(tipoServico).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(TbTipoServico tipoServico)
        {
            _context.Attach(tipoServico);
            _context.Entry(tipoServico).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}