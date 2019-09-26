using DynamicObjects.Models.Referral;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicObjects.Models.Context
{
    public class HMSContextTenantKTH:DbContext
    {
        public DbSet<Service1ReferralViewModel> Service1Referrals { get; set; }
        public DbSet<Service2ReferralViewModel> Service2Referrals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=NexawoKTH;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
    }
    public class HMSContextTenantLRH : DbContext
    {
        public DbSet<Service1ReferralViewModel> Service1Referrals { get; set; }
        public DbSet<Service2ReferralViewModel> Service2Referrals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=NexawoLRH;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
    }
}
