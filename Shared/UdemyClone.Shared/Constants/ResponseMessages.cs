namespace UdemyClone.Shared.Constants;

public static class ResponseMessages
{
    public const string ImageSaved = "The image saved succesfully";
    public static string Added(string fieldName) => $"{fieldName} added successfully";
    public static string FailedAdd(string fieldName) => $"An error occured while adding {fieldName} ";
    public static string Listed(string fieldName) => $"{fieldName} listed successfully";
    public static string Updated(string fieldName) => $"{fieldName} updated successfully.";
    public static string FailedUpdate(string fieldName) => $"An error occured while updating {fieldName}";
    public static string Deleted(string fieldName) => $"{fieldName} deleted successfully.";
    public static string FailedDelete(string fieldName) => $"An error occured while deleting {fieldName}";
    public static string NotFound(string fieldName) => $"{fieldName} not found";
    public static string AuthorizationFailed() => $"Authorization failed for action";
    public static string UserRegisteredSuccessfully() => $"Registered Successfully";
}