namespace xuanthulab.attribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Method)]
    public class DescAttribute(string description) : Attribute
    {
        public string Description { get; set; } = description;
    }
}
