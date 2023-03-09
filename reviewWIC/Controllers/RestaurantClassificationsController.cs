using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using restReview.Models;
using restReview.Models.DBEntities;
using reviewWIC.Areas.Identity.Data;
using reviewWIC.Models;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace restReview.Controllers
{
    public class RestaurantClassificationsController : Controller
    {
        private readonly ApplicationDbContext context;

        public RestaurantClassificationsController(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        [Authorize(Policy = $"{Constants.Policies.RequireDataAdmin}")]
        [HttpGet]
        public IActionResult Index()
        {
            List<RestaurantClassification> restaurantClassifications = context.RestaurantClassifications.ToList();
            List<RestaurantClassificationsViewModel> restaurantClassificationsList = new List<RestaurantClassificationsViewModel>();

            if (restaurantClassifications != null)
            {
                foreach (var row in restaurantClassifications)
                {
                    var restaurantClassificationViewModel = new RestaurantClassificationsViewModel()
                    {
                        ID = row.ID,
                        ClassificationName = row.ClassificationName,
                        CreatedAt = DateTime.Now,
                    };
                    restaurantClassificationsList.Add(restaurantClassificationViewModel);
                }
            }
            return View(restaurantClassificationsList);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            var restaurantClassificationViewModel = new RestaurantClassificationsViewModel();
            return View(restaurantClassificationViewModel);
        }

        [HttpPost]
        public IActionResult Create(RestaurantClassificationsViewModel restaurantClassificationData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var restaurantClassification = new RestaurantClassification()
                    {
                        ClassificationName = restaurantClassificationData.ClassificationName,
                    };
                    context.RestaurantClassifications.Add(restaurantClassification);
                    context.SaveChanges();
                    TempData["successMessage"] = "Restaurant Classification created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Invalid model data.";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var restaurantClassification = context.RestaurantClassifications.SingleOrDefault(x => x.ID == Id);

                if (restaurantClassification != null)
                {
                    var restaurantClassificationViewModel = new RestaurantClassificationsViewModel()
                    {
                        ID = restaurantClassification.ID,
                        ClassificationName = restaurantClassification.ClassificationName,
                    };
                    return View(restaurantClassificationViewModel);
                }
                else
                {
                    TempData["errorMessage"] = $"Restaurant Classification not found for ID {Id}.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(RestaurantClassificationsViewModel restaurantClassificationData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var restaurantClassification = new RestaurantClassification()
                    {
                        ID = restaurantClassificationData.ID,
                        ClassificationName = restaurantClassificationData.ClassificationName,
                        UpdatedAt = DateTime.Now,
                    };
                    context.RestaurantClassifications.Update(restaurantClassification);
                    context.SaveChanges();
                    TempData["successMessage"] = "Restaurant Classification updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Invalid model data.";
                    return View();
                }
            }
            catch (Exception e)
            {
                TempData["errorMessage"] = e.Message;
                return View();
            }
        }
    }
}
