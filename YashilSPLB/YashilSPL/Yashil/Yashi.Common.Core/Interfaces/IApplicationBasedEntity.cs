namespace Yashil.Common.Core.Interfaces
{
    public interface IApplicationBasedEntity
    {
        int ApplicationId { get; set; }
        int CreatorOrganizationId { get; set; }
    }
}
