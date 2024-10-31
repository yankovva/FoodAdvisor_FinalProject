using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FoodAdvisor.Common.EntityValidationConstants.Country;

namespace FoodAdvisor.Data.Models
{
    public class Country
    {

        [Key]
        [Comment("Identifier of the Country")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        [Comment("A collection of the Cities in the Country.")]
        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}
