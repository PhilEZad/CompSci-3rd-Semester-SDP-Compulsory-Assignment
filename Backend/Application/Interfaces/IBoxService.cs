using Application.Validators;
using Domain;

namespace Application.Interfaces;

public interface IBoxService
{
    public List<Box> GetAllBoxes();
    public Box CreateNewBox(PostBoxDTO dto);
    public Box UpdateBox(int id, Box box);
    public Box DeleteBox(int id);
    public void BuildDb();
}