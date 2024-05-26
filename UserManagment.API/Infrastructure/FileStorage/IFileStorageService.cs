namespace UserManagment.API.Infrastructure.FileStorage
{
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(IFormFile file);

    }
}