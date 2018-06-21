using API.Framework;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Core.Entities;
using AutoMapper;
using FluentValidation;

namespace API.Models.Vendors
{
    #region Model
    public class VendorModel
    {
        /// <summary>
        /// Vendor indentity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Vendor name
        /// </summary>
        public string Name { get; set; }

    }
    /// <summary>
    /// Vendor list model 
    /// </summary>
    public class VendorListModel : ApiJsonResult
    {
        /// <summary>
        /// default contructor
        /// </summary>
        public VendorListModel()
        {
            VendorList = new List<VendorModel>();
        }
        public List<VendorModel> VendorList { get; set; }
       
    }
    /// <summary>
    /// Vendor detail model
    /// </summary>
    public class VendorDetailModel: ApiJsonResult
    {/// <summary>
    /// Vendor indentity
    /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// vendor Name
        /// </summary>
        public string  Name { get; set; }
    }
    [Validator(typeof(VendorEditModel))]
    public class VendorEditModel
    {
        /// <summary>
        /// Vendor indentity
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
    }
    #endregion
    #region Mapping


    /// <summary>
    /// Implement Vendor Map
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
            config.CreateMap<Vendor, VendorModel>();
            config.CreateMap<Vendor, VendorDetailModel>();
            config.CreateMap<Vendor, VendorEditModel>();
            config.CreateMap<VendorEditModel, Vendor>();
        }
    }


    #endregion
    #region Validators

    /// <summary>
    /// Validate for VendorEditModel
    /// </summary>
    public class VendorEditValidator : AbstractValidator<VendorEditModel>
    {
        /// <summary>
        /// Define validators here
        /// </summary>
        public VendorEditValidator()
        {

        }
    }

    #endregion

}