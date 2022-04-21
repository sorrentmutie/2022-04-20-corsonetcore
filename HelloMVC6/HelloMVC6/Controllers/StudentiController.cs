using Microsoft.Extensions.Caching.Memory;

namespace HelloMVC6.Controllers;

public class StudentiController : Controller
{
    private readonly IStudentsService studentsService;
    private readonly IMemoryCache cache;

    public StudentiController(IStudentsService studentsService, IMemoryCache cache)
    {
        this.studentsService = studentsService;
        this.cache = cache;
    }

    public IActionResult Index()
    {
        // return View(studentsService.GetStudents());
        return View(studentsService.GetStudentiIndexViewModel());
    }

    public IActionResult Details(int id)
    {
        return View(studentsService.GetStudent(id));
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(StudenteCreateViewModel studente)
    {
        var id = studentsService.CreateStudent(studente);
        cache.Set("ultimoIdCreato", id);
        // return RedirectToAction("Index");
        return RedirectToAction("Details", new {id = id});
    }

    public IActionResult Edit(int id)
    {
        return View(studentsService.GetStudent(id));
    }

    [HttpPost]
    public IActionResult Edit(Studente studente)
    {
        studentsService.UpdateStudent(studente);
        return RedirectToAction("Index");
    }
}
