using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSCoreBAL.POSHostModels
{
    public enum ObjectFlags 
    {
        /// <summary>
        /// Is Object Taxed?
        /// </summary>
        Taxed = 0x01,
        /// <summary>
        /// Is this Object a Service Charge?
        /// </summary>
        ServiceCharge = 0x02,
        /// <summary>
        /// Is Object a Gratuity?
        /// </summary>
        Gratuity = 0x04,
        /// <summary>
        /// Is Object discounted?
        /// </summary>
        Discounted = 0x08,
        /// <summary>
        /// Is Object a modification?
        /// </summary>
        ObjectModified = 0x10,
        /// <summary>
        /// Object is exempt from Gratuity, or calculation is performed Pre-Gratuity otherwise it's Post-Gratuity
        /// </summary>
        /// <remarks>
        /// This flag will cause the object to not factor into Gratuity calculations
        /// </remarks>
        GratuityExempt = 0x20,
        /// <summary>
        /// Object is exempt from Tax, or calculation is performed Pre-Tax otherwise it's Post-Tax
        /// </summary>
        TaxExempt = 0x40,
        /// <summary>
        /// Object is exempt from Discounts, or calculation is performed Pre-Discount otherwise it's Post-Discount
        /// </summary>
        /// <remarks>
        /// This flag will trump the Discounted flag in calculations
        /// </remarks>
        DiscountExempt = 0x80,
        /// <summary>
        /// Object is exempt from Service Charges, or calculation is performed Pre-Service Charge otherwise it's Post-Service Charge
        /// </summary>
        ServiceChargeExempt = 0x100,
        /// <summary>
        /// Object calculation is performed Pre-Tax otherwise it's Post-Tax
        /// </summary>
        IsAppliedPreTax = 0x200,
        /// <summary>
        /// Object calculation is performed Pre-Discount otherwise it's Post-Discount
        /// </summary>
        IsAppliedPreDiscount = 0x400,
        /// <summary>
        /// Tax is a hidden tax
        /// </summary>
        InclusiveTax = 0x800,
        /// <summary>
        /// Exclude inclusive tax from amount calc
        /// </summary>
        ExcludeInclusiveTax = 0x1000,
        /// <summary>
        /// Discount calculation is accumlated otherwise it's done on original price
        /// </summary>
        IsAccumlatedDiscount = 0x2000,
    }
}
