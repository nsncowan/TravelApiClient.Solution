using Microsoft.AspNetCore.Mvc;
using TravelApiClient.Models;

namespace TravelApiClient.Controllers;

public class ReviewController : Controller
{
  public ActionResult Create(int destinationId)
  {
    ViewBag.DestId = destinationId.ToString();
    return View();
  }

  [HttpPost]
  public ActionResult Create(Review review)
  {
    Review.Post(review);
    return RedirectToAction("Index", "Destination");
  }

  public ActionResult Edit(int id)
  {
    Review destination = Review.GetDetails(id);
    return View(destination);
  }

  [HttpPost]
  public ActionResult Edit(Review review, int destinationId)
  {
    Review.Put(review);
    return RedirectToAction("Details", "Destination", new { id = destinationId });
  }

  public ActionResult Delete(int id)
  {
    Review review = Review.GetDetails(id);
    return View(review);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Review.Delete(id);
    return RedirectToAction("Index");
  }
}
