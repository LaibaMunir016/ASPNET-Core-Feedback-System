using MyMvcApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MyMvcApp.Controllers
{
public class FeedbackController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    } 
    [HttpGet]
    public IActionResult GiveFeedback(){
        return View(); 
    }
    [HttpPost] 
    public IActionResult GiveFeedback(Feedback feedback)
    {
        FeedbackRepository repo=new FeedbackRepository();
        repo.GiveFeedback(feedback);
        return RedirectToAction("FeedbackSummary",new{
            StudentName=feedback.StudentName,
            Course=feedback.Course,
            Comments=feedback.Comments,
            Rating=feedback.Rating
        });        
    } 
    [HttpGet] 
    public IActionResult AllFeedbacks(){
        FeedbackRepository repo=new FeedbackRepository();
        List<Feedback> listOfFeedbacks=repo.AllFeedbacks();
        return View(listOfFeedbacks);
    }
    [HttpGet]
    public IActionResult FeedbackSummary(Feedback feedback){
        return View(feedback);
    }
}
}