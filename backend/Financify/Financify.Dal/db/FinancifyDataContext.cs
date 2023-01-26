﻿using Microsoft.EntityFrameworkCore;

namespace Financify.Dal.db;

/// <summary>
///     Database context for Financify
/// </summary>
public class FinancifyDataContext : DbContext
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="options">The options for the context</param>
    public FinancifyDataContext(DbContextOptions<FinancifyDataContext> options) : base(options)
    {
    }
}