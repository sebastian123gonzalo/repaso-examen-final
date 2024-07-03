using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace si730ebu202217239.inventory.Domain.Model.Aggregates;

public partial class ProductAudit : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}