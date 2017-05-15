namespace Dto
{
    public interface IDto
    {
        int Id { get; set; }
        string GetInsertCommand();
        string GetUpdateCommand();
    }
}