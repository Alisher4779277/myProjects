//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Qabulxona.Models
{
    using System;
    
    public partial class expired10_ForIspol_Result
    {
        public long RequestId { get; set; }
        public Nullable<long> PersonId { get; set; }
        public string RequestSubject { get; set; }
        public string RequestShortText { get; set; }
        public string RequestText { get; set; }
        public string RequestFile { get; set; }
        public string RequestNumber { get; set; }
        public string RequestPassword { get; set; }
        public Nullable<int> RequestStatusId { get; set; }
        public Nullable<System.DateTime> InComeDate { get; set; }
        public Nullable<System.DateTime> ClosedDate { get; set; }
        public Nullable<System.DateTime> LastVisit { get; set; }
        public Nullable<System.DateTime> DaysToSolve { get; set; }
        public Nullable<int> UserId { get; set; }
        public string ispol { get; set; }
    }
}
