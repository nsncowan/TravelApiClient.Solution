using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;


namespace TravelApiClient.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string Text { get; set; }
    public string Author { get; set; }
    public int DestinationId { get; set; }
    public Destination Destination { get; set; }

    [Required]
    [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
    public int Rating { get; set; }


    public static void Post(Review review)
    {
      string jsonReview = JsonConvert.SerializeObject(review);
      ReviewApiHelper.Post(jsonReview);
    }

    public static void Put(Review review)
    {
      string jsonReview = JsonConvert.SerializeObject(review);
      ReviewApiHelper.Put(review.ReviewId, jsonReview);
    }

    public static void Delete(int id)
    {
      ReviewApiHelper.Delete(id);
    }

    public static Review GetDetails(int id)
    {
      var apiCallTask = ReviewApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Review review= JsonConvert.DeserializeObject<Review>(jsonResponse.ToString());

      return review;
    }

  }
}