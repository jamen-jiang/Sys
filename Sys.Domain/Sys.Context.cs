﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sys.Domain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SysContext : DbContext
    {
        public SysContext()
            : base("name=SysContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Operate> Operate { get; set; }
        public virtual DbSet<Privilege> Privilege { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Role_User> Role_User { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
