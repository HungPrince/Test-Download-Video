namespace Test_DownloadVideo.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("VideoSteam")]
    public partial class VideoSteam
    {
        [Key]
        public int SrNo { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [Required]
        [StringLength(20)]
        public string FileType { get; set; }

        [Required]
        [StringLength(150)]
        public string Url { get; set; }
    }
}
