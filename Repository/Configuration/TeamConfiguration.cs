﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.Models;
using Entities.Constants;

namespace Repository.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData
            (
            new Team
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name="Alahly",
                Color=Color.Red,
                Country= "EGY"

            },
            new Team
            {
                Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                Name = "ALZamalek",
                Color = Color.White,
                Country = "EGY"
            }
            );
        }
    }
}
