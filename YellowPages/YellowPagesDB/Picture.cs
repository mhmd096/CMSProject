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
    
    public partial class Picture
    {
        public long ID { get; set; }
        public string Picturelink { get; set; }
        public bool isMain { get; set; }
        public string ThumbLink { get; set; }
        public bool Active { get; set; }
        public Nullable<int> Order { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public long ItemID { get; set; }
    
        public virtual Item Item { get; set; }
    }
}