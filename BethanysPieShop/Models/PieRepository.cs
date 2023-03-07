﻿using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models;

public class PieRepository : IPieRepository
{
    private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

    public PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
    {
        _bethanysPieShopDbContext = bethanysPieShopDbContext;
    }

    public IEnumerable<Pie> AllPies => _bethanysPieShopDbContext.Pies.Include(p => p.Category);

    public IEnumerable<Pie> PiesOfTheWeek => _bethanysPieShopDbContext.Pies.Include(p => p.Category).Where(p => p.IsPieOfTheWeek == true);

    public Pie? GetPieById(int id) => _bethanysPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == id);
}
