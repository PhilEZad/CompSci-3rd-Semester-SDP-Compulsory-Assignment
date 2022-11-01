using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class BoxRepository : IBoxRepository
{
    private BoxDBContext _dbContext;
    
    public BoxRepository(BoxDBContext context)
    {
        _dbContext = context;
    }
    
    public List<Box> GetAllBoxes()
    {
        return _dbContext.BoxTable.ToList();
    }

    public Box CreateNewBox(Box box)
    {
        _dbContext.BoxTable.Add(box);
        _dbContext.SaveChanges();
        return box;
    }

    public Box UpdateBox(int id, Box box)
    {
        _dbContext.BoxTable.Update(box);
        _dbContext.SaveChanges();
        return box;
    }

    public Box DeleteBox(int id)
    {
        var box = _dbContext.BoxTable.Find(id);
        _dbContext.BoxTable.Remove(box);
        _dbContext.SaveChanges();
        return box;
    }

    public void BuildDb()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }
}