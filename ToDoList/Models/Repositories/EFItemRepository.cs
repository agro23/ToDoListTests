﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class EFItemRepository : IItemRepository
    {

        ToDoListDbContext db;
        public EFItemRepository()
        {
            db = new ToDoListDbContext();
        }
        public EFItemRepository(ToDoListDbContext thisDb)
        {
            db = thisDb;
        }

        //ToDoListDbContext db = new ToDoListDbContext();

        public IQueryable<Item> Items
        { get { return db.Items; } }

        public Item Save(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return item;
        }

        public Item Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }

        public void Remove(Item item)
        {
            db.Items.Remove(item);
            db.SaveChanges();
        }



    }
}
