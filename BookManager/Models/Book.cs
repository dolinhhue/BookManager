namespace BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int ID { get; set; }

        [StringLength(255)]
        [DisplayName("Tiêu đề")]
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [StringLength(255)]
        [Required]
        [DisplayName("Nội dung")]
        public string Description { get; set; }

        [StringLength(255)]
        [DisplayName("Tác giả")]
        [Required]
        [MaxLength(30)]
        public string Author { get; set; }

        [StringLength(255)]
        [DisplayName("Hình ảnh")]
        [Required]
        public string Images { get; set; }

        [DisplayName("Giá sách")]
        [Required]
        [Range(1000, 1000000)]
        public int? Price { get; set; }
    }
}
