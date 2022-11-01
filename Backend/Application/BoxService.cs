using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application;

public class BoxService : IBoxService
{
    private IBoxRepository _boxRepository;
    private IMapper _mapper;
    private IValidator<PostBoxDTO> _postBoxValidator;
    private IValidator<Box> _boxValidator;
    
    public BoxService(IBoxRepository repository, IMapper mapper, IValidator<PostBoxDTO> postBoxValidator, IValidator<Box> boxValidator)
    {
        _boxRepository = repository;
        _mapper = mapper;
        _postBoxValidator = postBoxValidator;
        _boxValidator = boxValidator;
    }

    public List<Box> GetAllBoxes()
    {
        return _boxRepository.GetAllBoxes();
    }

    public Box CreateNewBox(PostBoxDTO dto)
    {
        var validation = _postBoxValidator.Validate(dto);
        
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
        return _boxRepository.CreateNewBox(_mapper.Map<Box>(dto));
    }

    public Box UpdateBox(int id, Box box)
    {
        if (id != box.Id)
            throw new ValidationException("IDs do not match");
        
        var validation = _boxValidator.Validate(box);
        
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
        return _boxRepository.UpdateBox(id, box);
    }
    
    public Box DeleteBox(int id)
    {
        return _boxRepository.DeleteBox(id);
    }

    public void BuildDb()
    {
            _boxRepository.BuildDb();
    }
}