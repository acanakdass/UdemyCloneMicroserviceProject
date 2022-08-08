using AutoMapper;
using FreeCourse.Services.Catalog.DTOs;
using FreeCourse.Services.Catalog.Helpers.AppSettingsAccessHelper;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Services.Abstract;
using MongoDB.Driver;
using UdemyClone.Shared.Constants;
using UdemyClone.Shared.Results.Abstract;
using UdemyClone.Shared.Results.Concrete;
using IResult = UdemyClone.Shared.Results.Abstract.IResult;

namespace FreeCourse.Services.Catalog.Services.Concrete;

public class CategoryService:ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;
    private readonly IDatabaseSettings _databaseSettings;

    public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.ConnectionString);
        var db = mongoClient.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = db.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
        _databaseSettings = databaseSettings;
    }

    public async Task<IDataResult<List<Category>>> GetAllAsync()
    {
        var categories = await _categoryCollection.Find(_ => true).ToListAsync();
        return new SuccessDataResult<List<Category>>(categories, ResponseMessages.Listed("Categories"));
    }

    public async Task<IDataResult<Category>> GetByIdAsync(string id)
    {
        var category = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        if (category == null)
            return new ErrorDataResult<Category>(null, ResponseMessages.NotFound("Category"));
        return new SuccessDataResult<Category>(category, ResponseMessages.Listed("Category"));

    }

    public async Task<IResult> AddAsync(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryCollection.InsertOneAsync(category);
        return new SuccessResult(ResponseMessages.Added("Category"));
    }
}