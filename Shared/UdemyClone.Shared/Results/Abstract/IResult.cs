using System;
namespace UdemyClone.Shared.Results.Abstract;

    public interface IResult
    {
        bool Success { get; }
        string Message { get; }

    }

