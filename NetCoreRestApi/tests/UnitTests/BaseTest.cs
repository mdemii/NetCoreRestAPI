﻿using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.EF;
using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.EF.Repositories;
using DataLayer.interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks;
using DataLayer.UnitOfWorks.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System;

namespace UnitTests
{
    public abstract class BaseTest
    {
        public TestContext TestContext { get; set; }

        protected IServiceProvider ServiceProvider { get; set; }
        protected ServiceCollection Services { get; private set; }

        protected BaseTest()
        {
            InitializeBaseServices();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
        }

        protected void ConfigureServices()
        {
            ServiceProvider = Services.BuildServiceProvider();
        }

        private void InitializeBaseServices()
        {
            Services = new ServiceCollection();
            Services.AddTransient<IProductManager, ProductManager>()
                     .AddTransient<ICategoryManager, CategoryManager>()
                     .AddTransient<IConverter<ProductDto, ProductModel>, ProductServiceConverter>()
                     .AddTransient<IConverter<CategoryDto, CategoryModel>, CategoryServiceConverter>()
                     .AddTransient<IConverter<ProductEntity, ProductModel>, ProductModelConverter>()
                     .AddTransient<IConverter<CategoryEntity, CategoryModel>, CategoryModelConverter>()
                     .AddTransient<IProductUnitOfWork, ProductUnitOfWork>()
                     .AddTransient<ICategoryUnitOfWork, CategoryUnitOfWork>()
                     .AddTransient<IProductRepository, ProductRepository>()
                     .AddTransient<ICategoryRepository, CategoryRepository>()
                     .AddTransient<ITransactionManager, EfTransactionManagerMock>();
        }

        protected void InjectService<TInternalService>(TInternalService implementation) 
            where TInternalService : class
        {
            Services.AddTransient(serviceProvider => implementation);
        }
    }
}
