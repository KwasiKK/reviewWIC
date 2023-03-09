using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace restReview.Models
{
    public class RestaurantClassificationsViewModel
    {
        public int ID { get; set; }
        [DisplayName("Classification Name")]
        public string ClassificationName { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
