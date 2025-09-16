using AutoMapper;
using NoteMind.BLL.Map;
using NoteMind.DAL.Interface;

namespace NoteMind.BLL.Services
{
    internal class BaseService<T, M> : BaseMapper<T, M>
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper)
        {
            _unitOfWork = unitOfWork;
        }
    }
}