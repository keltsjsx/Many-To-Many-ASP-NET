using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieHolic.Interfaces;
using MovieHolic.Models;
using MovieHolic.ViewModels.PostViewModels;

namespace MovieHolic.Controllers;

public class PostController : Controller
{
     private readonly IUnitOfWork _unitOfWork;
     private IMapper _mapper;

    public PostController(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var model = _unitOfWork.Post.GetAll();
        var vm = _mapper.Map<List<PostViewModel>>(model);
        return View(vm);
    }

    public IActionResult Details(int id)
    {
        var model = _unitOfWork.Post.Details(id);
        return View(model);
    }

    public IActionResult Create()
    {
        var tagsFromRepository = _unitOfWork.Tag.GetAll();
        var selectList = new List<SelectListItem>();
        foreach(var item in tagsFromRepository)
        {
            selectList.Add(new SelectListItem(item.Title, item.Id.ToString()));
        }
        var vm = new CreatePostViewModel()
        {
            Tags = selectList
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreatePostViewModel vm)
    {
        try {
            Post post = new Post()
            {
                Title = vm.Title,
                Description = vm.Description
            };
            foreach(var item in vm.SelectedTags)
            {
                post.PostTags.Add(new PostTag()
                {
                    TagId = int.Parse(item)
                });
            }
            _unitOfWork.Post.Insert(post);
             _unitOfWork.Save();

             return RedirectToAction("Index");
        } catch {
            return View();
        }
    }

    public IActionResult Edit(int id)
    {
        var posts = _unitOfWork.Post.GetById(id);
        var tags = _unitOfWork.Tag.GetAll();
        var selectedTags = posts.PostTags.Select(x => new Tag()
        {
           Id = x.Tag.Id,
           Title = x.Tag.Title, 
        });

        var selectList = new List<SelectListItem>();
        tags.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.Id.ToString(), selectedTags.Select(x => x.Id).Contains(i.Id))));
        var vm = new EditPostViewModel(){
            Id = posts.Id,
            Title  = posts.Title,
            Description = posts.Description,
            Tags = selectList
        };
        
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(EditPostViewModel vm)
    {
        try {
            var post = _unitOfWork.Post.GetById(vm.Id);
            post.Title = vm.Title;
            post.Description = vm.Description;
            var selectedTags  = vm.SelectedTags;
            var existingTags = post.PostTags.Select(x => x.TagId.ToString()).ToList();

            var toAdd = selectedTags.Except(existingTags).ToList();
            var toRemove = existingTags.Except(selectedTags).ToList();

            post.PostTags = post.PostTags.Where(x => !toRemove.Contains(x.TagId.ToString())).ToList();
            foreach(var item in toAdd)
            {
                post.PostTags.Add(new PostTag()
                {
                    TagId = int.Parse(item),
                    PostId = post.Id
                });
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        } catch {
            return View();
        }
    }

    public IActionResult Delete(int id)
    {
        var post = _unitOfWork.Post.GetById(id);
        var vm = _mapper.Map<PostViewModel>(post);

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(PostViewModel vm)
    {
       try {
           var post = _mapper.Map<Post>(vm);
           _unitOfWork.Post.Delete(post);
           _unitOfWork.Save();
           return RedirectToAction("Index");
       } catch {
           return View();
       }
    }
}