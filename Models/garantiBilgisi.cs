//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public partial class garantiBilgisi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public garantiBilgisi()
        {
            this.Muzik1 = new HashSet<Muzik>();
        }
    
        public int garantiId { get; set; }
        public Nullable<int> aletId { get; set; }
        [Required(ErrorMessage = "Garanti süresini giriniz")]


        [DisplayName("Garanti Süresi")]
        public string garantiSüresi { get; set; }
        

        public virtual Muzik Muzik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Muzik> Muzik1 { get; set; }
    }
}