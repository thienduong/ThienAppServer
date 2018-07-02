using API.Core.Entities;
using API.Framework;
using AutoMapper;
using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    #region Models

    /// <summary>
    /// Product item model
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Product identity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Category Id
        /// </summary>
        public int CategoryId { get; set; }
    }

    /// <summary>
    /// Product list model
    /// </summary>
    public class ProductListModel : ApiJsonResult
    {
        /// <summary>
        /// Default contructor
        /// </summary>
        public ProductListModel()
        {
            ProductList = new List<ProductModel>();
        }
        /// <summary>
        /// List of user roles
        /// </summary>
        public List<ProductModel> ProductList { get; set; }
    }

    /// <summary>
    /// Product detail model
    /// </summary>
    public class ProductDetailModel : ApiJsonResult
    {
        /// <summary>
        /// Product identity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Category Id
        /// </summary>
        public int CategoryId { get; set; }
    }

    /// <summary>
    /// Product edit model
    /// </summary>
    [Validator(typeof(ProductEditValidator))]
    public class ProductEditModel
    {
        /// <summary>
        /// Product identity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Category Id
        /// </summary>
        public int CategoryId { get; set; }
    }

    #endregion

    #region Mappings

    /// <summary>
    /// Implement Product Map
    /// </summary>
    public class MapperRegistrar : IMapperRegistrar
    {
        public int Order
        {
            get
            {
                return 1;
            }
        }

        public void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Product, ProductModel>();
            config.CreateMap<Product, ProductDetailModel>();
            config.CreateMap<Product, ProductEditModel>();
            config.CreateMap<ProductEditModel, Product>();
        }
    }

    #endregion

    #region Validators

    /// <summary>
    /// Validate for ProductEditModel
    /// </summary>
    public class ProductEditValidator : AbstractValidator<ProductEditModel>
    {
        /// <summary>
        /// Define validators here
        /// </summary>
        public ProductEditValidator()
        {

        }
    }

    #endregion
}