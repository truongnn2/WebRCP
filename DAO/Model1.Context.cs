﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RCPEntities : DbContext
    {
        public RCPEntities()
            : base("name=RCPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AboutU> AboutUs { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BoxAd> BoxAds { get; set; }
        public virtual DbSet<CatService> CatServices { get; set; }
        public virtual DbSet<CatSubService> CatSubServices { get; set; }
        public virtual DbSet<Contactu> Contactus { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employment> Employments { get; set; }
        public virtual DbSet<GalleryImage> GalleryImages { get; set; }
        public virtual DbSet<Giamgia> Giamgias { get; set; }
        public virtual DbSet<GioiThieu> GioiThieux { get; set; }
        public virtual DbSet<LinkWebsite> LinkWebsites { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuSub> MenuSubs { get; set; }
        public virtual DbSet<MenuSubSub> MenuSubSubs { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Solution> Solutions { get; set; }
        public virtual DbSet<SupportOnline> SupportOnlines { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
    }
}
