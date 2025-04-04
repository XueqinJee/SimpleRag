﻿using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {
        }


        public DbSet<Knowledge> Knowledge { get; set; }
        public DbSet<KnowledgeInfo> KnowledgeInfo { get; set; }
        public DbSet<ChatModel> ChatModel { get; set; }
    }
}
