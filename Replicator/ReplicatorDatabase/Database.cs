using Global_Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorDatabase
{
    [ExcludeFromCodeCoverage]
    public class Dataset
    {
        public int ID { get; set; }
        public Code Code1 { get; set; }
        public int Value1 { get; set; }
        public Code Code2 { get; set; }
        public int Value2 { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class Dataset1 : Dataset { }
    public class Dataset2 : Dataset { }
    public class Dataset3 : Dataset { }
    public class Dataset4 : Dataset { }

    [ExcludeFromCodeCoverage]
    public class ReplicatorDbContext : DbContext
    {
        public DbSet<Dataset1> Dataset1 { get; set; }
        public DbSet<Dataset2> Dataset2 { get; set; }
        public DbSet<Dataset3> Dataset3 { get; set; }
        public DbSet<Dataset4> Dataset4 { get; set; }
    }

    [ExcludeFromCodeCoverage]
    class Database
    {
    }
}
