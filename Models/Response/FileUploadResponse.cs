namespace OBL_Zoho.Models.Response
{
    public class FileUploadResponse
    {
        public List<FileUploadData> Data { get; set; }
    }

    public class FileUploadData
    {
        public string Code { get; set; }
        public FileDetails Details { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }

    public class FileDetails
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }

}
