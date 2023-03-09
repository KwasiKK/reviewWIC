using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using restReview.Models.DBEntities;

namespace reviewWIC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string IDNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string CellNumber { get; set; }
    public string Address { get; set; }
    public string Province { get; set; }
    public bool CurrentlyEmployed { get; set; }
    // public List<RestaurantClassification> PreferredClassificationIds { get; set; }
}

