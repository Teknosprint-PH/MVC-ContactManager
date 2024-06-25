using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace tech_challenge.Models
{
    [Table("tbl_contacts")]
    public class Contact_Info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("contact_id")]
        [DisplayName("Contact Id")]
        public int? contact_id { get; set; }

        [Required]
        [Column("contact_lastname")]
        [DisplayName("Last Name")]
        [MaxLength(50)]
        public string? contact_lastname { get; set; }

        [Required]
        [Column("contact_firstname")]
        [DisplayName("First Name")]
        [MaxLength(50)]
        public string? contact_firstname { get; set; }

        [Required]
        [Column("contact_middlename")]
        [DisplayName("Middle Name")]
        [MaxLength(50)]
        public string? contact_middlename { get; set; }

        [Required]
        [Column("contact_address")]
        [DisplayName("Address")]
        [MaxLength(150)]
        public string? contact_address { get; set; }

        [Column("contact_no")]
        [DisplayName("Contact Number")]
        [MaxLength(20)]
        public string? contact_no { get; set; }

        [Required]
        [Column("contact_status")]
        [DisplayName("Status")]
        [MaxLength(2)]
        public string? contact_status { get; set; }

        [Required]
        [Column("created_by")]
        [DisplayName("Created By")]
        [MaxLength(15)]
        public string? created_by { get; set; }

        [Required]
        [Column("created_dt")]
        [DisplayName("Created Date")]
        public DateTime? created_dt { get; set; }

        [Column("updated_by")]
        [DisplayName("Updated By")]
        [MaxLength(15)]
        public string? updated_by { get; set; }

        [Column("updated_dt")]
        [DisplayName("Updated Date")]
        public DateTime? updated_dt { get; set; }
    }
}
