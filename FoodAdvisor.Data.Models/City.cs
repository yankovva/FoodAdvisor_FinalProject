using Microsoft.EntityFrameworkCore;
using static FoodAdvisor.Common.EntityValidationConstants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static FoodAdvisor.Common.EntityValidationConstants.City;

namespace FoodAdvisor.Data.Models
{
    public class City
    {
        [Key]
        [Comment("Unique Identifier for the city.")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("The name of the city.")]
        public string Name { get; set; } = null!;

        [Comment("A collection of the Places in the cities.")]
        public virtual ICollection<Place> Places { get; set; } = new List<Place>();

        [Comment("Identifier of the Country.")]

        [Required]
        public Guid CountryId { get; set; }

        [Required]
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; } = null!;
    }
}