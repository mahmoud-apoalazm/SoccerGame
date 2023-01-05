using Entities.Constants;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration;

public class PlayerConfiguration :IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasData
        (
        new Player
        {
            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
            Name= "Hussein El Shahat",
            Age = 20,
            Foot=Foot.Right,
            Number= 11,
            Position=Position.CF,
            TeamId= new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
        },
        new Player
        {
             Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb51a"),
             Name = "Mohamed Apo Treka",
             Age = 30,
             Foot = Foot.Both,
             Number = 22,
             Position = Position.CF,
             TeamId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
        },
        new Player
        {
            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
            Name = "Mohamed Awad",
            Age = 26,
            Foot = Foot.Right,
            Number = 1,
            Position = Position.GK,
            TeamId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
        }
        );
    }
}
