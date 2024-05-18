﻿using codePulse.API.Models.Domain;

namespace codePulse.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync(string? query = null, string? sortBy = null, string? sortDirection = null, int? pageNumberv = 1, int? pageSize = 100);
        Task<Category?> GetById(Guid id);
        Task<Category?> UpdateAsync(Category category);
        Task<Category?> DeleteAsync(Guid id);
    }
}
