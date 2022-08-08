using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Services.Catalog.Models;

public class Feature
{
    public int Duration { get; set; }
    public bool IsDownloadable { get; set; }
}