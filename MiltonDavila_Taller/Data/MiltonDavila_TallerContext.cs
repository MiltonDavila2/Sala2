using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiltonDavila_Taller.Models;

namespace MiltonDavila_Taller.Data
{
    public class MiltonDavila_TallerContext : DbContext
    {
        public MiltonDavila_TallerContext (DbContextOptions<MiltonDavila_TallerContext> options)
            : base(options)
        {
        }

        public DbSet<MiltonDavila_Taller.Models.EstudianteUDLA> EstudianteUDLA { get; set; } = default!;
    }
}
