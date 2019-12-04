using AutoMapper;

namespace Yashil.Common.Core.Interfaces
{
    public interface IYashilMapper
    {
        IMapper GetMapper();
    }
    public interface IOrderedMapperProfile
    {
        /// <summary>
        /// Gets order of this configuration implementation
        /// </summary>
        int Order { get; }
    }
}
