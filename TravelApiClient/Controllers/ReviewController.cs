using Microsoft.AspNetCore.Mvc;
using TravelApiClient.Models;

namespace TravelApiClient.Controllers;

public class ReviewController : Controller
{
  // GET: /Create/5
  public ActionResult Create(int id)
  {
    ViewBag.TestString = "Test";
    ViewBag.DestId = id;
    return View();
  }

    // Post: /Create/5
  [HttpPost]
  public ActionResult Create(Review review)
  {
    // review.DestinationId = destinationId;
    Review.Post(review);
    ModelState.Clear();
    return RedirectToAction("Details", "Destination", new { id = @review.DestinationId});
  }

  public ActionResult Edit(int id)
  {
    Review destination = Review.GetDetails(id);
    return View(destination);
  }

  [HttpPost]
  public ActionResult Edit(Review review)
  {
    Review.Put(review);
    return RedirectToAction("Details", "Destination", new { id = review.DestinationId});
  }

  public ActionResult Delete(int id)
  {
    Review review = Review.GetDetails(id);
    return View(review);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    int destId = Review.GetDetails(id).DestinationId;
    Review.Delete(id);
    ModelState.Clear();
    return RedirectToAction("Details", "Destination", new { id = destId });
  }
}
