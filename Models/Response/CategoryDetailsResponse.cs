namespace OBL_Zoho.Models.Response
{
    public class CategoryDetailsResponse
    {
        public string Category { get; set; }
        public string Size { get; set; }
        public CategoryDetailsParentId Parent_Id { get; set; }
        public int Box { get; set; }
        public DateTime Entry_Date { get; set; }
        public double Sq_Mt { get; set; }
    }

    public class CategoryDetailsDatum
    {
        public List<CategoryDetailsResponse> Category_Details_from_APP { get; set; }
        public string id { get; set; }
        public double Total_Sq_Mt { get; set; }
    }

    public class CategoryDetailsParentId
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class UpdateCategoryDetailsRequest
    {
        public List<CategoryDetailsDatum> data { get; set; }
    }
}
