using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodAdvisor.Common.EntityValidationConstants.Place;

namespace FoodAdvisor.Data.Models
{
    public class Place
    {
        [Key]
        [Comment("The Unique Identifier of the Place.")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("The Name of the Place.")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        [Comment("The Description of the Place.")]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLenght)]
        [Comment("The Address of the Place.")]
        public string Address { get; set; } = null!;

        [MaxLength(URLMaxLEnght)]
        [Comment("An Image Url of the Place.")]
        public string? ImageURL { get; set; }

        [Required]
        [Comment("The City Id.")]
        public Guid CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City City { get; set; } = null!;

        [Required]
        [Comment("The Publisher Id.")]
        public Guid PublisherId { get; set; } 

        [ForeignKey(nameof(PublisherId))]
        public ApplicationUser Publisher { get; set; } = null!;

        [Required]
        [Comment("The Category Id.")]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}
