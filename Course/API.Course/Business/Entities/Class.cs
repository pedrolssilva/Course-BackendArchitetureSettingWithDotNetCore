namespace API.Course.Business.Entities
{
    public class Class
    {
        public string Code { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
        public int UserCode { get; set; }
        public virtual User User { get; set; }
    }
}
