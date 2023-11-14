namespace Double.V.Presentation.Response
{
    public record PersonasListResponse(
        long id,
        string identificacion,
        string nombres,
        string email,
        string login
    );    
    
}
