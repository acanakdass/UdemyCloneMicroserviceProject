using System;
namespace UdemyClone.Shared.Results.Abstract;
public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
