//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YellowPagesDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.Pictures = new HashSet<Picture>();
        }
    
        public long ID { get; set; }
        public string ItemName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Nullable<int> Order { get; set; }
        public string isBanner { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string FacebookLink { get; set; }
        public string InstagramLink { get; set; }
        public string OtherLinks { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public string Keywords { get; set; }
        public long CategoryID { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
