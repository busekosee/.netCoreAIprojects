namespace NetCoreAI.Project2_ApiConsumeUI.Dtos
{
    public class UpdateCustomerDto
    {
        public int CustomerId { get; set; }
        public String CustomerName { get; set; }
        public String CustomerSurname { get; set; }

        public decimal CustomerBalance { get; set; }
    }
}
