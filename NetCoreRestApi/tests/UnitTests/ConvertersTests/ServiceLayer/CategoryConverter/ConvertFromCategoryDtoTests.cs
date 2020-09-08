﻿using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ConvertersTests.ServiceLayer.CategoryConverter
{
    [TestClass]    
    public class ConvertFromCategoryDtoTests
    {
        CategoryServiceConverter converter;
        CategoryModel categoryModel;
        List<CategoryModel> categoryModels;

        [TestInitialize]
        public void TestInitialize()
        {
            converter = new CategoryServiceConverter();

            categoryModel = new CategoryModel()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };

            categoryModels = new List<CategoryModel>()
            {
                categoryModel,
                new CategoryModel()
                {
                     Id = 0,
                     Name = "",
                     Description = null,
                }
            };
        }
        
        [TestMethod]         
        public void CorrectClassTypeConvertedToDto()
        {
            // Arrange

            // Act
            var actualCategoryDto = converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.IsInstanceOfType(actualCategoryDto, typeof(CategoryDto));           
        }

        [TestMethod]        
        public void ConvertToDtoIsNotNull()
        {
            // Arrange 

            // Act
            var actualCategoryDto = converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.IsNotNull(actualCategoryDto);
        }

        [TestMethod]
        [Description("Is Id property value converted correct")]
        [DataRow(1)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertToDtoIdPropertyValueIsSameId(int expectedId)
        {
            // Arrange 
            categoryModel.Id = expectedId;

            // Act
            var actualCategoryDto = converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.AreEqual(expectedId, actualCategoryDto.Id);
        }

        [TestMethod]
        [Description("Is name property value converted correct")]
        [DataRow("Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToDtoNamePropertyValueIsSameName(string expectedName)
        {
            // Arrange 
            categoryModel.Name = expectedName;

            // Act
            var actualCategoryDto = converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.AreEqual(expectedName, actualCategoryDto.Name);
        }

        [TestMethod]
        [Description("Is Description property value converted correct")]
        [DataRow("Description 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToDtoDescriptionPropertyValueIsSameDescription(string expectedDescription)
        {
            // Arrange 
            categoryModel.Description = expectedDescription;

            // Act
            var actualCategoryDto = converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.AreEqual(expectedDescription, actualCategoryDto.Description);
        }

        [TestMethod]
        public void CorrectClassTypeConvertedToDtoCollection()
        {
            // Arrange             

            // Act
            var actualCategoryDtos = converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.IsInstanceOfType(actualCategoryDtos, typeof(IEnumerable<CategoryDto>));
        }

        [TestMethod]
        public void CorrectAllItemsTypesConvertedToDtoCollection()
        {
            // Arrange             

            // Act
            var actualCategoryDtos = converter.ConvertFrom(categoryModels);

            // Assert            
            CollectionAssert.AllItemsAreInstancesOfType(actualCategoryDtos.ToList(), typeof(CategoryDto));
        }

        [TestMethod]
        public void ConvertToDtoCollectionIsNotNull()
        {
            // Arrange             

            // Act
            var actualCategoryDtos = converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.IsNotNull(actualCategoryDtos);
        }

        [TestMethod]
        public void ConvertToDtoCollectionAllItemsAreNotNull()
        {
            // Arrange             

            // Act
            var actualCategoryDtos = converter.ConvertFrom(categoryModels);

            // Assert            
            CollectionAssert.AllItemsAreNotNull(actualCategoryDtos.ToList());
        }

        [TestMethod]
        [Description("Is Id property value converted correct")]
        [DataRow(7)]
        [DataRow(0)]
        [DataRow(-5)]
        public void ConvertToDtoIdPropertyValueInCollectionIsSameId(int expectedId)
        {
            // Arrange 
            categoryModels.Last().Id = expectedId;

            // Act
            var actualCategoryDtos = converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.AreEqual(expectedId, actualCategoryDtos.Last().Id);
        }

        [TestMethod]
        [Description("Is name property value converted correct")]
        [DataRow("Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToDtoNamePropertyValueInCollectionIsSameName(string expectedName)
        {
            // Arrange 
            categoryModels.First().Name = expectedName;

            // Act
            var actualCategoryDtos = converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.AreEqual(expectedName, actualCategoryDtos.First().Name);
        }

        [TestMethod]
        [Description("Is Description property value converted correct")]
        [DataRow("Description 1 !@~#$%^&*()_+=-\\||'\"?/.><,")]
        [DataRow(null)]
        [DataRow("")]
        public void ConvertToDtoDescriptionPropertyValueInCollectionIsSameDescription(string expectedDescription)
        {
            // Arrange 
            categoryModels.Last().Description = expectedDescription;

            // Act
            var actualCategoryDtos = converter.ConvertFrom(categoryModels);

            // Assert            
            Assert.AreEqual(expectedDescription, actualCategoryDtos.Last().Description);
        }
    }
}