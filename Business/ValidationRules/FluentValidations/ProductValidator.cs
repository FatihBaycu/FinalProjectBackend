﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //RuleFor(p => p.ProductName).NotEmpty();
           // RuleFor(p => p.ProductName).MinimumLength(2);

            //RuleFor(p => p.UnitPrice).NotEmpty();
           // RuleFor(p => p.UnitPrice).GreaterThan(0);
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA);
            RuleFor(p => p.ProductName.StartsWith("A"));
            

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
