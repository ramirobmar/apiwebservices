using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using WebApi.Strings;

namespace WebApi.Models
{
    public class ShippingMethod
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string EstimatedTime { get; set; }

        public double Cost { get; set; }
    }
}