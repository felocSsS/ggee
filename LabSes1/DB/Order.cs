//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabSes1.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public Nullable<int> IdLaboratoryWorker { get; set; }
        public Nullable<int> IdPatient { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> IdService { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}
