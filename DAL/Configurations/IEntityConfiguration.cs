﻿using Microsoft.EntityFrameworkCore;

namespace DAL.Configurations
{
    public interface IEntityConfiguration
    {
        void OnModelCreating(ModelBuilder modelBuilder);
    }
}
