namespace OBL_Zoho.Models.Request
{
    public class ProjectInstallmentRequest
    {
        public string Name { get; set; }
        public string ReceiverEmpId { get; set; }
        public decimal ReceivedAmount { get; set; }
        public AssociateProject AssociateProject { get; set; }
        public List<CategoryDetail> Category_Details { get; set; }
    }

    public class AssociateProject
    {
        public string Id { get; set; }
    }

    public class CategoryDetail
    {
        public string Category { get; set; }
        public int Box { get; set; }
        public string Size { get; set; }
        public decimal Sq_Mt { get; set; }
        public DateTime Entry_Date { get; set; }
    }
}
