using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Infrastructure
{
    public interface IRepository<T>
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> Post(T entity);
        Task<IActionResult> Update(T entity);
        Task<IActionResult> Delete(int id);
    }
}
