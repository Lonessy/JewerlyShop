//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JewerlyShop.ModelBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            this.Sales = new HashSet<Sales>();
        }
    
        public int Id { get; set; }
        public int IdProvider { get; set; }
        public int IdTypeProducts { get; set; }
        public int IdMaterial { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public int Proba { get; set; }
        public int PurchasePrice { get; set; }
        public int Price { get; set; }
        public string ImageProduct { get; set; }
        public decimal Size { get; set; }
        public int Volume { get; set; }
    
        public virtual Materials Materials { get; set; }
        public virtual Providers Providers { get; set; }
        public virtual TypeProducts TypeProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
