using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FoodAdvisor.Common.EntityValidationConstants.Category;

namespace FoodAdvisor.Data.Models
{
    public class Category
    {
        [Key]
        [Comment("The Unique Identifier of the Category.")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("The Name of the Category.")]
        public string Name { get; set; } = null!;

        [Comment("A Collection of Places with the same Category.")]
        public virtual ICollection<Place> Places { get; set; } = new List<Place>();
    }
}