using UserManagment.API.Infrastructure.FileStorage;

public class LocalFileStorageService : IFileStorageService
{
    private readonly string _uploadDirectory;

    public LocalFileStorageService(string uploadDirectory)
    {
        _uploadDirectory = uploadDirectory ?? throw new ArgumentNullException(nameof(uploadDirectory));
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("Invalid file", nameof(file));

        // Create directory if it doesn't exist
        Directory.CreateDirectory(_uploadDirectory);

        // Generate unique file name
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(_uploadDirectory, fileName);

        // Copy file to storage
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return filePath;
    }


}