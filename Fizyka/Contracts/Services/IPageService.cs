using System;

namespace Fizyka.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);
}
