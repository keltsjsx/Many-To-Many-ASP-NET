using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieHolic.Interfaces;
using MovieHolic.Models;
using MovieHolic.Repositories;
using MovieHolic.ViewModels.TagViewModels;

namespace MovieHolic.Controllers;

public class TagController : Controller
{
   private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public TagController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public IActionResult Index()
    {
        var model = _unitOfWork.Tag.GetAll();
        var vm = _mapper.Map<List<TagViewModel>>(model);
        return View(vm);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateTagViewModel vm)
    {
        try {
            var model = _mapper.Map<Tag>(vm);
            _unitOfWork.Tag.Insert(model);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Tag");
        } catch {
            return View();
        }
    }

    public IActionResult Details(int id)
    {
        var model = _unitOfWork.Tag.GetById(id);
        var vm = _mapper.Map<TagViewModel>(model);
        return View(vm);
    }

    public IActionResult Edit(int id)
    {
        var model = _unitOfWork.Tag.GetById(id);
        var vm = _mapper.Map<TagViewModel>(model);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(TagViewModel vm)
    {
        try {
            var model = _mapper.Map<Tag>(vm);
            _unitOfWork.Tag.Update(model);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Tag");
        } catch {
            return View();
        }
    }

    public IActionResult Delete(int id)
    {
        var model = _unitOfWork.Tag.GetById(id);
        var vm = _mapper.Map<TagViewModel>(model);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(TagViewModel vm)
    {
        try {
            var model = _mapper.Map<Tag>(vm);
            _unitOfWork.Tag.Delete(model);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        } catch {
            return View();
        }
    }
}