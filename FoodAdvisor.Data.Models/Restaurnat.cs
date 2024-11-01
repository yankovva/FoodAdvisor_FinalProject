﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodAdvisor.Common.EntityValidationConstants.Restaurant;

namespace FoodAdvisor.Data.Models
{
    public class Restaurant
    {
        [Key]
        [Comment("The Unique Identifier of the Restaurant.")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(NameMaxLenght)]
        [Comment("The Name of the Restaurant.")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        [Comment("The Description of the Restaurant.")]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLenght)]
        [Comment("The Address of the Restaurant.")]
        public string Address { get; set; } = null!;

        [MaxLength(URLMaxLEnght)]
        [Comment("An Image Url of the Restaurant.")]
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

        [Comment("Shows wether the restaurant is deleted or not")]
        public bool IsDeleted { get; set; } = false;
    }
}
