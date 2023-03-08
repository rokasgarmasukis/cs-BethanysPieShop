using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class HomeController : Controller
{
    private readonly IPieRepository _pieRepository;

    public HomeController(IPieRepository ieRepository)
    {
        _pieRepository = ieRepository;
    }

    public IActionResult Index()
    {
        var piesOfTheWeek = _pieRepository.PiesOfTheWeek;
        var homeViewModel = new HomeViewModel(piesOfTheWeek);
        return View(homeViewModel);
    }
}
