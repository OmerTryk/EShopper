﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopper.Shipping.DataAccessLayer.Abstract;
using EShopper.Shipping.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace EShopper.Shipping.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var values = await _context.Set<T>().FindAsync(id);
            if (values != null) _context.Set<T>().Remove(values);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var values = await _context.Set<T>().FindAsync(id);
            return values;
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
