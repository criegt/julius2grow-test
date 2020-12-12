namespace Julius2GrowTest.Application.UseCases.Posts.RemovePost
{
    public class RemovePostPresenter : IOutputPort
    {
        public bool NotFoundOutput { get; private set; }
        public bool OkOutput { get; private set; }
        public bool ErrorOutput { get; private set; }

        public void Error() => ErrorOutput = true;

        public void NotFound() => NotFoundOutput = true;

        public void Ok() => OkOutput = true;
    }
}
