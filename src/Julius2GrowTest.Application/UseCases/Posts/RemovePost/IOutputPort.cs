namespace Julius2GrowTest.Application.UseCases.Posts.RemovePost
{
    public interface IOutputPort
    {
        void Ok();
        void NotFound();
        void Error();
    }
}
