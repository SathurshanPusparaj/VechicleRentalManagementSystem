using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace vehiclerent.Models
{
    public class ContextClass:DbContext
    {
        public DbSet<Renter> renterC { set; get; }
        public DbSet<Vehicle> vehicleC { set; get; } 
        public DbSet<VehicleAvailability> vehicleAvailabilityC { set; get; }
        public DbSet<Tenant> tenantC { set; get; }
    }
}