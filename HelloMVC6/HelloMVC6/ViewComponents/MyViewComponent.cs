namespace HelloMVC6.ViewComponents;

public class MyViewComponent: ViewComponent
{
    private readonly IStudentsService studentsService;

    public MyViewComponent(IStudentsService studentsService)
    {
        this.studentsService = studentsService;
    }

    public Task<IViewComponentResult> InvokeAsync(int parametro)
    {
        var id = studentsService.UltimoIdGenerato();
        var studente = studentsService.GetStudent(id);

        return Task.FromResult<IViewComponentResult>(
            View("CorsoCore", studente));
    }
}
