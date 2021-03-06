//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaVendas.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Tb_Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tb_Usuario()
        {
            this.Tb_Empresa = new HashSet<Tb_Empresa>();
            this.Tb_Vendas = new HashSet<Tb_Vendas>();
        }
    
        public long IdUsuario { get; set; }
        [Required(ErrorMessage="Nome ? obrigat?rio!")]
        public string Nome { get; set; }
        [Required(ErrorMessage="CPF ? obrigat?rio!")]
        [MinLength(14, ErrorMessage="CPF ? obrigat?rio, ele deve conter pontua??o!")]
        public string Cpf { get; set; }
        [Required(ErrorMessage="Telefone ? obrigat?rio!")]
        public string Telefone { get; set; }
        [Required(ErrorMessage="Login ? obrigat?rio!")]
        public string DesLogin { get; set; }
        [Required(ErrorMessage="Senha ? obrigat?rio!")]
        public string Senha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Empresa> Tb_Empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tb_Vendas> Tb_Vendas { get; set; }
    }
}
