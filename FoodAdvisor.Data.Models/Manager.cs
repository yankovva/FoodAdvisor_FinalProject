using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodAdvisor.Common.EntityValidationConstants.Manager;


namespace FoodAdvisor.Data.Models
{
	public class Manager
	{
		[Key]
        [Comment("The unique identifier of the manager.")]
        public Guid Id { get; set; } = Guid.NewGuid();

		[Required]
        [MaxLength(PhoneNumberMaxLenght)]
        [Comment("Work phone number of the manager.")]
        public string WorkPhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLenght)]
        [Comment("Address of the manager.")]
        public string Address { get; set; } = null!;

        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

		public virtual ICollection<Restaurant> AddedRestaurants { get; set; } = new List<Restaurant>();
	}
}
