using System.ComponentModel.DataAnnotations;

namespace DOMAIN.model;
public class GenericModel
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;
}