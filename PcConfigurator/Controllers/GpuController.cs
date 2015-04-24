﻿using System.Web.Mvc;
using PcConfigurator.Models;
using PcConfigurator.Models.GpuModels;
using PcConfigurator.Service;

namespace PcConfigurator.Controllers
{
    public class GpuController : Controller
    {
        private readonly IGpuService _service;

        public GpuController(IGpuService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var model = new GpuIndexModel {GpuList = _service.GetAll()};
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(GpuAddModel model)
        {
            if (this.ModelState.IsValid)
            {
                var gpuToAdd = new GpuDto {Brand = model.Brand, GpuModel = model.GpuModel};
                _service.Insert(gpuToAdd);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new GpuAddModel();
            return View(model);
        }
    }
}