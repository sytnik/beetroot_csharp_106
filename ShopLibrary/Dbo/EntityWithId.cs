using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopLibrary.Dbo;

public class EntityWithId
{
    // public EntityWithId(int id) => Id = id;

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
}