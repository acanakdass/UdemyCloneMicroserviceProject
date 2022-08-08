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

public class CourseService : ICourseService
{
    private readonly IMongoCollection<Course> _courseCollection;
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;
    private readonly IDatabaseSettings _databaseSettings;

    public CourseService(IMapper mapper, IDatabaseSettings databaseSettings,
        IMongoCollection<Category> categoryCollection)
    {
        var mongoClient = new MongoClient(databaseSettings.ConnectionString);
        var db = mongoClient.GetDatabase(databaseSettings.DatabaseName);
        _courseCollection = db.GetCollection<Course>(databaseSettings.CourseCollectionName);
        _mapper = mapper;
        _databaseSettings = databaseSettings;
        _categoryCollection = db.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        ;
    }

    public async Task<IDataResult<List<Course>>> GetAllAsync()
    {
        var courses = await _courseCollection.Find(_ => true).ToListAsync();
        if (courses.Any())
        {
            foreach (var course in courses)
            {
                course.Category = await _categoryCollection.Find(x => x.Id == course.CategoryId).FirstOrDefaultAsync();
            }
            return new SuccessDataResult<List<Course>>(courses, ResponseMessages.Listed("Courses"));
        }

        return new SuccessDataResult<List<Course>>(null, ResponseMessages.Listed("Courses"));
    }

    public async Task<IDataResult<Course>> GetByIdAsync(string id)
    {
        var course = await _courseCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        if (course == null)
            return new ErrorDataResult<Course>(null, ResponseMessages.NotFound("Course"));
        return new SuccessDataResult<Course>(course, ResponseMessages.Listed("Course"));
    }

    public async Task<IResult> AddAsync(CourseCreateDto courseCreateDto)
    {
        var course = _mapper.Map<Course>(courseCreateDto);
        await _courseCollection.InsertOneAsync(course);
        return new SuccessResult(ResponseMessages.Added("Course"));
    }
}